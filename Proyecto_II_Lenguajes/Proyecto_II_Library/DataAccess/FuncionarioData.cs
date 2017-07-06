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
            String sqlSelect = "SELECT f.id_funcionario,f.nombre_funcionario,f.apellidos_funcionario,f.userName,f.password,f.enable,f.id_role FROM Funcionario f WHERE id_funcionario =" + id;
            SqlConnection connection = new SqlConnection(this.connectionString);
            DataSet dsFuncionario = new DataSet();
            SqlDataAdapter daFuncionario = new SqlDataAdapter();
            daFuncionario.SelectCommand = new SqlCommand(sqlSelect, connection);
            daFuncionario.Fill(dsFuncionario, "Funcionario");
            return FuncionarioExtractor(dsFuncionario).First();
        }
        private LinkedList<Funcionario> FuncionarioExtractor(DataSet dsEditoriales)
        {
            DataRowCollection rows = dsEditoriales.Tables["Editorial"].Rows;
            LinkedList<Funcionario> funcionarios = new LinkedList<Funcionario>();
            foreach (DataRow row in rows)
            {


                Funcionario f = new Funcionario(Int32.Parse(row["id_funcionario"].ToString()), row["nombre_funcionario"].ToString(),
                    row["apellidos_funcionario"].ToString(), row["userName"].ToString(), row["password"].ToString(),
                    Boolean.Parse(row["enable"].ToString()));
                Role role = new Role();
                f.Role = role;

                funcionarios.AddLast(f);
            }
            return funcionarios;
        }
    }
}