using Xunit;

namespace Alura.CoisasAFazer.Testes
{
    public class GerenciaPrazoTarefasHandlerExecute
    {
        [Fact]
        public void QuandoTarefasEstiveremAtrasadasMudarStatus()
        {
            var categoriaCompras = new Categoria(1, "Compras");
            var categoriaCasa = new Categoria(2, "Casa");
            var categoriaTrabalho = new Categoria(3, "Trabalho");
            var categoriaSaude = new Categoria(4, "Saúde");
            var categoriaHigiene = new Categoria(5, "Higiene");

            var tarefas = new List<Tarefa>
            {
                new Tarefa(1, "Tirar o lixo", categoriaCasa, new DateTime(2019,12,31), null, StatusTarefa.Criada);
            }

            var options = new DbContextOptionsBuilder<DbTarefasContext>()
                .UseInMemoryDatabase("TesteIntegracao")
                .Options;

            var contexto = new DbTarefasContext(options);
            var repo = new RepositorioTarefa(contexto);

        }
    }
}