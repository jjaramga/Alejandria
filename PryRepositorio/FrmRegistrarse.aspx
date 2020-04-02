<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmRegistrarse.aspx.cs" Inherits="PryRepositorio.Registrarse" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" lang="en">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <link href="Vista/bootstrap-3.3.7-dist/css/bootstrap-theme.min.css" rel="stylesheet" />
    <link href="Vista/bootstrap-3.3.7-dist/css/bootstrap.min.css" rel="stylesheet" />
    <script src="Vista/bootstrap-3.3.7-dist/js/bootstrap.min.js"></script>
    <link href="Vista/CSS/StyleV1.css" rel="stylesheet" />
    <title>Registro - Biblioteca digital</title>
    
</head>
<body>
<div class="container">
<div class="login-form">
<div class="main-div">
    <div class="panel">
   <h2>Registro</h2>
        <br />
<asp:Label ID="txtMsg" runat="server" Text="" CssClass="alert alert-danger" Visible="false"></asp:Label>
   </div>
    <form  runat="server">

        <div class="form-group">
            <label>Usuario</label>
            <asp:TextBox ID="txtUser" runat="server" CssClass="form-control" ></asp:TextBox>

        </div>

        <div class="form-group">
            <label>Contraseña</label>
            <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
        </div>

        <div class="form-group">
            <label>Confirmar Contraseña</label>
            <asp:TextBox ID="txtPassword2" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
        </div>
    
        <br />
        <asp:Button ID="btnLogin" runat="server" Text="Registrarse" CssClass="btn btn-primary" OnClick="btnLogin_Click" />


    </form>
    </div>
<p class="botto-text"> Desarrollo de software</p>
</div>

</div>


</body>
</html>
