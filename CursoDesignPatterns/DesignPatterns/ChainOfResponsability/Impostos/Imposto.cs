using ChainOfResponsability.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace ChainOfResponsability.Impostos
{
    public interface Imposto
    {
        double Calcular(Orcamento orcamento);
    }
}
