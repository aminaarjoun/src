<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>WebCtos - Login</title>
    <link href="StyleSheet.css" rel="stylesheet" type="text/css" />
</head>
<body>
<center>
    <form id="form1" runat="server">
    <div id="Login">
  
        <div id="Titulo">
            Inicio de Sesión
        </div>
        <div id="Controles">
        <table>
            
            <tr>
                <td>Usuario:</td>
                <td><asp:TextBox ID="txtUser" runat="server" ></asp:TextBox></td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUser">*</asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td>Contraseña:</td>
                <td><asp:TextBox ID="txtPass" runat="server" TextMode="Password" ></asp:TextBox></td>
                <td><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPass">*</asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td></td>
                <td><asp:Label ID="lblError" runat="server" ForeColor="Red" ></asp:Label></td>
            </tr>
        </table>
        <div id="btnEntrar">
        <asp:Button ID="btnLogin" runat="server" Text="Entrar" OnClick="btnLogin_Click" />
        
        </div>
    </div>
   <div id="link"><asp:HyperLink ID="linkReg" runat="server" Text="Registrarme" 
           NavigateUrl="~/Registro.aspx" ></asp:HyperLink></div>
</div>
        
    </form>
    </center>
</body>
</html>
