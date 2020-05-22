using ChainOfResponsability.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChainOfResponsability.Descontos
{
    public class CalculadorDeDescontos
    {
        public double Calcular(Orcamento orcamento)
        {
            var desconto5itens = new DescontoPorCincoItens();
            var desconto500reais = new DescontoPorMaisQuinhentosReais();
            var descontoVendaCasada = new DescontoVendaCasada();
            var semDesconto = new SemDesconto();

            desconto5itens.Proximo = desconto500reais;
            desconto500reais.Proximo = descontoVendaCasada;
            descontoVendaCasada.Proximo = semDesconto;

            return desconto5itens.Desconto(orcamento);
        }
    }
}
