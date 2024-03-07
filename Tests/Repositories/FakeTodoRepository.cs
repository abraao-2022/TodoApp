using System;
using System.Collections.Generic;
using Domain.Entities;
using Domain.Repositories;

namespace Tests.Repositories
{
    public class FakeTodoRepository : ITodoRepository
    {
        public void Create(TodoItem todo)
        {
        }

        public void Update(TodoItem todo)
        {
        }

        public TodoItem GetById(Guid commandId, string commandUser)
        {
            return null;
        }

        public IEnumerable<TodoItem> GetAll(string user)
        {
            return null;
        }

        public IEnumerable<TodoItem> GetAllDone(string user)
        {
            return null;
        }

        public IEnumerable<TodoItem> GetAllUndone(string user)
        {
            return null;
        }

        public IEnumerable<TodoItem> GetByPeriod(string user, DateTime date, bool done)
        {
            return null;
        }
    }
}