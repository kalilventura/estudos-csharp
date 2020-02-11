using System.Collections.Generic;
using Chain_of_Responsability.Entidades;

namespace CursoDesignPatterns.Entidades
{
    public class Orcamento
    {
        public double Valor { get; private set; }
        public IList<Item> Itens { get; set; }
        public Orcamento(double valor)
        {
            Valor = valor;
            Itens = new List<Item>();
        }

        public void AdicionarItem(Item item)
        {
            Itens.Add(item);
        }
    }
}