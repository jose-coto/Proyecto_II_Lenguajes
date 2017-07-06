using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_II_Library.Domain
{
    public class GuiaReconocimiento
    {
        private int idGuiaReconocimiento;
        private String nombre;
        private DateTime annoPublicacion;
        private Boolean vigente;
        private LinkedList<AreaTematica> areasTematica;

        public GuiaReconocimiento()
        {
            this.areasTematica = new LinkedList<AreaTematica>();
        }

        public GuiaReconocimiento(int idGuiaReconocimiento, string nombre, DateTime annoPublicacion, bool vigente)
        {
            this.idGuiaReconocimiento = idGuiaReconocimiento;
            this.nombre = nombre;
            this.annoPublicacion = annoPublicacion;
            this.vigente = vigente;
            this.areasTematica = new LinkedList<AreaTematica>();
        }

        public int IdGuiaReconocimiento { get => idGuiaReconocimiento; set => idGuiaReconocimiento = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public DateTime AnnoPublicacion { get => annoPublicacion; set => annoPublicacion = value; }
        public bool Vigente { get => vigente; set => vigente = value; }
        public LinkedList<AreaTematica> AreasTematica { get => areasTematica; set => areasTematica = value; }
    }
}
