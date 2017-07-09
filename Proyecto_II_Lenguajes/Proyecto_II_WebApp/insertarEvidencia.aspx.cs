using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto_II_WebApp
{
    public partial class insertarEvidencia : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ddlTipoEvidencia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlTipoEvidencia.SelectedValue.ToString().Equals(""))
            {
                btnRegistrarEvidencia.Visible = false;
                UserControlAccionAdministrativa1.Visible = false;
                UserControlDocumento1.Visible = false;
                UserControlActividad1.Visible = false;
                UserControlNormativa1.Visible = false;
            }
            else if (ddlTipoEvidencia.SelectedValue.ToString().Equals("AA"))
            {
                btnRegistrarEvidencia.Visible = true;
                UserControlAccionAdministrativa1.Visible = true;
                UserControlDocumento1.Visible = false;
                UserControlActividad1.Visible = false;
                UserControlNormativa1.Visible = false;
            }
            else if (ddlTipoEvidencia.SelectedValue.ToString().Equals("DO"))
            {
                btnRegistrarEvidencia.Visible = true;
                UserControlDocumento1.Visible = true;
                UserControlAccionAdministrativa1.Visible = false;
                UserControlActividad1.Visible = false;
                UserControlNormativa1.Visible = false;
            }else if (ddlTipoEvidencia.SelectedValue.ToString().Equals("NO"))
            {
                btnRegistrarEvidencia.Visible = true;
                UserControlDocumento1.Visible = false;
                UserControlAccionAdministrativa1.Visible = false;
                UserControlActividad1.Visible = false;
                UserControlNormativa1.Visible = true;
            }
            else
            {
                btnRegistrarEvidencia.Visible = true;
                UserControlDocumento1.Visible = false;
                UserControlAccionAdministrativa1.Visible = false;
                UserControlActividad1.Visible = true;
                UserControlNormativa1.Visible = false;
            }
        }
    }
}