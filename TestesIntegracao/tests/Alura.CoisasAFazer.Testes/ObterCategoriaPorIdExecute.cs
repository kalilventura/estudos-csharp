using Xunit;
using Moq;
using Alura.CoisasAFazer.Core.Commands;
using Alura.CoisasAFazer.Services.Handlers;
using Alura.CoisasAFazer.Infrastructure;

namespace Alura.CoisasAFazer.Testes
{
    public class ObterCategoriaPorIdExecute
    {
        [Fact]
        public void QuandoIdForExistenteDeveChamarObtemCategoriaPorIdUmaUnicaVez()
        {
            //Given
            var idCategoria = 20;
            var comando = new ObtemCategoriaPorId(idCategoria);
            
            var moq = new Mock<IRepositorioTarefas>();
            var repo = moq.Object;

            var handler = new ObtemCategoriaPorIdHandler(repo);
            
            //When
            handler.Execute(comando);
            
            //Then
            moq.Verify(x => x.ObtemCategoriaPorId(idCategoria), Times.Once());
        }
    }
}