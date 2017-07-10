using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proyecto_II_Library.DataAccess;
using Proyecto_II_Library.Domain;

namespace Proyecto_II_Library.Business
{
    public class TipoDocumentoBusiness
    {
        private TipoDocumentoData tipoDocumentoData;

        public TipoDocumentoBusiness(String connectionString)
        {
            this.tipoDocumentoData = new TipoDocumentoData(connectionString);
        }

        public LinkedList<TipoDocumento> getAllTipoDeDocumento()
        {
            return tipoDocumentoData.getAllTipoDeDocumento();
        }
    }
}
