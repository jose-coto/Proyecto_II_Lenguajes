using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_II_Library.Domain
{
    public class Funcionario
    {
        private int idFuncionario;
        private String nombreFuncionario;
        private String apellidosFuncionario;
        private String userName;
        private String password;
        private Boolean enable;
        private Role role;

        public Role Role
        {
            get
            {
                return role;
            }
            set
            {
                role = value;
            }
        }

        public int IdFuncionario
        {
            get
            {
                return idFuncionario;
            }

            set
            {
                idFuncionario = value;
            }
        }

        public string NombreFuncionario
        {
            get
            {
                return nombreFuncionario;
            }

            set
            {
                nombreFuncionario = value;
            }
        }

        public string ApellidosFuncionario
        {
            get
            {
                return apellidosFuncionario;
            }

            set
            {
                apellidosFuncionario = value;
            }
        }

        public string UserName
        {
            get
            {
                return userName;
            }

            set
            {
                userName = value;
            }
        }

        public string Password
        {
            get
            {
                return password;
            }

            set
            {
                password = value;
            }
        }

        public bool Enable
        {
            get
            {
                return enable;
            }

            set
            {
                enable = value;
            }
        }

        public Funcionario()
        {
            this.role = new Role();
        }

        public Funcionario(int idFuncionario, string nombreFuncionario, string apellidosFuncionario, string userName, string password, bool enable)
        {
            this.idFuncionario = idFuncionario;
            this.nombreFuncionario = nombreFuncionario;
            this.apellidosFuncionario = apellidosFuncionario;
            this.userName = userName;
            this.password = password;
            this.enable = enable;
            this.role = new Role();
        }


    }
}
