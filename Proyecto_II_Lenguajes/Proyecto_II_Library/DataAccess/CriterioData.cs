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
    public class CriterioData
    {
        private String connectionString;

        public CriterioData(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public LinkedList<Criterio> findAllCriteriosByAreaTematica(int idAreaTematica)
        {
            String sqlSelect = "SELECT c.id_criterio,c.descripcion" +
                " FROM Criterio c" +
                " where c.id_area_tematica = " + idAreaTematica;

            SqlConnection connection = new SqlConnection(this.connectionString);
            DataSet dsCriterio = new DataSet();
            SqlDataAdapter daCriterio = new SqlDataAdapter();
            daCriterio.SelectCommand = new SqlCommand(sqlSelect, connection);
            daCriterio.Fill(dsCriterio, "Criterios");

            DataRowCollection rows = dsCriterio.Tables["Criterios"].Rows;

            LinkedList<Criterio> criterios = new LinkedList<Criterio>();

            foreach (DataRow row in rows)
            {
                Criterio criterio = new Criterio(Int32.Parse(row[""].ToString()), row[].ToString());

                criterios.AddLast(criterio);
            }

            return criterios;
        }

        public AreaTematica insertar(AreaTematica areaTematica)
        {
            SqlCommand cmdAreas = new SqlCommand();
            cmdAreas.CommandText = "insertar_area_tematica";
            cmdAreas.CommandType = System.Data.CommandType.StoredProcedure;
            cmdAreas.Parameters.Add(new SqlParameter("@nombreAreaTematica", areaTematica.Nombre));
            cmdAreas.Parameters.Add(new SqlParameter("@sigla", areaTematica.Sigla));
            cmdAreas.Parameters.Add(new SqlParameter("@idGuiaReconocimiento", areaTematica.));

            SqlParameter parametroIdArea = new SqlParameter("@idAreaTematica", System.Data.SqlDbType.Int);
            parametroIdArea.Direction = System.Data.ParameterDirection.Output;

            cmdAreas.Parameters.Add(parametroIdArea);

            SqlConnection connection = new SqlConnection(connectionString);
            SqlTransaction transaction = null;

            try
            {
                connection.Open();
                transaction = connection.BeginTransaction();
                cmdDetalleVenta.Connection = connection;
                cmdDetalleVenta.Transaction = transaction;
                cmdAreas.Connection = connection;
                cmdAreas.Transaction = transaction;

                cmdAreas.ExecuteNonQuery();
                venta.IdVenta = Int32.Parse(cmdAreas.Parameters["@idVenta"].Value.ToString());

                List<DetalleVenta> detallesVenta = venta.DetallesVenta;
                foreach (DetalleVenta detalleActual in detallesVenta)
                {
                    cmdDetalleVenta.Parameters.Add(new SqlParameter("@cantidad", detalleActual.Cantidad));
                    cmdDetalleVenta.Parameters.Add(new SqlParameter("@precio", detalleActual.Precio));
                    cmdDetalleVenta.Parameters.Add(new SqlParameter("@subtotal", detalleActual.Subtotal));
                    cmdDetalleVenta.Parameters.Add(new SqlParameter("@idLibro", detalleActual.Libro.IdLibro));
                    cmdDetalleVenta.Parameters.Add(new SqlParameter("@idVenta", venta.IdVenta));
                    cmdDetalleVenta.ExecuteNonQuery();
                    cmdDetalleVenta.Parameters.Clear();
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
        }
            return areaTematica;
        }
    }
}
