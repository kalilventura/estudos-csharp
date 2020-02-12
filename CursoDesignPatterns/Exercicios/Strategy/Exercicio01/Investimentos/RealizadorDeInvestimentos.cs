using System;
using Exercicio01.Investimentos.Interface;

namespace Exercicio01.Investimentos
{
    public class RealizadorDeInvestimentos
    {
        public void RealizaInvestimento(Conta conta, IInvestimento investimento)
        {
            double valorLucroInvestimento = CalcularImpostosNoLucro(investimento.Investir(conta));
            Console.WriteLine($"Valor do Investimento R$: {valorLucroInvestimento}");
            
            Console.WriteLine($"Valor anterior do Saldo R$: {conta.Saldo}");
            conta.Depositar(valorLucroInvestimento);                    
            Console.WriteLine($"Novo valor do Saldo R$: {conta.Saldo}");
        }

        private double CalcularImpostosNoLucro(double valorLucroInvestimento)
        {
            return valorLucroInvestimento * 0.75;
        }
    }
}