using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PryRepositorio.Modelo
{
    public class Area
    {
        String idArea;
        String nombre;
        String fkidArea;

        public string IdArea { get => idArea; set => idArea = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string FkidArea { get => fkidArea; set => fkidArea = value; }

        public Area(string idArea, string nombre, string fkidArea)
        {
            this.idArea = idArea;
            this.nombre = nombre;
            this.fkidArea = fkidArea;
        }

        public Area()
        {
            this.idArea = "";
            this.nombre = "";
            this.fkidArea = "";
        }

       

       
    }
}