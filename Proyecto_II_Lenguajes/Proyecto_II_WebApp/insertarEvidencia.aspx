<%@ Page Title="" Language="C#" MasterPageFile="~/ProyectoII.Master" AutoEventWireup="true" CodeBehind="insertarEvidencia.aspx.cs" Inherits="Proyecto_II_WebApp.insertarEvidencia" %>
<%@ Register src="UserControlAccionAdministrativa.ascx" tagname="UserControlAccionAdministrativa" tagprefix="uc1" %>
<%@ Register src="UserControlDocumento.ascx" tagname="UserControlDocumento" tagprefix="uc2" %>
<%@ Register src="UserControlNormativa.ascx" tagname="UserControlNormativa" tagprefix="uc3" %>
<%@ Register src="UserControlActividad.ascx" tagname="UserControlActividad" tagprefix="uc4" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
        <asp:Label ID="lblMensajeEvidencia" runat="server" Font-Bold="True" Font-Size="Large" Text="Pro favor rellena los siguientes espacios para insertar la evidencia"></asp:Label>
    <p>
        <asp:Label ID="lblTitulo" runat="server" Text="Título"></asp:Label>
&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="tbTitulo" runat="server" Width="425px"></asp:TextBox>
    <p>
        <asp:Label ID="lblFecha" runat="server" Text="Fecha: "></asp:Label>
&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="tbFecha" runat="server" TextMode="Date"></asp:TextBox>
    <p>
        <asp:Label ID="lblTipoEvidencia" runat="server" Font-Bold="False" Font-Size="Medium" Text="Tipo de evidencia:"></asp:Label>
&nbsp;&nbsp;&nbsp;
        <asp:DropDownList ID="ddlTipoEvidencia" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlTipoEvidencia_SelectedIndexChanged">
            <asp:ListItem></asp:ListItem>
            <asp:ListItem Value="AA">Acción Administrativa</asp:ListItem>
            <asp:ListItem Value="NO">Normativa</asp:ListItem>
            <asp:ListItem Value="DO">Documento</asp:ListItem>
            <asp:ListItem Value="AC">Actividad</asp:ListItem>
        </asp:DropDownList>    
    <br />
        &nbsp;<p>
        &nbsp;<uc1:UserControlAccionAdministrativa ID="UserControlAccionAdministrativa1" runat="server" Visible="False" />
    <br />
    <uc2:UserControlDocumento ID="UserControlDocumento1" runat="server" Visible="False" />
    <p>
        
    <uc3:UserControlNormativa ID="UserControlNormativa1" runat="server" Visible="False"/>
    <p>
    <uc4:UserControlActividad ID="UserControlActividad1" runat="server" Visible="False"/>

    <p>

    <asp:Button ID="btnRegistrarEvidencia" runat="server" Text="Registrar" Visible="False" OnClick="btnRegistrarEvidencia_Click" />
    <br />
</asp:Content>
