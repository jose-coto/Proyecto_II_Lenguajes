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
    public class DocumentoData
    {
        private String connectionString;

        public DocumentoData(String connectionString)
        {
            this.connectionString = connectionString;
        }

        public Documento getDocumentoByIdEvidencia(int idEvidencia)
        {
            String sqlSelect = "select d.detalle,d.fuente,d.fecha,d.id_tipo_documento, td.descripcion" +
                " from Documento d left join TipoDocumento td on d.id_tipo_documento = td.id_tipo_documento" +
                " where d.id_evidencia = " + idEvidencia;


            SqlConnection connection = new SqlConnection(this.connectionString);
            DataSet dsAccionAdministrativa = new DataSet();
            SqlDataAdapter daAccionAdministrativa = new SqlDataAdapter();
            daAccionAdministrativa.SelectCommand = new SqlCommand(sqlSelect, connection);
            daAccionAdministrativa.Fill(dsAccionAdministrativa, "AccionAdministrativa");

            DataRowCollection rows = dsAccionAdministrativa.Tables["AccionAdministrativa"].Rows;

            Documento documento = null;

            foreach (DataRow row in rows)
            {
                documento = new Documento(row["detalle"].ToString(), row["fuente"].ToString(), DateTime.Parse(row["fecha"].ToString()));
                documento.TipoDocumento = new TipoDocumento(Int32.Parse(row["id_tipo_documento"].ToString()), row["descripcion"].ToString());
            }

            return documento;
        }

        public void insertar(Documento documento)
        {
            SqlCommand cmdDocumento = new SqlCommand();
            cmdDocumento.CommandText = "insertar_documento";
            cmdDocumento.CommandType = System.Data.CommandType.StoredProcedure;
            cmdDocumento.Parameters.Add(new SqlParameter("@idEvidencia", documento.IdEvidencia));
            cmdDocumento.Parameters.Add(new SqlParameter("@detalle", documento.Detalle));
            cmdDocumento.Parameters.Add(new SqlParameter("@fuente", documento.Fuente));
            cmdDocumento.Parameters.Add(new SqlParameter("@fecha", documento.Fecha));
            cmdDocumento.Parameters.Add(new SqlParameter("@idTipoDocumento", documento.TipoDocumento.IdTipoDocumento));

            SqlConnection connection = new SqlConnection(connectionString);
            SqlTransaction transaction = null;

            try
            {
                connection.Open();
                transaction = connection.BeginTransaction();
                cmdDocumento.Connection = connection;
                cmdDocumento.Transaction = transaction;

                cmdDocumento.ExecuteNonQuery();

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
