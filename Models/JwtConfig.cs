using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWTExample
{
    public class JwtConfig
    {
        public string secret { get; set; }
        public string issuer { get; set; }
        public string audience { get; set; }
    }
}
