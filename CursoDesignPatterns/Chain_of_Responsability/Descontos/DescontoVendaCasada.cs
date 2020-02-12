using CursoDesignPatterns.Entidades;

namespace Chain_of_Responsability.Descontos
{
    public class DescontoVendaCasada : IDesconto
    {
        public IDesconto Proximo { get; set; }

        public double Desconto(Orcamento orcamento)
        {
            if (ExisteProduto("Caneta", orcamento) && ExisteProduto("Lapis", orcamento))
                return orcamento.Valor * 0.05;
            
            return Proximo.Desconto(orcamento);
        }

        private bool ExisteProduto(string nomeProduto, Orcamento orcamento)
        {
            foreach (var produto in orcamento.Itens)
            {
                if (produto.Nome.ToLower().Equals(nomeProduto.ToLower()))
                    return true;
            }
            return false;
        }
    }
}