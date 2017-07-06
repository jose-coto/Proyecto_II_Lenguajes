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

        public int IdAreaTematica { get => idAreaTematica; set => idAreaTematica = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Sigla { get => sigla; set => sigla = value; }
        public LinkedList<Criterio> Criterios { get => criterios; set => criterios = value; }
    }
}
