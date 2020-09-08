using System;

namespace CaraOuCoroa
{
    public class CaraOuCoroaResultado
    {
        public string Resultado { get; set; } = ObterResultado();
        public static int X = Y; // Noncompliant; Y at this time is still assigned default(int), i.e. 0
        public static int Y = 42;

        private static string ObterResultado()
        {
            var numero = new Random().Next(1,100);
            return numero % 2 == 0 ? "cara" : "coroa";
        }
        
        public override string ToString ()
        {
          if (String.IsNullOrEmpty(this.Resultado))
          {
            return null; // Noncompliant
          }
          else
          {
            return "...";
          }
        }
    }
}
