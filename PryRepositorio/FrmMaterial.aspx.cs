using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PryRepositorio.Controlador;
using PryRepositorio.Modelo;

namespace PryRepositorio
{
    public partial class FrmMateriales : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Boolean fileOK = false;
            String rutaMaterial = Server.MapPath("~/App_Data/Materiales/");
            String rutaImagen = Server.MapPath("~/Vista/imgMateriales/");

            try
            {
                if (FileUploadMaterial.HasFile)
                {
                    String fileExtension = System.IO.Path.GetExtension(FileUploadMaterial.FileName).ToLower();
                    String[] extensionesValidas = { ".zip", ".rar", ".iso" };

                    for (int i = 0; i < extensionesValidas.Length; i++)
                    {
                        if (fileExtension == extensionesValidas[i])
                        {
                            fileOK = true;
                        }
                    }

                    if (fileOK)
                    {
                        String fileName = FileUploadMaterial.FileName;
                        rutaMaterial += fileName;
                        FileUploadMaterial.SaveAs(rutaMaterial);
                        //labelMaterial.Text = "Archivo Cargado!";
                    }
                    else
                    {
                        throw new Exception("Solo se adminten archivos de tipo .rar .zip o .iso");
                        //labelMaterial.Text = "Cannot accept files of this type.";
                    }

                }

                if (FileUploadImg.HasFile)
                {
                    String fileExtension = System.IO.Path.GetExtension(FileUploadImg.FileName).ToLower();
                    String[] extensionesValidas = { ".jpg", ".jpeg", ".png", ".gif" };

                    for (int i = 0; i < extensionesValidas.Length; i++)
                    {
                        if (fileExtension == extensionesValidas[i])
                        {
                            fileOK = true;
                        }
                    }

                    if (fileOK)
                    {
                        String fileName = FileUploadImg.FileName;
                        rutaImagen += fileName;
                        FileUploadImg.SaveAs(rutaImagen);
                        //labelMaterial.Text = "Archivo Cargado!";
                    }
                    else
                    {
                        throw new Exception("Solo se adminten archivos de tipo .jpg .jpeg .png o .gif");
                        //labelMaterial.Text = "Cannot accept files of this type.";
                    }

                }

                Material objMaterial = new Material();
                Area[] objAreas = new Area[listBoxArea.Items.Count];
                Audiencia[] objAudiencias = new Audiencia[listBoxAudiencia.Items.Count];
                Autor[] objAutores = new Autor[listBoxAutor.Items.Count];
                Formato[] objFormatos = new Formato[listBoxFormato.Items.Count];
                Keyword[] objKeywords = new Keyword[listBoxKeyword.Items.Count];
                Lenguaje[] objLenguajes = new Lenguaje[listBoxLenguaje.Items.Count];


                objMaterial.IdMaterial = txtIdmaterial.Text;
                objMaterial.Titulo = txtTitulomaterial.Text;
                objMaterial.Descripcion = txtDescripcion.Text;
                objMaterial.Requerimientos = txtRequerimientos.Text;
                objMaterial.Tipo = txtTipomaterial.Text;
                objMaterial.Ruta = rutaMaterial;
                objMaterial.Imagen = rutaImagen;
                //objMaterial.FechaIngreso = DateTime.Parse(txtfechaIngreso.Text);
                //objMaterial.FechaModificacion = DateTime.Parse(txtFechamodificacion.Text);
                objMaterial.Propietario = txtPropietario.Text;
                objMaterial.Movil = checkMovil.Checked;
                objMaterial.Costo = Double.Parse(txtCosto.Text);

                for (int i = 0; i < listBoxArea.Items.Count; i++)
                {
                    Console.WriteLine("listBoxArea: " + listBoxArea.ToString());
                    Console.WriteLine("listBoxArea.Itemns.Count: " + listBoxArea.Items.Count);
                    objAreas[i] = new Area();
                    objAreas[i].Nombre = listBoxArea.Items[i].Text;
                    Console.WriteLine("objAreas[" + i + "]: " + objAreas[i].Nombre);
                }

                for (int i = 0; i < listBoxAudiencia.Items.Count; i++)
                {
                    objAudiencias[i] = new Audiencia();
                    objAudiencias[i].Nombre = listBoxAudiencia.Items[i].Text;
                }

                for (int i = 0; i < listBoxAutor.Items.Count; i++)
                {
                    objAutores[i] = new Autor();
                    objAutores[i].Nombre = listBoxAutor.Items[i].Text;
                }

                for (int i = 0; i < listBoxFormato.Items.Count; i++)
                {
                    objFormatos[i] = new Formato();
                    objFormatos[i].Nombre = listBoxFormato.Items[i].Text;
                }

                for (int i = 0; i < listBoxKeyword.Items.Count; i++)
                {
                    objKeywords[i] = new Keyword();
                    objKeywords[i].Nombre = listBoxKeyword.Items[i].Text;
                }

                for (int i = 0; i < listBoxLenguaje.Items.Count; i++)
                {
                    objLenguajes[i] = new Lenguaje();
                    objLenguajes[i].Nombre = listBoxLenguaje.Items[i].Text;
                }

                objMaterial.Areas = objAreas;
                objMaterial.Audiencia = objAudiencias;
                objMaterial.Autores = objAutores;
                objMaterial.Formatos = objFormatos;
                objMaterial.Keywords = objKeywords;
                objMaterial.Lenguajes = objLenguajes;

                controlMaterial objControl = new controlMaterial(objMaterial);
                labelMaterial.Text = objControl.guardarMaterial();
                //objAutor.Codigo

                ////ControlAutor objControl2 = new ControlAutor();
                ////objControl2.GuardarMaterialAutor(objMaterial.IdMaterial, CodigoAutor);

            }
            catch (Exception ex)
            {
                labelMaterial.Text = ex.Message;
            }
        }
            
        //Consultar Material
        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            try
            {

                Material objMaterial = new Material();
                objMaterial.IdMaterial = txtIdmaterial.Text;
                controlMaterial objControl = new controlMaterial(objMaterial);
                DataSet DS = objControl.Consultar();

                txtTitulomaterial.Text = DS.Tables[0].Rows[0][1].ToString();
                txtDescripcion.Text = DS.Tables[0].Rows[0][2].ToString();
                txtTipomaterial.Text = DS.Tables[0].Rows[0][3].ToString();
                txtRequerimientos.Text = DS.Tables[0].Rows[0][4].ToString();
                labelFechaIngreso.Text = DS.Tables[0].Rows[0][5].ToString();
                labelFechaModificacion.Text = DS.Tables[0].Rows[0][6].ToString();
                txtPropietario.Text = DS.Tables[0].Rows[0][9].ToString();
                txtCosto.Text = DS.Tables[0].Rows[0][11].ToString();

                if (DS.Tables[0].Rows[0][10].ToString().Equals("True"))
                {
                    checkMovil.Checked = true;
                }
                else
                {
                    checkMovil.Checked = false;
                }

                //Limpiar las listas de metadatos
                listBoxArea.Items.Clear();
                listBoxAudiencia.Items.Clear();
                listBoxAutor.Items.Clear();
                listBoxFormato.Items.Clear();
                listBoxKeyword.Items.Clear();
                listBoxLenguaje.Items.Clear();

                for (int i = 0; i < DS.Tables[1].Rows.Count; i++)
                {
                    listBoxArea.Items.Add(DS.Tables[1].Rows[i][0].ToString());
                }

                for(int i = 0; i < DS.Tables[2].Rows.Count; i++)
                {
                    listBoxAudiencia.Items.Add(DS.Tables[2].Rows[i][0].ToString());
                }

                for(int i = 0; i < DS.Tables[3].Rows.Count; i++)
                {
                    listBoxAutor.Items.Add(DS.Tables[3].Rows[i][0].ToString());
                }

                for(int i = 0; i < DS.Tables[4].Rows.Count; i++)
                {
                    listBoxFormato.Items.Add(DS.Tables[4].Rows[i][0].ToString());
                }

                for(int i = 0; i < DS.Tables[5].Rows.Count; i++)
                {
                    listBoxKeyword.Items.Add(DS.Tables[5].Rows[i][0].ToString());
                }

                for(int i = 0; i < DS.Tables[6].Rows.Count; i++)
                {
                    listBoxLenguaje.Items.Add(DS.Tables[6].Rows[i][0].ToString());
                }
            }
            catch(Exception Exc)
            {
            labelMaterial.Text = Exc.Message;
            }

        }


        // Modificar Material
        protected void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                Boolean fileOK = false;
                String rutaMaterial = Server.MapPath("~/App_Data/Materiales/");
                String rutaImagen = Server.MapPath("~/Vista/imgMateriales/");

                if (FileUploadMaterial.HasFile)
                {
                    String fileExtension = System.IO.Path.GetExtension(FileUploadMaterial.FileName).ToLower();
                    String[] extensionesValidas = { ".zip", ".rar", ".iso" };

                    for (int i = 0; i < extensionesValidas.Length; i++)
                    {
                        if (fileExtension == extensionesValidas[i])
                        {
                            fileOK = true;
                        }
                    }

                    if (fileOK)
                    {
                        String fileName = FileUploadMaterial.FileName;
                        rutaMaterial += fileName;
                        FileUploadMaterial.SaveAs(rutaMaterial);
                        //labelMaterial.Text = "Archivo Cargado!";
                    }
                    else
                    {
                        throw new Exception("Solo se adminten archivos de tipo .rar .zip o .iso");
                        //labelMaterial.Text = "Cannot accept files of this type.";
                    }

                }

                if (FileUploadImg.HasFile)
                {
                    String fileExtension = System.IO.Path.GetExtension(FileUploadImg.FileName).ToLower();
                    String[] extensionesValidas = { ".jpg", ".jpeg", ".png", ".gif" };

                    for (int i = 0; i < extensionesValidas.Length; i++)
                    {
                        if (fileExtension == extensionesValidas[i])
                        {
                            fileOK = true;
                        }
                    }

                    if (fileOK)
                    {
                        String fileName = FileUploadImg.FileName;
                        rutaImagen += fileName;
                        FileUploadImg.SaveAs(rutaImagen);
                        //labelMaterial.Text = "Archivo Cargado!";
                    }
                    else
                    {
                        throw new Exception("Solo se adminten archivos de tipo .jpg .jpeg .png o .gif");
                        //labelMaterial.Text = "Cannot accept files of this type.";
                    }

                }

                Material objMaterial = new Material();
                Area[] objAreas = new Area[listBoxArea.Items.Count];
                Audiencia[] objAudiencias = new Audiencia[listBoxAudiencia.Items.Count];
                Autor[] objAutores = new Autor[listBoxAutor.Items.Count];
                Formato[] objFormatos = new Formato[listBoxFormato.Items.Count];
                Keyword[] objKeywords = new Keyword[listBoxKeyword.Items.Count];
                Lenguaje[] objLenguajes = new Lenguaje[listBoxLenguaje.Items.Count];


                objMaterial.IdMaterial = txtIdmaterial.Text;
                objMaterial.Titulo = txtTitulomaterial.Text;
                objMaterial.Descripcion = txtDescripcion.Text;
                objMaterial.Requerimientos = txtRequerimientos.Text;
                objMaterial.Tipo = txtTipomaterial.Text;
                objMaterial.Ruta = rutaMaterial;
                objMaterial.Imagen = rutaImagen;
                //objMaterial.FechaIngreso = DateTime.Parse(txtfechaIngreso.Text);
                //objMaterial.FechaModificacion = DateTime.Parse(txtFechamodificacion.Text);
                objMaterial.Propietario = txtPropietario.Text;
                objMaterial.Movil = checkMovil.Checked;
                objMaterial.Costo = Double.Parse(txtCosto.Text);

                for (int i = 0; i < listBoxArea.Items.Count; i++)
                {
                    // replicar en los demás metadatos
                    Console.WriteLine("listBoxArea: " + listBoxArea.ToString());
                    Console.WriteLine("listBoxArea.Itemns.Count: " + listBoxArea.Items.Count);
                    objAreas[i] = new Area();
                    objAreas[i].Nombre = listBoxArea.Items[i].Text;
                    Console.WriteLine("objAreas[" + i + "]: " + objAreas[i].Nombre);
                }

                for (int i = 0; i < listBoxAudiencia.Items.Count; i++)
                {
                    objAudiencias[i] = new Audiencia();
                    objAudiencias[i].Nombre = listBoxAudiencia.Items[i].Text;
                }

                for (int i = 0; i < listBoxAutor.Items.Count; i++)
                {
                    objAutores[i] = new Autor();
                    objAutores[i].Nombre = listBoxAutor.Items[i].Text;
                }

                for (int i = 0; i < listBoxFormato.Items.Count; i++)
                {
                    objFormatos[i] = new Formato();
                    objFormatos[i].Nombre = listBoxFormato.Items[i].Text;
                }

                for (int i = 0; i < listBoxKeyword.Items.Count; i++)
                {
                    objKeywords[i] = new Keyword();
                    objKeywords[i].Nombre = listBoxKeyword.Items[i].Text;
                }

                for (int i = 0; i < listBoxLenguaje.Items.Count; i++)
                {
                    objLenguajes[i] = new Lenguaje();
                    objLenguajes[i].Nombre = listBoxLenguaje.Items[i].Text;
                }

                objMaterial.Areas = objAreas;
                objMaterial.Audiencia = objAudiencias;
                objMaterial.Autores = objAutores;
                objMaterial.Formatos = objFormatos;
                objMaterial.Keywords = objKeywords;
                objMaterial.Lenguajes = objLenguajes;

                controlMaterial objControl = new controlMaterial(objMaterial);
                labelMaterial.Text = objControl.modificarMaterial();

            }
            catch (Exception objExc)
            {
                labelMaterial.Text = objExc.Message;
            }
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                Material objMaterial = new Material();
                objMaterial.IdMaterial = txtIdmaterial.Text;
                controlMaterial objControl = new controlMaterial(objMaterial);
                labelMaterial.Text = objControl.Eliminar();
            }
            catch (Exception objExc)
            {
                labelMaterial.Text = objExc.Message;
            }
        }

        protected void SqlDataSource1_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {

        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        protected void dropAutor_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }


        //--------Boton Autor
        protected void agregarAutor_Click(object sender, EventArgs e)
        {
            if (!listBoxAutor.Items.Contains(dropAutor.SelectedItem))
            {
                listBoxAutor.Items.Add(dropAutor.SelectedItem);
            }   
        }

        protected void quitarAutor_Click(object sender, EventArgs e)
        {
            listBoxAutor.Items.Remove(listBoxAutor.Items[listBoxAutor.SelectedIndex]);
        }
        //--------

        //--------Boton Area

        protected void agregarArea_Click(object sender, EventArgs e)
        {
            if (!listBoxArea.Items.Contains(dropArea.SelectedItem))
            {
                listBoxArea.Items.Add(dropArea.SelectedItem);
            }
        }

        protected void quitarArea_Click(object sender, EventArgs e)
        {
            listBoxArea.Items.Remove(listBoxArea.Items[listBoxArea.SelectedIndex]);
        }
        //--------

        //--------Boton Audiencia

        protected void agregarAudiencia_Click(object sender, EventArgs e)
        {
            if (!listBoxAudiencia.Items.Contains(dropAudiencia.SelectedItem))
            {
                listBoxAudiencia.Items.Add(dropAudiencia.SelectedItem);
            }
        }

        protected void quitarAudiencia_Click(object sender, EventArgs e)
        {
            listBoxAudiencia.Items.Remove(listBoxAudiencia.Items[listBoxAudiencia.SelectedIndex]);
        }

        //--------

        //--------Boton Lenguaje

        protected void agregarLenguaje_Click(object sender, EventArgs e)
        {
            if (!listBoxLenguaje.Items.Contains(dropLenguaje.SelectedItem))
            {
                listBoxLenguaje.Items.Add(dropLenguaje.SelectedItem);
            }
        }

        protected void quitarLenguaje_Click(object sender, EventArgs e)
        {
            listBoxLenguaje.Items.Remove(listBoxLenguaje.Items[listBoxLenguaje.SelectedIndex]);
        }

        //--------


        //--------Boton Keyword
        protected void agregarKeyword_Click(object sender, EventArgs e)
        {
            if (!listBoxKeyword.Items.Contains(dropKeyword.SelectedItem))
            {
                listBoxKeyword.Items.Add(dropKeyword.SelectedItem);
            }
        }

        protected void quitarKeyword_Click(object sender, EventArgs e)
        {
            listBoxKeyword.Items.Remove(listBoxKeyword.Items[listBoxKeyword.SelectedIndex]);
        }
        //--------

        //--------Boton Formato
        protected void agregarFormato_Click(object sender, EventArgs e)
        {
            if (!listBoxFormato.Items.Contains(dropFormato.SelectedItem))
            {
                listBoxFormato.Items.Add(dropFormato.SelectedItem);
            }
        }

        protected void quitarFormato_Click(object sender, EventArgs e)
        {
            listBoxFormato.Items.Remove(listBoxFormato.Items[listBoxFormato.SelectedIndex]);
        }
        //--------

        protected void listBoxAutor_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void txtCosto_TextChanged(object sender, EventArgs e)
        {

        }

        //protected void listBoxAutor_DoubleClick(object sender, EventArgs e)
        //{
        //    //listBoxAutor.Items.Remove(listBoxAutor.Items[listBoxAutor.SelectedIndex]);
        //}


    }
}