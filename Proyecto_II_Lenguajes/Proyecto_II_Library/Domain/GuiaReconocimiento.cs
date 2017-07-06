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
        private LinkedList<AreaTematica> areasTematicas;

        public int IdGuiaReconocimiento
        {
            get
            {
                return idGuiaReconocimiento;
            }

            set
            {
                idGuiaReconocimiento = value;
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

        public DateTime AnnoPublicacion
        {
            get
            {
                return annoPublicacion;
            }

            set
            {
                annoPublicacion = value;
            }
        }

        public bool Vigente
        {
            get
            {
                return vigente;
            }

            set
            {
                vigente = value;
            }
        }

        public LinkedList<AreaTematica> AreasTematica
        {
            get
            {
                return areasTematicas;
            }

            set
            {
                areasTematicas = value;
            }
        }

        public GuiaReconocimiento()
        {
            this.areasTematicas = new LinkedList<AreaTematica>();
        }

        public GuiaReconocimiento(int idGuiaReconocimiento, string nombre, DateTime annoPublicacion, bool vigente)
        {
            this.idGuiaReconocimiento = idGuiaReconocimiento;
            this.nombre = nombre;
            this.annoPublicacion = annoPublicacion;
            this.vigente = vigente;
            this.areasTematicas = new LinkedList<AreaTematica>();
        }

        
    }
}
