<%@ Page Title="" Language="C#" MasterPageFile="~/ProyectoII.Master" AutoEventWireup="true" CodeBehind="AdministrarAreasTematicas.aspx.cs" Inherits="Proyecto_II_WebApp.AdministrarAreasTematicas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="lblMensajeError" runat="server" Font-Size="X-Large" ForeColor="Red"></asp:Label>
    <br />
    <br />
    <asp:Label ID="lblAreaTematica" runat="server" Text="Area Tematica:" Visible="False"></asp:Label>
&nbsp;&nbsp;&nbsp;
    <asp:DropDownList ID="ddlAreaTematica" runat="server" Visible="False">
    </asp:DropDownList>
    <br />
    <br />
    <asp:Label ID="lblCriterios" runat="server" Text="Criterios:" Visible="False"></asp:Label>
&nbsp;&nbsp;&nbsp;
    <asp:DropDownList ID="ddlCriterios" runat="server" Visible="False">
    </asp:DropDownList>
    <br />
    <br />
    <asp:DataList ID="dlSubCriterios" runat="server" Visible="False">
    </asp:DataList>
    <br />
</asp:Content>
