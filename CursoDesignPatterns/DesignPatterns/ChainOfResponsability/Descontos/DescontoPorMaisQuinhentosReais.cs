using ChainOfResponsability.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChainOfResponsability.Descontos
{
    public class DescontoPorMaisQuinhentosReais : IDesconto
    {
        public IDesconto Proximo { get; set; }
        public double Desconto(Orcamento orcamento)
        {
            if (orcamento.Valor > 500.00)
                return orcamento.Valor * 0.07;

            return Proximo.Desconto(orcamento);
        }
    }
}
