using Exercicio01.Investimentos.Interface;

namespace Exercicio01.Investimentos
{
    public class InvestimentoConservador : IInvestimento
    {
        public double Investir(Conta conta)
        {
            return conta.Saldo * 0.08;
        }
    }
}