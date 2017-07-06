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

        public AreaTematicaData(string connectionString)
        {
            this.connectionString = connectionString;
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

                areasTematicas.AddLast(area);
            }

            return areasTematicas;
        }
    }
}
