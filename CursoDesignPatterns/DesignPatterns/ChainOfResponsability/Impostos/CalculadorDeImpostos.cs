using ChainOfResponsability.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChainOfResponsability.Impostos
{
    public class CalculadorDeImpostos
    {
        public void RealizarCalculo(Orcamento orcamento, Imposto imposto)
        {
            double impostoCalculado = imposto.Calcular(orcamento);
            Console.WriteLine(impostoCalculado);
        }
    }
}
