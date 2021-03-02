using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTask.Core;
using TestTask.Infrastructure;
using TestTask.Interfaces;

namespace TestTask.Infrasctructure
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private DatabaseContext db;
        private UserRepository userRepository;
        public EFUnitOfWork(string connectionString)
        {
            db = new DatabaseContext(connectionString);
        }

        //Singltone
        public IRepository<User> Users
        {
            get
            {
                if (userRepository == null)
                {
                    userRepository = new UserRepository(db);
                }
                return userRepository;
            }
        }
        public void Save()
        {
            db.SaveChangesAsync();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
    }
