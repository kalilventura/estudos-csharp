using Alura.CoisasAFazer.Core.Commands;
using Alura.CoisasAFazer.Core.Models;
using Alura.CoisasAFazer.Infrastructure;
using Alura.CoisasAFazer.Services.Handlers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Xunit;
using Moq;
using Microsoft.Extensions.Logging;

namespace Alura.CoisasAFazer.Testes
{
    public class CadastraTarefaHandlerExecute
    {
        [Fact]
        public void DadaTarefaComInfoValidasDeveIncluirNoBD()
        {
            //arrange
            var comando = new CadastraTarefa("Estudar Xunit", new Categoria("Estudo"), new DateTime(2019, 12, 31));

            var moq = new Mock<ILogger<CadastraTarefaHandler>>();

            var options = new DbContextOptionsBuilder<DbTarefasContext>()
                                .UseInMemoryDatabase("DbTarefasContext").Options;
            var context = new DbTarefasContext(options);

            var repo = new RepositorioTarefa(context);
            var handler = new CadastraTarefaHandler(repo, moq.Object);

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
            var moqLogger = new Mock<ILogger<CadastraTarefaHandler>>();

            // Quando o argumento de entrada Incluir tarefas for chamado com qualquer parametro do tipo Tarefas[]
            // Vai lan�ar uma exce��o do tipo Exception
            moq.Setup(r => r.IncluirTarefas(It.IsAny<Tarefa[]>()))
                .Throws(new Exception("Houve um erro ao inserir a(s) tarefa(s)"));

            //Retornando o repositorio
            var repo = moq.Object;

            var handler = new CadastraTarefaHandler(repo, moqLogger.Object);

            //act
            CommandResult success = handler.Execute(comando); //SUT >> CadastraTarefaHandlerExecute

            //assert
            Assert.False(success.IsSuccess);
        }

        [Fact]
        public void QuandoExceptionForLancadaDeveLogarMensagemDaExcecao()
        {
            //Given
            var comando = new CadastraTarefa("Estudar Xunit", new Categoria("Estudo"), new DateTime(2019, 12, 31));
            string mensagemErro = "Houve um erro ao inserir a(s) tarefa(s)";
            var excecaoEsperada = new Exception(mensagemErro);

            //Criando um moq do repositorio
            var moq = new Mock<IRepositorioTarefas>();
            var moqLogger = new Mock<ILogger<CadastraTarefaHandler>>();

            moq.Setup(r => r.IncluirTarefas(It.IsAny<Tarefa[]>()))
                .Throws(excecaoEsperada);

            //Retornando o repositorio
            var repo = moq.Object;
            var handler = new CadastraTarefaHandler(repo, moqLogger.Object);

            //When
            handler.Execute(comando);

            //Then
            moqLogger.Verify(x => x.Log(
                        It.IsAny<LogLevel>(),
                        It.IsAny<EventId>(),
                        It.IsAny<object>(),
                        It.IsAny<Exception>(),
                        It.IsAny<Func<object, Exception, string>>()
                        ), Times.Once());

        }

        delegate void CapturaMensagemLog(LogLevel level,
                                            EventId eventId,
                                            object state,
                                            Exception exception,
                                            Func<object, Exception, string> function);

        [Fact]
        public void DadaTarefaValidaDeveLogar()
        {
            //Given
            string tituloTarefaEsperado = "Estudar Xunit";
            var comando = new CadastraTarefa(tituloTarefaEsperado, new Categoria("Estudo"), new DateTime(2019, 12, 31));

            //Criando um moq do repositorio
            var moq = new Mock<IRepositorioTarefas>();
            var moqLogger = new Mock<ILogger<CadastraTarefaHandler>>();

            LogLevel levelCapturado = LogLevel.None;
            string mensagemCapturada = string.Empty;

            CapturaMensagemLog capturaMensagemLog = (level, eventId, state, exception, func) =>
            {   
                levelCapturado = level;
                mensagemCapturada = func(state, exception);
            };

            moqLogger.Setup(x =>
                    x.Log(
                            It.IsAny<LogLevel>(),
                            It.IsAny<EventId>(),
                            It.IsAny<object>(),
                            It.IsAny<Exception>(),
                            It.IsAny<Func<object, Exception, string>>()
                        ))
                .Callback(capturaMensagemLog);

            var handler = new CadastraTarefaHandler(moq.Object, moqLogger.Object);

            //When
            CommandResult success = handler.Execute(comando);

            //Then
            Assert.Equal(LogLevel.Information, levelCapturado);
            Assert.Contains(tituloTarefaEsperado, mensagemCapturada);
        }
    }
}
