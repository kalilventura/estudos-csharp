using CursoDesignPatterns.Entidades;
using CursoDesignPatterns.Impostos;

namespace Template_Method.Impostos
{
    // Template Method
    // Utilizado em casos onde temos algoritmos semelhantes onde representamos de maneira abstrata
    // onde preenchemos as "lacunas", ou seja, a implementação dos métodos abstratos
    public abstract class TemplateImpostoCondicional : Imposto
    {
        public double Calcular(Orcamento orcamento)
        {
            if (DeveUsarMaximaTaxacao(orcamento))
                return MaximaTaxacao(orcamento);

            return MinimaTaxacao(orcamento);
        }

        public abstract bool DeveUsarMaximaTaxacao(Orcamento orcamento);
        public abstract double MaximaTaxacao(Orcamento orcamento);
        public abstract double MinimaTaxacao(Orcamento orcamento);
    }
}