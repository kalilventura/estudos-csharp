using System;
using Todo.Domain.Entities;

namespace Todo.Domain.Repositories
{
    public interface ITodoRepository
    {
        void Create(TodoItem item);
        void Update(TodoItem item);
        TodoItem GetById(Guid id, string user);
    }
}