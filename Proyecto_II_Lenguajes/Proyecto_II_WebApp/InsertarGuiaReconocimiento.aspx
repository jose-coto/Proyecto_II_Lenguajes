<%@ Page Title="" Language="C#" MasterPageFile="~/ProyectoII.Master" AutoEventWireup="true" CodeBehind="InsertarGuiaReconocimiento.aspx.cs" Inherits="Proyecto_II_WebApp.InsertarGuiaReconocimiento" %>
<%@ Register src="ucAreaTematica.ascx" tagname="ucAreaTematica" tagprefix="uc1" %>
<%@ Register src="ucCriterio.ascx" tagname="ucCriterio" tagprefix="uc2" %>
<%@ Register src="ucSubcriterio.ascx" tagname="ucSubcriterio" tagprefix="uc3" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1 class="text-center">Insertar guía de reconocimiento</h1>
    <div class="container container-fluid">
        <div class="container">
            <div class="col-xs-7">
                <asp:Label ID="lblMensaje" runat="server" Text="" ForeColor="Red"></asp:Label>
                <br />
                <asp:Label ID="Label1" runat="server" Text="Nombre guía reconocimiento"></asp:Label>
                &nbsp;&nbsp;
                <asp:TextBox ID="tbNombreGuia" runat="server" placeholder="Ej: GUÍA PARA EL PROYECTO RECONOCIMIENTO AMBIENTAL 'GALARDON AMBIENTAL UCR'" Width="319px" Height="22px"></asp:TextBox>
                <br />
                <br />
                <asp:Label ID="Label2" runat="server" Text="Año de Publicación"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="tbAnno" runat="server" EnableTheming="False" TextMode="Date" Width="176px" Height="22px"></asp:TextBox>
                <br />
                <br />
                <asp:Button ID="btnAddArea" runat="server" Text="Nueva área temática" CssClass="btn btn-sm btn-info" OnClick="btnAddArea_Click" />
                <asp:Button ID="btnReset" runat="server" Text="Reiniciar" CssClass="btn btn-sm btn-default" OnClick="btnReset_Click" />

            </div>
            <% if (gvGuias.Rows.Count != 0)
                {%>
            <div class="col-xs-4">
                
                <!-- Aquí puedo poner las guías de reconocimiento que hayan actualmente-->
                <h4>Histórico de guías</h4>
                <asp:GridView ID="gvGuias" runat="server" AutoGenerateColumns="False" DataSourceID="dsGvGuias" Height="98px" Width="253px" AllowPaging="True" PageSize="3">
                    <Columns>
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
                        <asp:BoundField DataField="Año Publicación" HeaderText="Año Publicación" ReadOnly="True" SortExpression="Año Publicación" />
                        <asp:CheckBoxField DataField="vigente" HeaderText="vigente" SortExpression="vigente" />
                    </Columns>

                    <PagerSettings Mode="NextPrevious" />

                </asp:GridView>
                <asp:SqlDataSource ID="dsGvGuias" runat="server" ConnectionString="<%$ ConnectionStrings:ProyectoII %>" SelectCommand="SELECT [nombre_guia_reconocimiento] as 'Nombre', Year([anno_publicacion]) as 'Año Publicación', [vigente] FROM [GuiaDeReconocimiento] ORDER BY [vigente], [anno_publicacion], [nombre_guia_reconocimiento]"></asp:SqlDataSource>
            </div>
            <% }%>
        </div>
        <div class="container">
            <div class="col-xs-4">
                <uc1:ucAreaTematica ID="UserControlAreaTematica" runat="server" Visible="False" />
            </div>
            <div class="col-xs-3">
                <uc2:ucCriterio ID="UserControlCriterio" runat="server" Visible="False" />
            </div>
            <div class="col-xs-3">
                <uc3:ucSubcriterio ID="UserControlSubcriterio" runat="server" Visible="False" />
            </div>
        </div>
        <br />
        <br />
        <% if (UserControlAreaTematica.Visible)
                    {%>
        <div class="text-center">
            
                <asp:Button ID="btnAgregarSubcriterio" CssClass="btn btn-sm btn-default" runat="server" Text="Agregar subcriterio" OnClick="btnAgregarSubcriterio_Click" />
            
        </div>
        <br />
        <br />
        <div class="container">
            <%if (gvAreas.Rows.Count != 0)
                { %>
            <h3 class="text-center"> Usted ha insertado: </h3>
            <%} %>
            <div class="col-xs-4">
                <!--Aquí un registro de lo que ha 'Insertado' -->
                <asp:GridView ID="gvAreas" runat="server" AutoGenerateSelectButton="True" OnSelectedIndexChanged="gvAreas_SelectedIndexChanged" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="Nombre" HeaderText="Nombre Área" />
                        <asp:BoundField DataField="Sigla" HeaderText="Sigla Área" />
                    </Columns>
                </asp:GridView>
            </div>
            <div class="col-xs-4">
                <!--Aquí un registro de lo que ha 'Insertado' -->
                <asp:GridView ID="gvCriterios" runat="server" AutoGenerateSelectButton="True" OnSelectedIndexChanged="gvCriterios_SelectedIndexChanged" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="Descripcion" HeaderText="Descripción Criterio" />
                    </Columns>
                </asp:GridView>
            </div>
            <div class="col-xs-3">
                <!--Aquí un registro de lo que ha 'Insertado' -->
                <asp:GridView ID="gvSubcriterios" runat="server" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="Descripcion" HeaderText="Descripción Subcriterio" />
                    </Columns>
                </asp:GridView>
            </div>
        </div>
         <%} %>
    </div>
    <br />
    <br />
    <div class="text-center">
        <asp:Button ID="btnInsertarGuia" runat="server" Text="Insertar Guia Reconocimiento" class="btn btn-sm btn-success" Visible="false" OnClick="btnInsertarGuia_Click"/>
    </div>
</asp:Content>
