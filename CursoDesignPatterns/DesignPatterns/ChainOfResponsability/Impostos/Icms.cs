using ChainOfResponsability.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChainOfResponsability.Impostos
{
    public class Icms : Imposto
    {
        public double Calcular(Orcamento orcamento)
        {
            return orcamento.Valor * 0.1;
        }
    }
}
