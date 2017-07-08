using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proyecto_II_Library.DataAccess;
using Proyecto_II_Library.Domain;

namespace Proyecto_II_Library.Business
{
    public class AccionAdministrativaBusiness
    {
        private AccionAdministrativaData accionAdministrativaData;

        public AccionAdministrativaBusiness(String connectionString)
        {
            this.accionAdministrativaData = new AccionAdministrativaData(connectionString);
        }

        public AccionAdministrativa getAccionAdministrativaByIdEvidencia(int idEvidencia)
        {
            return accionAdministrativaData.getAccionAdministrativaByIdEvidencia(idEvidencia);
        }

        public void insertar(AccionAdministrativa accion)
        {
            accionAdministrativaData.insertar(accion);
        }
    }
}
