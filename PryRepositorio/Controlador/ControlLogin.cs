using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using PryRepositorio.Modelo;
using PryRepositorio.Controlador.Connetion;

namespace PryRepositorio.Controlador
{
    public class ControlLogin
    {
        string userID, contrasena, tipo;

        public ControlLogin()
        {
        }

        public ControlLogin (Usuario user)
        {
            this.userID = user.NombreU;
            this.contrasena = user.Contrasena;
            this.tipo = user.Tipo;
        }

        public bool IniciarSesion()
        {
            Usuario usuario = new Usuario();
            Connection con = new Connection();
            SqlCommand com = new SqlCommand();


            try
            {
                con.OpenSqlConnection();
                com.Connection = con.Conexion();
                com.CommandType = CommandType.StoredProcedure;
                com.CommandText = "Inicio_Sesion";
                com.Parameters.Add("@usuario", SqlDbType.NVarChar).Value = userID;
                com.Parameters.Add("@contraseña", SqlDbType.NVarChar).Value = contrasena;
                SqlDataReader reader = com.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();
                    userID=(reader["nombreUsr"].ToString());
                    contrasena=(reader["contrasena"].ToString());
                    tipo = (reader["tipo"].ToString());

                    reader.Close();
                    reader = null;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
            finally
            {
                con.CloseSqlConnection();
                usuario = null;
                com = null;
                con = null;
            }
        }


        public bool ValidarUsuario()
        {
            
            Connection con = new Connection();
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter dt = new SqlDataAdapter();
            DataTable tabla = new DataTable();

            try
            {

                con.OpenSqlConnection();
                SqlDataAdapter da = new SqlDataAdapter("ValidarUsuario", con.Conexion());
                da.SelectCommand.CommandType = CommandType.StoredProcedure;
                da.SelectCommand.Parameters.Add("@usuario", SqlDbType.VarChar, 100);
                da.SelectCommand.Parameters["@usuario"].Value= userID;
                da.Fill(tabla);

                if (tabla.Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch(Exception ex)
            {
                return false;
            }
            finally
            {
                con.CloseSqlConnection();
                cmd = null;
                dt = null;
                tabla = null;
            }
        }


        public bool Registrar()
        {
            Conexion con = new Conexion();
            try
            {
                SqlCommand cmd = new SqlCommand("procRegistrarUsr", con.Conex);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@nombreUsr", SqlDbType.VarChar, 10);
                cmd.Parameters.Add("@contrasena", SqlDbType.VarChar, 50);
                cmd.Parameters.Add("@tipo", SqlDbType.VarChar, 10);
                cmd.Parameters["@nombreUsr"].Value = userID;
                cmd.Parameters["@contrasena"].Value = contrasena;
                cmd.Parameters["@tipo"].Value = tipo;
                con.Conex.Open();
                cmd.ExecuteNonQuery();
                con.Conex.Close();
                return true;

            }
            catch (Exception objExc)
            {
                return false;
            }
           
        }

        //    Modelo.Usuario usuario = new Modelo.Usuario();
        //    Connetion.Connection con = new Connetion.Connection();
        //    SqlCommand cmd = new SqlCommand();

        //    try
        //    {

        //        con.OpenSqlConnection();
        //        cmd.Connection = con.Conexion();
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.CommandText = "procRegistrarUsr";
        //        cmd.Parameters.Add("@nombreUsr", SqlDbType.VarChar).Value = usuario.NombreU;
        //        cmd.Parameters.Add("@contrasena", SqlDbType.VarChar).Value = usuario.Contrasena;
        //        cmd.Parameters.Add("@tipo", SqlDbType.VarChar).Value = usuario.Tipo;

        //        int reader = cmd.ExecuteNonQuery();

        //        if (reader > 0)
        //        {
        //            return true;
        //        }
        //        else
        //        {
        //            return false;
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }
        //    finally
        //    {
        //        con.CloseSqlConnection();
        //        cmd = null;
        //        usuario = null;
        //    }
        //}

    }
       
}
