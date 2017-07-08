using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proyecto_II_Library.DataAccess;
using Proyecto_II_Library.Domain;

namespace Proyecto_II_Library.Business
{
    public class EvidenciaBusiness
    {
        private EvidenciaData evidenciaData;

        public EvidenciaBusiness(String connectionString)
        {
            this.evidenciaData = new EvidenciaData(connectionString);
        }

        public Evidencia getEvidenciasBySubCriterio(int idSubCriterio)
        {
            return evidenciaData.getEvidenciaBySubCriterio(idSubCriterio);
        }

        public Evidencia insertar(Evidencia evidencia, Evaluacion evaluacion, AccionAdministrativa accion,
                                  Normativa normativa, Documento documento, Actividad actividad)
        {
            evidenciaData.insertar(evidencia, evaluacion, accion, normativa, documento, actividad);
        }
    }
}
