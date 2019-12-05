using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Alura.LeilaoOnline.Core
{
    public class OfertaSuperiorMaisProxima : IModalidadeAvaliacao
    {
        public double ValorDestino { get; private set; }

        public OfertaSuperiorMaisProxima(double valorDestino)
        {
            ValorDestino = valorDestino;
        }

        public Lance Avalia(Leilao leilao)
        {
            return leilao
                .Lances
                .DefaultIfEmpty(new Lance(null, 0))
                .Where(x => x.Valor > ValorDestino)
                .OrderBy(l => l.Valor)
                .FirstOrDefault();
        }
    }
}
