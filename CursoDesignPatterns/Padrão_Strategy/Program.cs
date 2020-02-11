namespace CursoDesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            // Design Pattern Strategy Implementado
            // Podemos implementar o padrão Strategy quando temos diversas regras e todas tem a mesmas essencia

            /*
            Quando utilizamos uma hierarquia, como fizemos com a interface Imposto e as implementações ICMS e ISS, 
            e recebemos o tipo mais genérico como parâmetro, para ganharmos o polimorfismo na regra que será executada, 
            simplificando o código e sua evolução, estamos usando o Design Pattern chamado Strategy.
            */
            Imposto iss = new Iss();
            Imposto icms = new Icms();
            Orcamento orcamento = new Orcamento(500);
            CalculadorDeImpostos calculador = new CalculadorDeImpostos();

            calculador.RealizarCalculo(orcamento, icms);
            calculador.RealizarCalculo(orcamento, iss);
        }
    }
}
