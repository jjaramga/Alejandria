<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmLogin.aspx.cs" Inherits="PryRepositorio.FormUsuarios" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" lang="en">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="Vista/bootstrap-3.3.7-dist/css/bootstrap-theme.min.css" rel="stylesheet" />
    <link href="Vista/bootstrap-3.3.7-dist/css/bootstrap.min.css" rel="stylesheet" />
    <script src="Vista/bootstrap-3.3.7-dist/js/bootstrap.min.js"></script>
    <link href="Vista/CSS/StyleV1.css" rel="stylesheet" />
    <title>Biblioteca digital</title>

</head>
<body>
    <div class="container">
        <div class="login-form">
            <div class="main-div">
                <div class="panel">
                    <h2>Login</h2>
                    <p>Please enter your email and password</p>
                    <asp:Label ID="txtMsg" runat="server" Text="" CssClass="alert alert-danger" Visible="false"></asp:Label>
                </div>
                <form runat="server">

                    <div class="form-group">

                        <asp:TextBox ID="txtUsuario" runat="server" CssClass="form-control"></asp:TextBox>

                    </div>

                    <div class="form-group">

                        <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                    
                    </div>

                    <div class="forgot">
                       <a href="reset.html">¿Olvidaste contraseña?</a>
                    </div>
                    <asp:Button ID="btnlogin" runat="server" Text="Iniciar Sesión" OnClick="BtnIniciarSesion" CssClass="btn btn-primary" />


                </form>
            </div>
            <p class="botto-text">Desarrollo de software</p>
        </div>

    </div>


</body>
</html>
