using Flunt.Notifications;
using Todo.Domain.Commands;
using Todo.Domain.Commands.Contracts;
using Todo.Domain.Entities;
using Todo.Domain.Handlers.Contracts;
using Todo.Domain.Repositories;

namespace Todo.Domain.Handlers
{
    public class Handler : Notifiable, IHandler<CreateTodoCommand>
    {
        private readonly ITodoRepository _repository;

        public Handler(ITodoRepository repository)
        {
            _repository = repository;
        }

        public ICommandResult Handle(CreateTodoCommand command)
        {
            // Fail Fast Validation
            command.Validate();
            if (command.Invalid)
                return
                    new GenericCommandResult(false, "Ops, parece que sua tarefa está errada !", command.Notifications);

            // Generate TodoItem
            var todo = new TodoItem(command.Title, command.Date, command.User);

            // Save Todo in database
            _repository.Create(todo);

            // Notify User 
            return new GenericCommandResult(true, "Item salvo com sucesso", todo);
        }
    }
}