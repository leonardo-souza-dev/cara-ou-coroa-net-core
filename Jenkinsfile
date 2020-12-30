#!/usr/bin/env groovy
@Library("convair@develop")
@Library("vv-convair-hub@feature/NetCoreSonar")
import br.com.viavarejo.jornada.jenkins.stages.common.DefineType
import br.com.viavarejo.jornada.jenkins.stages.common.RootCleanup
import br.com.viavarejo.jornada.jenkins.stages.docker.DockerBuildAndPush
import br.com.viavarejo.jornada.jenkins.stages.docker.DockerBuildAndPushParameter
import br.com.viavarejo.jornada.jenkins.stages.git.GitVersion
import br.com.viavarejo.jornada.jenkins.stages.git.GitVersionParameters
import br.com.viavarejo.jornada.jenkins.stages.kubernetes.KustomizeLint
import br.com.viavarejo.jornada.jenkins.stages.netcore.NetCoreBuild
import br.com.viavarejo.jornada.jenkins.stages.netcore.NetCoreBuildParameter
import br.com.viavarejo.jornada.jenkins.stages.netcore.NetCoreDeployNexus
import br.com.viavarejo.jornada.jenkins.stages.netcore.NetCoreDeployNexusParameter
import br.com.viavarejo.jornada.jenkins.stages.netcore.NetCoreSetVersion
import br.com.viavarejo.jornada.jenkins.stages.netcore.NetCoreSetVersionParameter
import br.com.viavarejo.jornada.jenkins.stages.netcore.NetCoreSonar
import br.com.viavarejo.jornada.jenkins.stages.netcore.NetCoreSonarParameter
import br.com.viavarejo.jornada.jenkins.stages.netcore.NetCoreTest
import br.com.viavarejo.jornada.jenkins.stages.netcore.NetCoreTestParameter
import br.com.viavarejo.jornada.jenkins.stages.sonarqube.QualityGate
import br.com.viavarejo.jornada.jenkins.stages.xlrelease.XLReleasePromoteApplication

Convair {
    variables = [
            NAMESPACE_PREFIX    : "poc-cara-ou-coroa",
            SQUAD_NAME          : "qa",
            PROJECT_NAME        : 'poc-cara-ou-coroa',
            APPLICATION_NAMES   : 'poc-cara-ou-coroa',
            DOTNET_CLI_HOME     : "/tmp/DOTNET_CLI_HOME",
            SERVICE_NOW_CI      : "e3c07ba81b2b80980c32edb22b4bcba5",
            DEPLOYMENT_STRATEGY : 'openshift',
            SOURCE_REGISTRY     : "harbor01.viavarejo.com.br",
            HARBOR_PROJECT_NAME : "poc-cara-ou-coroa",
            PROJECT_REPO        : "https://github.com/ltreze/cara-ou-coroa-net-core.git"
    ]

    selectedAgent = "master"

    selectedStages = [

            DefineType      : DefineType.use(),

            BuildNetCore    : NetCoreBuild.use(new NetCoreBuildParameter(
                    projectNames: ["CaraOuCoroa"]
            ), { true }, "mcr.microsoft.com/dotnet/core/sdk:3.1"),     

            SonarQube       : NetCoreSonar.use(new NetCoreSonarParameter(
                    solutionFile: "CaraOuCoroa.sln",
                    sonarUrl: "http://sonarcloud.io",
                    sonarLoginToken: "7e0931ec63d248fcf90a73284c252d1e197d4846",
                    sonarProjectName: "cara-ou-coroa-net-core",
                    projectNames: [ "CaraOuCoroa" ]
             ), { true }, "sonikro/netcore-java:3.1"),  
            
            QualityGate     : QualityGate.use([:], { true }),        
            
            RootCleanup     : RootCleanup.use()
    ]

    onFailure = {
        if (env.COMMITER_EMAIL) {
            step([$class                  : 'Mailer',
                  notifyEveryUnstableBuild: true,
                  recipients              : env.COMMITER_EMAIL,
                  sendToIndividuals       : true]
            )
        }
    }

    always = {
        cleanWs()
    }
}
