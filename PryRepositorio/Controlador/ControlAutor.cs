using PryRepositorio.Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace PryRepositorio.Controlador
{
    public class ControlAutor
    {
        String mensaje;
        Conexion objCon = new Conexion();

        public string Mensaje { get => mensaje; set => mensaje = value; }

        public ControlAutor()
        {
            Mensaje = "";
        }

        public void GuardarMaterialAutor(String IdMaterial, int CodigoAutor)
        {
            try
            {
                String comandoSql = String.Format("EXEC InserMaterial_Autor '{0}',{1}", IdMaterial, CodigoAutor);
                Conexion conexion = new Conexion();
                conexion.EjecutarCosulta(comandoSql);
                
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.Add("@idMaterial", SqlDbType.VarChar, 10);
                //cmd.Parameters.Add("@idAutor", SqlDbType.Int);

                //cmd.Parameters["@idMaterial"].Value = IdMaterial;
                //cmd.Parameters["@idAutor"].Value = CodigoAutor;

            }
            catch (Exception objEx)
            {
                
            }
            
        }

        public String IngresarAutor(Autor autor)
        {
            try
            {
                String comandoSql = String.Format("EXEC procInsertAutor {0},'{1}', '{2}'", autor.Codigo, autor.Nombre, autor.Nacionalidad);
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

        public String ModificarAutor(Autor autor)
        {
            try
            {
                String comandoSql = String.Format("EXEC procModificarAutor {0},'{1}','{2}'", autor.Codigo, autor.Nombre, autor.Nacionalidad);
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

        public DataSet ConsultarAutor(Autor autor)
        {
            try
            {
                DataSet DS = new DataSet();
                String comandoSql = String.Format("EXEC procConsultarAutor {0}", autor.Codigo);
                Conexion conexion = new Conexion();

                return conexion.EjecutarCosulta(comandoSql);
            }
            catch (Exception objEx)
            {
                return null;
            }
        }
    }
}