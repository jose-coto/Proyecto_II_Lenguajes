using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_II_Library.Domain
{
    public class SubCriterio
    {
        private int idSubCriterio;
        private String descripcion;

        public SubCriterio()
        {
        }

        public SubCriterio(int idSubCriterio, string descripcion)
        {
            this.idSubCriterio = idSubCriterio;
            this.descripcion = descripcion;
        }

        public int IdSubCriterio { get => idSubCriterio; set => idSubCriterio = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
    }
}
