using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proyecto_II_Library.Domain;

namespace Proyecto_II_Library.DataAccess
{
    public class SubCriterioData
    {
        private String connectionString;

        public SubCriterioData(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public LinkedList<SubCriterio> getAllSubCriteriosByCriterio(int idCriterio)
        {
            String sqlSelect = "select sc.id_subCriterio,sc.descripcion " +
                " from SubCriterio sc" +
                " where sc.id_criterio=" + idCriterio;


            SqlConnection connection = new SqlConnection(this.connectionString);
            DataSet dsSubCriterio = new DataSet();
            SqlDataAdapter daSubCriterio = new SqlDataAdapter();
            daSubCriterio.SelectCommand = new SqlCommand(sqlSelect, connection);
            daSubCriterio.Fill(dsSubCriterio, "SubCriterio");

            DataRowCollection rows = dsSubCriterio.Tables["SubCriterio"].Rows;

            LinkedList<SubCriterio> subCriterios = new LinkedList<SubCriterio>();

            foreach (DataRow row in rows)
            {
                SubCriterio subCriterio = new SubCriterio(Int32.Parse(row["id_subcriterio"].ToString()), row["descripcion"].ToString());

                subCriterios.AddLast(subCriterio);
            }

            return subCriterios;
        }

        public SubCriterio getSubCriteriosByCode(int idSubCriterio)
        {
            String sqlSelect = "select sc.id_subCriterio,sc.descripcion " +
                " from SubCriterio sc" +
                " where sc.id_subCriterio=" + idSubCriterio;


            SqlConnection connection = new SqlConnection(this.connectionString);
            DataSet dsSubCriterio = new DataSet();
            SqlDataAdapter daSubCriterio = new SqlDataAdapter();
            daSubCriterio.SelectCommand = new SqlCommand(sqlSelect, connection);
            daSubCriterio.Fill(dsSubCriterio, "SubCriterio");

            DataRowCollection rows = dsSubCriterio.Tables["SubCriterio"].Rows;

            SubCriterio subCriterio = null;

            foreach (DataRow row in rows)
            {
                subCriterio = new SubCriterio(Int32.Parse(row["id_subcriterio"].ToString()), row["descripcion"].ToString());

            }

            return subCriterio;
        }

        public SubCriterio insertar(SubCriterio subCriterio, Criterio criterio)
        {
            SqlCommand cmdSubCriterios = new SqlCommand();
            cmdSubCriterios.CommandText = "insertar_subCriterio";
            cmdSubCriterios.CommandType = System.Data.CommandType.StoredProcedure;
            cmdSubCriterios.Parameters.Add(new SqlParameter("@descripcion", subCriterio.Descripcion));
            cmdSubCriterios.Parameters.Add(new SqlParameter("@idCriterio", criterio.IdCriterio));

            SqlParameter parametroIdSubCriterio = new SqlParameter("@idSubCriterio", System.Data.SqlDbType.Int);
            parametroIdSubCriterio.Direction = System.Data.ParameterDirection.Output;
            cmdSubCriterios.Parameters.Add(parametroIdSubCriterio);

            SqlConnection connection = new SqlConnection(connectionString);
            SqlTransaction transaction = null;

            try
            {
                connection.Open();
                transaction = connection.BeginTransaction();
                cmdSubCriterios.Connection = connection;
                cmdSubCriterios.Transaction = transaction;

                cmdSubCriterios.ExecuteNonQuery();
                subCriterio.IdSubCriterio = Int32.Parse(cmdSubCriterios.Parameters["@idSubCriterio"].Value.ToString());
                
                transaction.Commit();
            }
            catch (SqlException ex)
            {
                if (transaction != null)
                {
                    transaction.Rollback();
                }
                throw ex;
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();

                }
            }

            return subCriterio;
        }
    }
}
