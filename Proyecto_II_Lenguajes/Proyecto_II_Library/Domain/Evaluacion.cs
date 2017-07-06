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
        private LinkedList<EncargadoEvaluacion> evaluadores;

        public int IdEvaluacion
        {
            get
            {
                return idEvaluacion;
            }

            set
            {
                idEvaluacion = value;
            }
        }

        public DateTime FechaInicioEvaluacion
        {
            get
            {
                return fechaInicioEvaluacion;
            }

            set
            {
                fechaInicioEvaluacion = value;
            }
        }

        public DateTime FechaFinalEvaluacion
        {
            get
            {
                return fechaFinalEvaluacion;
            }

            set
            {
                fechaFinalEvaluacion = value;
            }
        }

        public Recinto Recinto
        {
            get
            {
                return recinto;
            }

            set
            {
                recinto = value;
            }
        }

        public LinkedList<Evidencia> Evidencias
        {
            get
            {
                return evidencias;
            }

            set
            {
                evidencias = value;
            }
        }

        public GuiaReconocimiento GuiaReconocimiento
        {
            get
            {
                return guiaReconocimiento;
            }

            set
            {
                guiaReconocimiento = value;
            }
        }

        public Evaluacion()
        {
            this.recinto = new Recinto();
            this.evidencias = new LinkedList<Evidencia>();
            this.guiaReconocimiento = new GuiaReconocimiento();
            this.evaluadores = new LinkedList<EncargadoEvaluacion>();
        }

        public Evaluacion(int idEvaluacion, DateTime fechaInicioEvaluacion, DateTime fechaFinalEvaluacion)
        {
            this.idEvaluacion = idEvaluacion;
            this.fechaInicioEvaluacion = fechaInicioEvaluacion;
            this.fechaFinalEvaluacion = fechaFinalEvaluacion;
            this.recinto = new Recinto();
            this.evidencias = new LinkedList<Evidencia>();
            this.guiaReconocimiento = new GuiaReconocimiento();
            this.evaluadores = new LinkedList<EncargadoEvaluacion>();

        }


    }
}
