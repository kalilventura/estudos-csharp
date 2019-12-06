using Alura.CoisasAFazer.Core.Commands;
using Alura.CoisasAFazer.Core.Models;
using Alura.CoisasAFazer.Infrastructure;
using Alura.CoisasAFazer.Services.Handlers;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Alura.CoisasAFazer.Testes
{
    public class GerenciaPrazoDasTarefasHandlerExecute
    {
        [Fact]
        public void QuandoTarefasEstiveremAtrasadasDeveMudarSeuStatus()
        {
            //Arrange
            // Fake Object
            var categoriaCompras = new Categoria(1, "Compras");
            var categoriaCasa = new Categoria(2, "Casa");
            var categoriaTrabalho = new Categoria(3, "Trabalho");
            var categoriaSaude = new Categoria(4, "Saude");
            var categoriaHigiene = new Categoria(5, "Higiene");

            var tarefas = new List<Tarefa>
            {
                //Atrasadas a partir de 2019/1/1
                new Tarefa(1, "Tirar o lixo", categoriaCasa, new DateTime(2018,12,31), null, StatusTarefa.Criada),
                new Tarefa(4, "Fazer o almoço", categoriaCasa, new DateTime(2017,12,1), null, StatusTarefa.Criada),
                new Tarefa(9, "Ir a academia", categoriaSaude, new DateTime(2018,12,31), null, StatusTarefa.Criada),
                new Tarefa(7, "Concluir o relatório", categoriaSaude, new DateTime(2018,5,7), null, StatusTarefa.Pendente),
                new Tarefa(10, "Beber água", categoriaSaude, new DateTime(2018,12,31), null, StatusTarefa.Criada),
                //Dentro do prazo em 2019/1/1
                new Tarefa(8, "Comparecer a reunião", categoriaTrabalho, new DateTime(2018,11,12), null, StatusTarefa.Concluida),
                new Tarefa(2, "Arrumar a cama", categoriaCasa, new DateTime(2019,4,5), null, StatusTarefa.Criada),
                new Tarefa(3, "Escovar os dentes", categoriaHigiene, new DateTime(2019,1,2), null, StatusTarefa.Criada),
                new Tarefa(5, "Comprar presentes para o João", categoriaCompras, new DateTime(2019,10,8), null, StatusTarefa.Criada),
                new Tarefa(6, "Comprar ração", categoriaCompras, new DateTime(2019,11,20), null, StatusTarefa.Criada)
            };

            var options = new DbContextOptionsBuilder<DbTarefasContext>()
                                .UseInMemoryDatabase("DbTarefasContext").Options;
            var context = new DbTarefasContext(options);

            var repository = new RepositorioTarefa(context);

            repository.IncluirTarefas(tarefas.ToArray());

            var comando = new GerenciaPrazoDasTarefas(new DateTime(2019, 1, 1));
            var handler = new GerenciaPrazoDasTarefasHandler(repository);

            //Act
            handler.Execute(comando);

            //Assert
            var tarefasEmAtraso = repository.ObtemTarefas(x => x.Status == StatusTarefa.EmAtraso);

            Assert.Equal(5, tarefasEmAtraso.Count());
        }

        [Fact]
        public void QuandoInvocadoDeveChamarAtualizarTarefasQtdVezesDoTotalDeTarefasAtrasadas()
        {
            //Given
            var categoriaCasa = new Categoria(2, "Casa");
            var categoriaSaude = new Categoria(4, "Saude");

            var tarefas = new List<Tarefa>
            {
                new Tarefa(1, "Tirar o lixo", categoriaCasa, new DateTime(2018,12,31), null, StatusTarefa.Criada),
                new Tarefa(4, "Fazer o almoço", categoriaCasa, new DateTime(2017,12,1), null, StatusTarefa.Criada),
                new Tarefa(9, "Ir a academia", categoriaSaude, new DateTime(2018,12,31), null, StatusTarefa.Criada)
            };
            
            var moq = new Mock<IRepositorioTarefas>();
            moq.Setup(r => r.ObtemTarefas(It.IsAny<Func<Tarefa, bool>>())).Returns(tarefas);
            var repository = moq.Object;

            var comando = new GerenciaPrazoDasTarefas(new DateTime(2019, 1, 1));
            var handler = new GerenciaPrazoDasTarefasHandler(repository);
            
            //When
            handler.Execute(comando);

            //Then
            // Verifica se o método foi chamado 1 vez
            moq.Verify(x => x.AtualizarTarefas(It.IsAny<Tarefa[]>()), Times.Once());
        }
    }
}
