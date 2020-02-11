using CursoDesignPatterns.Entidades;

namespace Chain_of_Responsability.Descontos
{
    public class SemDesconto : IDesconto
    {
        public IDesconto Proximo { get; set; }

        public double Desconto(Orcamento orcamento)
        {
            return 0;
        }
    }
}