<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Agregar.aspx.cs" Inherits="ctos_Agregar" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>WebCtos - Agregar contacto</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table>
            <tr>
                <td><asp:Label ID="lblMensaje" runat="server" ForeColor="CornflowerBlue"></asp:Label></td>
            </tr>
            <tr>
                <td>Nombre: </td>
                <td><asp:TextBox ID="txtNombre" runat="server"></asp:TextBox></td>
                <td><asp:RequiredFieldValidator ID="reqNombre" runat="server" 
                        ControlToValidate="txtNombre">*</asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td>Apellido: </td>
                <td><asp:TextBox ID="txtApellido" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>E-mail: </td>
                <td><asp:TextBox ID="txtEmail" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Celular: </td>
                <td><asp:TextBox ID="txtCelular" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Tel. casa: </td>
                <td><asp:TextBox ID="txtCasa" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Tel. trabajo: </td>
                <td><asp:TextBox ID="txtTelTrab" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Calidad: </td>
                <td><asp:DropDownList ID="dropCalidad" runat="server">
                    <asp:ListItem Value="0">Muy Buena</asp:ListItem>
                    <asp:ListItem Value="1">Buena</asp:ListItem>
                    <asp:ListItem Value="2">Mala</asp:ListItem>
                    </asp:DropDownList></td>
            </tr>
            <tr>
                <td></td>
                <td><asp:Button ID="btnAgregar" runat="server" onclick="btnAgregar_Click" 
                        Text="Agregar y continuar" /></td>
            </tr>
            <tr>
                <td></td>
                <td><asp:Button ID="btnFinalizar" runat="server"
                        Text="Agregar y finalizar" onclick="btnFinalizar_Click" /></td>       
            </tr>
        </table>    
    </div>
    </form>
</body>
</html>
