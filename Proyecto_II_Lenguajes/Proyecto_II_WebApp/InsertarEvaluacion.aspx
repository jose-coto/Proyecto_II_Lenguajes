<%@ Page Title="" Language="C#" MasterPageFile="~/ProyectoII.Master" AutoEventWireup="true" CodeBehind="InsertarEvaluacion.aspx.cs" Inherits="Proyecto_II_WebApp.InsertarEvaluacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
        <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="X-Large" Text="Registro de una nueva evaluación"></asp:Label>
    <br />
    <br />
    <asp:Label ID="Label2" runat="server" Font-Size="Large" Text="Fecha Inicial:"></asp:Label>
&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="tbFechaInicial" runat="server" TextMode="Date"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="Label3" runat="server" Font-Size="Large" Text="Fecha Final: "></asp:Label>
&nbsp;&nbsp;&nbsp;
    <asp:TextBox ID="tbFechaFinal" runat="server" TextMode="Date"></asp:TextBox>
    <br />
    <br />
    <asp:Label ID="Label4" runat="server" Font-Size="Large" Text="Sede o Recinto: "></asp:Label>
&nbsp;&nbsp;
    <asp:DropDownList ID="ddlRecinto" runat="server" AutoPostBack="True">
    </asp:DropDownList>
    <br />
    <br />
&nbsp;<asp:Label ID="Label5" runat="server" Font-Size="Large" Text="Guía de Reconocimiento: "></asp:Label>
&nbsp;&nbsp;
    <asp:DropDownList ID="ddlGuiaReconocimiento" runat="server" AutoPostBack="True">
    </asp:DropDownList>
    <br />
    <br />
    <asp:Button ID="btnRegistrarEvaluacion" runat="server" OnClick="btnRegistrarEvaluacion_Click" Text="Registrar" />
&nbsp;
</asp:Content>
