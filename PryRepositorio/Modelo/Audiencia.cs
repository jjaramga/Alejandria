using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PryRepositorio.Modelo
{
    public class Audiencia
    {
        int id;
        String nombre;

        public Audiencia()
        {
            this.id = 0;
            this.nombre = null;
        }

        public Audiencia(int id, string nombre)
        {
            this.id = id;
            this.nombre = nombre;
        }

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
    }
}