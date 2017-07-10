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
    public class TipoParticipanteData
    {
        private String connectionString;

        public TipoParticipanteData(String connectionString)
        {
            this.connectionString = connectionString;
        }

        public LinkedList<TipoParticipante> getAllTipoDeParticipantes()
        {
            String sqlSelect = "SELECT tp.id_tipo_participante,tp.descripcion" +
                " FROM TipoParticipante tp";

            SqlConnection connection = new SqlConnection(this.connectionString);
            DataSet dsTipoParticipante = new DataSet();
            SqlDataAdapter daTipoParticipante = new SqlDataAdapter();
            daTipoParticipante.SelectCommand = new SqlCommand(sqlSelect, connection);
            daTipoParticipante.Fill(dsTipoParticipante, "TipoParticipante");

            DataRowCollection rows = dsTipoParticipante.Tables["TipoParticipante"].Rows;

            LinkedList<TipoParticipante> tipoParticipantes = new LinkedList<TipoParticipante>();

            foreach (DataRow row in rows)
            {
                TipoParticipante tipoParticipante = new TipoParticipante(Int32.Parse(row["id_tipo_participante"].ToString()), row["descripcion"].ToString());
                tipoParticipantes.AddLast(tipoParticipante);
            }

            return tipoParticipantes;
        }
    }
}
