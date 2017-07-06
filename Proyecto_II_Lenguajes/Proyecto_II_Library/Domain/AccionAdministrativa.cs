using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_II_Library.Domain
{
    public class AccionAdministrativa : Evidencia //: funciona como el extends
    {
        private String detalle;
        private String informeTecnico;

        public AccionAdministrativa()
        {
        }

        public AccionAdministrativa(string detalle, string informeTecnico)
        {
            this.detalle = detalle;
            this.informeTecnico = informeTecnico;
        }

        public string Detalle { get => detalle; set => detalle = value; }
        public string InformeTecnico { get => informeTecnico; set => informeTecnico = value; }
    }
}
