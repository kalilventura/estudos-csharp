using System;
using System.Collections.Generic;
using System.Text;

namespace ChainOfResponsability.Entidades
{
    public class Item
    {
        public Item(string nome, double valor)
        {
            Nome = nome;
            Valor = valor;
        }

        public string Nome { get; private set; }
        public double Valor { get; private set; }
    }
}
