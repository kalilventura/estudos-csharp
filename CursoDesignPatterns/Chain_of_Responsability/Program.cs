using Chain_of_Responsability.Descontos;
using Chain_of_Responsability.Entidades;
using CursoDesignPatterns.Entidades;

namespace Chain_of_Responsability
{
    class Program
    {
        static void Main(string[] args)
        {
            // Implementação de Chain Of Responsability

            // Condição para implementação: Quando temos várias regras de negócio e temos condições para
            // aplicar cada um delas
			
			/*
			A ideia do padrão é resolver problemas como esses: de acordo com o cenário, 
			devemos realizar alguma ação. Ao invés de escrevermos código procedural, 
			e deixarmos um único método descobrir o que deve ser feito, 
			quebramos essas responsabilidades em várias diferentes classes, 
			e as unimos como uma corrente.
			*/
            var calculadorDescontos = new CalculadorDeDescontos();
            var orcamento = new Orcamento(500);

            orcamento.AdicionarItem(new Item("Caneta", 500));
            orcamento.AdicionarItem(new Item("Lapis", 500));
            orcamento.AdicionarItem(new Item("Lapis", 500));
            orcamento.AdicionarItem(new Item("Lapis", 500));
            orcamento.AdicionarItem(new Item("Lapis", 500));
            orcamento.AdicionarItem(new Item("Lapis", 500));

            double desconto = calculadorDescontos.Calcular(orcamento);
            System.Console.WriteLine(desconto);
        }
    }
}
