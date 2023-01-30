<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="PanelSuperior.ascx.vb" Inherits="Maqueta.PanelSuperior1" %>


<style type="text/css">

         .style1
        {
            width: 800px;
            border-style: solid;
            border-width: 1px;
        }
        .style70
        {
            width: 394px;
        }
        .auto-style1 {
            width: 900px;
        }
        .auto-style2 {
            width: 88px;
        }
        .auto-style4 {
            width: 125px;
        }
        .auto-style5 {
            width: 109px;
        }
    </style>
<nav class="navbar navbar-expand-lg navbar-dark ftco_navbar bg-secondary ftco-navbar-light " id="ftco-navbar">
    <div class="container">
        <img class="me-2" src="Complementos/img/logoTO.png" alt="" width="300" />
        <div class="collapse navbar-collapse" id="ftco-nav">
            <ul class="navbar-nav nav ml-auto">
                <asp:Panel ID="PanelUsuarios" runat="server">
                    <li class="nav-item"><a href="#" class="nav-link"><span class="nav-link-icon"><span class="far fa-user" style="font-size: large"></span></span><span style="font-size: large; color: white">Usuarios</span></a></li>
                </asp:Panel>
                <asp:Panel ID="PanelObras" runat="server">
                    <li class="nav-item"><a href="FichaObra.aspx" class="nav-link"><span class="nav-link-icon"><span class="fas fa-wrench" style="font-size: large"></span></span><span style="font-size: large; color: white">Obras</span></a></li>
                </asp:Panel>
                <asp:Panel ID="PanelPiezas" runat="server">
                    <li class="nav-item"><a href="#" class="nav-link"><span class="nav-link-icon"><span class="fas fa-puzzle-piece" style="font-size: large"></span></span><span style="font-size: large; color: white">Ver piezas</span></a></li>
                </asp:Panel>
                <asp:Panel ID="PanelCrearIT" runat="server">
                    <li class="nav-item"><a href="#" class="nav-link"><span class="nav-link-icon"><span class="fas fa-search" style="font-size: large"></span></span><span style="font-size: large; color: white">Crear I.T</span></a></li>
                </asp:Panel>
                <asp:Panel ID="PanelInformes" runat="server">
                    <li class="nav-item"><a href="#" class="nav-link"><span class="nav-link-icon"><span class="fas fa-clipboard-list" style="font-size: large"></span></span><span style="font-size: large; color: white">Informes</span></a></li>
                </asp:Panel>
                <asp:Panel ID="PanelParametros" runat="server">
                    <li class="nav-item"><a href="#" class="nav-link"><span class="nav-link-icon"><span class="fas fa-cogs" style="font-size: large"></span></span><span style="font-size: large; color: white">Parametros</span></a></li>
                </asp:Panel>
                <asp:Panel ID="PanelGestion" runat="server">
                    <li class="nav-item"><a href="#" class="nav-link"><span class="nav-link-icon"><span class="fas fa-dollar-sign" style="font-size: large"></span></span><span style="font-size: large; color: white">Gestion O.C</span></a></li>
                </asp:Panel>
                <asp:Panel ID="PanelInet" runat="server">
                    <li class="nav-item"><a href="#" class="nav-link"><span class="nav-link-icon"><span class="fas fa-laptop" style="font-size: large"></span></span><span style="font-size: large; color: white">INET-Cubigest</span></a></li>
                </asp:Panel>
                <asp:Panel ID="PanelRRHH" runat="server">
                    <li class="nav-item"><a href="#" class="nav-link"><span class="nav-link-icon"><span class="fas fa-handshake" style="font-size: large"></span></span><span style="font-size: large; color: white">RR.HH</span></a></li>
                </asp:Panel>
                <asp:Panel ID="PanelServiciosTI" runat="server">
                    <li class="nav-item"><a href="#" class="nav-link"><span class="nav-link-icon"><span class="fas fa-server" style="font-size: large"></span></span><span style="font-size: large; color: white">Servicios TI</span></a></li>
                </asp:Panel>
                <asp:Panel ID="PanelComercial" runat="server">
                    <li class="nav-item"><a href="#" class="nav-link"><span class="nav-link-icon"><span class="fas fa-file-invoice-dollar" style="font-size: large"></span></span><span style="font-size: large; color: white">Comercial</span></a></li>
                </asp:Panel>
            </ul>
        </div>
    </div>
    <ul class="navbar-nav navbar-nav-icons ms-auto flex-row align-items-center">
        <li class="nav-item dropdown"></li>
        <!-- ===============================================-->
        <!--    Usuario-->
        <!-- ===============================================-->
        <li class="nav-item dropdown"><a class="nav-link pe-0" id="navbarDropdownUser" href="#" role="button" data-bs-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
            <div class="avatar avatar-xl">
                <img class="rounded-circle" src="complementos/img/default-avatar.png" alt="" />
            </div>
        </a>
            <div class="dropdown-menu dropdown-menu-end py-0" aria-labelledby="navbarDropdownUser">
                <div class="bg-white dark__bg-1000 rounded-2 py-2">
                    <a class="dropdown-item" href="login.aspx">Cerrar Sesion</a>
                </div>
            </div>
        </li>
    </ul>
    <br />

</nav>
<%--<nav class="navbar navbar-expand-lg navbar-dark ftco_navbar bg-secondary ftco-navbar-light ">
    <div class="center">
        <asp:Label class="value" ID="lbl" Style="color: white; font-size: large" runat="server" Text="Usuario activo: "></asp:Label>
        <asp:Label class="value" ID="Label1" Style="color: white; font-size: large" runat="server" Text="Dconcha "></asp:Label>
        <asp:Label class="value" ID="Label2" Style="color: white; font-size: large" runat="server" Text=" - Entorno:"></asp:Label>
        <asp:Label class="value" ID="Label3" Style="color: white; font-size: large" runat="server" Text="CUBIGEST - PRODUCCION"></asp:Label>
    </div>
</nav>--%>
<%--<nav>
    <table class="style1" style="align-content: center">
        <tr>
            <td class="style70" style="align-content: center">
                <asp:Image ID="Image1" runat="server" style="vertical-align: middle" ImageUrl="/Complementos/img/usuario.png" />
                <br />
                <asp:Label ID="Label2" runat="server" Text="Usuario"></asp:Label>
            </td>
            <td class="style70" style="align-content: center">
                <span class="fas fa-wrench" style="font-size: large"></span>
                <asp:Label ID="Label1" runat="server" Text="Obras"></asp:Label>
            </td>
        </tr>
    </table>
</nav>--%>
<br />






