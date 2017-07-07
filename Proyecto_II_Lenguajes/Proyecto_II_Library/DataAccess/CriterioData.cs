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

    }
}
