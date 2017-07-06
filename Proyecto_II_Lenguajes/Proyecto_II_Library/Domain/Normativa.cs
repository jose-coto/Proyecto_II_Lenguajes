using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_II_Library.Domain
{
    public class Normativa:Evidencia
    {
        private String detalle;
        private String normativaAdjunta;

        public Normativa()
        {
        }

        public Normativa(string detalle, string normativaAdjunta)
        {
            this.detalle = detalle;
            this.normativaAdjunta = normativaAdjunta;
        }

        public string Detalle
        {
            get
            {
                return detalle;
            }

            set
            {
                detalle = value;
            }
        }

        public string NormativaAdjunta
        {
            get
            {
                return normativaAdjunta;
            }

            set
            {
                normativaAdjunta = value;
            }
        }
    }
}
