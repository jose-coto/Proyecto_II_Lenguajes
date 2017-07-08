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
    public class AccionAdministrativaData
    {
        private String connectionString;

        public AccionAdministrativaData(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public AccionAdministrativa getAccionAdministrativaByIdEvidencia(int idEvidencia)
        {
            String sqlSelect = "select ad.detalle, ad.informe_tecnico" +
                " from AccionAdministrativa ad" +
                " where ad.id_evidencia=" + idEvidencia;


            SqlConnection connection = new SqlConnection(this.connectionString);
            DataSet dsAccionAdministrativa = new DataSet();
            SqlDataAdapter daAccionAdministrativa = new SqlDataAdapter();
            daAccionAdministrativa.SelectCommand = new SqlCommand(sqlSelect, connection);
            daAccionAdministrativa.Fill(dsAccionAdministrativa, "AccionAdministrativa");

            DataRowCollection rows = dsAccionAdministrativa.Tables["AccionAdministrativa"].Rows;

            AccionAdministrativa accion = null;

            foreach (DataRow row in rows)
            {
                accion = new AccionAdministrativa(row["detalle"].ToString(), row["informe_tecnico"].ToString());
            }

            return accion;
        }

        public void insertar(AccionAdministrativa accion)
        {
            SqlCommand cmdAccion = new SqlCommand();
            cmdAccion.CommandText = "insertar_accion_administrativa";
            cmdAccion.CommandType = System.Data.CommandType.StoredProcedure;
            cmdAccion.Parameters.Add(new SqlParameter("@idEvidencia", accion.IdEvidencia));
            cmdAccion.Parameters.Add(new SqlParameter("@detalle", accion.Detalle));
            cmdAccion.Parameters.Add(new SqlParameter("@informeTecnico", accion.InformeTecnico));

            SqlConnection connection = new SqlConnection(connectionString);
            SqlTransaction transaction = null;

            try
            {
                connection.Open();
                transaction = connection.BeginTransaction();
                cmdAccion.Connection = connection;
                cmdAccion.Transaction = transaction;

                cmdAccion.ExecuteNonQuery();

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
        }
    }
}
