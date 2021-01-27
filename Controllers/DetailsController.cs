using JWTExample.Data;
using JWTExample.Models;
using JWTExample.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace JWTExample.Controllers
{
    [Route("api/{controller}")]
    [ApiController]
    public class DetailsController : Controller
    {
        private readonly AuthDBContext _context;
        private readonly IRequestHeader _header;
        public DetailsController(AuthDBContext context,
                                 IRequestHeader header)
        {
            _context = context;
            _header = header;
        }

        [Authorize]
        public List<Details> Index()
        {
            List<Details> todo = new List<Details>();

            var id = _header.GetUserId(HttpContext);

            todo = _context.todo.Where(x => x.MOTHER_UUID == id).ToList();

            return todo;

        }

        [Authorize]
        [HttpPost("Add")]
        public ActionResult Add(Details todo)
        {
            if (string.IsNullOrEmpty(todo.TODO) == false)
            {
                var id = _header.GetUserId(HttpContext);

                todo.MOTHER_UUID = id;

                _context.todo.Add(todo);
                _context.SaveChanges();
                return Ok();
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

            var details = _context.todo.Where(x => x.UUID == todo.UUID).FirstOrDefault();

            details.MOTHER_UUID = todo.MOTHER_UUID;

            details.TODO = todo.TODO;


            _context.todo.Update(details);

            _context.SaveChanges();

            return Ok();
        }


        [Authorize]
        [HttpDelete("Delete")]
        public ActionResult Delete(Guid uuid)
        {
            var entry = _context.todo.Where(x => x.UUID == uuid).FirstOrDefault();

            if (entry != null)
            {
                _context.todo.Remove(entry);

                _context.SaveChanges();

                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
