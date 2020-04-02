using PryRepositorio.Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace PryRepositorio.Controlador
{
    public class ControlUsuario
    {
        String mensaje;
        public string Mensaje { get => mensaje; set => mensaje = value; }

        public ControlUsuario()
        {
            mensaje = "";
        }

        public String IngresarUsuario(Usuario usuario)
        {
            try
            {
                String comandoSql = String.Format("EXEC procInsertUsuario '{0}','{1}','{2}'", usuario.NombreU, usuario.Contrasena, usuario.Tipo);
                Conexion conexion = new Conexion();

                conexion.EjecutarCosulta(comandoSql);
                mensaje = "REGISTRO INGRESADO";
            }
            catch (Exception objEx)
            {
                mensaje = objEx.Message;
            }

            return mensaje;
        }

        public String ModificarUsuario(Usuario usuario)
        {
            try
            {
                String comandoSql = String.Format("EXEC procModificarUsuario '{0}','{1}','{2}'", usuario.NombreU, usuario.Contrasena, usuario.Tipo);
                Conexion conexion = new Conexion();

                conexion.EjecutarCosulta(comandoSql);
                mensaje = "REGISTRO MODFICADO EXITOSAMENTE";
            }
            catch (Exception objEx)
            {
                mensaje = objEx.Message;
            }

            return mensaje;
        }

        public DataSet ConsultarUsuario(Usuario usuario)
        {
            try
            {
                DataSet DS = new DataSet();
                String comandoSql = String.Format("EXEC procConsultarUsuario {0}", usuario.NombreU);
                Conexion conexion = new Conexion();

                return conexion.EjecutarCosulta(comandoSql);
            }
            catch (Exception objEx)
            {
                return null;
            }
        }

        public String EliminarUsuario(Usuario usuario)
        {
            try
            {
                String comandoSql = String.Format("EXEC procBorrarUsuario {0}", usuario.NombreU);
                Conexion conexion = new Conexion();

                conexion.EjecutarCosulta(comandoSql);
                mensaje = "REGISTRO BORRADO";
            }
            catch (Exception objEx)
            {
                mensaje = objEx.Message;
            }
            return mensaje;
        }
    }
}