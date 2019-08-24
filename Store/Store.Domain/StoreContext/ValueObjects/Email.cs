using FluentValidator;
using FluentValidator.Validation;

namespace Store.Domain.StoreContext.ValueObjects
{
    public class Email : Notifiable
    {
        public Email(string address)
        {
            Address = address;

            AddNotifications(new ValidationContract()
                .Requires()
                .IsEmail(Address,"Email","O email é inválido")
                );
        }
        public string Address { get; private set; }

        public override string ToString()
        {
            return Address;
        }
    }
}