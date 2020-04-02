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
    public partial class FrmAutores : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        { // Usando el controlador
            try
            {
                Autor autor = new Autor(this.txtCodigo.Text.Trim(), this.txtNombre.Text.Trim(), this.txtNacionalidad.Text.Trim());
                ControlAutor controlAutor = new ControlAutor();

                Label1.Text = controlAutor.IngresarAutor(autor);

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
                Autor autor = new Autor(this.txtCodigo.Text.Trim(), this.txtNombre.Text.Trim(), this.txtNacionalidad.Text.Trim());
                ControlAutor controlAutor = new ControlAutor();

                DS = controlAutor.ConsultarAutor(autor);

                txtCodigo.Text = DS.Tables[0].Rows[0][0].ToString();
                txtNombre.Text = DS.Tables[0].Rows[0][1].ToString();
                txtNacionalidad.Text = DS.Tables[0].Rows[0][2].ToString();
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
                Autor autor = new Autor(this.txtCodigo.Text.Trim(), this.txtNombre.Text.Trim(), this.txtNacionalidad.Text.Trim());
                ControlAutor controlAutor = new ControlAutor();

                Label1.Text = controlAutor.ModificarAutor(autor);

            }
            catch (Exception objEx)
            {
                Label1.Text = objEx.Message;
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        { // sin usar el controlador
            try
            {
                String comandoSql = String.Format("EXEC procBorrarAutor {0}", txtCodigo.Text);
                Conexion conexion = new Conexion();

                conexion.EjecutarCosulta(comandoSql);
            }
            catch (Exception objEx)
            {
                Label1.Text = objEx.Message;
            }
        }
    }
}