using ChainOfResponsability.Entidades;

namespace ChainOfResponsability.Descontos
{
    public interface IDesconto
    {
        double Desconto(Orcamento orcamento);
        IDesconto Proximo { get; set; }
    }
}
