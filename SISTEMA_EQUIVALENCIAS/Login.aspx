<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SISTEMA_EQUIVALENCIAS.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
     <style>
        body{
            text-align:center;
        }
    </style>
</head>
<body style="background-image:url(Scripts/fondo.jpg); background-repeat: no-repeat; background-attachment: fixed">
    <form id="form1" runat="server">
        
        <h1>Sistema de Equivalencias Cunori USAC</h1>
        <div>
             <asp:Image ID="imgImagen" runat="server" ImageUrl="~/Scripts/Usac_logo.png" Width="150px" AlternateText="kyocode" />

        
            <table style="margin:auto;border:5px solid white">
        <tr>
            <td>
                <asp:Label ID="Label1" runat="server" Text="Usuario"></asp:Label></td>
            <td>
                <asp:TextBox ID="txtuss" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Label2" runat="server" Text="Contraseña"></asp:Label></td>
            <td>
                <asp:TextBox ID="txtpass" runat="server" TextMode="Password"></asp:TextBox></td>
        </tr>
        <tr>
            <td>
                </td>
            <td>
                 <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Ingresar" />
            </td>
        </tr>
        <tr>
            <td></td>
            <td>
                <asp:Label ID="lblerr" runat="server" Text="Datos Incorrectos" ForeColor="Red" Visible="False"></asp:Label></td>
        </tr>


         </table>
        </div>
    </form>
</body>
</html>
