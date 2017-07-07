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
    public class AreaTematicaData
    {
        private String connectionString;
        private CriterioData criterioData;

        public AreaTematicaData(string connectionString)
        {
            this.connectionString = connectionString;
            this.criterioData = new CriterioData(connectionString);
        }

        public LinkedList<AreaTematica> getAllAreaTematicas()
        {
            String sqlSelect = "SELECT at.id_area_tematica,at.nombre_area_tematica,at.sigla," +
                " at.id_guia_reconocimiento" +
                " FROM AreaTematica at ";

            SqlConnection connection = new SqlConnection(this.connectionString);
            DataSet dsAreas = new DataSet();
            SqlDataAdapter daAreas = new SqlDataAdapter();
            daAreas.SelectCommand = new SqlCommand(sqlSelect, connection);
            daAreas.Fill(dsAreas, "Areas");

            DataRowCollection rows = dsAreas.Tables["Areas"].Rows;

            LinkedList<AreaTematica> areasTematicas = new LinkedList<AreaTematica>();

            foreach (DataRow row in rows)
            {
                AreaTematica area = new AreaTematica(Int32.Parse(row["id_area_tematica"].ToString()), row["nombre_area_tematica"].ToString(),
                    row["sigla"].ToString());

                area.Criterios = criterioData.findAllCriteriosByAreaTematica(area.IdAreaTematica);
                areasTematicas.AddLast(area);
            }

            return areasTematicas;
        }

        public LinkedList<AreaTematica> getAllAreaTematicasByGuide(int idGuiaReconocimiento)
        {
            String sqlSelect = "SELECT at.id_area_tematica,at.nombre_area_tematica,at.sigla," +
                " at.id_guia_reconocimiento" +
                " FROM AreaTematica at " +
                " where at.id_guia_reconocimiento=" + idGuiaReconocimiento;

            SqlConnection connection = new SqlConnection(this.connectionString);
            DataSet dsAreas = new DataSet();
            SqlDataAdapter daAreas = new SqlDataAdapter();
            daAreas.SelectCommand = new SqlCommand(sqlSelect, connection);
            daAreas.Fill(dsAreas, "Areas");

            DataRowCollection rows = dsAreas.Tables["Areas"].Rows;

            LinkedList<AreaTematica> areasTematicas = new LinkedList<AreaTematica>();

            foreach (DataRow row in rows)
            {
                AreaTematica area = new AreaTematica(Int32.Parse(row["id_area_tematica"].ToString()), row["nombre_area_tematica"].ToString(),
                    row["sigla"].ToString());

                area.Criterios = criterioData.findAllCriteriosByAreaTematica(area.IdAreaTematica);
                areasTematicas.AddLast(area);
            }

            return areasTematicas;
        }

        public AreaTematica findAreaTematicaByCode(int idAreaTematica)
        {
            String sqlSelect = "SELECT at.id_area_tematica,at.nombre_area_tematica,at.sigla," +
                " at.id_guia_reconocimiento" +
                " FROM AreaTematica at " +
                " where at.id_guia_reconocimiento=" + idAreaTematica;

            SqlConnection connection = new SqlConnection(this.connectionString);
            DataSet dsAreas = new DataSet();
            SqlDataAdapter daAreas = new SqlDataAdapter();
            daAreas.SelectCommand = new SqlCommand(sqlSelect, connection);
            daAreas.Fill(dsAreas, "Areas");

            DataRowCollection rows = dsAreas.Tables["Areas"].Rows;

            AreaTematica areasTematica = null;

            foreach (DataRow row in rows)
            {
                areasTematica = new AreaTematica(Int32.Parse(row["id_area_tematica"].ToString()), row["nombre_area_tematica"].ToString(),
                    row["sigla"].ToString());

                areasTematica.Criterios = criterioData.findAllCriteriosByAreaTematica(areasTematica.IdAreaTematica);
            }

            return areasTematica;
        }

        public AreaTematica insertar(AreaTematica areaTematica,GuiaReconocimiento guia)
        {
            SqlCommand cmdAreas = new SqlCommand();
            cmdAreas.CommandText = "insertar_area_tematica";
            cmdAreas.CommandType = System.Data.CommandType.StoredProcedure;
            cmdAreas.Parameters.Add(new SqlParameter("@nombreAreaTematica", areaTematica.Nombre));
            cmdAreas.Parameters.Add(new SqlParameter("@sigla", areaTematica.Sigla));
            cmdAreas.Parameters.Add(new SqlParameter("@idGuiaReconocimiento", guia.IdGuiaReconocimiento));

            SqlParameter parametroIdArea = new SqlParameter("@idAreaTematica", System.Data.SqlDbType.Int);
            parametroIdArea.Direction = System.Data.ParameterDirection.Output;

            cmdAreas.Parameters.Add(parametroIdArea);

            //Comando para insertar criterios
            SqlCommand cmdCriterios = new SqlCommand();
            cmdCriterios.CommandText = "insertar_criterio";
            cmdCriterios.CommandType = System.Data.CommandType.StoredProcedure;

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
                cmdAreas.Connection = connection;
                cmdAreas.Transaction = transaction;

                cmdAreas.ExecuteNonQuery();
                areaTematica.IdAreaTematica = Int32.Parse(cmdAreas.Parameters["@idAreaTematica"].Value.ToString());

                LinkedList<Criterio> criterios = areaTematica.Criterios;
                foreach (Criterio criterioActual in criterios)
                {
                    cmdCriterios.Parameters.Add(new SqlParameter("@descripcion", criterioActual.Descripcion));
                    cmdCriterios.Parameters.Add(new SqlParameter("@idAreaTematica", areaTematica.IdAreaTematica));
                    SqlParameter parametroIdCriterio = new SqlParameter("@idCriterio", System.Data.SqlDbType.Int);
                    parametroIdCriterio.Direction = System.Data.ParameterDirection.Output;
                    cmdCriterios.Parameters.Add(parametroIdCriterio);

                    cmdCriterios.ExecuteNonQuery();
                    criterioActual.IdCriterio= Int32.Parse(cmdCriterios.Parameters["@idCriterio"].Value.ToString());

                    LinkedList<SubCriterio> subCriterios = criterioActual.SubCriterios;
                    foreach (SubCriterio subCriterioActual in subCriterios)
                    {
                        cmdSubCriterios.Parameters.Add(new SqlParameter("@descripcion", subCriterioActual.Descripcion));
                        cmdSubCriterios.Parameters.Add(new SqlParameter("@idCriterio", criterioActual.IdCriterio));
                        SqlParameter parametroIdSubCriterio = new SqlParameter("@idSubCriterio", System.Data.SqlDbType.Int);
                        parametroIdSubCriterio.Direction = System.Data.ParameterDirection.Output;
                        cmdSubCriterios.Parameters.Add(parametroIdSubCriterio);

                        cmdSubCriterios.ExecuteNonQuery();
                        subCriterioActual.IdSubCriterio = Int32.Parse(cmdSubCriterios.Parameters["@idSubCriterio"].Value.ToString());
                        cmdSubCriterios.Parameters.Clear();
                    }

                    cmdCriterios.Parameters.Clear();
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

            return areaTematica;
        }
    }
}
