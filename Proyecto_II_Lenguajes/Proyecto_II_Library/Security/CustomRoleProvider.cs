using Proyecto_II_Library.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;
using System.Web.Security;

namespace Proyecto_II_Library.Security
{
    public class CustomRoleProvider : RoleProvider
    {
        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }

            set
            {
                throw new NotImplementedException();
            }
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
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
            String connection = WebConfigurationManager.ConnectionStrings["ProyectoII"].ConnectionString;
            SeguridadBusiness seguridadBusiness = new SeguridadBusiness(connection);
            return seguridadBusiness.getAllRoles();
        }

        public override string[] GetRolesForUser(string username)
        {
            String connection = WebConfigurationManager.ConnectionStrings["ProyectoII"].ConnectionString;
            SeguridadBusiness seguridadBusiness = new SeguridadBusiness(connection);
            return seguridadBusiness.getRolesForUser(username);
        }

        public override string[] GetUsersInRole(string roleName)
        {
            String connection = WebConfigurationManager.ConnectionStrings["ProyectoII"].ConnectionString;
            SeguridadBusiness seguridadBusiness = new SeguridadBusiness(connection);
            return seguridadBusiness.getUsersInRole(roleName);
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            String connection = WebConfigurationManager.ConnectionStrings["ProyectoII"].ConnectionString;
            SeguridadBusiness seguridadBusiness = new SeguridadBusiness(connection);
            return seguridadBusiness.isInRole(username, roleName);
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            String connection = WebConfigurationManager.ConnectionStrings["ProyectoII"].ConnectionString;
            SeguridadBusiness seguridadBusiness = new SeguridadBusiness(connection);
            return seguridadBusiness.RoleExists(roleName);
        }
    }
}
