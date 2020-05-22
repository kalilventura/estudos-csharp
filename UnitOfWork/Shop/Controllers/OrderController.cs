using Microsoft.AspNetCore.Mvc;
using Shop.Data;
using Shop.Models;
using Shop.Repositories;
using System;

namespace Shop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ICustomerRepository customerRepository;
        private readonly IOrderRepository orderRepository;
        private readonly IUnitOfWork unitOfWork;

        public OrderController(ICustomerRepository customerRepository, IOrderRepository orderRepository, IUnitOfWork unitOfWork)
        {
            this.customerRepository = customerRepository;
            this.orderRepository = orderRepository;
            this.unitOfWork = unitOfWork;
        }

        [HttpPost]
        public Order Post()
        {
            try
            {
                var customer = new Customer
                {
                    Id = 1,
                    Name = "Teste"
                };

                var order = new Order
                {
                    Number = "lalalalla",
                    Customer = customer
                };

                customerRepository.Save(customer);
                orderRepository.Save(order);

                unitOfWork.Commit();

                return order;
            }
            catch (Exception ex)
            {
                unitOfWork.Rollback();

                return null;
            }
        }
    }
}
