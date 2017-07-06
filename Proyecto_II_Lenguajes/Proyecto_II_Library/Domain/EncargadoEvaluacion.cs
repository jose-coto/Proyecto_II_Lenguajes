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
        private Evaluacion evaluacion;
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

        public Evaluacion Evaluacion
        {
            get
            {
                return evaluacion;
            }

            set
            {
                evaluacion = value;
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

        public EncargadoEvaluacion()
        {
            this.funcionario = new Funcionario();
            this.evaluacion = new Evaluacion();
            this.encargadoAreaTematica = new AreaTematica();
        }
       
    }
}
