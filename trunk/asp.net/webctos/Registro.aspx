<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Registro.aspx.cs" Inherits="Registro" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>WebCtos - Registro</title>
    <link href="StyleSheet.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    
    <div class="divTablaEditar">
    <div id="divTituloAg">
            <asp:Label ID="lblTituloTabla" runat="server">Registrar cuenta</asp:Label>
        </div>
    <table>
            <tr>
                <td>Usuario: </td>
                <td><asp:TextBox ID="txtUser" runat="server"></asp:TextBox></td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                        ControlToValidate="txtUser">*</asp:RequiredFieldValidator></td>
                <td><asp:Label ID="lblUsuarioExiste" runat="server" ForeColor="Red"></asp:Label></td>
            </tr>
            <tr>
                <td>Contraseña: </td>
                <td><asp:TextBox ID="txtPass" runat="server" TextMode="Password"></asp:TextBox></td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                        ControlToValidate="txtPass">*</asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td>Repetir Contraseña: </td>
                <td><asp:TextBox ID="txtRePass" TextMode="Password" runat="server"></asp:TextBox></td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                        ControlToValidate="txtRePass">*</asp:RequiredFieldValidator></td>
                        <td>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" 
                        ErrorMessage="CompareValidator" ControlToCompare="txtPass" 
                        ControlToValidate="txtRePass">No coincide</asp:CompareValidator></td>
            </tr>
            <tr>
                <td>E-mail: </td>
                <td><asp:TextBox ID="txtEmail" runat="server"></asp:TextBox></td>
                <td>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                        ControlToValidate="txtEmail">*</asp:RequiredFieldValidator></td>
            </tr>
            
            <tr>
                <td></td>
                <td><asp:Button ID="btnRegistro" runat="server" 
                        Text="Registrarme" onclick="btnRegistro_Click" /></td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
