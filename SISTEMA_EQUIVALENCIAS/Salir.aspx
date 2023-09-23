<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Salir.aspx.cs" Inherits="SISTEMA_EQUIVALENCIAS.Salir" %>

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
               <h1>Desea salir realmente?</h1>
    <div>
        <asp:Label ID="lblUserDetails" runat="server" Text=""></asp:Label>
        <br />
        <asp:Button ID="btnLogout" runat="server" Text="Cerrar Sesion" OnClick="btnLogout_Click" />
         <br />
         <br />
         <asp:Button ID="btnLogin" runat="server" Text="Regresar" OnClick="btnLogin_Click" />
    </div>
    </form>
</body>
</html>

