using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_II_Library.Domain
{
    public class TipoParticipante
    {
        private int idTipoParticipante;
        private String descripcion;

        public int IdTipoParticipante
        {
            get
            {
                return idTipoParticipante;
            }

            set
            {
                idTipoParticipante = value;
            }
        }

        public string Descripcion
        {
            get
            {
                return descripcion;
            }

            set
            {
                descripcion = value;
            }
        }

        public TipoParticipante()
        {
        }

        public TipoParticipante(int idTipoParticipante, string descripcion)
        {
            this.idTipoParticipante = idTipoParticipante;
            this.descripcion = descripcion;
        }


    }
}
