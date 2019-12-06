using Alura.CoisasAFazer.Core.Commands;
using Alura.CoisasAFazer.Core.Models;
using Alura.CoisasAFazer.Infrastructure;
using Alura.CoisasAFazer.Services.Handlers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Xunit;
using Moq;

namespace Alura.CoisasAFazer.Testes
{
    public class CadastraTarefaHandlerExecute
    {
        [Fact]
        public void DadaTarefaComInfoValidasDeveIncluirNoBD()
        {
            //arrange
            var comando = new CadastraTarefa("Estudar Xunit", new Categoria("Estudo"), new DateTime(2019, 12, 31));

            var options = new DbContextOptionsBuilder<DbTarefasContext>()
                                .UseInMemoryDatabase("DbTarefasContext").Options;
            var context = new DbTarefasContext(options);

            var repo = new RepositorioTarefa(context);
            var handler = new CadastraTarefaHandler(repo);

            //act
            handler.Execute(comando); //SUT >> CadastraTarefaHandlerExecute

            //assert
            var tarefa = repo.ObtemTarefas(t => t.Titulo == "Estudar Xunit").FirstOrDefault();
            Assert.NotNull(tarefa);
        }

        [Fact]
        public void QuandoExceptionForLancadaResultadoIsSuccessDeveSerFalso()
        {
            //arrange
            var comando = new CadastraTarefa("Estudar Xunit", new Categoria("Estudo"), new DateTime(2019, 12, 31));

            //Criando um moq do repositorio
            var moq = new Mock<IRepositorioTarefas>();

            // Quando o argumento de entrada Incluir tarefas for chamado com qualquer parametro do tipo Tarefas[]
            // Vai lançar uma exceção do tipo Exception
            moq.Setup(r => r.IncluirTarefas(It.IsAny<Tarefa[]>()))
                .Throws(new Exception("Houve um erro ao inserir a(s) tarefa(s)"));

            //Retornando o repositorio
            var repo = moq.Object;
            
            var handler = new CadastraTarefaHandler(repo);

            //act
            CommandResult success = handler.Execute(comando); //SUT >> CadastraTarefaHandlerExecute

            //assert
            Assert.False(success.IsSuccess);
        }
    }
}
