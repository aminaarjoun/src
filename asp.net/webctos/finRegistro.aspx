<%@ Page Language="C#" AutoEventWireup="true" CodeFile="finRegistro.aspx.cs" Inherits="finRegistro" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>WebCtos - Cuenta comprobada</title>
    <link href="StyleSheet.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="divTablaEditar">
        <br />
        <asp:Label ID="lblMensaje" runat="server"></asp:Label>    
        <br />
        <br />
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/ctos/contactos.aspx">Empezar a agregar contactos!</asp:HyperLink>
        <br />
    </div>
    </form>
</body>
</html>
