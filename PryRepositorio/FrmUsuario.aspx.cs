using PryRepositorio.Controlador;
using PryRepositorio.Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PryRepositorio
{
	public partial class FrmUsuarios : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario usuario = new Usuario (this.txtNombreUsr.Text.Trim(), this.txtContraseña.Text.Trim(), this.txtTipo.Text.Trim());
                ControlUsuario controlUsuario = new ControlUsuario();

                Label1.Text = controlUsuario.IngresarUsuario(usuario);

            }
            catch (Exception objEx)
            {
                Label1.Text = objEx.Message;
            }
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet DS = new DataSet();
                Usuario usuario = new Usuario(this.txtNombreUsr.Text.Trim(), this.txtContraseña.Text.Trim(), this.txtTipo.Text.Trim());
                ControlUsuario controlUsuario = new ControlUsuario();

                DS = controlUsuario.ConsultarUsuario(usuario);

                txtNombreUsr.Text = DS.Tables[0].Rows[0][0].ToString();
                txtContraseña.Text = DS.Tables[0].Rows[0][1].ToString();
                txtTipo.Text = DS.Tables[0].Rows[0][2].ToString();

            }
            catch (Exception objEx)
            {
                Label1.Text = objEx.Message;
            }
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario usuario = new Usuario(this.txtNombreUsr.Text.Trim(), this.txtContraseña.Text.Trim(), this.txtTipo.Text.Trim());
                ControlUsuario controlUsuario = new ControlUsuario();

                Label1.Text = controlUsuario.ModificarUsuario(usuario);

            }
            catch (Exception objEx)
            {
                Label1.Text = objEx.Message;
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                Usuario usuario = new Usuario(this.txtNombreUsr.Text.Trim(), this.txtContraseña.Text.Trim(), this.txtTipo.Text.Trim());
                ControlUsuario controlUsuario = new ControlUsuario();

                Label1.Text = controlUsuario.EliminarUsuario(usuario);

            }
            catch (Exception objEx)
            {
                Label1.Text = objEx.Message;
            }
        }
    }
}