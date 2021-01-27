using JWTExample.Data;
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
        private readonly  JwtConfig _conf;
        private readonly IJwtAuthcs _auth;
        private readonly AuthDBContext _context;
        public ValuesController(JwtConfig conf,
                            IJwtAuthcs auth,
                            AuthDBContext context)
    {
        _conf = conf;
        _auth = auth;
        _context = context;
    }


        [AllowAnonymous]
        [HttpPost("Login")]
    public IActionResult Login(UserCredentials user)
    {
            if (string.IsNullOrEmpty(user.Name))
            {
               return BadRequest();
            }

            try
            {

                var exists = _context.credentials.Where(x => x.Name == user.Name && x.Password == user.Password).FirstOrDefault();

                if (exists != null)
                {
                    var token = _auth.GenerateJWTToken(exists);

                    return Ok(new { token });

                }
                else
                {
                    return Ok(new { exists });
                }

            }
            catch (Exception e) {
                return BadRequest();
            }
    }
    }
}
