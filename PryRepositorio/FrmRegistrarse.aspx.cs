using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PryRepositorio.Controlador;
using PryRepositorio.Modelo;

namespace PryRepositorio
{
    public partial class Registrarse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                txtMsg.Text = "";
                txtMsg.Visible = true;

                Usuario usuario = new Usuario();


                if(txtUser.Text =="" || txtPassword.Text=="" || txtPassword2.Text =="")
                {
                    txtMsg.Text = "Por favor ingrese todos los datos.";
                }
                else
                {
                    if (txtPassword.Text == txtPassword2.Text)
                    {
                        
                        Usuario user = new Usuario (txtUser.Text, txtPassword.Text,"usuario");
                        ControlLogin control = new ControlLogin(user);
                        //usuario.NombreU=(txtUser.Text);
                        //usuario.Contrasena=(txtPassword.Text);
                        //usuario.Tipo=("usuario");

                        if (control.ValidarUsuario())
                        {
                            txtMsg.Text = "Este usuario ya esta registrado. Intente con otro.";
                        }
                        else
                        {
                            if (control.Registrar())
                            {
                                txtMsg.Text = "Registro exitoso";
                            }
                            else
                            {
                                txtMsg.Text = "Error al registrar el usuario";
                            }
                        }
                    }
                    else
                    {
                        txtMsg.Text = "Las contraseñas no coinciden.";
                    }
                }
            }
            catch(Exception ex)
            {
                txtMsg.Text = "Error del sistema.";
            }
        }
    }
}