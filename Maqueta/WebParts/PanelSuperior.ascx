<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="PanelSuperior.ascx.vb" Inherits="Maqueta.PanelSuperior1" %>


<style>
body {font-family: Arial, Helvetica, sans-serif;}

.navbar a {
  float: left;
  padding: 12px;
  color: white;
  text-decoration: none;
  font-size: 17px;
}

.navbar  a:hover {
  background-color: #eb702c;
}

/*#nab {
    position: absolute;
    left: 0px;
    height: 40px;
    background-color: #2C64B4;
    width: 100%;
    display: flex;
    justify-content: center;
}*/

</style>

<div class="navbar navbar-expand-lg navbar-dark ftco_navbar bg-secondary ftco-navbar-light" >
    <img class="me-2" src="Complementos/img/logoTO.png" alt="" width="280" style="float: left"/>
    <asp:Panel ID="PanelUsuarios" runat="server"><a href="#"><img class="centerImage" src="Complementos/img/equipo.png" width="30"/><br /> Usuarios</a> </asp:Panel>
    <asp:Panel ID="PanelObras" runat="server" ><a href="FichaObra.aspx"><img class="me-2" src="Complementos/img/proteccion.png" width="30" style="vertical-align: middle"/><br /> Obras</a> </asp:Panel>  
    <asp:Panel ID="PanelPiezas" runat="server"><a href="#"><img class="me-2" src="Complementos/img/haz.png" width="30" style="vertical-align: middle"/><br /> Ver piezas</a> </asp:Panel>
    <asp:Panel ID="panelCrearIT" runat="server"><a href="#"><img class="me-2" src="Complementos/img/bosquejo.png" width="30" style="vertical-align: middle"/><br /> Crear I.T</a></asp:Panel>
    <asp:Panel ID="panelInformes" runat="server"><a href="#"><img class="me-2" src="Complementos/img/reporte.png" width="30" style="vertical-align: middle"/><br /> Informes</a></asp:Panel>
    <asp:Panel ID="PanelParametros" runat="server"><a href="#"><img class="me-2" src="Complementos/img/configuraciones.png" width="30" style="vertical-align: middle"/><br /> Parametros</a></asp:Panel>
    <asp:Panel ID="PanelGestionOC" runat="server"><a href="#"><img class="me-2" src="Complementos/img/factura.png" width="30" style="vertical-align: middle"/><br /> Gestion O.C</a></asp:Panel>
    <asp:Panel ID="PanelINET" runat="server"><a href="#"><img class="me-2" src="Complementos/img/INET.png" width="30" style="vertical-align: middle"/><br /> INET-Cubigest</a></asp:Panel>
    <asp:Panel ID="PanelRRHH" runat="server"><a href="#"><img class="me-2" src="Complementos/img/rrhh.png" width="30" style="vertical-align: middle"/><br /> RR.HH</a></asp:Panel>
    <asp:Panel ID="PanelServiciosTI" runat="server"><a href="#"><img class="me-2" src="Complementos/img/soporte.png" width="30" style="vertical-align: middle"/><br /> Servicios TI</a></asp:Panel>
    <asp:Panel ID="PanelComercial" runat="server"><a href="#"><img class="me-2" src="Complementos/img/tratar.png" width="30" style="vertical-align: middle"/><br /> Comercial</a></asp:Panel>
    <a href="#"><img class="me-2" src="Complementos/img/logout.png" width="30" style="vertical-align: middle"/><br /> Desconectar</a>
</div>



   <%-- ENTORNO--%>
<nav class="navbar navbar-expand-lg navbar-dark ftco_navbar bg-secondary ftco-navbar-light">
    <div style="text-align: center">
        <asp:Label class="value" ID="lbl" Style="color: white; font-size: large" runat="server" Text="Usuario activo: "></asp:Label>
        <asp:Label class="value" ID="lblUsuario" Style="color: white; font-size: large" runat="server" Text="Dconcha"></asp:Label>
        <asp:Label class="value" ID="Label2" Style="color: white; font-size: large" runat="server" Text=" - Entorno:"></asp:Label>
        <asp:Label class="value" ID="lblEntorno" Style="color: white; font-size: large" runat="server" Text="CUBIGEST - PRODUCCION"></asp:Label>
    </div>
</nav>
<br />










