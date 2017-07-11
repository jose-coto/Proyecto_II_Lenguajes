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
    public class EvaluacionData
    {
        private String connectionString;

        public EvaluacionData(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public int getEvaluacionByAreaTematicaAndIdFuncionario(int idAreaTematica)
        {
            String sqlSelect = "SELECT ev.id_evaluacion,ev.fecha_inicio_evaluacion,ev.fecha_final_evaluacion" +
                " FROM Evaluacion ev left join EncargadoEvaluacion ee on ev.id_evaluacion = ee.id_evaluacion" +
                " where ee.id_area_tematica ="+idAreaTematica;

            SqlConnection connection = new SqlConnection(this.connectionString);
            DataSet dsEvaluacion = new DataSet();
            SqlDataAdapter daEvaluacion = new SqlDataAdapter();
            daEvaluacion.SelectCommand = new SqlCommand(sqlSelect, connection);
            daEvaluacion.Fill(dsEvaluacion, "Evaluacion");

            DataRowCollection rows = dsEvaluacion.Tables["Evaluacion"].Rows;

            Evaluacion evaluacion = null;

            foreach (DataRow row in rows)
            {
                evaluacion = new Evaluacion(Int32.Parse(row["id_evaluacion"].ToString()), DateTime.Parse(row["fecha_inicio_evaluacion"].ToString()),
                                          DateTime.Parse(row["fecha_final_evaluacion"].ToString()));
            }

            return evaluacion.IdEvaluacion;
        }

        public LinkedList<Evaluacion> getEvaluaciones()
        {
            String sqlSelect = "SELECT ev.id_evaluacion,ev.fecha_inicio_evaluacion,ev.fecha_final_evaluacion" +
                " FROM Evaluacion ev ";

            SqlConnection connection = new SqlConnection(this.connectionString);
            DataSet dsEvaluacion = new DataSet();
            SqlDataAdapter daEvaluacion = new SqlDataAdapter();
            daEvaluacion.SelectCommand = new SqlCommand(sqlSelect, connection);
            daEvaluacion.Fill(dsEvaluacion, "Evaluacion");

            DataRowCollection rows = dsEvaluacion.Tables["Evaluacion"].Rows;

            LinkedList<Evaluacion> evaluaciones = new LinkedList<Evaluacion>();

            foreach (DataRow row in rows)
            {
                Evaluacion evaluacion = new Evaluacion(Int32.Parse(row["id_evaluacion"].ToString()), DateTime.Parse(row["fecha_inicio_evaluacion"].ToString()),
                                          DateTime.Parse(row["fecha_final_evaluacion"].ToString()));
                evaluaciones.AddLast(evaluacion);
            }

            return evaluaciones;
        }

        public void Insertar(Evaluacion evaluacion)
        {
            SqlCommand cmdEvaluacion = new SqlCommand();
            cmdEvaluacion.CommandText = "insertar_evaluacion";
            cmdEvaluacion.CommandType = System.Data.CommandType.StoredProcedure;
            cmdEvaluacion.Parameters.Add(new SqlParameter("@fechaInicioEvaluacion", evaluacion.FechaInicioEvaluacion));
            cmdEvaluacion.Parameters.Add(new SqlParameter("@fechaFinalEvaluacion", evaluacion.FechaFinalEvaluacion));
            cmdEvaluacion.Parameters.Add(new SqlParameter("@idRecinto", evaluacion.Recinto.IdRecinto));
            cmdEvaluacion.Parameters.Add(new SqlParameter("@idGuiaReconocimiento", evaluacion.GuiaReconocimiento.IdGuiaReconocimiento));

            SqlParameter parametroIdCriterio = new SqlParameter("@idEvaluacion", System.Data.SqlDbType.Int);
            parametroIdCriterio.Direction = System.Data.ParameterDirection.Output;
            cmdEvaluacion.Parameters.Add(parametroIdCriterio);

            SqlConnection connection = new SqlConnection(connectionString);
            SqlTransaction transaction = null;

            try
            {
                connection.Open();
                transaction = connection.BeginTransaction();
                cmdEvaluacion.Connection = connection;
                cmdEvaluacion.Transaction = transaction;

                cmdEvaluacion.ExecuteNonQuery();
                evaluacion.IdEvaluacion = Int32.Parse(cmdEvaluacion.Parameters["@idEvaluacion"].Value.ToString());
                
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
