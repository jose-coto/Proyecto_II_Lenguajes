using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proyecto_II_Library.DataAccess;
using Proyecto_II_Library.Domain;

namespace Proyecto_II_Library.Business
{
    public class FuncionarioBusiness
    {
        private FuncionarioData funcionarioData;

        public FuncionarioBusiness(String connectionString)
        {
            this.funcionarioData = new FuncionarioData(connectionString);
        }

        public Funcionario getFuncionarioByUserName(String userName)
        {
            return funcionarioData.getFuncionarioByUserName(userName);
        }

        public Funcionario BuscarFuncionarioId(int id)
        {
            return funcionarioData.BuscarFuncionarioId(id);
        }

        public Funcionario insertarFuncionario(Funcionario funcionario)
        {
            return funcionarioData.insertarFuncionario(funcionario);
        }

        public LinkedList<Funcionario> GetFuncionarios()
        {
            return funcionarioData.GetFuncionarios();
        }
    }
}
