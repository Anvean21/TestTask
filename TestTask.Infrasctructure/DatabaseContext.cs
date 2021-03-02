using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Core;

namespace TestTask.Infrastructure
{
    public class DatabaseContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        static DatabaseContext()
        {
            Database.SetInitializer(new DbInitializer());
        }
        public DatabaseContext(string connectionString)
            : base(connectionString)
        {
        }

    }
}