using Domain.Commands;
using Domain.Commands.Contracts;
using Domain.Entities;
using Domain.Handlers.Contracts;
using Domain.Repositories;
using Flunt.Notifications;

namespace Domain.Handlers
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
            command.Validate();
            if (command.Invalid)
            {
                return new GenericCommandResult(false,
                    "Ops, parece que sua tarefa está errada",
                    command.Notifications);
            }

            var todo = new TodoItem(command.Title, command.User, command.Date);
            
            _repository.Create(todo);

            return new GenericCommandResult(true, "Tarefa salva", todo);
        }

        public ICommandResult Handle(UpdateTodoCommand command)
        {
            command.Validate();
            if (command.Invalid)
            {
                return new GenericCommandResult(false,
                    "Ops, parece que sua tarefa está errada",
                    command.Notifications);
            }

            var todo = _repository.GetById(command.Id, command.User);

            todo.UpdateTitle(command.Title);
            
            _repository.Update(todo);

            return new GenericCommandResult(true, "Tarefa salva", todo);
        }

        public ICommandResult Handle(MarkTodoAsDoneCommand command)
        {
            command.Validate();
            if (command.Invalid)
            {
                return new GenericCommandResult(false,
                    "Ops, parece que sua tarefa está errada",
                    command.Notifications);
            }

            var todo = _repository.GetById(command.Id, command.User);

            todo.MarkAsDone();
            
            _repository.Update(todo);

            return new GenericCommandResult(true, "Tarefa salva", todo);
        }

        public ICommandResult Handle(MarkTodoAsUndoneCommand command)
        {
            command.Validate();
            if (command.Invalid)
            {
                return new GenericCommandResult(false,
                    "Ops, parece que sua tarefa está errada",
                    command.Notifications);
            }

            var todo = _repository.GetById(command.Id, command.User);

            todo.MarkAsUndone();
            
            _repository.Update(todo);

            return new GenericCommandResult(true, "Tarefa salva", todo);
        }
    }
}