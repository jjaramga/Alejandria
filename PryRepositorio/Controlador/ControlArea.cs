using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using PryRepositorio.Modelo;

namespace PryRepositorio.Controlador { 

    public class ControlArea
    {
        String idArea;
        String nombre;
        String fkidArea;
        Conexion objCon = new Conexion();
       

        public ControlArea(Area objArea)
        {
            this.idArea = objArea.IdArea;
            this.nombre = objArea.Nombre;
            this.fkidArea = objArea.FkidArea;
            
        }

        public String Guardar()
        {
            String mensaje = "";
            try
            {
                
                SqlCommand cmd = new SqlCommand("procInsertArea", objCon.Conex);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@idArea", SqlDbType.VarChar, 10);
                cmd.Parameters.Add("@nombre", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@fkArea", SqlDbType.VarChar, 10);

                cmd.Parameters["@idArea"].Value = idArea;
                cmd.Parameters["@nombre"].Value = nombre;
                cmd.Parameters["@fkArea"].Value = fkidArea;

                objCon.Conex.Open();
                cmd.ExecuteNonQuery();
                objCon.Conex.Close();
                mensaje = "RESGISTRO GUARDADO";
            }
            catch (Exception objExc)
            {
                mensaje = objExc.Message;
            }
            return mensaje;
        }

        public String Modificar()
        {
            String mensaje = "";
            try
            {
                SqlCommand cmd = new SqlCommand("procModificarArea", objCon.Conex);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@idArea", SqlDbType.VarChar, 10);
                cmd.Parameters.Add("@nombre", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@fkArea", SqlDbType.VarChar, 10);

                cmd.Parameters["@idArea"].Value = idArea;
                cmd.Parameters["@nombre"].Value = nombre;
                cmd.Parameters["@fkArea"].Value = fkidArea;
                objCon.Conex.Open();
                cmd.ExecuteNonQuery();
                objCon.Conex.Close();
                mensaje = "RESGISTRO GUARDADO";
            }
            catch(Exception objExc)
            {
                mensaje = objExc.Message;
            }
            return mensaje;
        }

        public DataSet Consultar()
        {
            DataSet objDs = new DataSet();
            try
            {
                SqlCommand cmd = new SqlCommand("procConsultarArea", objCon.Conex);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@idArea", SqlDbType.VarChar, 10);
                cmd.Parameters["@idArea"].Value = idArea;
                objCon.Conex.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                
                da.Fill(objDs);
                objCon.Conex.Close();
            }
            catch(Exception objExc)
            {

            }

            return objDs;
        }

        public String Eliminar()
        {
            String mensaje = "";
            try
            {
                SqlCommand cmd = new SqlCommand("procEliminarArea", objCon.Conex);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@idArea", SqlDbType.VarChar, 10);
                cmd.Parameters["@idArea"].Value = idArea;
                objCon.Conex.Open();
                cmd.ExecuteNonQuery();
                objCon.Conex.Close();
                mensaje = "REGISTRO ELIMINADO";

            }
            catch(Exception objExc)
            {
                mensaje = objExc.Message;
            }
            return mensaje;
        }
    }
}
