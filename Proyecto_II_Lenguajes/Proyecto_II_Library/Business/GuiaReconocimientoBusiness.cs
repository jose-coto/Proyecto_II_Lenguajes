using Proyecto_II_Library.DataAccess;
using Proyecto_II_Library.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_II_Library.Business
{
    public class GuiaReconocimientoBusiness
    {
        private GuiaReconocimientoData guiaReconocimientoData;

        public GuiaReconocimientoBusiness(String connectionString)
        {
            guiaReconocimientoData = new GuiaReconocimientoData(connectionString);
        }

        public GuiaReconocimiento findGuideById(int idGuia)
        {
            return guiaReconocimientoData.findGuideById(idGuia);
        }

        public LinkedList<GuiaReconocimiento> findGuides()
        {
            return guiaReconocimientoData.findGuides();
        }

        public GuiaReconocimiento insertGuide(GuiaReconocimiento guiaReconocimiento)
        {
            return guiaReconocimientoData.insertGuide(guiaReconocimiento);
        }
    }
}
