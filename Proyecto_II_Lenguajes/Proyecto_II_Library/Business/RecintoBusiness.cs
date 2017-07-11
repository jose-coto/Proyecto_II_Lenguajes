using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proyecto_II_Library.DataAccess;
using Proyecto_II_Library.Domain;

namespace Proyecto_II_Library.Business
{
    public class RecintoBusiness
    {
        private RecintoData recintoData;

        public RecintoBusiness(String connectionString)
        {
            this.recintoData = new RecintoData(connectionString);
        }

        public LinkedList<Recinto> getAllRecintos()
        {
            return recintoData.getAllRecintos();
        }
    }
}
