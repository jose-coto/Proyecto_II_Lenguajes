using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_II_Library.Domain
{
    public class Documento:Evidencia
    {
        private String detalle;
        private String fuente;
        private DateTime fecha;
        private TipoDocumento tipoDocumento;

        public Documento()
        {
            this.tipoDocumento = new TipoDocumento();
        }

        public Documento(string detalle, string fuente, DateTime fecha)
        {
            this.detalle = detalle;
            this.fuente = fuente;
            this.fecha = fecha;
            this.tipoDocumento = new TipoDocumento();
        }

        public string Detalle { get => detalle; set => detalle = value; }
        public string Fuente { get => fuente; set => fuente = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public TipoDocumento TipoDocumento { get => tipoDocumento; set => tipoDocumento = value; }
    }
}
