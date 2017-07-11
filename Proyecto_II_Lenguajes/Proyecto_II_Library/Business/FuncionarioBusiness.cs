using Proyecto_II_Library.DataAccess;
using Proyecto_II_Library.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_II_Library.Business
{
    public class FuncionarioBusiness
    {
        private FuncionarioData funcionarioData;

        public FuncionarioBusiness(string connectionString)
        {
            this.funcionarioData = new FuncionarioData(connectionString);
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
