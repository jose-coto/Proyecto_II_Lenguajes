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

        public TipoDocumento()
        {
        }

        public TipoDocumento(int idTipoDocumento, string descripcion)
        {
            this.idTipoDocumento = idTipoDocumento;
            this.descripcion = descripcion;
        }

        public int IdTipoDocumento { get => idTipoDocumento; set => idTipoDocumento = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
    }
}
