using Domain.Commands.Requests;
using Domain.Commands.Response;

namespace Domain.Handlers
{
    public interface ICreateCustomerHandler
    {
        CreateCustomerResponse Handle(CreateCustomerRequest request);
    }
}