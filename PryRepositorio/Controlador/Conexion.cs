using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data; // Lo uso para crear el metodo ejecutarConsulta que retorna un DataSet

namespace PryRepositorio.Controlador
{
    class Conexion
    {
        String cadenaConexion;
        String comando;
        SqlConnection conex;
        DataSet DS;
        SqlDataAdapter adapter;
        SqlCommand cmd;


        public string CadenaConexion { get => cadenaConexion; set => cadenaConexion = value; }
        public string Comando { get => comando; set => comando = value; }
        public SqlConnection Conex { get => conex; set => conex = value; }
        public DataSet DS1 { get => DS; set => DS = value; }
        public SqlDataAdapter Adapter { get => adapter; set => adapter = value; }

        public Conexion()
        {
            cadenaConexion = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\JuanFeLds\Documents\Desarrollo Software\Proyecto Alejandria\PryRepositorio20181105\PryRepositorio\App_Data\BDRepositorio.mdf; Integrated Security = True";
            
            Comando = "";
            Conex = new SqlConnection(CadenaConexion);
            cmd = new SqlCommand();
            DS1 = new DataSet();
            Adapter = new SqlDataAdapter();
        }

        public DataSet EjecutarCosulta(String comando)
        {
            Conex.Open();
            Adapter = new SqlDataAdapter(comando, Conex);

            Adapter.Fill(DS1);
            Conex.Close();

            return DS1;
        }
    }
}
