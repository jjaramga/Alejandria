<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmInicio.aspx.cs" Inherits="PryRepositorio.FrmInicio" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="Vista/bootstrap-3.3.7-dist/css/bootstrap-theme.min.css" rel="stylesheet" />
    <link href="Vista/bootstrap-3.3.7-dist/css/bootstrap.min.css" rel="stylesheet" />
    <script src="Vista/bootstrap-3.3.7-dist/js/bootstrap.min.js"></script>
    <link href="Vista/CSS/StyleV1.css" rel="stylesheet" />

    <title>Inicio - Bliblioteca Digital</title>
</head>
<body>
    <form runat="server">
        <nav class="navbar navbar-default">
          <div class="container-fluid">
            <ul class="nav navbar-nav">
                <li class="active"><asp:LinkButton ID="btninicio" runat="server" > <span class="glyphicon glyphicon-home"></span>Inicio</asp:LinkButton></li>
                <li><asp:LinkButton ID="btnMaterial" runat="server" OnClick="btnMaterial_Click" ><span class="glyphicon glyphicon-send"></span> Materiales</asp:LinkButton></li>
                <li><asp:LinkButton ID="btnAutores" runat="server" OnClick="btnAutores_Click" ><span class="glyphicon glyphicon-th"></span> Autores</asp:LinkButton></li>
                <li><asp:LinkButton ID="btnCargar" runat="server"  OnClick="btnCargarMaterial_Click"><span class="glyphicon glyphicon-time"></span> Cargar Material</asp:LinkButton></li>
                <li><asp:LinkButton ID="btnArea" runat="server"   OnClick="btnArea_Click"><span class="glyphicon glyphicon-search"></span> Areas</asp:LinkButton></li>
                <li><asp:LinkButton ID="btngestionMaestros" runat="server"  Visible="false"><span class="glyphicon glyphicon-list-alt"></span> Gestión de Maestros</asp:LinkButton></li>
                <li><asp:LinkButton ID="btnadmUsuarios" runat="server"  Visible="false"><span class="glyphicon glyphicon-user"></span> Administración de Usuarios</asp:LinkButton></li>
            </ul>
            <ul class="nav navbar-nav navbar-right">
                <li><asp:LinkButton ID="btnayuda" runat="server" ><span class="glyphicon glyphicon-question-sign"></span> Ayuda</asp:LinkButton></li>
                <li><asp:LinkButton ID="btnIniciarSesion" runat="server" OnClick="btnIniciarSesion_Click" ><span class="glyphicon glyphicon-cog"></span> Iniciar Sesión</asp:LinkButton></li>
                <li><asp:LinkButton ID="btnRegistrarse" runat="server" OnClick="btnRegistrarse_Click"><span class="glyphicon glyphicon-log-in"></span> Registrarse</asp:LinkButton></li>
            </ul>
          </div>
        </nav>
    </form>
    <div class="container">
        <h3>Misión</h3>
        <hr class="hr" />
        <p>La Biblioteca de la Universidad El Bosque es la extensión del conocimiento de su entorno. Se relaciona e interactúa con todas las áreas 
            de la Universidad para apoyar los procesos académicos de aprendizaje, docencia e investigación, conectando a su comunidad y a la sociedad con la información, 
            acompañándolos en los procesos de descubrimiento y creación de nuevo conocimiento.</p>
        
        <br />
        <h3>Visión</h3>
        <hr class="hr" />
        <p>Ser reconocida en los próximos 7 años como ventaja competitiva de la Universidad. La Biblioteca será un referente para las
            bibliotecas universitarias a nivel local y regional. Se caracterizará por el alto nivel de calidad en el servicio, la experiencia
            de sus usuarios, el apoyo al crecimiento personal y profesional de sus visitantes y su aporte para el mejoramiento de la investigación y la calidad de la educación en Colombia.</p>
        
        <br />
    </div>
    <br />
    <div class="container">
        <hr class="hr" />
    </div>
    <footer class="footer">
        <div class="container">
            <p class="text-muted text-center"> Biblioteca Digital - Facultad de Ingenieria - Sistemas de Información - 2018 - Todos los derechos reservados.   /  </p>
        </div> 
    </footer>
</body>
</html>
