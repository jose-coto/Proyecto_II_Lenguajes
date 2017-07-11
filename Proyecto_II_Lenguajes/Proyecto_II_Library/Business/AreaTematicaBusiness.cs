using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Proyecto_II_Library.DataAccess;
using Proyecto_II_Library.Domain;

namespace Proyecto_II_Library.Business
{
    public class AreaTematicaBusiness
    {
        private AreaTematicaData areaTematicaData;

        public AreaTematicaBusiness(String connectionString)
        {
            this.areaTematicaData = new AreaTematicaData(connectionString);
        }

        public LinkedList<AreaTematica> getAllAreaTematicas()
        {
            return areaTematicaData.getAllAreaTematicas();
        }

        public LinkedList<AreaTematica> getAllAreaTematicasByGuide(int idGuiaReconocimiento)
        {
            return areaTematicaData.getAllAreaTematicasByGuide(idGuiaReconocimiento);
        }

        public AreaTematica findAreaTematicaByCode(int idAreaTematica)
        {
            return areaTematicaData.findAreaTematicaByCode(idAreaTematica);
        }

        public AreaTematica insertar(AreaTematica areaTematica, GuiaReconocimiento guia)
        {
            return areaTematicaData.insertar(areaTematica, guia);
        }

        public LinkedList<AreaTematica> getAllAreaTematicasByEncargado(int idEncargado)
        {
            return areaTematicaData.getAllAreaTematicasByEncargado(idEncargado);
        }

    }
}
