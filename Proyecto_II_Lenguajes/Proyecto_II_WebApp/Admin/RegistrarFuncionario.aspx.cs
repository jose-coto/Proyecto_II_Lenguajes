using Proyecto_II_Library.Business;
using Proyecto_II_Library.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Proyecto_II_WebApp
{
    public partial class RegistrarFuncionario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                SeguridadBusiness seguridadBusiness = new SeguridadBusiness(
                    WebConfigurationManager.ConnectionStrings["ProyectoII"].ConnectionString);

                ddlRoles.DataSource = seguridadBusiness.getAllRolesList();
                ddlRoles.DataTextField = "nombreRole";
                ddlRoles.DataValueField = "idRole";
                ddlRoles.DataBind();

                btnActualizar.Visible = false;
                btnRegistrar.Visible = true;

                Session["Encargado"] = new EncargadoEvaluacion();
            }
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            FuncionarioBusiness funcionarioBusiness = new FuncionarioBusiness(
                WebConfigurationManager.ConnectionStrings["ProyectoII"].ConnectionString);

            if (tbNombre.Text.Equals("")|| tbApellidos.Text.Equals("") ||
                tbPassword.Text.Equals("") || tbUsername.Text.Equals(""))
            {
                lblMensaje.Text = "Por favor llene todos los campos solicitados";
            }
            else
            {
                lblMensaje.Text = "";

                Funcionario funcionario = new Funcionario();
                funcionario.NombreFuncionario = tbNombre.Text.ToString();
                funcionario.ApellidosFuncionario = tbApellidos.Text.ToString();
                funcionario.UserName = tbUsername.Text.ToString();
                funcionario.Password = tbPassword.Text.ToString(); //Falta encriptar pass
                funcionario.Role.IdRole = Int32.Parse(ddlRoles.SelectedValue.ToString());

                funcionarioBusiness.insertarFuncionario(funcionario);
            }
        }

        protected void gvEncargadoDe_SelectedIndexChanged(object sender, EventArgs e)
        {
            AreaTematicaBusiness areaTematicaBusiness = new AreaTematicaBusiness(
                    WebConfigurationManager.ConnectionStrings["ProyectoII"].ConnectionString);
            

            ddlAreas.DataSource = areaTematicaBusiness.getAllAreaTematicasByGuide(
                Int32.Parse(gvEncargadoDe.SelectedRow.Cells[6].Text));

            ddlAreas.DataTextField = "nombre";
            ddlAreas.DataValueField = "idAreaTematica";
            ddlAreas.DataBind();
            
            ddlAreas.Visible = true;
        }

        protected void gvFuncionarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            tbNombre.Text = gvFuncionarios.SelectedRow.Cells[1].Text;
            tbApellidos.Text = gvFuncionarios.SelectedRow.Cells[2].Text;
            tbUsername.Text = gvFuncionarios.SelectedRow.Cells[3].Text;
            tbPassword.Text = "";

            btnActualizar.Visible = true;
            btnRegistrar.Visible = false;
        }

        protected void btnEncargadoDe_Click(object sender, EventArgs e)
        {
            EncargadoEvaluacion encargado = Session["Encargado"] as EncargadoEvaluacion;
            AreaTematica area = new AreaTematica();

            area.IdAreaTematica = Int32.Parse(ddlAreas.SelectedValue.ToString());
            encargado.EncargadoAreaTematica = area;

            Evaluacion eval = new Evaluacion();
            eval.IdEvaluacion = Int32.Parse(gvEncargadoDe.SelectedRow.Cells[1].Text);

            Recinto recinto = new Recinto();
            recinto.IdRecinto = Int32.Parse(gvEncargadoDe.SelectedRow.Cells[4].Text);
            eval.Recinto = recinto;

            GuiaReconocimiento guia = new GuiaReconocimiento();
            guia.IdGuiaReconocimiento = Int32.Parse(gvEncargadoDe.SelectedRow.Cells[6].Text);
            eval.GuiaReconocimiento = guia;
            
            encargado.Evaluaciones.AddLast(eval);
        }
    }
}