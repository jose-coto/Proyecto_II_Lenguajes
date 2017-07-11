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
    public partial class InsertarEvaluacion : System.Web.UI.Page
    {

        private String connectionString = WebConfigurationManager.ConnectionStrings["ProyectoII"].ConnectionString;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GuiaReconocimientoBusiness guiaBus = new GuiaReconocimientoBusiness(connectionString);
                RecintoBusiness recintoBus = new RecintoBusiness(connectionString);

                ddlRecinto.DataSource = recintoBus.getAllRecintos();
                ddlRecinto.DataTextField = "nombreRecinto";
                ddlRecinto.DataValueField = "idRecinto";
                ddlRecinto.DataBind();

                LinkedList<GuiaReconocimiento> guias = guiaBus.findGuides();
                GuiaReconocimiento g = new GuiaReconocimiento();
                g.IdGuiaReconocimiento = 0;
                g.Nombre = "";
                guias.AddFirst(g);

                ddlGuiaReconocimiento.DataSource = guias;
                ddlGuiaReconocimiento.DataTextField = "nombre";
                ddlGuiaReconocimiento.DataValueField = "idGuiaReconocimiento";
                ddlGuiaReconocimiento.DataBind();
            }
        }

        protected void btnRegistrarEvaluacion_Click(object sender, EventArgs e)
        {
            DateTime fechaInicial = DateTime.Parse(tbFechaInicial.Text);
            DateTime fechaFinal = DateTime.Parse(tbFechaFinal.Text);
            int recinto = Int32.Parse(ddlRecinto.SelectedItem.Value);
            int guia = Int32.Parse(ddlGuiaReconocimiento.SelectedItem.Value);

            Evaluacion eva = new Evaluacion();
            eva.FechaInicioEvaluacion = fechaInicial;
            eva.FechaFinalEvaluacion = fechaFinal;
            eva.Recinto.IdRecinto = recinto;
            eva.GuiaReconocimiento.IdGuiaReconocimiento = guia;

            EvaluacionBusiness evaluacionBus = new EvaluacionBusiness(connectionString);
            try
            {
                evaluacionBus.Insertar(eva);
                tbFechaInicial.Text = "";
                tbFechaFinal.Text = "";
                Response.Write("<script language='JavaScript'>alert('Evaluacion insertada con exito');</script>");
            }
            catch
            {
                Response.Write("<script language='JavaScript'>alert('No se pudo insertar problemas de conexion con el servidor');</script>");
            }
        }
    }
}