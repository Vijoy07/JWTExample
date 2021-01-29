using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace JWTExample
{
    public class JwtAuth: IJwtAuthcs
    {
        private JwtConfig _config;
        public JwtAuth(JwtConfig conf)
        {
            _config = conf;
        }

        public string GenerateJWTToken(UserCredentials user)
        {
            var JwtToken = new System.IdentityModel.Tokens.Jwt.JwtSecurityToken(_config.issuer,
                                                                                _config.audience,
                                                                                new[] {
                                                                                    new Claim(ClaimTypes.Name, user.Name),
                                                                                    new Claim("UUID", user.UUID.ToString())
                                                                                },
                                                                                null,
                                                                                DateTime.Now.AddMinutes(5),
                                                                                new Microsoft.IdentityModel.Tokens.SigningCredentials(new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(Encoding.ASCII.GetBytes(_config.secret)),
                                                                                Microsoft.IdentityModel.Tokens.SecurityAlgorithms.HmacSha256Signature));

            var accessToken = new JwtSecurityTokenHandler().WriteToken(JwtToken);

            return accessToken;
        }
    }
}
