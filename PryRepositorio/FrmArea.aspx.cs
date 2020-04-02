using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PryRepositorio.Controlador;
using System.Data.SqlClient;
using System.Data;
using PryRepositorio.Modelo;

namespace PryRepositorio
   
{
    public partial class FrmArea1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Area objArea = new Area();
                objArea.IdArea = txtArea.Text;
                objArea.Nombre = txtNombre.Text;
                objArea.FkidArea = dropFkarea.Text;
                ControlArea objControl = new ControlArea(objArea);
                Label1.Text= objControl.Guardar();

                //    String ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + @"C:\Users\González Peña\source\repos\PryRepositorio\PryRepositorio\App_Data\BDRepositorio.mdf" + @";Integrated Security=True";
                //    //String ConnectionString = @"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename = C:\Users\JuanFeLds\Documents\Desarrollo Software\Proyecto Alejandria\PryRepositorio\PryRepositorio\App_Data\BDRepositorio.mdf; Integrated Security = True";
                //    //String ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\repos\PryRepositorio\PryRepositorio\App_Data\BDRepositorio.mdf;Integrated Security=True";
                //    SqlConnection cnn = new SqlConnection(ConnectionString);
                //    SqlCommand cmd = new SqlCommand("procInsertArea", cnn);
                //    cmd.CommandType = CommandType.StoredProcedure;

                //    cmd.Parameters.Add("@idArea", SqlDbType.VarChar, 10);
                //    cmd.Parameters.Add("@nombre", SqlDbType.VarChar, 50);
                //    cmd.Parameters.Add("@fkArea", SqlDbType.VarChar, 10);

                //    cmd.Parameters["@idArea"].Value = idArea;
                //    cmd.Parameters["@nombre"].Value = nombre;
                //    cmd.Parameters["@fkArea"].Value = fkidArea;

                //    cnn.Open();
                //    cmd.ExecuteNonQuery();
                //    cnn.Close();
                //}
                //    catch(Exception objExc)
                //{
                //    Label1.Text = objExc.Message;
                //}
            }
            catch (Exception objExc)
            {
                Label1.Text = objExc.Message;
            }
        }


        protected void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                Area objArea = new Area();
                objArea.IdArea = txtArea.Text;
                objArea.Nombre = txtNombre.Text;
                objArea.FkidArea = dropFkarea.Text;
                ControlArea objControl = new ControlArea(objArea);
                Label1.Text = objControl.Modificar();
            }
            catch (Exception objExc)
            {
                Label1.Text = objExc.Message;
            }
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                Area objArea = new Area();
                objArea.IdArea = txtArea.Text;
                ControlArea objControl = new ControlArea(objArea);
                DataSet DS = objControl.Consultar();

                txtNombre.Text = DS.Tables[0].Rows[0][0].ToString();
                //txtFkarea.Text = DS.Tables[0].Rows[0][1].ToString();

            }
            catch (Exception objExc)
            {
                Label1.Text = objExc.Message;
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                Area objArea = new Area();
                objArea.IdArea = txtArea.Text;
                ControlArea objControl = new ControlArea(objArea);
                Label1.Text = objControl.Modificar();
            }
            catch (Exception objExc)
            {
                Label1.Text = objExc.Message;
            }
        }
    }
}