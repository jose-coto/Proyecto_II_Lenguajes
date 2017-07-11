using Proyecto_II_Library.Business;
using Proyecto_II_Library.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto_II_WebApp
{
    public partial class InsertarGuiaReconocimiento : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Session["guiaReconocimiento"] = new GuiaReconocimiento();
            }
        }

        protected void btnAddArea_Click(object sender, EventArgs e)
        {
            if (tbNombreGuia.Text.ToString().Equals("") || tbAnno.Text.ToString().Equals(""))
            {
                lblMensaje.Text = "Por favor llene los campos solicitados";
                tbNombreGuia.Enabled = true;
                tbAnno.Enabled = true;
            }
            else
            {
                GuiaReconocimiento guiaReconocimiento =
                    Session["guiaReconocimiento"] as GuiaReconocimiento;

                guiaReconocimiento.Nombre = tbNombreGuia.Text.ToString();
                guiaReconocimiento.AnnoPublicacion = DateTime.Parse(tbAnno.Text.ToString());

                UserControlAreaTematica.Visible = true;
                UserControlCriterio.Visible = true;
                UserControlSubcriterio.Visible = true;

                tbNombreGuia.Enabled = false;
                tbAnno.Enabled = false;
            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {

            tbNombreGuia.Enabled = true;
            tbAnno.Enabled = true;

            UserControlAreaTematica.Visible = false;
            UserControlCriterio.Visible = false;
            UserControlSubcriterio.Visible = false;


            Session["guiaReconocimiento"] = new GuiaReconocimiento();

            gvAreas.DataSource = null;
            gvAreas.DataBind();

            gvCriterios.DataSource = null;
            gvCriterios.DataBind();

            gvSubcriterios.DataSource = null;
            gvSubcriterios.DataBind();

        }

        protected void btnAgregarSubcriterio_Click(object sender, EventArgs e)
        {
            GuiaReconocimiento guiaReconocimiento =
                    Session["guiaReconocimiento"] as GuiaReconocimiento;

            //Aquí sucede la magia
            AreaTematica area = new AreaTematica();
            Criterio criterio = new Criterio();
            SubCriterio subcriterio = new SubCriterio();
            
            area.Nombre = UserControlAreaTematica.tbNombreAreaText;
            area.Sigla = UserControlAreaTematica.tbSiglasAreaText;

            
            criterio.Descripcion = UserControlCriterio.tbDescripcionText;
            subcriterio.Descripcion = UserControlSubcriterio.tbDescripcionText;

            if (area.Nombre.ToString().Equals("") || area.Sigla.ToString().Equals("")
                || criterio.Descripcion.ToString().Equals("") || subcriterio.Descripcion.ToString().Equals(""))
            {
                lblMensaje.Text = "Por favor ingrese todos los datos";
            }
            else
            {
                //Se verifica si el área existe
                Boolean existe = false;
                foreach (AreaTematica areaActual in guiaReconocimiento.AreasTematicas)
                {
                    if (areaActual.Sigla.ToString().Equals(area.Sigla.ToString()))
                    {
                        existe = true;
                        area = areaActual;
                    }
                }

                if (!existe)
                    guiaReconocimiento.AreasTematicas.AddLast(area);

            

                //Se verifica si el criterio existe
                existe = false;
                foreach (Criterio criterioActual in area.Criterios)
                {
                    if(criterioActual.Descripcion.ToString().Equals(criterio.Descripcion))
                    {
                        existe = true;
                        criterio = criterioActual;
                    }
                }

                if (!existe)
                    area.Criterios.AddLast(criterio);

                //Se verifica si el subcriterio existe
                existe = false;
                foreach (SubCriterio subcriterioActual in criterio.SubCriterios)
                {
                    if (subcriterioActual.Descripcion.ToString().Equals(subcriterio.Descripcion.ToString()))
                    {
                        existe = true;
                        subcriterio = subcriterioActual;
                    }
                }

                if (!existe)
                { 
                    criterio.SubCriterios.AddLast(subcriterio);
                    btnInsertarGuia.Visible = true;
                }
                else
                    lblMensaje.Text = "El subcriterio ya existe";
                
                gvAreas.DataSource = guiaReconocimiento.AreasTematicas;
                gvAreas.DataBind();

                gvCriterios.DataSource = null;
                gvCriterios.DataBind();

                gvSubcriterios.DataSource = null;
                gvSubcriterios.DataBind();
            }
        }

        protected void gvAreas_SelectedIndexChanged(object sender, EventArgs e)
        {
            GuiaReconocimiento guiaReconocimiento =
                    Session["guiaReconocimiento"] as GuiaReconocimiento;

            gvCriterios.DataSource = guiaReconocimiento.AreasTematicas.ElementAt(gvAreas.SelectedIndex).Criterios;
            gvCriterios.DataBind();

            gvSubcriterios.DataSource = null;
            gvSubcriterios.DataBind();
        }

        protected void gvCriterios_SelectedIndexChanged(object sender, EventArgs e)
        {
            GuiaReconocimiento guiaReconocimiento =
                    Session["guiaReconocimiento"] as GuiaReconocimiento;

            gvSubcriterios.DataSource = guiaReconocimiento.AreasTematicas
                .ElementAt(gvAreas.SelectedIndex).Criterios
                .ElementAt(gvCriterios.SelectedIndex).SubCriterios;

            gvSubcriterios.DataBind();
        }

        protected void btnInsertarGuia_Click(object sender, EventArgs e)
        {
            GuiaReconocimientoBusiness guiaReconocimientoBusiness = new GuiaReconocimientoBusiness(
                WebConfigurationManager.ConnectionStrings["ProyectoII"].ConnectionString);
            
            try
            {
                GuiaReconocimiento guiaReconocimiento = Session["guiaReconocimiento"] as GuiaReconocimiento;
                guiaReconocimiento.Vigente = true;
                guiaReconocimientoBusiness.insertGuide(guiaReconocimiento);
            }
            catch(Exception ex)
            {
                lblMensaje.Text = "Ha ocurrido un error al insertar la guía, intentelo de nuevo más tarde";
            }
        }
    }
}