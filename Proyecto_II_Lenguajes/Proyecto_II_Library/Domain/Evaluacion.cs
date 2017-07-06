using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_II_Library.Domain
{
    public class Evaluacion
    {
        private int idEvaluacion;
        private DateTime fechaInicioEvaluacion;
        private DateTime fechaFinalEvaluacion;
        private Recinto recinto;
        private LinkedList<Evidencia> evidencias;
        private GuiaReconocimiento guiaReconocimiento;

        public Evaluacion()
        {
            this.recinto = new Recinto();
            this.evidencias = new LinkedList<Evidencia>();
            this.guiaReconocimiento = new GuiaReconocimiento();
        }

        public Evaluacion(int idEvaluacion, DateTime fechaInicioEvaluacion, DateTime fechaFinalEvaluacion)
        {
            this.idEvaluacion = idEvaluacion;
            this.fechaInicioEvaluacion = fechaInicioEvaluacion;
            this.fechaFinalEvaluacion = fechaFinalEvaluacion;
            this.recinto = new Recinto();
            this.evidencias = new LinkedList<Evidencia>();
            this.guiaReconocimiento = new GuiaReconocimiento();
        }

        public int IdEvaluacion { get => idEvaluacion; set => idEvaluacion = value; }
        public DateTime FechaInicioEvaluacion { get => fechaInicioEvaluacion; set => fechaInicioEvaluacion = value; }
        public DateTime FechaFinalEvaluacion { get => fechaFinalEvaluacion; set => fechaFinalEvaluacion = value; }
        public Recinto Recinto { get => recinto; set => recinto = value; }
        public LinkedList<Evidencia> Evidencias { get => evidencias; set => evidencias = value; }
        internal GuiaReconocimiento GuiaReconocimiento { get => guiaReconocimiento; set => guiaReconocimiento = value; }
    }
}
