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
    public class RecintoData
    {
        private String connectionString;

        public RecintoData(String connectionString)
        {
            this.connectionString = connectionString;
        }

        public LinkedList<Recinto> getAllRecintos()
        {
            String sqlSelect = "SELECT id_recinto,nombre_recinto" +
                " FROM Recinto r";

            SqlConnection connection = new SqlConnection(this.connectionString);
            DataSet dsRecinto = new DataSet();
            SqlDataAdapter daRecinto = new SqlDataAdapter();
            daRecinto.SelectCommand = new SqlCommand(sqlSelect, connection);
            daRecinto.Fill(dsRecinto, "Recinto");

            DataRowCollection rows = dsRecinto.Tables["Recinto"].Rows;

            LinkedList<Recinto> recintos = new LinkedList<Recinto>();

            foreach (DataRow row in rows)
            {
                Recinto r = new Recinto(Int32.Parse(row["id_recinto"].ToString()), row["nombre_recinto"].ToString());
                recintos.AddLast(r);
            }

            return recintos;
        }
    }
}
