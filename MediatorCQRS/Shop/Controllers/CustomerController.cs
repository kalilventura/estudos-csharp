using Domain.Commands.Requests;
using Domain.Commands.Response;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Shop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator mediator;

        public CustomerController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost]
        public Task<CreateCustomerResponse> Create([FromBody] CreateCustomerRequest command)
        {
            return mediator.Send(command);
        }
    }
}
