using System;

namespace Aula1_CriarTipos
{
    public class TiposDeValor : IAulaItem
    {
        public void Executar()
        {
            float idade = 15;
            idade = 15.5f;

            //int massa = 6_000000_000000_000000;
            //long massa = 6e24;
            Console.WriteLine($"long.MinValue: { long.MinVAlue}");
            Console.WriteLine($"long.MaxValue: { long.MaxValue}");

            float massaDaTerra = 5.9736e24f; //System.Single
            Console.WriteLine($"massaDaTerra: {massaDaTerra}");

            double numeroPI = 3.14159; // System.Single
            Console.WriteLine($"numeroPI: {numeroPI}");

            //float numeroMuitoMaior = 6e100f
            //double numeroMuitoMaior = 6e100f;


            Console.WriteLine();
            Console.WriteLine("Operação com int, float e short");

            int x = 3;
            short y = 5;

            var resultado1 = x * y;
            Console.WriteLine("x * y= (0)", resultado1);
            Console.WriteLine($"O resultado é do tipo: ");

        }
    }
}