using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_II_Library.Domain
{
    public class TipoDocumento
    {
        private int idTipoDocumento;
        private String descripcion;

        public int IdTipoDocumento
        {
            get
            {
                return idTipoDocumento;
            }

            set
            {
                idTipoDocumento = value;
            }
        }

        public string Descripcion
        {
            get
            {
                return descripcion;
            }

            set
            {
                descripcion = value;
            }
        }

        public TipoDocumento()
        {
        }

        public TipoDocumento(int idTipoDocumento, string descripcion)
        {
            this.idTipoDocumento = idTipoDocumento;
            this.descripcion = descripcion;
        }


    }
}
