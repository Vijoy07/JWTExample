using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWTExample.Repository
{
    public interface ICredentialsRepository
    {
        public UserCredentials Login(UserCredentials user);
        public bool Register(UserCredentials user);
    }
}
