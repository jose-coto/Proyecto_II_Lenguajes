using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proyecto_II_Library.DataAccess;
using Proyecto_II_Library.Domain;

namespace Proyecto_II_Library.Business
{
    public class DocumentoBusiness
    {
        private DocumentoData documentoData;

        public DocumentoBusiness(String connectionString)
        {
            this.documentoData = new DocumentoData(connectionString);
        }

        public Documento getDocumentoByIdEvidencia(int idEvidencia)
        {
            return documentoData.getDocumentoByIdEvidencia(idEvidencia);
        }

        public void insertar(Documento documento)
        {
            documentoData.insertar(documento);
        }
    }
}
