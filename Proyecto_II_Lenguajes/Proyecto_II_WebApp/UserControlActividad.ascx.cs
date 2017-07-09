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
    public partial class UserControlActividad : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String connectionString = WebConfigurationManager.ConnectionStrings["ProyectoII"].ConnectionString;

            TipoParticipanteBusiness tipoParticipanteBuss = new TipoParticipanteBusiness(connectionString);
            LinkedList<TipoParticipante> tipoParticipantes = tipoParticipanteBuss.ggetAllTipoDeParticipantes();

            foreach (TipoParticipante tpActual in tipoParticipantes)
            {
                lbTipoDeParticipantesDisponibles.Items.Add(new ListItem(tpActual.Descripcion, tpActual.IdTipoParticipante.ToString()));
            }
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


        protected void btnRigth_Click(object sender, EventArgs e)
        {
            int i = 0;
            while (i < lbTipoDeParticipantesDisponibles.Items.Count)
            {
                if (lbTipoDeParticipantesDisponibles.Items[i].Selected)
                {
                    lblTipoPrticipantesSeleccionados.Items.Add(lbTipoDeParticipantesDisponibles.Items[i]);
                    lbTipoDeParticipantesDisponibles.Items.RemoveAt(i);
                }
                else
                {
                    i++;
                }
            }
        }

        protected void btnLeft_Click(object sender, EventArgs e)
        {
            int i = 0;
            while (i < lblTipoPrticipantesSeleccionados.Items.Count)
            {
                if (lblTipoPrticipantesSeleccionados.Items[i].Selected)
                {
                    lbTipoDeParticipantesDisponibles.Items.Add(lblTipoPrticipantesSeleccionados.Items[i]);
                    lblTipoPrticipantesSeleccionados.Items.RemoveAt(i);
                }
                else
                {
                    i++;
                }
            }
        }
    }
}