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

        public int CantidadParticipantes { get => cantidadParticipantes; set => cantidadParticipantes = value; }
        public DateTime Fecha { get => fecha; set => fecha = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public LinkedList<Imagen> Imagenes { get => imagenes; set => imagenes = value; }
    }
}
