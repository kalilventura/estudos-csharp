using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Todo.Domain.Tests.CommandTests
{
    [TestClass]
    public class CreateTodoCommand
    {
        [TestMethod]
        public void Dado_um_comando_invalido()
        {
            var command = new CreateTodoCommand();
        }

        [TestMethod]
        public void Dado_um_comando_valido()
        {
            Assert.Fail();
        }


    }
}