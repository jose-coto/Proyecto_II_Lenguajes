
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_II_Library.Domain
{
    public class Evidencia
    {
        private int idEvidencia;
        private String titulo;
        private DateTime fechaIngreso;
        private Char tipo;
        private SubCriterio subCriterio;

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

        public string Titulo
        {
            get
            {
                return titulo;
            }

            set
            {
                titulo = value;
            }
        }

        public DateTime FechaIngreso
        {
            get
            {
                return fechaIngreso;
            }

            set
            {
                fechaIngreso = value;
            }
        }

        public char Tipo
        {
            get
            {
                return tipo;
            }

            set
            {
                tipo = value;
            }
        }

        public SubCriterio SubCriterio
        {
            get
            {
                return subCriterio;
            }

            set
            {
                subCriterio = value;
            }
        }

        public Evidencia()
        {
            this.subCriterio = new SubCriterio();
        }

        public Evidencia(int idEvidencia, string titulo, DateTime fechaIngreso,char tipo)
        {
            this.idEvidencia = idEvidencia;
            this.titulo = titulo;
            this.fechaIngreso = fechaIngreso;
            this.tipo = tipo;
            this.subCriterio = new SubCriterio();
        }

    }
}
