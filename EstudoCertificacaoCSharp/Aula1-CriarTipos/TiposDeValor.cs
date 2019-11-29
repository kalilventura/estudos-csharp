using System;

namespace Aula1_CriarTipos
{
    public class TiposDeValor : IAulaItem
    {
        public void Executar()
        {
            // Por Valor
            
            // System.Int32
            int idade;
            idade = 30;
            Console.WriteLine(idade);

            // Por referencia
            int copiaIdade = idade;
            
            idade = 10;

            Console.WriteLine($"Idade : {idade}");
            Console.WriteLine($"copiaIdade : {copiaIdade}");

            // O int? é a mesma coisa que System.Nullable<int>
            int? idade2 = null;

            System.Nullable<int> idade3 = null;
        }
    }
}