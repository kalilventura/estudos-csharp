using System.Collections.Generic;
using Chain_of_Responsability.Entidades;
using CursoDesignPatterns.Entidades;

namespace Template_Method.Impostos
{
    public class IHIT : TemplateImpostoCondicional
    {
        public override bool DeveUsarMaximaTaxacao(Orcamento orcamento)
        {
            IList<string> noOrcamento = new List<string>();

            foreach (Item item in orcamento.Itens)
            {
                if (noOrcamento.Contains(item.Nome))
                    return true;
                else
                    noOrcamento.Add(item.Nome);
            }

            return false;
        }
        public override double MaximaTaxacao(Orcamento orcamento)
        {
            return orcamento.Valor * 0.13 + 100;
        }
        public override double MinimaTaxacao(Orcamento orcamento)
        {
            return orcamento.Valor * (0.01 * orcamento.Itens.Count);
        }
    }
}