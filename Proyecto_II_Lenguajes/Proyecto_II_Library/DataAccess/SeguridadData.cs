using Proyecto_II_Library.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_II_Library.DataAccess
{
    public class SeguridadData
    {

        private String connectionString;

        public SeguridadData(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public Funcionario signInUser(String username, String password)
        {
            String sqlSelect = "SELECT f.id_funcionario,f.nombre_funcionario,f.apellidos_funcionario,f.userName,f.password,f.enable," +
                "f.id_role,r.nombre_role FROM Funcionario f left join Role r on f.id_role = r.id_role WHERE f.username ='" + username + "' and f.password = '"+password+"'";
            SqlConnection connection = new SqlConnection(this.connectionString);
            DataSet dsFuncionario = new DataSet();
            SqlDataAdapter daFuncionario = new SqlDataAdapter();
            daFuncionario.SelectCommand = new SqlCommand(sqlSelect, connection);
            daFuncionario.Fill(dsFuncionario, "Funcionario");
            LinkedList<Funcionario> funcionarios = FuncionarioExtractor(dsFuncionario);
            return funcionarios.Count!=0?funcionarios.First() : null;
        }

        private LinkedList<Funcionario> FuncionarioExtractor(DataSet dsFuncionario)
        {
            DataRowCollection rows = dsFuncionario.Tables["Funcionario"].Rows;
            LinkedList<Funcionario> funcionarios = new LinkedList<Funcionario>();
            foreach (DataRow row in rows)
            {
                Funcionario f = new Funcionario(Int32.Parse(row["id_funcionario"].ToString()), row["nombre_funcionario"].ToString(),
                    row["apellidos_funcionario"].ToString(), row["userName"].ToString(), row["password"].ToString(),
                    Boolean.Parse(row["enable"].ToString()));
                Role role = new Role(Int32.Parse(row["id_role"].ToString()), row["nombre_role"].ToString());
                f.Role = role;

                funcionarios.AddLast(f);
            }
            return funcionarios;
        }

        private String[] RoleExtractor(DataSet dsRole)
        {
            DataRowCollection rows = dsRole.Tables["Role"].Rows;
            LinkedList<Role> roles = new LinkedList<Role>();
            foreach (DataRow row in rows)
            {
                Role role = new Role(Int32.Parse(row["id_role"].ToString()), row["nombre_role"].ToString());
                roles.AddLast(role);
            }
            String[] rols = new String [roles.Count];
            int i = 0;
            foreach (Role r in roles)
            {
                rols[i] = r.NombreRole;
                i++;
            }
            return rols;

        }

        public Boolean isInRole(String username, String role)
        {
            String sqlSelect = "SELECT f.id_funcionario,f.nombre_funcionario,f.apellidos_funcionario,f.userName,f.password,f.enable," +
               "f.id_role,r.nombre_role FROM Funcionario f left join Role r on f.id_role = r.id_role WHERE f.username ='" + username + "' and r.nombre_role = '" + role + "'";
            SqlConnection connection = new SqlConnection(this.connectionString);
            DataSet dsFuncionario = new DataSet();
            SqlDataAdapter daFuncionario = new SqlDataAdapter();
            daFuncionario.SelectCommand = new SqlCommand(sqlSelect, connection);
            daFuncionario.Fill(dsFuncionario, "Funcionario");
            LinkedList<Funcionario> funcionarios = FuncionarioExtractor(dsFuncionario);
            return funcionarios.Count != 0;
        }

        public Boolean RoleExists(String roleName)
        {
            String sqlSelect = "SELECT * From Role r WHERE r.nombre_role = '" + roleName + "'";
            SqlConnection connection = new SqlConnection(this.connectionString);
            DataSet dsRole = new DataSet();
            SqlDataAdapter daRole = new SqlDataAdapter();
            daRole.SelectCommand = new SqlCommand(sqlSelect, connection);
            daRole.Fill(dsRole, "Role");
            return dsRole.Tables["Role"].Rows.Count != 0;
        }

        public String[] getRolesForUser(String username)
        {
            String sqlSelect = "SELECT r.id_role, r.nombre_role From Role r " +
                               "left join Funcionario f on f.id_role = r.id_role " +
                               "WHERE f.userName = '" + username + "'";
            SqlConnection connection = new SqlConnection(this.connectionString);
            DataSet dsRole = new DataSet();
            SqlDataAdapter daRole = new SqlDataAdapter();
            daRole.SelectCommand = new SqlCommand(sqlSelect, connection);
            daRole.Fill(dsRole, "Role");
            return RoleExtractor(dsRole);
        }

        public String[] getUsersInRole(String roleName)
        {
            String sqlSelect = "SELECT f.id_funcionario,f.nombre_funcionario,f.apellidos_funcionario,f.userName,f.password,f.enable," +
               "f.id_role,r.nombre_role FROM Funcionario f left join Role r on f.id_role = r.id_role WHERE r.nombre_role = '" + roleName + "'";
            SqlConnection connection = new SqlConnection(this.connectionString);
            DataSet dsFuncionario = new DataSet();
            SqlDataAdapter daFuncionario = new SqlDataAdapter();
            daFuncionario.SelectCommand = new SqlCommand(sqlSelect, connection);
            daFuncionario.Fill(dsFuncionario, "Funcionario");
            LinkedList<Funcionario> funcionarios = FuncionarioExtractor(dsFuncionario);
            int i = 0;
            String[] usuarios = new String[funcionarios.Count];
            foreach (Funcionario f in funcionarios)
            {
                usuarios[i] = f.UserName;
                i++;
            }
            return usuarios;
        }

        public String[] getAllRoles()
        {
            String sqlSelect = "SELECT * From Role";
            SqlConnection connection = new SqlConnection(this.connectionString);
            DataSet dsRole = new DataSet();
            SqlDataAdapter daRole = new SqlDataAdapter();
            daRole.SelectCommand = new SqlCommand(sqlSelect, connection);
            daRole.Fill(dsRole, "Role");
            return RoleExtractor(dsRole);
        }

    }
}
