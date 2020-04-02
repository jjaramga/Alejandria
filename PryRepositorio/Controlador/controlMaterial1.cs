using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using PryRepositorio.Modelo;

namespace PryRepositorio.Controlador
{
    public class ControlMaterial1
    {
        Conexion objCon;

        ControlMaterial1()
        {
            objCon = new Conexion();
        }

        public String guardarMaterial(Material material)
        {
            String mensaje = "";
            try
            {
                String comandoSql = String.Format(
                    "EXEC procInsertMaterial '{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}',{8},{9}",
                    material.IdMaterial, material.Titulo, material.Descripcion, material.Tipo, material.Imagen, material.Ruta, material.Propietario, material.Movil, material.Costo
                );
                
                objCon.EjecutarCosulta(comandoSql);

                //pendiente guardar en todas las tablas intermedias
            }
            catch(Exception objEx)
            {
                mensaje = objEx.Message;
            }
            return mensaje;
        }

        public String modificarMaterial(Material material)
        {
            String mensaje = "";
            try
            {
                String comandoSql = String.Format(
                    "EXEC procModificarMaterial '{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}',{8},{9}",
                    material.IdMaterial, material.Titulo, material.Descripcion, material.Tipo, material.Imagen, material.Ruta, material.Propietario, material.Movil, material.Costo
                );

                objCon.EjecutarCosulta(comandoSql);

                //pendiente guardar en todas las tablas intermedias
            }
            catch (Exception objEx)
            {
                mensaje = objEx.Message;
            }
            return mensaje;
        }

        
    }
}