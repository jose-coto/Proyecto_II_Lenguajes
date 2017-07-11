<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserControlNormativa.ascx.cs" Inherits="Proyecto_II_WebApp.UserControlNormativa" %>
<asp:Label ID="lblDetalleNormativa" runat="server" Text="Detalle:"></asp:Label>
&nbsp;&nbsp;&nbsp;
<asp:TextBox ID="tbDetalleNormativa" runat="server" Width="379px"></asp:TextBox>
<p>
    <asp:Label ID="lblAñadirNormativa" runat="server" Text="Añadir normativa: "></asp:Label>
&nbsp;&nbsp;&nbsp; </p>

<asp:FileUpload runat="server" ID="fuDocument"/>
