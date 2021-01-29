using JWTExample.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWTExample.Repository
{
    public class CredentialsRepository : ICredentialsRepository
    {
        private readonly RepositoryHelper _repository;
        public CredentialsRepository(RepositoryHelper helper)
        {
            _repository = helper;
        }
        public UserCredentials Login(UserCredentials user)
        {
            return _repository.Login(user);
        }

        public bool Register(UserCredentials user)
        {
            return _repository.Register(user);
        }
    }
}
