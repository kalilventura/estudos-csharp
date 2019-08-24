using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using FluentValidator;
using Store.Domain.StoreContext.Enum;

namespace Store.Domain.StoreContext.Entities
{
    public class Order : Notifiable
    {
        private readonly IList<OrderItem> _orderItem;
        private readonly IList<Delivery> _deliveries;
        public Order(Customer customer)
        {
            this.Customer = customer;

            CreateDate = DateTime.Now;
            Status = EOrderStatus.Created;
            _orderItem = new List<OrderItem>();
            _deliveries = new List<Delivery>();
        }
        public Customer Customer { get; private set; }
        public string Number { get; private set; }
        public DateTime CreateDate { get; private set; }
        public EOrderStatus Status { get; private set; }
        public IReadOnlyCollection<OrderItem> Items => _orderItem.ToArray();
        public IReadOnlyCollection<Delivery> Deliveries => _deliveries.ToArray();

        //Cria a ordem de venda
        public void Place()
        {
            //Gera o numero do pedido
            this.Number = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 8).ToUpper();
            if (_orderItem.Count == 0)
                AddNotification("Order", "Este pedido não possui itens");

        }
        
        public void AddItem(Product product, decimal quantity)
        {
            if (quantity > product.QuantityOnhand)
                AddNotification("OrderItem", $"Produto {product.Title} não tem {quantity} itens em estoque.");

            var item = new OrderItem(product, quantity);
            _orderItem.Add(item);
        }

        public void Pay()
        {
            Status = EOrderStatus.Paid;

        }

        public void Ship()
        {
            var count = 1;
            var deliveries = new List<Delivery>();
            foreach (var item in _orderItem)
            {
                if (count.Equals(5))
                {
                    count = 1;
                    deliveries.Add(new Delivery(DateTime.Now.AddDays(5)));
                }
                count++;
            }
            //Envia todas as entregas
            deliveries.ForEach(x => x.Ship());
            //Adiciona as entregas ao pedido
            deliveries.ForEach(x => _deliveries.Add(x));
        }

        public void Cancel()
        {
            Status = EOrderStatus.Canceled;
            _deliveries.ToList().ForEach(x => x.Cancel());
        }
    }
}