using JWTExample.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWTExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController : Controller
    {
        private readonly AuthDBContext _context;
        public RegistrationController(AuthDBContext dbContext)
        {
            _context = dbContext;
        }

        // GET: RegistrationController
        [AllowAnonymous]
        [HttpPost("Register")]
        public IActionResult Register(UserCredentials cred)
        {
            try
            {
                var user = _context.credentials.Select(x => x.Name == cred.Name).FirstOrDefault();

                if (user)
                {
                    return Ok(new { user });
                }

                _context.credentials.Add(cred);

                _context.SaveChanges();

                return Ok(new { user });
            }
            catch (Exception e) {
                return BadRequest();
            }
        }
    }
}
