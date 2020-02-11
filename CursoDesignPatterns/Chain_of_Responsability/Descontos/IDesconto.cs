using CursoDesignPatterns.Entidades;

namespace Chain_of_Responsability.Descontos
{
    public interface IDesconto
    {
        double Desconto(Orcamento orcamento);
        IDesconto Proximo { get; set; }
    }
}