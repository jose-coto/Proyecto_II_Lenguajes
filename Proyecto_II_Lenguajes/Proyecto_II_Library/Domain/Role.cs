using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_II_Library.Domain
{
    public class Role
    {
        private int idRole;
        private String nombreRole;

        public Role()
        {
        }

        public Role(int idRole, string nombreRole)
        {
            this.idRole = idRole;
            this.nombreRole = nombreRole;
        }

        public int IdRole { get => idRole; set => idRole = value; }
        public string NombreRole { get => nombreRole; set => nombreRole = value; }
    }
}
