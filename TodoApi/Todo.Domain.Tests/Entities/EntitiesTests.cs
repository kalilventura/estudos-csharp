using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Todo.Domain.Entities;

namespace Todo.Domain.Tests.Entities
{
    [TestClass]
    public class EntitiesTests
    {
        private readonly TodoItem _validTodo = new TodoItem("Titulo Aqui", DateTime.Now, "andrebaltieri");

        [TestMethod]
        public void Dado_um_novo_todo_o_mesmo_nao_pode_ser_concluido()
        {
            Assert.AreEqual(_validTodo.Done, false);
        }
    }
}