using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Proyecto_II_Library.Domain;

namespace Proyecto_II_WebApp
{
    public partial class UserControlActividad : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public int CantidadParticipantesActividad
        {
            get { return Int32.Parse(tbCantidadParticipantesctividad.Text); }
            set { tbCantidadParticipantesctividad.Text = value.ToString(); }
        }

        public DateTime FechaActividad
        {
            get { return DateTime.Parse(tbFechaActividad.Text); }
            set { tbFechaActividad.Text = value.ToString(); }
        }

        public String DescripcionActividad
        {
            get { return tbDescripcionActividad.Text; }
            set { tbDescripcionActividad.Text = value; }
        }

    }
}