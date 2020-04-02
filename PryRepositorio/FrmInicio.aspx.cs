using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PryRepositorio
{
    public partial class FrmInicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnMaterial_Click(object sender, EventArgs e)
        {
            Response.Redirect("FrmMaterial.aspx");
        }

        protected void btnAutores_Click(object sender, EventArgs e)
        {
            Response.Redirect("FrmAutor.aspx");

        }

        protected void btnArea_Click(object sender, EventArgs e)
        {
            Response.Redirect("FrmArea.aspx");
        }

        protected void btnCargarMaterial_Click(object sender, EventArgs e)
        {
            Response.Redirect("FormCargarMaterial.aspx");
        }

        protected void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            Response.Redirect("FrmLogin.aspx");
        }

        protected void btnRegistrarse_Click(object sender, EventArgs e)
        {
            Response.Redirect("FrmRegistrarse.aspx");
        }
    }
}