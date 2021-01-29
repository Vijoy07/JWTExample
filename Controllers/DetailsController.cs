using JWTExample.Data;
using JWTExample.Models;
using JWTExample.Repository;
using JWTExample.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace JWTExample.Controllers
{
    [Route("api/{controller}")]
    [ApiController]
    public class DetailsController : Controller
    {
        private readonly IRequestHeader _header;
        private readonly ITodoService _todo;
        public DetailsController(IRequestHeader header,
                                 ITodoService todo)
        {
            _header = header;
            _todo = todo;
        }

        [Authorize]
        public List<Details> Index()
        {
        var id = _header.GetUserId(HttpContext);            

        return _todo.TodoList(id);
        }

        [Authorize]
        [HttpPost("Add")]
        public ActionResult Add(Details todo)
        {
            if (string.IsNullOrEmpty(todo.TODO) == false)
            {
                var id = _header.GetUserId(HttpContext);

                todo.MOTHER_UUID = id;

               var add =_todo.Add(todo);

                if (add)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }

              
            }
            else
            {
                return BadRequest();
            }
            
        }

        [Authorize]
        [HttpPut("Update")]
        public ActionResult Update(Details todo)
        {
            if (string.IsNullOrEmpty(todo.TODO))
            {
                return BadRequest();
            }

            var update = _todo.Update(todo);

            if (update)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
            
        }


        [Authorize]
        [HttpDelete("Delete")]
        public ActionResult Delete(Guid uuid)
        {
            var delete = _todo.Delete(uuid);

            if (delete)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
