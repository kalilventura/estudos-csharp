using Exercicio01.Investimentos;

namespace Exercicio01
{
    class Program
    {
        static void Main(string[] args)
        {
            var conta = new Conta("Kalil", 2000);

            var moderado = new InvestimentoModerado();
            var conservador = new InvestimentoConservador();
            var arrojado = new InvestimentoArrojado();

            var realizaInvestimento = new RealizadorDeInvestimentos();

            realizaInvestimento.RealizaInvestimento(conta, arrojado);

        }
    }
}
