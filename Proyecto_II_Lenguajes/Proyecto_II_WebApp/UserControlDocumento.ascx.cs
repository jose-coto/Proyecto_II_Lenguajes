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
    public partial class UserControlDocumento : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String connectionString = WebConfigurationManager.ConnectionStrings["ProyectoII"].ConnectionString;

            TipoDocumentoBusiness tipoDocumentoBuss = new TipoDocumentoBusiness(connectionString);
            LinkedList<TipoDocumento> tipoDocumentos = tipoDocumentoBuss.getAllTipoDeDocumento();
            ddlTipoDocumento.DataSource =tipoDocumentos;
            ddlTipoDocumento.DataTextField = "Descripcion";
            ddlTipoDocumento.DataValueField = "IdTipoDocumento";
            ddlTipoDocumento.DataBind();
        }

        public String DetalleDocumento 
        {
            get { return tbDetalleDocumento.Text; }
            set { tbDetalleDocumento.Text = value; }
        }

        public String FuenteDocumento
        {
            get { return tbFuenteDocumento.Text; }
            set { tbFuenteDocumento.Text = value; }
        }

        public DateTime FechaDocumento
        {
            get { return DateTime.Parse(tbFechaDocumento.Text); }
            set { tbFechaDocumento.Text = value.ToString(); }
        }

        public TipoDocumento TipoDocumento
        {
            get { return new TipoDocumento(Int32.Parse(ddlTipoDocumento.SelectedItem.Value), ddlTipoDocumento.SelectedItem.Text); }
        }
    }
}