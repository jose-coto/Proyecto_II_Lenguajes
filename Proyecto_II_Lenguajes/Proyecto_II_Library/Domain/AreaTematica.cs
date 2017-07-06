using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_II_Library.Domain
{
    public class AreaTematica
    {
        private int idAreaTematica;
        private String nombre;
        private String sigla;
        private LinkedList<Criterio> criterios;

        public int IdAreaTematica
        {
            get
            {
                return idAreaTematica;
            }

            set
            {
                idAreaTematica = value;
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

        public string Sigla
        {
            get
            {
                return sigla;
            }

            set
            {
                sigla = value;
            }
        }

        public LinkedList<Criterio> Criterios
        {
            get
            {
                return criterios;
            }

            set
            {
                criterios = value;
            }
        }

        public AreaTematica()
        {
            this.criterios = new LinkedList<Criterio>();
        }

        public AreaTematica(int idAreaTematica, string nombre, string sigla)
        {
            this.idAreaTematica = idAreaTematica;
            this.nombre = nombre;
            this.sigla = sigla;
            this.criterios = new LinkedList<Criterio>();
        }

    }
}
