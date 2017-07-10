using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proyecto_II_Library.DataAccess;
using Proyecto_II_Library.Domain;

namespace Proyecto_II_Library.Business
{
    public class SubCriterioBusiness
    {
        private SubCriterioData subCriterioData;

        public SubCriterioBusiness(String connectionString)
        {
            this.subCriterioData = new SubCriterioData(connectionString);
        }

        public LinkedList<SubCriterio> getAllSubCriteriosByCriterio(int idCriterio)
        {
            return subCriterioData.getAllSubCriteriosByCriterio(idCriterio);
        }

        public SubCriterio getSubCriteriosByCode(int idSubCriterio)
        {
            return subCriterioData.getSubCriterioByCode(idSubCriterio);
        }

        public SubCriterio insertar(SubCriterio subCriterio, Criterio criterio)
        {
            return subCriterioData.insertar(subCriterio, criterio);
        }
    }
}
