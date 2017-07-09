<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UserControlActividad.ascx.cs" Inherits="Proyecto_II_WebApp.UserControlActividad" %>
<asp:Label ID="Label1" runat="server" Text="Cantidad Participantes:"></asp:Label>
&nbsp;&nbsp;&nbsp;
<asp:TextBox ID="tbCantidadParticipantesctividad" runat="server" TextMode="Number"></asp:TextBox>
<p>
    <asp:Label ID="lblFechaActividad" runat="server" Text="Fecha: "></asp:Label>
&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="tbFechaActividad" runat="server" TextMode="Date"></asp:TextBox>
</p>
<p>
    <asp:Label ID="lblDescripcionActividad" runat="server" Text="Descripción"></asp:Label>
&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="tbDescripcionActividad" runat="server"></asp:TextBox>
</p>
<p>
    <asp:Label ID="lblTipoParticipantes" runat="server" Text="Seleccione un o varios tipos de participantes:"></asp:Label>
</p>
<p>
    <asp:ListBox ID="lbTipoDeParticipantesDisponibles" runat="server" Width="140px"></asp:ListBox>
&nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnRigth" runat="server" Text="&gt;&gt;" />
    <asp:Button ID="btnLeft" runat="server" Text="&lt;&lt;" />
&nbsp;&nbsp;&nbsp;
    <asp:ListBox ID="lblTipoPrticipantesSeleccionados" runat="server" Width="140px"></asp:ListBox>
</p>
<p>
    <asp:Label ID="lblImagenesActividad" runat="server" Text="Imagenes: "></asp:Label>
&nbsp;&nbsp;&nbsp; //Codigo de subida de imagenes</p>

