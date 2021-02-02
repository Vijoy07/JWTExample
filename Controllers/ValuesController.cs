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

namespace JWTExample
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly  JwtConfig _conf;
        private readonly IJwtAuthcs _auth;
        private readonly ILoginService _login;
        public ValuesController(JwtConfig conf,
                            IJwtAuthcs auth,
                            ILoginService login)
    {
        _conf = conf;
        _auth = auth;
        _login = login;
    }

        // POST: ValuesController
        // POST api/Values/Login    
        /// <summary>    
        /// ValuesController Api Post method    
        /// </summary>    
        /// <returns></returns> 

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

                var exists = _login.Login(user);

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
