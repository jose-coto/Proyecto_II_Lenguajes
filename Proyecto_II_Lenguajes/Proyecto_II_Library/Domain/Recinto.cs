using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_II_Library.Domain
{
    public class Recinto
    {
        private int idRecinto;
        private String nombreRecinto;

        public Recinto()
        {

        }

        public Recinto(int idRecinto, string nombreRecinto)
        {
            this.idRecinto = idRecinto;
            this.nombreRecinto = nombreRecinto;
        }

        public int IdRecinto { get => idRecinto; set => idRecinto = value; }
        public string NombreRecinto { get => nombreRecinto; set => nombreRecinto = value; }
    }
}
