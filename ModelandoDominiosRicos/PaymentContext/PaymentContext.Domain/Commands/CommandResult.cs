using PaymentContext.Shared.Commands;

namespace PaymentContext.Domain.Commands
{
    public class CommandResult : ICommandResult
    {
        public CommandResult() { }
        public CommandResult(bool succes, string message)
        {
            this.Succes = succes;
            this.Message = message;

        }
        public bool Succes { get; set; }
        public string Message { get; set; }
    }
}