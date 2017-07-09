<%@ Page Title="" Language="C#" MasterPageFile="~/ProyectoII.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Proyecto_II_WebApp.Index" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>Hola <%=Context.User.Identity.Name %></h1>
    <h2><asp:label runat="server" ID="lblMsj"></asp:label></h2>
<h2>
    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />
</h2>
</asp:Content>
