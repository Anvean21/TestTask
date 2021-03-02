using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using TestTask.Core;
using TestTask.Infrastructure;

namespace TestTask.Infrasctructure.Providers
{
    class CustomRoleProvider : RoleProvider
    {
        EFUnitOfWork eFUnitOfWork;
        public override string[] GetRolesForUser(string username)
        {
            string[] roles = new string[] { };
           
                // Получаем пользователя
                User user = eFUnitOfWork.Users.GetAll().FirstOrDefault(u => u.Email == username);
                if (user != null && user.Role != null)
                {
                    // получаем роль
                    roles = new string[] { user.Role.Name };
                }
                return roles;
            
        }
        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }
        public override bool IsUserInRole(string username, string roleName)
        {
            
                // Получаем пользователя
                User user = eFUnitOfWork.Users.GetAll().FirstOrDefault(u => u.Email == username);

                if (user != null && user.Role != null && user.Role.Name == roleName)
                    return true;
                else
                    return false;
            
        }
        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName
        {
            get { throw new NotImplementedException(); }
            set { throw new NotImplementedException(); }
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}
