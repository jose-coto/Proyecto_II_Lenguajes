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
        private String connectionString = WebConfigurationManager.ConnectionStrings["ProyectoII"].ConnectionString;
        private Funcionario funcionario;
        private Evaluacion evaluacion;
        private AreaTematica areaTematica;
        private int codEvaluacion;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                String userName = User.Identity.Name;
                FuncionarioBusiness funcionarioBus = new FuncionarioBusiness(connectionString);
                AreaTematicaBusiness areaTematicaBus = new AreaTematicaBusiness(connectionString);

                funcionario = funcionarioBus.getFuncionarioByUserName(userName);

                LinkedList<AreaTematica> areasTematicasEncargado = areaTematicaBus.getAllAreaTematicasByEncargado(funcionario.IdFuncionario);

                if (areasTematicasEncargado != null)
                {
                    AreaTematica a = new AreaTematica();
                    a.IdAreaTematica = 0;
                    a.Nombre = "";
                    areasTematicasEncargado.AddFirst(a);

                    lblAreaTematica.Visible = true;
                    ddlAreaTematica.Visible = true;
                    ddlAreaTematica.DataSource = areasTematicasEncargado;
                    ddlAreaTematica.DataTextField = "nombre";
                    ddlAreaTematica.DataValueField = "idAreaTematica";
                    ddlAreaTematica.DataBind();
                }
                else
                {
                    lblMensajeError.Text = "El funcionario en seccion no posee Areas Tematicas a su cargo";
                }
            }

        }

        protected void btnInsertarEvidencia_Click(object sender, EventArgs e)
        {
            LinkButton btnInsertarEvidencia = sender as LinkButton;
            int codSubCriterio = Int32.Parse(btnInsertarEvidencia.CommandArgument);

            Response.Redirect("/insertarEvidencia.aspx?idSubCriterio="+codSubCriterio);
        }

        protected void ddlAreaTematica_SelectedIndexChanged(object sender, EventArgs e)
        {

            AreaTematicaBusiness areaBus = new AreaTematicaBusiness(connectionString);
            areaTematica = areaBus.findAreaTematicaByCode(Int32.Parse(ddlAreaTematica.SelectedItem.Value));

            CriterioBusiness criterioBus = new CriterioBusiness(connectionString);
            LinkedList<Criterio> criterios = criterioBus.findAllCriteriosByAreaTematica(Int32.Parse(ddlAreaTematica.SelectedItem.Value));

            if (criterios != null)
            {
                Criterio a = new Criterio();
                a.IdCriterio = 0;
                a.Descripcion = "";
                criterios.AddFirst(a);

                lblCriterios.Visible = true;
                ddlCriterios.Visible = true;
                ddlCriterios.DataSource = criterios;
                ddlCriterios.DataTextField = "descripcion";
                ddlCriterios.DataValueField = "idCriterio";
                ddlCriterios.DataBind();
            }
            else
            {
                lblMensajeError.Text = "El area tematica seleccionada no tiene criterios registrados";
            }
        }

        protected void ddlCriterios_SelectedIndexChanged(object sender, EventArgs e)
        {
            SubCriterioBusiness subCriteriosBus = new SubCriterioBusiness(connectionString);
            LinkedList<SubCriterio> subcriterios = subCriteriosBus.getAllSubCriteriosByCriterio(Int32.Parse(ddlCriterios.SelectedItem.Value));

            if (subcriterios != null)
            {
                lblSubCriterios.Visible = true;
                dlSubCriterios.Visible = true;
                dlSubCriterios.DataSource = subcriterios;
                dlSubCriterios.DataBind();
            }
            else
            {
                lblMensajeError.Text = "El criterio seleccionado no tiene subcriterios registrados";

            }
        }
    }
}