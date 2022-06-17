using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthenticationService.DataAccess
{
    public class AuthContext: DbContext
    {
        private readonly string _connectionString;

        public AuthContext()
        {
            _connectionString = @"Data Source=V-FURSENKO-1\SQLEXPRESS;Initial Catalog=AUTH;Integrated Security=True";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}
