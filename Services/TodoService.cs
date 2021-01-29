using JWTExample.Models;
using JWTExample.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWTExample.Services
{
    public class TodoService : ITodoService
    {
        private readonly ITodoRepository _todo;
        public TodoService(ITodoRepository todo)
        {
            _todo = todo;
        }
        public bool Add(Details d)
        {
            return _todo.Add(d);
        }

        public bool Delete(Guid id)
        {
            return _todo.Delete(id);
        }

        public List<Details> TodoList(Guid id)
        {
           return _todo.GetTodo(id);
        }

        public bool Update(Details todo)
        {
            return _todo.Update(todo);
        }
    }
}
