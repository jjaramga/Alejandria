using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PryRepositorio.Modelo
{
    public class Usuario
    {
        String nombre ;
        String contrasena ;
        String tipo ;

        

        public Usuario()
        {
            this.nombre = "";
            this.contrasena = "";
            this.tipo = "";
        }

        public Usuario(String NombreUsr,String contrasena)
        {
            this.nombre = NombreUsr;
            this.contrasena = contrasena;
            this.tipo = "";
        }

        public Usuario(String NombreUsr, String contrasena, String tipo)
        {
            this.nombre = NombreUsr;
            this.contrasena = contrasena;
            this.tipo = tipo;
        }

        public string NombreU { get => nombre; set => nombre = value; }
        public string Contrasena { get => contrasena; set => contrasena = value; }
        public string Tipo { get => tipo; set => tipo = value; }


        /***********Actions *************/

        //public Boolean IniciarSesion()
        //{
        //    Controlador.ControlLogin controller = new Controlador.ControlLogin();
        //    return controller.IniciarSesion();
        //}

        //public Boolean ValidarUsuario()
        //{
        //    Controlador.ControlLogin controller = new Controlador.ControlLogin();
        //    return controller.ValidarUsuario();
        //}

        //public Boolean RegistrarUsuario()
        //{
        //    Controlador.ControlLogin controller = new Controlador.ControlLogin();
        //    return controller.Registrar();
        //}


       
}
}