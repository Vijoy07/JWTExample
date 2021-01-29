using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;

namespace JWTExample.Services
{
    public class RequestHeader : IRequestHeader
    {
        public Guid GetUserId(HttpContext context)
        {
            Guid Id = new Guid();


            string header = context.Request.Headers["Authorization"];

            if (header != null &&
                header.StartsWith("Bearer") == true)
            {
                var key = header.Substring("Bearer ".Length).Trim();
                var handler = new JwtSecurityTokenHandler();
                var decodedValue = handler.ReadJwtToken(key);

                var uuid = decodedValue.Claims.Where(y => y.Type == "UUID").Select(x => x.Value).FirstOrDefault();
                Guid.TryParse(uuid, out Id);

            }


            return Id;
        }
    }
}
