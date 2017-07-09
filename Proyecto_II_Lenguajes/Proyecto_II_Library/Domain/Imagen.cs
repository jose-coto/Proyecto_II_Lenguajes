using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_II_Library.Domain
{
    public class Imagen
    {
        private int idImagen;
        private string nombre;
        private int size;
        private string contentType;
        private byte[] data;

        public int IdImagen
        {
            get
            {
                return idImagen;
            }

            set
            {
                idImagen = value;
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

        public Imagen()
        {

        }

        public Imagen(int idImagen, string nombre, int size, string contentType, byte[] data)
        {
            this.idImagen = idImagen;
            this.nombre = nombre;
            this.size = size;
            this.contentType = contentType;
            this.data = data;
        }
    }
}
