using Proyecto_II_Library.DataAccess;
using Proyecto_II_Library.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_II_Library.Business
{
    public class SeguridadBusiness
    {
        SeguridadData seguridadData;

        public SeguridadData SeguridadData
        {
            get
            {
                return seguridadData;
            }

            set
            {
                seguridadData = value;
            }
        }

        public SeguridadBusiness(string connectionString)
        {
            SeguridadData = new SeguridadData(connectionString);
        }

        public Funcionario signInUser(String username, String password)
        {
            return SeguridadData.signInUser(username, password);
        }

        public Boolean isInRole(String username, String role)
        {
            return SeguridadData.isInRole(username, role);
        }

        public Boolean RoleExists(String roleName)
        {
            return SeguridadData.RoleExists(roleName);
        }
        public String[] getAllRoles()
        {
            return seguridadData.getAllRoles();
        }
        public LinkedList<Role> getAllRolesList()
        {
            return seguridadData.getAllRolesList();
        }
        public String[] getRolesForUser(String username)
        {
            return seguridadData.getRolesForUser(username);
        }
        public String[] getUsersInRole(String roleName)
        {
            return seguridadData.getUsersInRole(roleName);
        }
        public Role getRoleByName(String name)
        {
            return seguridadData.getRoleByName(name);
        }
    }   
}
