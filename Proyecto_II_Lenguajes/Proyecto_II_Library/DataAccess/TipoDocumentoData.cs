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
    public class TipoDocumentoData
    {
        private String connectionString;

        public TipoDocumentoData(String connectionString)
        {
            this.connectionString = connectionString;
        }

        public LinkedList<TipoDocumento> getAllTipoDeDocumento()
        {
            String sqlSelect = "SELECT td.id_tipo_documento,td.descripcion" +
                " FROM TipoDocumento td";

            SqlConnection connection = new SqlConnection(this.connectionString);
            DataSet dsTipoDocumento = new DataSet();
            SqlDataAdapter daTipoDocumento = new SqlDataAdapter();
            daTipoDocumento.SelectCommand = new SqlCommand(sqlSelect, connection);
            daTipoDocumento.Fill(dsTipoDocumento, "TipoDocumento");

            DataRowCollection rows = dsTipoDocumento.Tables["TipoDocumento"].Rows;

            LinkedList<TipoDocumento> tipoDocumentos = new LinkedList<TipoDocumento>();

            foreach (DataRow row in rows)
            {
                TipoDocumento tipoDocumento = new TipoDocumento(Int32.Parse(row["id_tipo_documento"].ToString()), row["descripcion"].ToString());
                tipoDocumentos.AddLast(tipoDocumento);
            }

            return tipoDocumentos;
        }
    }
}
