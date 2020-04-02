<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FrmMaterial.aspx.cs" Inherits="PryRepositorio.FrmMateriales" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 228px;
        }
        .auto-style2 {
            width: 228px;
            height: 23px;
        }
        .auto-style3 {
            height: 23px;
        }
        .auto-style4 {
            margin-left: 0px;
        }
        .auto-style5 {
            height: 23px;
            width: 436px;
        }
        .auto-style6 {
            width: 436px;
            margin-left: 40px;
        }
        .auto-style7 {
            width: 83%;
        }
        .auto-style9 {
            width: 166px;
            height: 30px;
        }
        .auto-style10 {
            width: 181px;
            height: 30px;
        }
        .auto-style11 {
            height: 30px;
        }
        .auto-style12 {
            width: 228px;
            height: 59px;
        }
        .auto-style13 {
            width: 436px;
            height: 59px;
            display: inline;
        }
        .auto-style14 {
            width: 228px;
            height: 42px;
        }
        .auto-style15 {
            width: 436px;
            height: 42px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <table class="auto-style7">
            <tr>
                <td class="auto-style3" colspan="2" style="text-align: center">MATERIAL</td>
            </tr>
            <tr>
                <td class="auto-style2">ID MATERIAL</td>
                <td class="auto-style5">
                    <asp:TextBox ID="txtIdmaterial" runat="server" CssClass="auto-style4" Width="531px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">TÍTULO</td>
                <td class="auto-style6">
                    <asp:TextBox ID="txtTitulomaterial" runat="server" Width="532px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">DESCRIPCIÓN</td>
                <td class="auto-style6">
                    <asp:TextBox ID="txtDescripcion" runat="server" Width="534px" Height="124px"></asp:TextBox>
                </td>
                <td>
                    <asp:Image ID="Image1" runat="server" Height="120px" />
                    <asp:FileUpload ID="FileUploadImg" runat="server" />
                </td>
            </tr>
            <td class="auto-style1">REQUERIMIENTOS TÉCNICOS</td>
                <td class="auto-style6">
                    <asp:TextBox ID="txtRequerimientos" runat="server" Width="534px" Height="124px"></asp:TextBox>
                </td>
                <td><asp:Button ID="botonDescargar" runat="server" Text="Descargar Material" /></td>
            <tr>
                <td class="auto-style1">TIPO</td>
                <td class="auto-style6">
                    <asp:TextBox ID="txtTipomaterial" runat="server" Width="532px"></asp:TextBox>
                </td>
            </tr>
            
            <tr>
                <td>PROPIETARIO</td>
                <td class="auto-style6">
                    <asp:TextBox ID="txtPropietario" runat="server" Width="532px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style14">COMPATIBILIDAD MOVIL</td>
                <td class="auto-style15">

                    <asp:CheckBox ID="checkMovil" runat="server" OnCheckedChanged="CheckBox1_CheckedChanged" />

                </td>
            </tr>
			<tr>
				<td class="auto-style12">AUTOR</td>
			    <td class="auto-style13">
                    <asp:DropDownList ID="dropAutor" runat="server" DataSourceID="SqlDataSource1" DataTextField="nombre" DataValueField="codigo">
					</asp:DropDownList>
					<asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [nombre], [codigo] FROM [AUTORES]" OnSelecting="SqlDataSource1_Selecting"></asp:SqlDataSource>
                    <div>
                    <asp:Button ID="agregarAutor" runat="server" Text="Agregar" OnClick="agregarAutor_Click" display="block" />
                    <asp:Button ID="quitarAutor" runat="server" OnClick="quitarAutor_Click" Text="Quitar" display="block" />
                    </div>
                    <asp:ListBox ID="listBoxAutor" runat="server" SelectionMode="Multiple"  ></asp:ListBox>
                </td>
                
			</tr>
            <tr>
                <td class="auto-style1">AREA</td>
			    <td class="auto-style6">
                    <asp:DropDownList ID="dropArea" runat="server" DataSourceID="SqlDataSource2" DataTextField="nombre" DataValueField="idArea">
					</asp:DropDownList>
					<asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [idArea], [nombre] FROM [AREA]" OnSelecting="SqlDataSource1_Selecting"></asp:SqlDataSource>
                    <asp:Button ID="agregarArea" runat="server" Text="Agregar" OnClick="agregarArea_Click" display="block" />
                    <asp:Button ID="quitarArea" runat="server" OnClick="quitarArea_Click" Text="Quitar" display="block" />
                    <asp:ListBox ID="listBoxArea" runat="server" SelectionMode="Multiple"></asp:ListBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">AUDIENCIA</td>
			    <td class="auto-style6">
                    <asp:DropDownList ID="dropAudiencia" runat="server" DataSourceID="SqlDataSource3" DataTextField="audiencia" DataValueField="id">
					</asp:DropDownList>
					<asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [id], [audiencia] FROM [AUDIENCIA]" OnSelecting="SqlDataSource1_Selecting"></asp:SqlDataSource>
                    <asp:Button ID="agregarAudiencia" runat="server" Text="Agregar" OnClick="agregarAudiencia_Click" display="block" />
                    <asp:Button ID="quitarAudiencia" runat="server" OnClick="quitarAudiencia_Click" Text="Quitar" display="block" />
                    <asp:ListBox ID="listBoxAudiencia" runat="server" SelectionMode="Multiple"></asp:ListBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">LENGUAJE</td>
			    <td class="auto-style6">
                    <asp:DropDownList ID="dropLenguaje" runat="server" DataSourceID="SqlDataSource4" DataTextField="lenguaje" DataValueField="id">
					</asp:DropDownList>
					<asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [id], [lenguaje] FROM [LENGUAJE]" OnSelecting="SqlDataSource1_Selecting"></asp:SqlDataSource>
                    <asp:Button ID="agregarLenguaje" runat="server" Text="Agregar" OnClick="agregarLenguaje_Click" display="block" />
                    <asp:Button ID="quitarLenguaje" runat="server" OnClick="quitarLenguaje_Click" Text="Quitar" display="block" />
                    <asp:ListBox ID="listBoxLenguaje" runat="server" SelectionMode="Multiple"></asp:ListBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">PALABRAS CLAVE</td>
			    <td class="auto-style6">
                    <asp:DropDownList ID="dropKeyword" runat="server" DataSourceID="SqlDataSource5" DataTextField="keyword" DataValueField="id">
					</asp:DropDownList>
					<asp:SqlDataSource ID="SqlDataSource5" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [id], [keyword] FROM [KEYWORD]" OnSelecting="SqlDataSource1_Selecting"></asp:SqlDataSource>
                    <asp:Button ID="agregarKeyword" runat="server" Text="Agregar" OnClick="agregarKeyword_Click" display="block" />
                    <asp:Button ID="quitarKeyword" runat="server" OnClick="quitarKeyword_Click" Text="Quitar" display="block" />
                    <asp:ListBox ID="listBoxKeyword" runat="server" SelectionMode="Multiple"></asp:ListBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">FORMATO</td>
			    <td class="auto-style6">
                    <asp:DropDownList ID="dropFormato" runat="server" DataSourceID="SqlDataSource6" DataTextField="formato" DataValueField="id">
					</asp:DropDownList>
					<asp:SqlDataSource ID="SqlDataSource6" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT * FROM [FORMATO]" OnSelecting="SqlDataSource1_Selecting"></asp:SqlDataSource>
                    <asp:Button ID="agregarFormto" runat="server" Text="Agregar" OnClick="agregarFormato_Click" display="block" />
                    <asp:Button ID="quitarFormato" runat="server" OnClick="quitarFormato_Click" Text="Quitar" display="block" />
                    <asp:ListBox ID="listBoxFormato" runat="server" SelectionMode="Multiple"></asp:ListBox>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">COSTO</td>
			    <td class="auto-style6">
                    <asp:TextBox ID="txtCosto" runat="server" Width="532px" OnTextChanged="txtCosto_TextChanged"></asp:TextBox>
                </td>
            </tr>
			<tr>
				<td class="auto-style1">FECHA DE INGRESO</td>
                <td class="auto-style6">
                    <asp:Label ID="labelFechaIngreso" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">FECHA DE MODIFICACIÓN</td>
                <td class="auto-style6">
                    <asp:Label ID="labelFechaModificacion" runat="server" Text="Label"></asp:Label>
                </td>
            </tr>
            <tr>
                <td class="auto-style1">SUBIR MATERIAL</td>
                <td class="auto-style6">
                    
                    <asp:FileUpload ID="FileUploadMaterial" runat="server" />
                    
                </td>
            </tr>

        </table>
        <table style="width: 100%;">
            <tr>
                <td class="auto-style11">
                    <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
                    </td>
                    <td class="auto-style10">
                    <asp:Button ID="btnConsultar" runat="server" Text="Consultar" style="margin-left: 0px" OnClick="btnConsultar_Click" />
                    </td>
                        <td class="auto-style9">
                    <asp:Button ID="btnModificar" runat="server" Text="Modificar" OnClick="btnModificar_Click" />
                    </td>
                <td class="auto-style11">
                    <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" />            
                    </td>
				
            </tr>
            </table>
        <asp:Label ID="labelMaterial" runat="server" Text="Label"></asp:Label>
    </form>
</body>
</html>
