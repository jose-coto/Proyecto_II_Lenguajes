<%@ Page Title="" Language="C#" MasterPageFile="~/ProyectoII.Master" AutoEventWireup="true" CodeBehind="Logon.aspx.cs" Inherits="Proyecto_II_WebApp.Logon" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h3>Iniciar sesión</h3>
    <table>
      <tr>
        <td>
          Correo:</td>
        <td>
          <asp:TextBox ID="UserEmail" runat="server" /></td>
        <td>
          <asp:RequiredFieldValidator ID="RequiredFieldValidator1" 
            ControlToValidate="UserEmail"
            Display="Dynamic" 
            ErrorMessage="No puede estar vacío." 
            runat="server" />
        </td>
      </tr>
      <tr>
        <td>
          Password:</td>
        <td>
          <asp:TextBox ID="UserPass" TextMode="Password" 
             runat="server" />
        </td>
        <td>
          <asp:RequiredFieldValidator ID="RequiredFieldValidator2" 
            ControlToValidate="UserPass"
            ErrorMessage="No puede estar vacío." 
            runat="server" />
        </td>
      </tr>
      <tr>
        <td>
          Recordarme?</td>
        <td>
          <asp:CheckBox ID="Persist" runat="server" /></td>
      </tr>
    </table>
    <asp:Button ID="btnLogOn" Text="Log On" 
       runat="server" OnClick="Logon_Click" />
    <p>
      <asp:Label ID="Msg" ForeColor="red" runat="server" />
    </p>

</asp:Content>
