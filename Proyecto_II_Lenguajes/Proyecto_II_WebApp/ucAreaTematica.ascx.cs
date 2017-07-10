using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto_II_WebApp
{
    public partial class ucAreaTematica : System.Web.UI.UserControl
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        
        public String tbNombreAreaText
        {
            get { return tbNombreArea.Text.ToString(); }
            set { tbNombreArea.Text = value; }
        }

        public String tbSiglasAreaText
        {
            get { return tbSiglaArea.Text; }
            set { tbSiglaArea.Text = value; }
        }
    }
}