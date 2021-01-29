using JWTExample.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JWTExample.Data
{
    public class AuthDBContext: DbContext
    {
        public AuthDBContext(DbContextOptions options): base(options)
        {

        }

        public DbSet<UserCredentials> credentials { get; set; }
        public DbSet<Details> todo { get; set; }
    }
}
