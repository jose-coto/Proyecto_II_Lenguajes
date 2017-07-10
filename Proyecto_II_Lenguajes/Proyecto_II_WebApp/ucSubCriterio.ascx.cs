using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto_II_WebApp
{
    public partial class ucSubCriterio : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public String tbDescripcionText
        {
            get { return tbDescripcion.Text; }
            set { tbDescripcion.Text = value; }
        }
    }
}