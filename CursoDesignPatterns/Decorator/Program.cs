using System;

namespace Decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            Pessoa pessoa = new Pessoa();
            
        }
    }

    public class Primata
    {
        public void Barulho()
        {
            Console.WriteLine("Hello World!");
        }
    }
    public class Humano : Primata
    {
        public float Peso { get; set; }
        public float Altura { get; set; }
    }
    public class Pessoa : Humano
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
    }
}
