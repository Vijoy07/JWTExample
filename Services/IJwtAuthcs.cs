using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWTExample
{
    public interface IJwtAuthcs
    {
        public string GenerateJWTToken(UserCredentials name);
    }
}
