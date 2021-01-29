using JWTExample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWTExample.Services
{
    public interface ITodoService
    {
        List<Details>TodoList(Guid id);
        bool Add(Details d);
        bool Delete(Guid id);
        bool Update(Details todo);
    }
}
