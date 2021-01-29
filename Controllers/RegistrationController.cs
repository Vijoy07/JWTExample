using JWTExample.Data;
using JWTExample.Repository;
using JWTExample.Services;
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

        private readonly IRegisterService _register;
        public RegistrationController(IRegisterService reg)
        {
            _register = reg;
        }

        // GET: RegistrationController
        [AllowAnonymous]
        [HttpPost("Register")]
        public IActionResult Register(UserCredentials cred)
        {
            try
            {
                var user = _register.Register(cred);

                if (user)
                {
                    return Ok(new { user });
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception e) {
                return BadRequest();
            }
        }
    }
}
