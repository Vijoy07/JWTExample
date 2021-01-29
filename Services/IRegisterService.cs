using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWTExample.Services
{
    public interface IRegisterService
    {
        bool Register(UserCredentials user);
    }
}
