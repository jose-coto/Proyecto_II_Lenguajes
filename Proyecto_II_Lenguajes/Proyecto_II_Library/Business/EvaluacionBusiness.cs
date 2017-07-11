using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proyecto_II_Library.DataAccess;
using Proyecto_II_Library.Domain;

namespace Proyecto_II_Library.Business
{
    public class EvaluacionBusiness
    {
        private EvaluacionData evaluacionData;

        public EvaluacionBusiness(String connectionString)
        {
            this.evaluacionData = new EvaluacionData(connectionString);
        }

        public int getEvaluacionByAreaTematicaAndIdFuncionario(int idAreaTematica)
        {
            return evaluacionData.getEvaluacionByAreaTematicaAndIdFuncionario(idAreaTematica);
        }

        public LinkedList<Evaluacion> getEvaluaciones()
        {
            return evaluacionData.getEvaluaciones();
        }

        public void Insertar(Evaluacion evaluacion)
        {
            evaluacionData.Insertar(evaluacion);
        }
    }
}
