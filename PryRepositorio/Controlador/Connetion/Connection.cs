using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace PryRepositorio.Controlador.Connetion
{
    public class Connection:generic.Config
    {
        public void OpenSqlConnection()
        {
            con.Open();
        }

        public void CloseSqlConnection()
        {
            con.Close();
        }

        public SqlConnection Conexion()
        {
            return con;
        }
    }
}