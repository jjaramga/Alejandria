//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Web;
//using System.Web.UI;
//using System.Web.UI.WebControls;
//using Microsoft.Win32.OpenFileDialog;

//namespace PryRepositorio
//{
//    public partial class FormCargarMaterial : System.Web.UI.Page
//    {
//        String carpeta;
//        FileUpload file = new FileUpload();
//        protected void Page_Load(object sender, EventArgs e)
//        {
//            carpeta = Path.Combine(Request.PhysicalApplicationPath, @"App_Data\");
//            if(file.PostedFile == null || file.PostedFile.FileName == "")
//            {
//               MessageBox.Show("No haz seleccionado ningún archivo");
//            }
//            else
//            {
//                try
//                {
//                    String archivo = Path.GetFileName(file.PostedFile.FileName);
//                    String carpetaFinal = Path.Combine(carpeta, archivo);
//                    file.PostedFile.SaveAs(carpetaFinal);
//                }
//                catch(Exception objEx)
//                {
//                   // MessageBox.Show(objEx.Message);
//                }
                
//            }
//        }

//        protected void Examinar_Click(object sender, EventArgs e)
//        {
//            OpenFileDialog dlg = new OpenFileDialog();
//        }
//    }
//}