﻿using System;
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
        private int idEvidencia;
        private LinkedList<TipoParticipante> tipoParticipantes;
        private LinkedList<Imagen> imagenes;

        public LinkedList<TipoParticipante> TipoParticipantes
        {
            get
            {
                return tipoParticipantes;
            }
            set
            {
                tipoParticipantes = value;
            }
        }

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

        public int IdEvidencia
        {
            get
            {
                return idEvidencia;
            }

            set
            {
                idEvidencia = value;
            }
        }

        public Actividad()
        {
            this.imagenes = new LinkedList<Imagen>();
            this.tipoParticipantes = new LinkedList<TipoParticipante>();
        }

        public Actividad(int cantidadParticipantes, DateTime fecha, string descripcion, int idEvidencia, LinkedList<TipoParticipante> tipoParticipantes, LinkedList<Imagen> imagenes)
        {
            this.cantidadParticipantes = cantidadParticipantes;
            this.fecha = fecha;
            this.descripcion = descripcion;
            this.idEvidencia = idEvidencia;
            this.tipoParticipantes = tipoParticipantes;
            this.imagenes = imagenes;
        }
    }
}
