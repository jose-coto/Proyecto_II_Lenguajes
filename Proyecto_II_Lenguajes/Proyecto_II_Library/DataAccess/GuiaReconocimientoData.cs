using Proyecto_II_Library.Business;
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
    public class GuiaReconocimientoData
    {
        String connectionString;
        AreaTematicaBusiness areaTematicaBusiness;

        public GuiaReconocimientoData(String connectionString)
        {
            this.connectionString = connectionString;
            this.areaTematicaBusiness = new AreaTematicaBusiness(connectionString);
        }

        public GuiaReconocimiento findGuideById(int idGuia)
        {
            String selectSql = "SELECT g.id_guia_reconocimiento,g.nombre_guia_reconocimiento," +
                "g.anno_publicacion,g.vigente FROM GuiaDeReconocimiento g where g.id_guia_reconocimiento = "+idGuia;

            SqlConnection sqlConnection = new SqlConnection(this.connectionString);
            DataSet dsGuides = new DataSet();
            SqlDataAdapter daGuides = new SqlDataAdapter();
            daGuides.SelectCommand = new SqlCommand(selectSql, sqlConnection);
            daGuides.Fill(dsGuides, "GuiaDeReconocimiento");

            DataRowCollection rows = dsGuides.Tables["GuiaDeReconocimiento"].Rows;
            GuiaReconocimiento guiaReconocimiento = new GuiaReconocimiento();

            foreach (DataRow row in rows)
            {
                guiaReconocimiento.IdGuiaReconocimiento = Int32.Parse(row["id_guia_reconocimiento"].ToString());
                guiaReconocimiento.Nombre = row["nombre_guia_reconocimiento"].ToString();
                guiaReconocimiento.AnnoPublicacion = DateTime.Parse(row["anno_publicacion"].ToString());
                guiaReconocimiento.Vigente = Boolean.Parse(row["vigente"].ToString());
                guiaReconocimiento.AreasTematicas = areaTematicaBusiness.getAllAreaTematicasByGuide(guiaReconocimiento.IdGuiaReconocimiento);
            }
            return guiaReconocimiento;
        }

        public LinkedList<GuiaReconocimiento> findGuides()
        {
            String selectSql = "SELECT g.id_guia_reconocimiento,g.nombre_guia_reconocimiento," +
                "g.anno_publicacion,g.vigente FROM GuiaDeReconocimiento g ";

            SqlConnection sqlConnection = new SqlConnection(this.connectionString);
            DataSet dsGuides = new DataSet();
            SqlDataAdapter daGuides = new SqlDataAdapter();
            daGuides.SelectCommand = new SqlCommand(selectSql, sqlConnection);
            daGuides.Fill(dsGuides, "GuiaDeReconocimiento");

            DataRowCollection rows = dsGuides.Tables["GuiaDeReconocimiento"].Rows;

            LinkedList<GuiaReconocimiento> guiasDeReconocimiento = new LinkedList<GuiaReconocimiento>();

            foreach (DataRow row in rows)
            {
                GuiaReconocimiento guiaReconocimiento = new GuiaReconocimiento();

                guiaReconocimiento.IdGuiaReconocimiento = Int32.Parse(row["id_guia_reconocimiento"].ToString());
                guiaReconocimiento.Nombre = row["nombre_guia_reconocimiento"].ToString();
                guiaReconocimiento.AnnoPublicacion = DateTime.Parse(row["anno_publicacion"].ToString());
                guiaReconocimiento.Vigente = Boolean.Parse(row["vigente"].ToString());
                guiaReconocimiento.AreasTematicas = areaTematicaBusiness.getAllAreaTematicasByGuide(guiaReconocimiento.IdGuiaReconocimiento);

                guiasDeReconocimiento.AddLast(guiaReconocimiento);
            }
            
            return guiasDeReconocimiento;
        }

        public GuiaReconocimiento insertGuide(GuiaReconocimiento guiaReconocimiento)
        {
            SqlCommand cmdGuide = new SqlCommand();
            cmdGuide.CommandText = "insertar_guia_reconocimiento";
            cmdGuide.CommandType = System.Data.CommandType.StoredProcedure;
            cmdGuide.Parameters.Add(new SqlParameter("@nombreGuiaReconocimiento", guiaReconocimiento.Nombre));
            cmdGuide.Parameters.Add(new SqlParameter("@annoPublicacion", guiaReconocimiento.AnnoPublicacion));
            cmdGuide.Parameters.Add(new SqlParameter("@vigente", guiaReconocimiento.Vigente));

            SqlParameter parIdGuide = new SqlParameter("@idGuiaReconocimiento", System.Data.SqlDbType.Int);
            parIdGuide.Direction = System.Data.ParameterDirection.Output;
            cmdGuide.Parameters.Add(parIdGuide);

            SqlConnection connection = new SqlConnection(connectionString);
            SqlTransaction transaction = null;

            try
            {
                connection.Open();
                transaction = connection.BeginTransaction();
                cmdGuide.Connection = connection;
                cmdGuide.Transaction = transaction;

                cmdGuide.ExecuteNonQuery();

                guiaReconocimiento.IdGuiaReconocimiento = Int32.Parse(cmdGuide.Parameters["@idGuiaReconocimiento"].Value.ToString());

                //Inserta las areas temáticas de la guia
                foreach (AreaTematica areaTematicaActual in guiaReconocimiento.AreasTematicas)
                {
                    areaTematicaBusiness.insertar(areaTematicaActual, guiaReconocimiento);
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

            return guiaReconocimiento;
        }
    }
}
