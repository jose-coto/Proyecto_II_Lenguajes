using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proyecto_II_Library.DataAccess;
using Proyecto_II_Library.Domain;

namespace Proyecto_II_Library.Business
{
    public class CriterioBusiness
    {
        private CriterioData criterioData;

        public CriterioBusiness(String connectionString)
        {
            this.criterioData = new CriterioData(connectionString);
        }

        public LinkedList<Criterio> findAllCriteriosByAreaTematica(int idAreaTematica)
        {
            return criterioData.findAllCriteriosByAreaTematica(idAreaTematica);
        }

        public Criterio findCriterioByCode(int idCriterio)
        {
            return criterioData.findCriterioByCode(idCriterio);
        }

        public Criterio insertar(Criterio criterio, AreaTematica areaTematica)
        {
            return criterioData.insertar(criterio, areaTematica);
        }
    }
}
