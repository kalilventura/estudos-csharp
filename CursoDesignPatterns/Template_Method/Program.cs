using CursoDesignPatterns.Entidades;
using Template_Method.Impostos;

namespace Template_Method
{
    class Program
    {
        static void Main(string[] args)
        {
            var orcamento = new Orcamento(2000);
            var ihit = new IHIT();
            var ikcv = new Ikcv();
            var icpp = new Icpp();

            // Classes utilizando o Template Method
            ihit.Calcular(orcamento);
            ikcv.Calcular(orcamento);
            icpp.Calcular(orcamento);
        }
    }
}
