using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWTExample.Services
{
    public interface IRequestHeader
    {
        public Guid GetUserId(HttpContext context);
    }
}
