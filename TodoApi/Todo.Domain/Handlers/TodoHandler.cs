using Flunt.Notifications;
using Todo.Domain.Commands;
using Todo.Domain.Commands.Contracts;
using Todo.Domain.Entities;
using Todo.Domain.Handlers.Contracts;
using Todo.Domain.Repositories;

namespace Todo.Domain.Handlers
{
    public class TodoHandler : Notifiable,
                               IHandler<CreateTodoCommand>,
                               IHandler<UpdateTodoCommand>,
                               IHandler<MarkTodoAsDoneCommand>,
                               IHandler<MarkTodoAsUndoneCommand>
    {
        private readonly ITodoRepository _repository;

        public TodoHandler(ITodoRepository repository)
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

        public ICommandResult Handle(UpdateTodoCommand command)
        {
            // Fail Fast Validation
            command.Validate();
            if (command.Invalid)
                return
                    new GenericCommandResult(false, "Ops, parece que sua tarefa está errada !", command.Notifications);

            // Get TodoItem
            var todo = _repository.GetById(command.Id, command.User);

            // Alter Title
            todo.UpdateTitle(command.Title);

            // Save Todo in database
            _repository.Update(todo);

            // Notify User 
            return new GenericCommandResult(true, "Tarefa Salva", todo);
        }

        public ICommandResult Handle(MarkTodoAsUndoneCommand command)
        {
            // Fail Fast Validation
            command.Validate();
            if (command.Invalid)
                return
                    new GenericCommandResult(false, "Ops, parece que sua tarefa está errada !", command.Notifications);

            // Get TodoItem
            var todo = _repository.GetById(command.Id, command.User);

            // Alter To Done
            todo.MarkAsDone();

            // Save Todo in database
            _repository.Update(todo);

            // Notify User 
            return new GenericCommandResult(true, "Tarefa Salva", todo);
        }

        public ICommandResult Handle(MarkTodoAsDoneCommand command)
        {
            // Fail Fast Validation
            command.Validate();
            if (command.Invalid)
                return
                    new GenericCommandResult(false, "Ops, parece que sua tarefa está errada !", command.Notifications);

            // Get TodoItem
            var todo = _repository.GetById(command.Id, command.User);

            // Alter To Done
            todo.MarkAsUndone();

            // Save Todo in database
            _repository.Update(todo);

            // Notify User 
            return new GenericCommandResult(true, "Tarefa Salva", todo);
        }
    }
}