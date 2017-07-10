using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proyecto_II_Library.DataAccess;
using Proyecto_II_Library.Domain;

namespace Proyecto_II_Library.Business
{
    public class TipoParticipanteBusiness
    {
        private TipoParticipanteData tipoParticipanteData;

        public TipoParticipanteBusiness(String connectionString)
        {
            this.tipoParticipanteData = new TipoParticipanteData(connectionString);
        }

        public LinkedList<TipoParticipante> ggetAllTipoDeParticipantes()
        {
            return tipoParticipanteData.getAllTipoDeParticipantes();
        }
    }
}
