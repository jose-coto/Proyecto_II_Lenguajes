using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_II_Library.Domain
{
    public class Actividad
    {
        private int cantidadParticipantes;
        private DateTime fecha;
        private String descripcion;
        private LinkedList<Imagen> imagenes;

        public int CantidadParticipantes
        {
            get
            {
                return cantidadParticipantes;
            }

            set
            {
                cantidadParticipantes = value;
            }
        }

        public DateTime Fecha
        {
            get
            {
                return fecha;
            }

            set
            {
                fecha = value;
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

        public LinkedList<Imagen> Imagenes
        {
            get
            {
                return imagenes;
            }

            set
            {
                imagenes = value;
            }
        }

        public Actividad()
        {
            this.imagenes = new LinkedList<Imagen>();
        }

        public Actividad(int cantidadParticipantes, DateTime fecha, string descripcion)
        {
            this.cantidadParticipantes = cantidadParticipantes;
            this.fecha = fecha;
            this.descripcion = descripcion;
            this.imagenes = new LinkedList<Imagen>();
        }


    }
}
