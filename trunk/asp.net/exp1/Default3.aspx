<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default3.aspx.cs" Inherits="Default3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Listado de contactos</title>
    <link rel="stylesheet" type="text/css" href="StyleSheet2.css"/> 
    <script type="text/javascript">
        function Over(){
            document.body.style.cursor='hand';
            document.getElementById('NewContacto').style.background='#cccccc';
        }
        function Out(){
            document.body.style.cursor='default';
            document.getElementById('NewContacto').style.background='#ffffff';
        }
 
        function revealModal(divID)
        {
            window.onscroll = function () { document.getElementById(divID).style.top = document.body.scrollTop; };
            document.getElementById(divID).style.display = "block";
            document.getElementById(divID).style.top = document.body.scrollTop;
        }

        function hideModal(divID)
        {
     
            document.getElementById('txtApellido').value="";
            document.getElementById('txtCel').value="";
            document.getElementById('txtFechaNac').value="";
            document.getElementById('txtNombre').value="";
            document.getElementById('ddlSexo').value="";
            document.getElementById('txtMail').value="";
            
            document.getElementById(divID).style.display = "none";
        }
                function ValidarCelular(source, args){
            var valor=document.getElementById('txtCel').value;
            
            if ((valor.substr(0,1)=='0') && (valor.substr(1,1)=='9')){
                args.IsValid=true;
            }
            else{
                args.IsValid=false;
            }
            
        }
        
    </script>
</head>
<body>
    <div id="contenido">
         <div id="Titulo">
            <h1>Lista de Contactos.</h1>
        </div>
        <div id="NewContacto" class="contacto" onclick="revealModal('modalPage')" onmouseover="Over();" onmouseout="Out();">
            <img src="img/edit_add.png" alt="Agregar contacto" title="Agregar contacto" style="float:left;" />
            <h2 style="position:relative;margin-top:50px; margin-left:150px;">Agregar Nuevo...</h2>
        </div>
        <% lst = (System.Collections.Generic.List<Contacto>)Session["lst"]; %>
           <% for (int i = 0; i < lst.Count; i++){ %>
            <div class="contacto">
            <% if (lst[i].EsHombre)
               {%>
                <img src="img/user_male.png" alt="<% Response.Write( lst[i].Nombre); %>"  style="float:left;"/>
            <%}
               else
               { %>
               <img src="img/user_female.png" alt="<% Response.Write( lst[i].Nombre); %>"  style="float:left;"/>
            <%} %>
                
                <div class="textoContacto">
                <strong><% Response.Write(lst[i].Nombre + " " + lst[i].Apellido); %></strong><br /><br />
                <img src="img/cake.png" alt="cake" /> <% Response.Write(lst[i].FechaNacimiento.ToString("dd/MM/yyyy")); %><br />
                <% Response.Write(lst[i].Mail); %><br />
                <% Response.Write(lst[i].Celular); %>
                </div>
            </div>
            <%} %>
            <div id="modalPage">
    <div class="modalBackground">
    </div>
    <div class="modalContainer">
        <div class="modal">
            <div class="modalTop"><a href="#" onclick="hideModal('modalPage');">[X]</a></div>
            <div class="modalBody">
            <form runat="server" id="form2">
                <asp:ValidationSummary ID="ValidationSummary1" runat="server" HeaderText="Han ocurrido los siguientes errores..." />
    <table>
                    <tr>
                        <td>Nombre: </td>
                        <td><asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="reqNombre" runat="server" ControlToValidate="txtNombre"
                                ErrorMessage="El nombre es requerido.">*</asp:RequiredFieldValidator></td>
                    </tr>
                    <tr>
                       <td>Apellido: </td>
                       <td><asp:TextBox ID="txtApellido" runat="server"></asp:TextBox></td>
                    </tr>
                    <tr>
                       <td>Sexo: </td>
                       <td><asp:DropDownList ID="ddlSexo" runat="server">
                        <asp:ListItem Value="" Text=""></asp:ListItem>
                        <asp:ListItem Value="F" Text="Femenino"></asp:ListItem>
                        <asp:ListItem Value="M" Text="Masculino"></asp:ListItem>
                       </asp:DropDownList>
                           <asp:RequiredFieldValidator ID="reqSexo" runat="server" ErrorMessage="El sexo es requerido." ControlToValidate="ddlSexo">*</asp:RequiredFieldValidator></td>
                    </tr>
                     <tr>
                       <td>F. Nacimiento: </td>
                       <td><asp:TextBox ID="txtFechaNac" runat="server"></asp:TextBox>
                           <asp:CompareValidator ID="compFechaNac" runat="server" ErrorMessage="Fecha de nacimiento Inválida."
                               Operator="DataTypeCheck" ControlToValidate="txtFechaNac" Type="Date">*</asp:CompareValidator>
                           <asp:RequiredFieldValidator ID="reqFechaNac" runat="server" ControlToValidate="txtFechaNac"
                               ErrorMessage="La fecha de nacimiento es requerida.">*</asp:RequiredFieldValidator></td>
                    </tr>
                     <tr>
                       <td>
                           Celular:
                       </td>
                       <td><asp:TextBox ID="txtCel" runat="server"></asp:TextBox>
                           <asp:CustomValidator ID="cusValCelular" runat="server" ClientValidationFunction="ValidarCelular"
                               ControlToValidate="txtCel" ErrorMessage="El celular no es válido.">*</asp:CustomValidator>
                           <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtCel"
                               ErrorMessage="Celular requerido.">*</asp:RequiredFieldValidator></td>
                    </tr>
                     <tr>
                       <td>
                           E-mail:
                       </td>
                       <td><asp:TextBox ID="txtMail" runat="server"></asp:TextBox>
                           <asp:RegularExpressionValidator ID="regValidatorMail" runat="server" ErrorMessage="Formato de mail inválido." ControlToValidate="txtMail" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">*</asp:RegularExpressionValidator>
                           <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtMail"
                               ErrorMessage="Mail requerido.">*</asp:RequiredFieldValidator></td>
                   </tr>
                     <tr>
                       <td></td>
                       <td>
                           <asp:Button ID="btnAceptar" runat="server" text="Aceptar" OnClick="btnAceptar_Click"/>
                           <input id="btnCancelar" type="button" value="Cancelar" onclick="hideModal('modalPage');"  />
                       </td>
                    </tr>
                </table>
            </form>
            </div>
        </div>
    </div>
</div>
</div>
</body>
</html>
