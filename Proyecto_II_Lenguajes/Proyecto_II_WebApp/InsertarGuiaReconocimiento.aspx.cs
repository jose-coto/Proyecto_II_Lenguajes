using Proyecto_II_Library.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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

                //Control ucAT = Page.LoadControl("~/ucAreaTematica.ascx");
                //Control ucCT = Page.LoadControl("~/ucCriterio.ascx");
                //Control ucSC = Page.LoadControl("~/ucSubCriterio.ascx");

                ucAreaTematica ucAT =(ucAreaTematica) Page.LoadControl("~/ucAreaTematica.ascx");
                ucCriterio ucCT = (ucCriterio) Page.LoadControl("~/ucCriterio.ascx");
                ucSubCriterio ucSC = (ucSubCriterio) Page.LoadControl("~/ucSubCriterio.ascx");

                phAreaTematica.Controls.Clear();
                phCriterio.Controls.Clear();
                phSubcriterio.Controls.Clear();

                phAreaTematica.Controls.Add(ucAT);
                phCriterio.Controls.Add(ucCT);
                phSubcriterio.Controls.Add(ucSC);

                Session["ucAT"] = phAreaTematica.Controls[0];
                Session["ucCT"] = phCriterio.Controls[0];
                Session["ucSC"] = phSubcriterio.Controls[0];


                tbNombreGuia.Enabled = false;
                tbAnno.Enabled = false;
            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {

            tbNombreGuia.Enabled = true;
            tbAnno.Enabled = true;

            phAreaTematica.Controls.Clear();
            phCriterio.Controls.Clear();
            phSubcriterio.Controls.Clear();

            Session["guiaReconocimiento"] = new GuiaReconocimiento();

        }

        protected void btnAgregarSubcriterio_Click(object sender, EventArgs e)
        {
            GuiaReconocimiento guiaReconocimiento =
                    Session["guiaReconocimiento"] as GuiaReconocimiento;

            //Aquí sucede la magia
            //Este control es el user control
            //Control ctAT = Session["ucAT"] as ucAreaTematica;
            //Control ctCT = Session["ucCT"] as ucCriterio;
            //Control ctSC = Session["ucSC"] as ucSubCriterio;

            ucAreaTematica ucAT = Session["ucAT"] as ucAreaTematica;
            ucCriterio ucCT = Session["ucCT"] as ucCriterio;
            ucSubCriterio ucSC = Session["ucSC"] as ucSubCriterio;

            AreaTematica area = new AreaTematica();
            Criterio criterio = new Criterio();
            SubCriterio subcriterio = new SubCriterio();

            area.Nombre = ucAT.tbNombreAreaText;
            area.Sigla = ucAT.tbSiglasAreaText;

            criterio.Descripcion = ucCT.tbDescripcionText;
            subcriterio.Descripcion = ucSC.tbDescripcionText;

            /*
            foreach (Control ctActual in ctAT.Controls)
            {
                if (ctActual is TextBox)
                {
                    TextBox tbControl = ctActual as TextBox;
                    if(tbControl.ID.ToString().Equals("tbNombreArea"))
                        area.Nombre = tbControl.Text.ToString();
                    else if (tbControl.ID.ToString().Equals("tbSiglaArea"))
                        area.Sigla = tbControl.Text.ToString();
                }
                
            }
            
            foreach (Control ctActual in ctCT.Controls)
            {
                if (ctActual is TextBox)
                {
                    TextBox tbDescripcion = ctActual as TextBox;
                    if (tbDescripcion.ID.ToString().Equals("tbDescripcion"))
                    {
                        criterio.Descripcion = tbDescripcion.Text.ToString();
                    }
                }
                
            }

            foreach (Control ctActual in ctSC.Controls)
            {
                if (ctActual is TextBox)
                {
                    TextBox tbDescripcion = ctActual as TextBox;
                    if (tbDescripcion.ID.ToString().Equals("tbDescripcion"))
                    {
                        subcriterio.Descripcion = tbDescripcion.Text.ToString();
                    }
                }
            }*/

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
                criterio.SubCriterios.AddLast(subcriterio);
            else
                lblMensaje.Text = "El subcriterio ya existe";

            gvAreas.DataSource = guiaReconocimiento.AreasTematicas;
            gvAreas.DataBind();
            
        }
    }
}