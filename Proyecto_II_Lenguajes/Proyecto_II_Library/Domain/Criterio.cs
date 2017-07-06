using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_II_Library.Domain
{
    public class Criterio
    {
        private int idCriterio;
        private String descripcion;
        private LinkedList<SubCriterio> subCriterios;

        public int IdCriterio
        {
            get
            {
                return idCriterio;
            }

            set
            {
                idCriterio = value;
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

        public LinkedList<SubCriterio> SubCriterios
        {
            get
            {
                return subCriterios;
            }

            set
            {
                subCriterios = value;
            }
        }

        public Criterio()
        {
            this.subCriterios = new LinkedList<SubCriterio>();
        }

        public Criterio(int idCriterio, string descripcion)
        {
            this.idCriterio = idCriterio;
            this.descripcion = descripcion;
            this.subCriterios = new LinkedList<SubCriterio>();
        }

     
    }
}
