using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using Proyecto_II_Library.Business;
using Proyecto_II_Library.Domain;

namespace Proyecto_II_WebApp
{
    public partial class AdministrarAreasTematicas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String connectionString = WebConfigurationManager.ConnectionStrings["ProyectoII"].ConnectionString;

            String userName = User.Identity.Name;
            FuncionarioBusiness funcionarioBus = new FuncionarioBusiness(connectionString);
            AreaTematicaBusiness areaTematicaBus = new AreaTematicaBusiness(connectionString);

            Funcionario funcionario = funcionarioBus.getFuncionarioByUserName(userName);

            LinkedList<AreaTematica> areasTematicasEncargado = areaTematicaBus.getAllAreaTematicasByEncargado(funcionario.IdFuncionario);
            if (areasTematicasEncargado!=null)
            {
                ddlAreaTematica.Visible = true;
                ddlAreaTematica.DataSource = areasTematicasEncargado;
                ddlAreaTematica.DataTextField = "nombre";
                ddlAreaTematica.DataValueField = "idAreaTematica";
            }
            else
            {
                lblMensajeError.Text = "El funcionario en seccion no posee Areas Tematicas a cargo";
            }
        }
    }
}