using Shop.Data;
using Shop.Models;

namespace Shop.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DataContext context;

        public OrderRepository(DataContext context)
        {
            this.context = context;
        }

        public void Save(Order order)
        {
            // Save
            context.Orders.Add(order);
        }
    }

    public interface IOrderRepository
    {
        void Save(Order order);
    }
}
