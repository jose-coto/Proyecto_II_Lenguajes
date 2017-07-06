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

        public EncargadoEvaluacion()
        {
            this.funcionario = new Funcionario();
            this.evaluacion = new Evaluacion();
            this.encargadoAreaTematica = new AreaTematica();
        }
        public Funcionario Funcionario { get => funcionario; set => funcionario = value; }
        public Evaluacion Evaluacion { get => evaluacion; set => evaluacion = value; }
        public AreaTematica EncargadoAreaTematica { get => encargadoAreaTematica; set => encargadoAreaTematica = value; }
    }
}
