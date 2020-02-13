namespace Template_Method.Relatorios
{
    public abstract class TemplateRelatorios
    {
        public void Imprimir(IList<Conta> contas)
        {
            Cabecalho();
            Corpo(contas);
            Rodape();
        }

        protected abstract void Cabecalho();
        protected abstract void Corpo(IList<Conta> contas);
        protected abstract void Rodape();
    }
}