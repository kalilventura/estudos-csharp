using ChainOfResponsability.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChainOfResponsability.Descontos
{
    public class DescontoPorCincoItens : IDesconto
    {
        public IDesconto Proximo { get; set; }
        public double Desconto(Orcamento orcamento)
        {
            if (orcamento.Itens.Count > 5)
                return orcamento.Valor * 0.1;

            return Proximo.Desconto(orcamento);
        }
    }
}
