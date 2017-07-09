using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto_II_WebApp
{
    public partial class UserControlAccionAdministrativa : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public String DetalleAccion
        {
            get { return tbDetalleAccion.Text; }
            set { tbDetalleAccion.Text = value; }
        }

        public String InformeAccion
        {
            get { return tbInformeAccion.Text;}
            set { tbInformeAccion.Text = value; }
        }

    }
}