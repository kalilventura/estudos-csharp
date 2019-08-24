using PaymentContext.Domain.Entities;
using PaymentContext.Domain.Repository;
using PaymentContext.Domain.Services;

namespace PaymentContext.Tests.Mocks
{
    public class FakeEmailService : IEmailService
    {
        public void SendEmail(string to, string email, string subject, string body)
        {
            
        }
    }
}