using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_II_Library.Domain
{
    public class DocumetoNormativa
    {
        private int idDocumento;
        private string nombre;
        private int size;
        private string contentType;
        private byte[] data;

        public int IdDocumento
        {
            get
            {
                return idDocumento;
            }

            set
            {
                idDocumento = value;
            }
        }

        public string Nombre
        {
            get
            {
                return nombre;
            }

            set
            {
                nombre = value;
            }
        }

        public int Size
        {
            get
            {
                return size;
            }

            set
            {
                size = value;
            }
        }

        public string ContentType
        {
            get
            {
                return contentType;
            }

            set
            {
                contentType = value;
            }
        }

        public byte[] Data
        {
            get
            {
                return data;
            }

            set
            {
                data = value;
            }
        }

        public DocumetoNormativa(int idDocumento, string nombre, int size, string contentType, byte[] data)
        {
            this.idDocumento = idDocumento;
            this.nombre = nombre;
            this.size = size;
            this.contentType = contentType;
            this.data = data;
        }

        public DocumetoNormativa()
        {

        }
    }
}
