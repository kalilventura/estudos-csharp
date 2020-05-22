using Shop.Data;
using Shop.Models;

namespace Shop.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly DataContext context;

        public CustomerRepository(DataContext context)
        {
            this.context = context;
        }

        public void Save(Customer customer)
        {
            context.Customers.Add(customer);
        }
    }

    public interface ICustomerRepository
    {
        void Save(Customer customer);
    }
}
