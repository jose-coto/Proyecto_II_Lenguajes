using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Proyecto_II_Library.Business;
using System.Web.Configuration;
using System.Web.Security;
using Proyecto_II_Library.Domain;

namespace Proyecto_II_WebApp
{
    public partial class Logon : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Logon_Click(object sender, EventArgs e)
        {
            SeguridadBusiness seguridadBusiness = new SeguridadBusiness(
                WebConfigurationManager.ConnectionStrings["ProyectoII"].ConnectionString);
            Funcionario f;
            if ((f = seguridadBusiness.signInUser(UserEmail.Text.ToString(),UserPass.Text.ToString())) != null)
            {
                FormsAuthentication.RedirectFromLoginPage
                   (UserEmail.Text, Persist.Checked);
                Session["currentUser"] = f;
            }
            else
            {
                Msg.Text = "Credenciales invalidas, por favor inténtelo de nuevo";
            }
        }

    }
}