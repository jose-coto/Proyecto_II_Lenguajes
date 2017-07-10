using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proyecto_II_Library.Business;
using Proyecto_II_Library.Domain;
using System.Data.OleDb;

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

        public Evidencia insertar(Evidencia evidencia, Evaluacion evaluacion)
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


        public void insertarActividad(Actividad actividad)
        {

            // colocamos procedemos a insertar la actividad
            SqlCommand cmd = new SqlCommand();
            SqlConnection conn = new SqlConnection(this.connectionString);
            SqlConnection connTP = new SqlConnection(this.connectionString);
            
            // Estableciento propiedades
            cmd.Connection = conn;
            cmd.CommandText = "INSERT INTO Actividad VALUES (@idEvidencia, @cantParticipantes, @fecha, @descripcion)";
            // Creando los parámetros necesarios
            cmd.Parameters.Add("@idEvidencia", System.Data.SqlDbType.Int);
            cmd.Parameters.Add("@cantParticipantes", System.Data.SqlDbType.Int);
            cmd.Parameters.Add("@fecha", System.Data.SqlDbType.Date);
            cmd.Parameters.Add("@descripcion", System.Data.SqlDbType.VarChar);

            // Asignando los valores a los atributos
            cmd.Parameters["@idEvidencia"].Value = actividad.IdEvidencia;
            cmd.Parameters["@cantParticipantes"].Value = actividad.CantidadParticipantes;
            cmd.Parameters["@fecha"].Value = actividad.Fecha;
            cmd.Parameters["@descripcion"].Value = actividad.Descripcion;

                //Inserta Actividad        
                conn.Open();            
                cmd.Connection = conn;                
                cmd.ExecuteNonQuery();

                //Insertamos las imagenes
                foreach (Imagen imagen in actividad.Imagenes)
                {
                    WriteImageToDB(imagen, actividad.IdEvidencia);   
                }


            //Insertamos los participantes
            foreach (TipoParticipante tParticipante in actividad.TipoParticipantes)
            {
                // Estableciento propiedades
                SqlCommand cmdTP = new SqlCommand();

                cmdTP.CommandText = "INSERT INTO TipoParticipanteActividad VALUES (@idTP, @idEvidencia)";
                cmdTP.Connection = connTP;
                connTP.Open();
                // Creando los parámetros necesarios
                cmdTP.Parameters.Add("@idTP", System.Data.SqlDbType.Int);
                cmdTP.Parameters.Add("@idEvidencia", System.Data.SqlDbType.Int);

                // Asignando los valores a los atributos
                cmdTP.Parameters["@idTP"].Value = tParticipante.IdTipoParticipante;
                cmdTP.Parameters["@idEvidencia"].Value = actividad.IdEvidencia;

                cmdTP.ExecuteNonQuery();
                connTP.Close();

            }
                conn.Close();

        }


        private Imagen WriteImageToDB(Imagen imagen, int idAct)
        {
            
            SqlCommand cmd = new SqlCommand();
            SqlConnection conn = new SqlConnection(this.connectionString);
            SqlTransaction transaction = null;

            // Estableciento propiedades
            cmd.Connection = conn;
            cmd.CommandText = "insert_image";
            cmd.CommandType = System.Data.CommandType.StoredProcedure;

            // Creando los parámetros necesarios
            cmd.Parameters.Add("@name", System.Data.SqlDbType.VarChar);
            cmd.Parameters.Add("@size", System.Data.SqlDbType.Int);
            cmd.Parameters.Add("@type", System.Data.SqlDbType.VarChar);
            cmd.Parameters.Add("@data", System.Data.SqlDbType.VarBinary);
            cmd.Parameters.Add("@idEvidencia", System.Data.SqlDbType.Int);

            // Asignando los valores a los atributos
            cmd.Parameters["@name"].Value = imagen.Nombre;
            cmd.Parameters["@size"].Value = imagen.Data.Length;
            cmd.Parameters["@type"].Value = imagen.ContentType;
            cmd.Parameters["@data"].Value = imagen.Data;
            cmd.Parameters["@idEvidencia"].Value = idAct;

            //Asignamos el parametro de salida
            SqlParameter parametroId = new SqlParameter("@id", System.Data.SqlDbType.Int);
            parametroId.Direction = System.Data.ParameterDirection.Output;
            cmd.Parameters.Add(parametroId);

            //Inicia transaccion
            try
            {
                conn.Open();
                transaction = conn.BeginTransaction();
                cmd.Connection = conn;
                cmd.Transaction = transaction;

                //Ejecutamos y obtenemos el id de la imagen guardada
                cmd.ExecuteNonQuery();
                imagen.IdImagen = Int32.Parse(cmd.Parameters["@id"].Value.ToString());

                transaction.Commit();
            }
            catch (SqlException ex)
            {
                if (transaction != null) transaction.Rollback();
                throw ex;
            }
            finally
            {
                if (conn != null) conn.Close();
            }

            return imagen;
        }


        public Imagen ShowTheFile(int FileID)
        {
            string SQL = "SELECT FILE_SIZE, FILE_DATA, CONTENT_TYPE, FILE_NAM FROM Imagen WHERE ID_IMAGEN = "
            + FileID.ToString();

            // Create Connection object
            OleDbConnection dbConn = new OleDbConnection("Provider=SQLOLEDB; Data Source=163.178.173.148;Initial Catalog=ProyectoII_Lenguajes_2017;User ID=lenguajes;Password=lenguajes");

            // Create Command Object
            OleDbCommand dbComm = new OleDbCommand(SQL, dbConn);

            // Open Connection
            dbConn.Open();

            // Execute command and receive DataReader
            OleDbDataReader dbRead = dbComm.ExecuteReader();

            // Read row
            dbRead.Read();

            Imagen result = new Imagen(FileID, (string)dbRead["FILE_NAM"], (int)dbRead["FILE_SIZE"], (string)dbRead["CONTENT_TYPE"], (byte[])dbRead["FILE_DATA"]);

            // Close database connection
            dbConn.Close();

            return result;

        }
    }
}
