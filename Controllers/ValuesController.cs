using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWTExample
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private JwtConfig _conf;
        private IJwtAuthcs _auth;
    public ValuesController(JwtConfig conf,IJwtAuthcs auth)
    {
        _conf = conf;
        _auth = auth;
    }

    [HttpGet]
    public JwtConfig Get()
        {
            return _conf;
        }

    [HttpGet("details")]
    [Authorize]
    public string[] Details()
    {
        return new string[] { "A", "B", "C" };
    }

        [AllowAnonymous]
        [HttpPost("Login")]
    public IActionResult Login(UserCredentials user)
    {
            if (string.IsNullOrEmpty(user.Name))
            {
               return BadRequest();
            }

            var token = _auth.GenerateJWTToken(user.Name);

            return Ok(new { token });


        }
    }
}
