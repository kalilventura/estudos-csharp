using CursoDesignPatterns.Entidades;
namespace Template_Method.Impostos
{
    public class Ikcv : TemplateImpostoCondicional
    {
        public override bool DeveUsarMaximaTaxacao(Orcamento orcamento)
        {
            return orcamento.Valor > 500 && TemItemMaiorCemReaisNoOrcamento(orcamento);
        }

        public override double MaximaTaxacao(Orcamento orcamento)
        {
            return orcamento.Valor * 0.06;
        }

        public override double MinimaTaxacao(Orcamento orcamento)
        {
            return orcamento.Valor * 0.10;
        }

        private bool TemItemMaiorCemReaisNoOrcamento(Orcamento orcamento)
        {
            foreach (var item in orcamento.Itens)
            {
                if (item.Valor > 100)
                    return true;
            }

            return false;
        }
    }
}