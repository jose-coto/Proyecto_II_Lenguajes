using Proyecto_II_Library.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto_II_WebApp
{
    public partial class UserControlNormativa : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public String DetalleNormativa
        {
            get { return tbDetalleNormativa.Text; }
            set { tbDetalleNormativa.Text = value; }
        }

        public DocumetoNormativa documento()
        {
            DocumetoNormativa documento = new DocumetoNormativa();
            if (fuDocument.PostedFile != null)
            {
                HttpPostedFile currentImage = fuDocument.PostedFile;          
                int size = documento.Size;
                documento.Nombre = currentImage.FileName;
                documento.ContentType = currentImage.ContentType;
                documento.Data = new byte[size];
                currentImage.InputStream.Read(documento.Data, 0, size);
            }

            return documento;
        }




    }
}