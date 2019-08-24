using Microsoft.VisualStudio.TestTools.UnitTesting;
using Store.Domain.StoreContext.Entities;
using Store.Domain.StoreContext.Enum;
using Store.Domain.StoreContext.ValueObjects;
using System;
using System.Collections.Generic;
using System.Text;

namespace Store.Tests.Entities.OrderTests
{
    //Criar um novo pedido
    //Ao criar um novo pedido, o status deve ser Created
    //Ao adicionar um novo item, a quantidade de itens deve mudar
    //Ao adicionar um novo item, deve subtrait a quantidade do produto
    //Ao confirmar o pedido, deve gerar um numero
    //Ao pagar um pedido, o status deve ser PAGO
    //Dados mais que 10 produtos, devem haver duas entregas
    //Ao cancelar o pedido, o status deve ser Cancelled
    //Ao cancelar o pedido, deve-se cancelar as entregas

    [TestClass]
    public class OrderTests
    {
        private readonly Customer _customer;
        private readonly Order _order;

        public OrderTests()
        {
            var name = new Name("Kalil", "Ventura");
            var document = new Document("40771124864");
            var email = new Email("kalilventur@gmail.com");
            _customer = new Customer(name, document, email, "46185916");
            _order = new Order(_customer);
        }
        
        [TestMethod]
        public void ShouldCreateOrderWhenValid()
        {
            var customer = new Order(_customer);
            Assert.IsTrue(customer.Valid);
        }

        [TestMethod]
        public void StatusShouldBeCreatedWhenOrderCreated()
        {
            Assert.AreEqual(EOrderStatus.Created, _order.Status);
        }

        [TestMethod]
        public void ShouldReturnTwoWhenAddTwoItens()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void ShouldReturnFiveWhenAddedItem()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void ShouldReturnANumberWhenPlaceOrderPlaced()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void ShouldReturnPaidWhenOrderPaid()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void ShouldTwoWhenPurchasedTenProducts()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void StatusShouldBeCanceledWhenOrderCanceled()
        {
            Assert.Fail();
        }

        [TestMethod]
        public void ShouldCancelShippingsWhenOrderCanceled()
        {
            Assert.Fail();
        }
    }
}
