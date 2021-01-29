using JWTExample.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWTExample.Services
{
    public class RegisterServicecs : IRegisterService
    {
        private readonly ICredentialsRepository _repo;
        public RegisterServicecs(ICredentialsRepository repo)
        {
            _repo = repo;
        }
        public bool Register(UserCredentials user)
        {
            return _repo.Register(user);
        }
    }
}
