using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestTask.Infrasctructure;
using TestTask.Interfaces;

namespace TestTask.Util
{
    public class NinjectRegistration : NinjectModule
    {
        private string connectinString;

        public NinjectRegistration(string connection)
        {
            connectinString = connection;
        }
        public override void Load()
        {
            Bind<IUnitOfWork>().To<EFUnitOfWork>().WithConstructorArgument(connectinString);
            
        }
    }
}