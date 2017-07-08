using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proyecto_II_Library.Business;
using Proyecto_II_Library.Domain;

namespace Proyecto_II_Library.DataAccess
{
    public class EvidenciaData
    {
        private String connectionString;

        public EvidenciaData(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public Evidencia getEvidenciaBySubCriterio(int idSubCriterio)
        {
            String sqlSelect = "select e.id_evidencia,e.fecha,e.titulo,e.tipo_evidencia,e.id_subCriterio" +
                " from Evidencia e" +
                " where e.id_subCriterio=" + idSubCriterio;


            SqlConnection connection = new SqlConnection(this.connectionString);
            DataSet dsEvidencia = new DataSet();
            SqlDataAdapter daEvidencia = new SqlDataAdapter();
            daEvidencia.SelectCommand = new SqlCommand(sqlSelect, connection);
            daEvidencia.Fill(dsEvidencia, "Evidencia");

            DataRowCollection rows = dsEvidencia.Tables["Evidencia"].Rows;

            Evidencia evidencia = null;

            foreach (DataRow row in rows)
            {
                evidencia = new Evidencia(Int32.Parse(row["id_evidencia"].ToString()),row["titulo"].ToString(),
                                          DateTime.Parse(row["fecha"].ToString()),Char.Parse(row["tipo_evidencia"].ToString()));

                SubCriterioData scd = new SubCriterioData(connectionString);
                evidencia.SubCriterio = scd.getSubCriterioByCode(Int32.Parse(row["id_subCriterio"].ToString()));
            }

            return evidencia;
        }

        public Evidencia insertar(Evidencia evidencia, Evaluacion evaluacion,AccionAdministrativa accion,
                                  Normativa normativa,Documento documento,Actividad actividad)
        {
            SqlCommand cmdEvidencia = new SqlCommand();
            cmdEvidencia.CommandText = "insertar_evidencia";
            cmdEvidencia.CommandType = System.Data.CommandType.StoredProcedure;
            cmdEvidencia.Parameters.Add(new SqlParameter("@fechaIngreso", evidencia.FechaIngreso));
            cmdEvidencia.Parameters.Add(new SqlParameter("@titulo", evidencia.Titulo));
            cmdEvidencia.Parameters.Add(new SqlParameter("@idSubCriterio", evidencia.SubCriterio.IdSubCriterio));
            cmdEvidencia.Parameters.Add(new SqlParameter("@idEvaluacion", evaluacion.IdEvaluacion));
            cmdEvidencia.Parameters.Add(new SqlParameter("@tipoEvidencia", evidencia.Tipo));

            SqlParameter parametroIdEvidencia = new SqlParameter("@idEvidencia", System.Data.SqlDbType.Int);
            parametroIdEvidencia.Direction = System.Data.ParameterDirection.Output;
            cmdEvidencia.Parameters.Add(parametroIdEvidencia);

            SqlConnection connection = new SqlConnection(connectionString);
            SqlTransaction transaction = null;

            try
            {
                connection.Open();
                transaction = connection.BeginTransaction();
                cmdEvidencia.Connection = connection;
                cmdEvidencia.Transaction = transaction;

                cmdEvidencia.ExecuteNonQuery();
                evidencia.IdEvidencia = Int32.Parse(cmdEvidencia.Parameters["@idEvidencia"].Value.ToString());

                if (evidencia.Tipo.Equals("AD"))
                {
                    AccionAdministrativaBusiness aad = new AccionAdministrativaBusiness(connectionString);
                    aad.insertar(accion);
                }else if (evidencia.Tipo.Equals("NO"))
                {
                    //insertar normativa
                }
                else if (evidencia.Tipo.Equals("DO"))
                {
                    DocumentoBusiness dd = new DocumentoBusiness(connectionString);
                    dd.insertar(documento);
                }
                else
                {
                    //insertar Actividad
                }

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

            return evidencia;
        }
    }
}
