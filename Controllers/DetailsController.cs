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
    [Route("api/[controller]")]
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

        // GET: DetailsController
        // GET: api/Details    
        /// <summary>    
        /// DetailsController Api Get method    
        /// </summary>    
        /// <returns></returns> 
        [Authorize]
        [HttpGet]
        public List<Details> Index()
        {
        var id = _header.GetUserId(HttpContext);            

        return _todo.TodoList(id);
        }


        // POST: DetailsController
        // POST: api/Details/Add    
        /// <summary>    
        /// DetailsController Api Post method    
        /// </summary>    
        /// <returns></returns> 
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

        // POST: DetailsController
        // POST: api/Details/Update    
        /// <summary>    
        /// DetailsController Api Put method    
        /// </summary>    
        /// <returns></returns> 
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

        // DELETE: DetailsController
        // DELETE: api/Details/{uuid}    
        /// <summary>    
        /// DetailsController Api Delete method    
        /// </summary>    
        /// <returns></returns> 
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
