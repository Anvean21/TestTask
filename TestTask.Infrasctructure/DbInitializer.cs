using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Core;

namespace TestTask.Infrastructure
{
    class DbInitializer : DropCreateDatabaseIfModelChanges<DatabaseContext>
    {
        protected override void Seed(DatabaseContext db)
        {
            Role admin = new Role { Name = "admin" };
            Role user = new Role { Name = "user" };
            db.Roles.Add(admin);
            db.Roles.Add(user);
            db.Users.Add(new User
            {
                Email = "Admin@gmail.com",
                Password = "adminpass1",
                Role = admin
            });
            db.Users.Add(new User
            {
                Email = "User@gmail.com",
                Password = "userpass2",
                Role = user
            });

            db.SaveChanges();
            base.Seed(db);
        }
    }
}
