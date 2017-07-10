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

        protected void btnRegistrarEvidencia_Click(object sender, EventArgs e)
        {
            String connectionString = WebConfigurationManager.ConnectionStrings["ProyectoII"].ConnectionString;

            Evidencia evidencia = new Evidencia();
            evidencia.Titulo = tbTitulo.Text;
            evidencia.FechaIngreso = DateTime.Parse(tbFecha.Text);
            evidencia.Tipo = Char.Parse(ddlTipoEvidencia.SelectedValue.ToString());
            //evidencia.SubCriterio.IdSubCriterio= subcriterio tomado del link

            EvidenciaBusiness evidenciaBusiness = new EvidenciaBusiness(connectionString);

            Evaluacion evaluacion = null;

            evidencia = evidenciaBusiness.insertar(evidencia, evaluacion);

            if (evidencia.Tipo.Equals("AA"))
            {
                AccionAdministrativa accion = new AccionAdministrativa();
                accion.Detalle = UserControlAccionAdministrativa1.DetalleAccion;
                accion.InformeTecnico = UserControlAccionAdministrativa1.InformeAccion;

                AccionAdministrativaBusiness aad = new AccionAdministrativaBusiness(connectionString);
                aad.insertar(accion);
            }
            else if (evidencia.Tipo.Equals("NO"))
            {
                Normativa normativa = new Normativa();
                //insertar normativa
            }
            else if (evidencia.Tipo.Equals("DO"))
            {
                Documento documento = new Documento();
                documento.Detalle = UserControlDocumento1.DetalleDocumento;
                documento.Fuente = UserControlDocumento1.FuenteDocumento;
                documento.Fecha = UserControlDocumento1.FechaDocumento;
                documento.TipoDocumento = UserControlDocumento1.TipoDocumento;

                DocumentoBusiness db = new DocumentoBusiness(connectionString);
                db.insertar(documento);
            }
            else
            {
                Actividad actividad = new Actividad();
                //insertar Actividad
            }
        }
    }
}