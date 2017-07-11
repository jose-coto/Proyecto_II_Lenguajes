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
    public partial class ViewDocument : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int id = int.Parse(Request.QueryString["id"]);

            string connectionString = WebConfigurationManager.ConnectionStrings["ProyectoII"].ConnectionString;
            EvidenciaBusiness evidBussines = new Proyecto_II_Library.Business.EvidenciaBusiness(connectionString);

            DocumetoNormativa doc = evidBussines.ShowDocumentNormativa(id);

            // Clear Response buffer        
            Response.Clear();

            // Set ContentType to the ContentType of our file
            Response.ContentType = doc.ContentType;

            // Write data out of database into Output Stream
            Response.OutputStream.Write(doc.Data, 0, doc.Size);

            // End the page
            Response.End();
        }
    }
}