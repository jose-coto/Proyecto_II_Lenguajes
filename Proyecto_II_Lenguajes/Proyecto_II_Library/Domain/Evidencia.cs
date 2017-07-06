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
     
        private SubCriterio subCriterio;

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

        public int IdEvidencia { get => idEvidencia; set => idEvidencia = value; }
        public string Titulo { get => titulo; set => titulo = value; }
        public DateTime FechaIngreso { get => fechaIngreso; set => fechaIngreso = value; }
        public SubCriterio SubCriterio { get => subCriterio; set => subCriterio = value; }
        public char Tipo { get => tipo; set => tipo = value; }
    }
}
