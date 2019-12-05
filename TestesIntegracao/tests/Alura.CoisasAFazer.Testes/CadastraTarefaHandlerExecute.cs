using Alura.CoisasAFazer.Core.Commands;
using Alura.CoisasAFazer.Core.Models;
using Alura.CoisasAFazer.Infrastructure;
using Alura.CoisasAFazer.Services.Handlers;
using Alura.CoisasAFazer.Testes.TestDubles;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Alura.CoisasAFazer.Testes
{
    public class CadastraTarefaHandlerExecute
    {
        [Fact]
        public void DataTarefaComInformacoesValidasDeveIncluirNoRepositorio_InMemoryDatabase()
        {
            //arrange
            var comando = new CadastraTarefa("Estudar Xunit", new Core.Models.Categoria("Estudo"), new DateTime(2019, 12, 31));

            //setup
            var options = new DbContextOptionsBuilder<DbTarefasContext>()
                .UseInMemoryDatabase("TesteIntegracao")
                .Options;

            var contexto = new DbTarefasContext(options);
            var repo = new RepositorioTarefa(contexto);

            var handler = new CadastraTarefaHandler(repo);

            //act
            handler.Execute(comando);

            //assert
            var tarefa = repo
                            .ObtemTarefas(t => t.Categoria.Descricao == "Estudo")
                            .FirstOrDefault();
            
            Assert.NotNull(tarefa);
            Assert.Equal("Estudar Xunit", tarefa.Titulo);
            Assert.Equal(new DateTime(2019, 12, 31), tarefa.Prazo);
        }
    }
}
