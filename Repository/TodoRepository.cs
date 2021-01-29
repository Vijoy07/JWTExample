using JWTExample.Data;
using JWTExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWTExample.Repository
{
    public class TodoRepository : ITodoRepository
    {
        private readonly RepositoryHelper _helper;

        public TodoRepository(RepositoryHelper helper)
        {
            _helper = helper;
        }
        public bool Add(Details d)
        {
            return _helper.Add(d);
        }

        public bool Delete(Guid id)
        {
            return _helper.Delete(id);
        }

        public List<Details> GetTodo(Guid id)
        {
            return _helper.Todo(id);
        }

        public bool Update(Details d)
        {
            return _helper.Update(d);
        }
    }
}
