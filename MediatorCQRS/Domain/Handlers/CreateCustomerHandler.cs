using System;
using System.Threading;
using System.Threading.Tasks;
using Domain.Commands.Requests;
using Domain.Commands.Response;
using MediatR;

namespace Domain.Handlers
{
    public class CreateCustomerHandler : IRequestHandler<CreateCustomerRequest, CreateCustomerResponse>
    {
        public Task<CreateCustomerResponse> Handle(CreateCustomerRequest request, CancellationToken cancellationToken)
        {
            var result = new CreateCustomerResponse
            {
                Date = DateTime.Now,
                Email = "teste@teste.com",
                Id = Guid.NewGuid(),
                Name = "Teste"
            };

            return Task.FromResult(result);
        }
    }
}