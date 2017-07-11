<%@ Page Title="" Language="C#" MasterPageFile="~/ProyectoII.Master" AutoEventWireup="true" CodeBehind="RegistrarFuncionario.aspx.cs" Inherits="Proyecto_II_WebApp.RegistrarFuncionario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container container-fluid">
        <div class="col-xs-4"> <!--Insertar un funcionario-->
            <div class="container">
                <h3>Registrar un nuevo funcionario</h3><br />
                <asp:Label ID="lblMensaje" runat="server" Text="" ForeColor="Red"></asp:Label><br />

                <asp:Label ID="Label1" runat="server" Text="Nombre"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="tbNombre" runat="server" placeholder="Nombre"></asp:TextBox><br /><br />
                <asp:Label ID="Label2" runat="server" Text="Apellidos"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="tbApellidos" runat="server" placeholder="Apellidos"></asp:TextBox><br /><br />
                <asp:Label ID="Label3" runat="server" Text="Correo"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="tbUsername" runat="server" placeholder="Correo"></asp:TextBox><br /><br />
                <asp:Label ID="Label4" runat="server" Text="Contraseña"></asp:Label>
                &nbsp;<asp:TextBox ID="tbPassword" runat="server" placeholder="Contraseña" TextMode="Password"></asp:TextBox><br /><br />
                <asp:Label ID="Label5" runat="server" Text="Role"></asp:Label>
                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:DropDownList ID="ddlRoles" runat="server" Height="22px" Width="128px"></asp:DropDownList>
            </div>
            <div class="container">
                <br /><br />
                <asp:Button ID="btnRegistrar" runat="server" Text="Registrar Funcionario" CssClass="btn btn-sm btn-success" OnClick="btnRegistrar_Click" />
                <br /><br />
                <asp:Button ID="btnActualizar" runat="server" Text="Actualizar Funcionario" CssClass="btn btn-sm btn-success" Visible ="false" />
                <br /><br />
                <asp:Button ID="btnReset" runat="server" Text="Reiniciar" CssClass="btn btn-sm btn-default" />
            </div>
        </div><!--Fin Insertar nuevo funcionario-->
        <div class="col-xs-7">
            <h3>Historial de funcionarios</h3>
            <asp:GridView ID="gvFuncionarios" runat="server" AllowPaging="True" AutoGenerateColumns="False" AutoGenerateSelectButton="True" DataSourceID="dsGVFuncionarios" PageSize="5" SelectedIndex="0" OnSelectedIndexChanged="gvFuncionarios_SelectedIndexChanged">
                <Columns>
                    <asp:BoundField DataField="Nombre" HeaderText="Nombre" SortExpression="Nombre" />
                    <asp:BoundField DataField="Apellidos" HeaderText="Apellidos" SortExpression="Apellidos" />
                    <asp:BoundField DataField="userName" HeaderText="userName" SortExpression="userName" />
                    <asp:BoundField DataField="Role" HeaderText="Role" SortExpression="Role" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="dsGVFuncionarios" runat="server" ConnectionString="<%$ ConnectionStrings:ProyectoII %>" SelectCommand="Select f.nombre_funcionario as 'Nombre', f.apellidos_funcionario as 'Apellidos', f.userName, r.nombre_role as 'Role' From Funcionario f left join Role r on f.id_role = r.id_role left join EncargadoEvaluacion e on f.id_funcionario = e.id_funcionario"></asp:SqlDataSource>
            <br />
            <br />
            <% if (gvEncargadoDe.Visible)
                { %>
                <h3>Encargado de:</h3>
            <%} %>
            <asp:GridView ID="gvEncargadoDe" runat="server" AutoGenerateColumns="False" AutoGenerateSelectButton="True" DataKeyNames="Evaluacion" DataSourceID="dsGVEncargados" OnSelectedIndexChanged="gvEncargadoDe_SelectedIndexChanged" SelectedIndex="0">
                <Columns>
                    <asp:BoundField DataField="Evaluacion" HeaderText="Evaluacion" InsertVisible="False" ReadOnly="True" SortExpression="Evaluacion" />
                    <asp:BoundField DataField="Fecha Inicio" HeaderText="Fecha Inicio" SortExpression="Fecha Inicio" />
                    <asp:BoundField DataField="Fecha Fin" HeaderText="Fecha Fin" SortExpression="Fecha Fin" />
                    <asp:BoundField DataField="id recinto" HeaderText="Id Recinto" SortExpression="Id Recinto" />
                    <asp:BoundField DataField="Recinto" HeaderText="Recinto" SortExpression="Recinto" />
                    <asp:BoundField DataField="id Guia" HeaderText="Guia" SortExpression="Guia" />
                    <asp:BoundField DataField="Guia" HeaderText="Guia" SortExpression="Guia" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="dsGVEncargados" runat="server" ConnectionString="<%$ ConnectionStrings:ProyectoII %>" 
                SelectCommand="SELECT Evaluacion.id_evaluacion as 'Evaluacion', Evaluacion.fecha_inicio_evaluacion AS 'Fecha Inicio', Evaluacion.fecha_final_evaluacion AS 'Fecha Fin', Recinto.id_recinto as 'id recinto', Recinto.nombre_recinto AS 'Recinto',GuiaDeReconocimiento.id_guia_reconocimiento as 'id Guia', GuiaDeReconocimiento.nombre_guia_reconocimiento AS 'Guia' FROM Evaluacion INNER JOIN Recinto ON Evaluacion.id_recinto = Recinto.id_recinto INNER JOIN GuiaDeReconocimiento ON Evaluacion.id_guia_reconocimiento = GuiaDeReconocimiento.id_guia_reconocimiento"></asp:SqlDataSource>
            <br />
            <asp:DropDownList ID="ddlAreas" runat="server" Visible="false"></asp:DropDownList><br />
            <asp:Button ID="btnEncargadoDe" runat="server" Text="Añadir encargado de" visible="false" CssClass="btn btn-sm btn-info" OnClick="btnEncargadoDe_Click"/>
        </div>
    </div>
</asp:Content>
