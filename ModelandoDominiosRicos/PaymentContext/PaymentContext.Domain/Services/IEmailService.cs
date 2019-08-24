namespace PaymentContext.Domain.Services
{
    public interface IEmailService
    {
         void SendEmail(string to, string email, string subject, string body);
    }
}