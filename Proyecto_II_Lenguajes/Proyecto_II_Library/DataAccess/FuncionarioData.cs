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
    public class FuncionarioData
    {
        private String connectionString;

        public FuncionarioData(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public Funcionario BuscarFuncionarioId(int id)
        {
            String sqlSelect = "SELECT f.id_funcionario,f.nombre_funcionario,f.apellidos_funcionario,f.userName,f.password,f.enable," +
                "f.id_role,r.nombre_role FROM Funcionario f, Role r WHERE f.id_funcionario =" + id + " and r.id_role=f.id_role";
            SqlConnection connection = new SqlConnection(this.connectionString);
            DataSet dsFuncionario = new DataSet();
            SqlDataAdapter daFuncionario = new SqlDataAdapter();
            daFuncionario.SelectCommand = new SqlCommand(sqlSelect, connection);
            daFuncionario.Fill(dsFuncionario, "Funcionario");
            return FuncionarioExtractor(dsFuncionario).First();
        }

        public Funcionario insertarFuncionario(Funcionario funcionario)
        {
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.CommandText = "insertar_funcionario";
            sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;
            sqlCommand.Parameters.Add(new SqlParameter("@nombre", funcionario.NombreFuncionario));
            sqlCommand.Parameters.Add(new SqlParameter("@apellidos", funcionario.ApellidosFuncionario));
            sqlCommand.Parameters.Add(new SqlParameter("@userName", funcionario.UserName));
            sqlCommand.Parameters.Add(new SqlParameter("@password", funcionario.Password));
            sqlCommand.Parameters.Add(new SqlParameter("@enable", funcionario.Enable));
            sqlCommand.Parameters.Add(new SqlParameter("@apellidos", funcionario.Role.IdRole));
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open();
                sqlCommand.Connection = connection;
                sqlCommand.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            if (connection != null)
            {
                connection.Close();
            }

            return funcionario;
        }

        public LinkedList<Funcionario> GetFuncionarios()
        {
            String sqlSelect = "SELECT f.id_funcionario,f.nombre_funcionario,f.apellidos_funcionario,f.userName," +
                "f.password,f.enable,f.id_role,r.nombre_role FROM Funcionario f, Role r WHERE r.id_role=f.id_role";
            SqlConnection connection = new SqlConnection(this.connectionString);
            DataSet dsFuncionarios = new DataSet();
            SqlDataAdapter daFuncionarios = new SqlDataAdapter();
            daFuncionarios.SelectCommand = new SqlCommand(sqlSelect, connection);
            daFuncionarios.Fill(dsFuncionarios, "Funcionario");
            return FuncionarioExtractor(dsFuncionarios);
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

    }
}