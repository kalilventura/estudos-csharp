using CursoDesignPatterns.Entidades;

namespace Chain_of_Responsability.Descontos
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