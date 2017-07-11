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

        public Evidencia insertar(Evidencia evidencia, Evaluacion evaluacion)
        {
            return evidenciaData.insertar(evidencia, evaluacion);
        }

        public void insertarActividad(Actividad actividad)
        {
            evidenciaData.insertarActividad(actividad);
        }

        public Imagen ShowTheFile(int FileID)
        {
            return evidenciaData.ShowTheFile(FileID);
        }

        }
}
