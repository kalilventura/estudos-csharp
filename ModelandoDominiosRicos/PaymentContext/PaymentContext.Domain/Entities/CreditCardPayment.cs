using System;
using PaymentContext.Domain.ValueObjects;

namespace PaymentContext.Domain.Entities
{
    // Obs: Usar um gateway de pagamentos, isso seria algumas informações para o sistema para o cliente
    // mas nada de armazenamento de dados complexos de cartoes de credito
    public class CreditCardPayment : Payment
    {
        public CreditCardPayment(
            string cardHolderName,
            string cardNumber,
            string lastTransactionNumber,
            DateTime paidDate,
            DateTime expireDate,
            decimal total,
            decimal totalPaid,
            string owner,
            Address address,
            Document document,
            Email email)
            : base(
                paidDate,
                expireDate,
                total,
                totalPaid,
                owner,
                address,
                document,
                email)
        {
            CardHolderName = cardHolderName;
            CardNumber = cardNumber;
            LastTransactionNumber = lastTransactionNumber;
        }

        public string CardHolderName { get; private set; }
        public string CardNumber { get; private set; }
        public string LastTransactionNumber { get; private set; }
    }
}