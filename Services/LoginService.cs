using JWTExample.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWTExample.Services
{
    public class LoginService : ILoginService
    {
        private readonly ICredentialsRepository _CredRepo;
        public LoginService(ICredentialsRepository repo)
        {
            _CredRepo = repo; 
        }
        public UserCredentials Login(UserCredentials user)
        {
            return _CredRepo.Login(user);
        }
    }
}
