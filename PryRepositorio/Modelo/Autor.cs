using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PryRepositorio.Modelo
{
    public class Autor
    {
        String codigo;
        String nombre;
        String nacionalidad;

        public Autor()
        {
            this.Codigo = "";
            this.Nombre = "";
            this.Nacionalidad = "";
        }

        public Autor(string codigo, string nombre, String nacionalidad)
        {
            this.Codigo = codigo;
            this.Nombre = nombre;
            this.Nacionalidad = nacionalidad;
        }

        public string Codigo { get => codigo; set => codigo = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Nacionalidad { get => nacionalidad; set => nacionalidad = value; }
    }
}