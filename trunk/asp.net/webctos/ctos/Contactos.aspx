<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Contactos.aspx.cs" Inherits="ctos_Contactos" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>WebCtos - Mis WebCtos</title>
    <link href="../StyleSheet.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div id="divLinks">
            <table>
                <tr>
                    <td><asp:HyperLink ID="HyperAgregar" runat="server" NavigateUrl="contactos.aspx">Agregar Nuevo</asp:HyperLink></td>
                    <td><asp:HyperLink ID="HyperCerrar" runat="server" NavigateUrl="~/Login.aspx?action=signout" >Cerrar sesión</asp:HyperLink></td>
                </tr>
            </table>
        </div>
        <div id="divGrid">
            <asp:GridView ID="grdContactos" runat="server" CellPadding="4" 
                ForeColor="#333333" GridLines="None" onrowdeleting="borrandoFila" 
                onrowediting="editandoFila" AllowPaging="False" AllowSorting="True" 
                onsorting="alOrdenar" PageSize="500">
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <RowStyle BackColor="#EFF3FB" />
                <Columns>
                    <asp:CommandField EditText="Editar" ShowEditButton="True" />
                    <asp:BoundField />
                </Columns>
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <EditRowStyle BackColor="#2461BF" />
                <AlternatingRowStyle BackColor="White" />
            </asp:GridView>
        </div>
        <div id="divAgContacto" class="divTablaEditar">
        <div id="divTituloAg">
            <asp:Label ID="lblTituloTabla" runat="server">Agregar contacto</asp:Label>
        </div>
         <table>
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
                        Text="Agregar"/><asp:Button ID="btnCancelar" runat="server" text="Cancelar" 
                        onclick="btnCancelar_Click"/></td>
                <td></td>
            </tr>
        </table>    
        </div>
    </form>
</body>
</html>
