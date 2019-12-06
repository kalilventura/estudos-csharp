using Xunit;
using Moq;
using Alura.CoisasAFazer.WebApp.Controllers;
using Alura.CoisasAFazer.WebApp.Models;
using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Alura.CoisasAFazer.Services.Handlers;
using Alura.CoisasAFazer.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Alura.CoisasAFazer.Core.Models;

namespace Alura.CoisasAFazer.Testes
{
    public class TarefasControllerEndpointCadastraTarefa
    {
        [Fact]
        public void DadaTarefaComInformacoesValidasRetornaOkResult()
        {
            //Given
            var moqLogger = new Mock<ILogger<CadastraTarefaHandler>>();

            var options = new DbContextOptionsBuilder<DbTarefasContext>()
                                    .UseInMemoryDatabase("DbTarefas").Options;

            var context = new DbTarefasContext(options);
            var repo = new RepositorioTarefa(context);

            var controlador = new TarefasController(repo, moqLogger.Object);
            var model = new CadastraTarefaVM()
            {
                IdCategoria = 20,
                Titulo = "Estudar Xunit",
                Prazo = new DateTime(2019, 31, 12)
            };

            //When
            context.Categorias.Add(new Categoria(20, "Estudo"));
            context.SaveChanges();

            var resultado = controlador.EndpointCadastraTarefa(model);

            //Then
            // HTTP Status 200
            Assert.IsType<OkResult>(resultado);
        }

        [Fact]
        public void QuandoExcecaoForLancadaDeveRetornarStatusCode500()
        {
            //Given
            var moqLogger = new Mock<ILogger<CadastraTarefaHandler>>();

            var moq = new Mock<IRepositorioTarefas>();
            // Stub
            moq.Setup(x => x.ObtemCategoriaPorId(20)).Returns(new Categoria(20, "Estudo"));
            moq.Setup(x => x.IncluirTarefas(It.IsAny<Tarefa[]>())).Throws(new Exception("Erro"));

            var repo = moq.Object;

            var controlador = new TarefasController(repo, moqLogger.Object);
            var model = new CadastraTarefaVM()
            {
                IdCategoria = 20,
                Titulo = "Estudar Xunit",
                Prazo = new DateTime(2019, 31, 12)
            };
            
            //When
            var resultado = controlador.EndpointCadastraTarefa(model);

            //Then
            // HTTP Status 500
            Assert.IsType<StatusCodeResult>(resultado);
            
            var statuscode = (resultado as StatusCodeResult).StatusCode;
            Assert.Equal(500, statuscode);
        }
    }
}