using System;

namespace CaraOuCoroa
{
    public class CaraOuCoroaResultado
    {
        public string Resultado { get; set; } = ObterResultado();

        private static string ObterResultado()
        {
            var numero = new Random().Next(1,100);
            return numero % 2 == 0 ? "cara" : "coroa";
        }
    }
}
