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
        //private Image imagen;

        public Imagen()
        {

        }

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
    }
}
