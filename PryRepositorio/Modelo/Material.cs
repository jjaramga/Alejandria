using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PryRepositorio.Modelo
{
    public class Material
    {
        String idMaterial;
        String titulo;
        String descripcion;
        String tipo;
        String imagen;
        String ruta;
        String propietario;

        Area[] areas;
        Audiencia[] audiencia;
        Autor[] autores;
        Keyword[] keywords;
        Lenguaje[] lenguajes;
        Formato[] formatos;
        String requerimientos;

        DateTime fechaIngreso;
        DateTime fechaModificacion;
        DateTime ?fechaIngreso2;
        DateTime ?fechaModificacion2;
        
        Boolean movil;
        Double costo;

        public Material()
        {
            this.idMaterial = "";
            this.titulo = "";
            this.descripcion = "";
            this.tipo = "";
            fechaIngreso2 = FechaIngreso;
            fechaModificacion2 = FechaModificacion;
            this.fechaIngreso2 = null;
            this.fechaModificacion2 = null;
            this.imagen = "";
            this.ruta = "";
            this.propietario = "";
            this.movil = false;
            this.costo = 0.0;

            this.areas = null;
            this.audiencia = null;
            this.autores = null;
            this.keywords = null;
            this.lenguajes = null;
            this.formatos = null;

        }

        public Material(string idMaterial, string titulo, string descripcion, string tipo, DateTime fechaIngreso, DateTime fechaModificacion, string imagen, string ruta, string propietario, Boolean movil, Double costo)
        {
            IdMaterial = idMaterial;
            Titulo = titulo;
            Descripcion = descripcion;
            Tipo = tipo;
            FechaIngreso = fechaIngreso;
            FechaModificacion = fechaModificacion;
            Imagen = imagen;
            Ruta = ruta;
            Propietario = propietario;
            Movil = movil;
            Costo = costo;
            
        }

        public Material(String idMaterial, String titulo, String descripcion,
            String tipo, String imagen, String ruta, String propietario,
            Area[] areas, Audiencia[] audiencia, Autor[] autores, Keyword[] keywords,
            Lenguaje[] lenguajes, Formato[] formatos, String requerimientos,
            DateTime fechaIngreso, DateTime fechaModificacion, DateTime? fechaIngreso2,
            DateTime? fechaModificacion2, Boolean movil, Double costo)
        {
            this.idMaterial = idMaterial;
            this.titulo = titulo;
            this.descripcion = descripcion;
            this.tipo = tipo;
            this.imagen = imagen;
            this.ruta = ruta;
            this.propietario = propietario;
            this.areas = areas;
            this.audiencia = audiencia;
            this.autores = autores;
            this.keywords = keywords;
            this.lenguajes = lenguajes;
            this.formatos = formatos;
            this.requerimientos = requerimientos;
            this.fechaIngreso = fechaIngreso;
            this.fechaModificacion = fechaModificacion;
            this.fechaIngreso2 = fechaIngreso2;
            this.fechaModificacion2 = fechaModificacion2;
            this.movil = movil;
            this.costo = costo;
        }

        public String IdMaterial { get => idMaterial; set => idMaterial = value; }
        public String Titulo { get => titulo; set => titulo = value; }
        public String Descripcion { get => descripcion; set => descripcion = value; }
        public String Tipo { get => tipo; set => tipo = value; }
        public String Imagen { get => imagen; set => imagen = value; }
        public String Ruta { get => ruta; set => ruta = value; }
        public String Propietario { get => propietario; set => propietario = value; }
        public Area[] Areas { get => areas; set => areas = value; }
        public Audiencia[] Audiencia { get => audiencia; set => audiencia = value; }
        public Autor[] Autores { get => autores; set => autores = value; }
        public Keyword[] Keywords { get => keywords; set => keywords = value; }
        public Lenguaje[] Lenguajes { get => lenguajes; set => lenguajes = value; }
        public Formato[] Formatos { get => formatos; set => formatos = value; }
        public String Requerimientos { get => requerimientos; set => requerimientos = value; }
        public DateTime FechaIngreso { get => fechaIngreso; set => fechaIngreso = value; }
        public DateTime FechaModificacion { get => fechaModificacion; set => fechaModificacion = value; }
        public DateTime? FechaIngreso2 { get => fechaIngreso2; set => fechaIngreso2 = value; }
        public DateTime? FechaModificacion2 { get => fechaModificacion2; set => fechaModificacion2 = value; }
        public Boolean Movil { get => movil; set => movil = value; }
        public Double Costo { get => costo; set => costo = value; }
        
    }
}