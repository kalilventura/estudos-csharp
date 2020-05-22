using System;
using Exercicio01.Investimentos.Interface;

namespace Exercicio01.Investimentos
{
    public class InvestimentoModerado : IInvestimento
    {
        private Random random;

        public InvestimentoModerado()
        {
            this.random = new Random();
        }

        public double Investir(Conta conta)
        {
            if (random.Next(2) == 0)
                return conta.Saldo * 0.025;
            else
                return conta.Saldo * 0.007;
        }
    }
}