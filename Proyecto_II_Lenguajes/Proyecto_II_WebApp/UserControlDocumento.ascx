<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserControlDocumento.ascx.cs" Inherits="Proyecto_II_WebApp.UserControlDocumento" %>
<asp:Label ID="lblDetalleDocumento" runat="server" Text="Detalle: "></asp:Label>
&nbsp;&nbsp;&nbsp;
<asp:TextBox ID="tbDetalleDocumento" runat="server" Width="401px"></asp:TextBox>
<br />
<br />
<asp:Label ID="lblFuenteDocumento" runat="server" Text="Fuente: "></asp:Label>
&nbsp;&nbsp;&nbsp;
<asp:TextBox ID="tbFuenteDocumento" runat="server" Width="400px"></asp:TextBox>
<br />
<br />
<asp:Label ID="lblFechaDocumento" runat="server" Text="Fecha Documento: "></asp:Label>
&nbsp;&nbsp;&nbsp;
<asp:TextBox ID="tbFechaDocumento" runat="server" TextMode="Date"></asp:TextBox>
<br />
<br />
<asp:Label ID="lblTipoDocumento" runat="server" Text="Tipo Documento:"></asp:Label>
&nbsp;&nbsp;&nbsp;
<asp:DropDownList ID="ddlTipoDocumento" runat="server">
</asp:DropDownList>



