<%@ Page Title="" Language="C#" MasterPageFile="~/ProyectoII.Master" AutoEventWireup="true" CodeBehind="AdministrarAreasTematicas.aspx.cs" Inherits="Proyecto_II_WebApp.AdministrarAreasTematicas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="lblMensajeError" runat="server" Font-Size="X-Large" ForeColor="Red"></asp:Label>
    <br />
    <br />
    <asp:Label ID="lblAreaTematica" runat="server" Text="Area Tematica:" Visible="False"></asp:Label>
&nbsp;&nbsp;&nbsp;
    <asp:DropDownList ID="ddlAreaTematica" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlAreaTematica_SelectedIndexChanged" Visible="False">
    </asp:DropDownList>
    <br />
    <br />
    <asp:Label ID="lblCriterios" runat="server" Text="Criterios:" Visible="False"></asp:Label>
&nbsp;&nbsp;&nbsp;
    <asp:DropDownList ID="ddlCriterios" runat="server" Visible="false" AutoPostBack="True" OnSelectedIndexChanged="ddlCriterios_SelectedIndexChanged">
    </asp:DropDownList>
    <br />
    <br />
    <asp:Label ID="lblSubCriterios" runat="server" Text="SubCriterios:" Visible="False"></asp:Label>
    <br />
    <br />
    <asp:DataList ID="dlSubCriterios" runat="server" Visible="false" RepeatLayout="Flow">
        <HeaderTemplate>
            ID&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Descripción&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Acción
        </HeaderTemplate>
        <ItemTemplate>
            <asp:Label ID="lblCodigo" runat="server"
                            Text='<%# Eval("idSubCriterio") %>' />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="lblDescripcion" runat="server"
                            Text='<%# Eval("descripcion") %>' />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:LinkButton ID="btnInsertarEvidencia" runat="server" 
                CommandArgument='<%# Eval("idSubCriterio")%>' OnClick="btnInsertarEvidencia_Click">Insertar Evidencia</asp:LinkButton>
            <br />
            <br />
    </ItemTemplate>
    </asp:DataList>
    <br />
</asp:Content>
