using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_II_Library.Domain
{
    public class EncargadoEvaluacion
    {
        private Funcionario funcionario;
        private LinkedList<Evaluacion> evaluaciones;
        private AreaTematica encargadoAreaTematica;

        public Funcionario Funcionario
        {
            get
            {
                return funcionario;
            }

            set
            {
                funcionario = value;
            }
        }


        public AreaTematica EncargadoAreaTematica
        {
            get
            {
                return encargadoAreaTematica;
            }

            set
            {
                encargadoAreaTematica = value;
            }
        }

        public LinkedList<Evaluacion> Evaluaciones
        {
            get
            {
                return evaluaciones;
            }


            set
            {
                evaluaciones = value;
            }
        }

        public EncargadoEvaluacion()
        {
            this.funcionario = new Funcionario();
            this.evaluaciones = new LinkedList<Evaluacion>();
            this.encargadoAreaTematica = new AreaTematica();
        }
       
    }
}
