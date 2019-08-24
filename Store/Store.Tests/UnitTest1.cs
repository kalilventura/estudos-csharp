using Microsoft.VisualStudio.TestTools.UnitTesting;
using Store.Domain.StoreContext.Entities;
using Store.Domain.StoreContext.ValueObjects;

namespace Store.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var name = new Name("Kalil", "Ventura");
            var document = new Document("12345678911");
            var email = new Email("teste@teste.com");
            var customer = new Customer(name, document, email, "950365874");
            var mouse = new Product("Mouse", "Rato", "image.jpg", 159.90M, 10);
            var teclado = new Product("Teclado", "Teclado", "image.jpg", 159.90M, 10);
            var impressora = new Product("Impressora", "Impressora", "image.jpg", 359.90M, 10);
            var cadeira = new Product("Cadeira", "Cadeira", "image.jpg", 559.90M, 10);

            var order = new Order(customer);
            //order.AddItem(new OrderItem(mouse, 5));
            //order.AddItem(new OrderItem(teclado, 5));
            //order.AddItem(new OrderItem(impressora, 5));
            //order.AddItem(new OrderItem(cadeira, 5));

            //Realizar pedido
            order.Place();

            //Verificar se o pedido é válido
            var valid = order.Valid;

            //Realizar o pagamento
            order.Pay();

            //Simular o envio
            order.Ship();

            //Simular o cancelamento
            order.Cancel();
        }
    }
}
