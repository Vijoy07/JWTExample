using JWTExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWTExample.Repository
{
    public interface ITodoRepository
    {
        public List<Details> GetTodo(Guid id);
        public bool Add(Details d);
        public bool Update(Details d);
        public bool Delete(Guid id);
    }
}
