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
        private SubCriterioData subCriterioData;

        public CriterioData(string connectionString)
        {
            this.connectionString = connectionString;
            this.subCriterioData = new SubCriterioData(connectionString);
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
            daCriterio.Fill(dsCriterio, "Criterio");

            DataRowCollection rows = dsCriterio.Tables["Criterio"].Rows;

            LinkedList<Criterio> criterios = new LinkedList<Criterio>();

            foreach (DataRow row in rows)
            {
                Criterio criterio = new Criterio(Int32.Parse(row["id_criterio"].ToString()), row["descripcion"].ToString());
                criterio.SubCriterios = subCriterioData.getAllSubCriteriosByCriterio(criterio.IdCriterio);
                criterios.AddLast(criterio);
            }

            return criterios;
        }

        public Criterio findCriterioByCode(int idCriterio)
        {
            String sqlSelect = "SELECT c.id_criterio,c.descripcion" +
                " FROM Criterio c" +
                " where c.id_criterio = " + idCriterio;

            SqlConnection connection = new SqlConnection(this.connectionString);
            DataSet dsCriterio = new DataSet();
            SqlDataAdapter daCriterio = new SqlDataAdapter();
            daCriterio.SelectCommand = new SqlCommand(sqlSelect, connection);
            daCriterio.Fill(dsCriterio, "Criterio");

            DataRowCollection rows = dsCriterio.Tables["Criterio"].Rows;

            Criterio criterio = null;

            foreach (DataRow row in rows)
            {
                criterio = new Criterio(Int32.Parse(row["id_criterio"].ToString()), row["descripcion"].ToString());
                criterio.SubCriterios = subCriterioData.getAllSubCriteriosByCriterio(criterio.IdCriterio);
            }

            return criterio;
        }

        public Criterio insertar(Criterio criterio, AreaTematica areaTematica)
        {
            SqlCommand cmdCriterios = new SqlCommand();
            cmdCriterios.CommandText = "insertar_criterio";
            cmdCriterios.CommandType = System.Data.CommandType.StoredProcedure;
            cmdCriterios.Parameters.Add(new SqlParameter("@descripcion", criterio.Descripcion));
            cmdCriterios.Parameters.Add(new SqlParameter("@idAreaTematica", areaTematica.IdAreaTematica));

            SqlParameter parametroIdCriterio = new SqlParameter("@idCriterio", System.Data.SqlDbType.Int);
            parametroIdCriterio.Direction = System.Data.ParameterDirection.Output;
            cmdCriterios.Parameters.Add(parametroIdCriterio);

            //Comando para insertar subcriterios
            SqlCommand cmdSubCriterios = new SqlCommand();
            cmdSubCriterios.CommandText = "insertar_subCriterio";
            cmdSubCriterios.CommandType = System.Data.CommandType.StoredProcedure;

            SqlConnection connection = new SqlConnection(connectionString);
            SqlTransaction transaction = null;

            try
            {
                connection.Open();
                transaction = connection.BeginTransaction();
                cmdSubCriterios.Connection = connection;
                cmdSubCriterios.Transaction = transaction;
                cmdCriterios.Connection = connection;
                cmdCriterios.Transaction = transaction;

                cmdCriterios.ExecuteNonQuery();
                criterio.IdCriterio = Int32.Parse(cmdCriterios.Parameters["@idCriterio"].Value.ToString());

                LinkedList<SubCriterio> subCriterios = criterio.SubCriterios;
                foreach (SubCriterio subCriterioActual in subCriterios)
                {
                    cmdSubCriterios.Parameters.Add(new SqlParameter("@descripcion", subCriterioActual.Descripcion));
                    cmdSubCriterios.Parameters.Add(new SqlParameter("@idCriterio", criterio.IdCriterio));
                    SqlParameter parametroIdSubCriterio = new SqlParameter("@idSubCriterio", System.Data.SqlDbType.Int);
                    parametroIdSubCriterio.Direction = System.Data.ParameterDirection.Output;
                    cmdSubCriterios.Parameters.Add(parametroIdSubCriterio);

                    cmdSubCriterios.ExecuteNonQuery();
                    subCriterioActual.IdSubCriterio = Int32.Parse(cmdSubCriterios.Parameters["@idSubCriterio"].Value.ToString());
                    cmdSubCriterios.Parameters.Clear();
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

            return criterio;
        }
    }
}
