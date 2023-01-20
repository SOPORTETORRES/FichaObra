﻿<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="CodigosParaFacturar.aspx.vb" Inherits="Maqueta.CodigosParaFacturar" %>

<%@ Register Src="~/WebParts/PanelSuperior.ascx" TagPrefix="uc1" TagName="PanelSuperior" %>


<!DOCTYPE html>
<html lang="en-US" dir="ltr">

<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">


    <!-- ===============================================-->
    <!--    Document Title-->
    <!-- ===============================================-->
    <title>CUBIGEST | Agregar codigos para facturar</title>


    <!-- ===============================================-->
    <!--    Favicons-->
    <!-- ===============================================-->
    <link rel="manifest" href="../assets/img/favicons/manifest.json">
    <meta name="msapplication-TileImage" content="../assets/img/favicons/mstile-150x150.png">
    <meta name="theme-color" content="#ffffff">
    <script src="Complementos/js/config.js"></script>
    <script src="Complementos/js/notificaciones.js"></script>
    <script src="//cdn.jsdelivr.net/npm/sweetalert2@11"></script>
    <script src="Complementos/vendors/overlayscrollbars/OverlayScrollbars.min.js"></script>
    <script src="Complementos/js/Validaciones.js"></script>


    <!-- ===============================================-->
    <!--    Stylesheets-->
    <!-- ===============================================-->
    <link rel="preconnect" href="https://fonts.gstatic.com">
    <link href="https://fonts.googleapis.com/css?family=Open+Sans:300,400,500,600,700%7cPoppins:300,400,500,600,700,800,900&amp;display=swap" rel="stylesheet">
    <link href="Complementos/vendors/overlayscrollbars/OverlayScrollbars.min.css" rel="stylesheet">
    <link href="Complementos/css/theme-rtl.min.css" rel="stylesheet" id="style-rtl">
    <link href="Complementos/css/theme.min.css" rel="stylesheet" id="style-default">
    <link href="Complementos/css/user-rtl.min.css" rel="stylesheet" id="user-style-rtl">
    <link href="Complementos/css/user.min.css" rel="stylesheet" id="user-style-default">
    <%--<link href="Complementos/css/theme-rtl.css" rel="stylesheet" />--%>
    <link href="Complementos/css/estilos.css" rel="stylesheet" />
    <script>
        var isRTL = JSON.parse(localStorage.getItem('isRTL'));
        if (isRTL) {
            var linkDefault = document.getElementById('style-default');
            var userLinkDefault = document.getElementById('user-style-default');
            linkDefault.setAttribute('disabled', true);
            userLinkDefault.setAttribute('disabled', true);
            document.querySelector('html').setAttribute('dir', 'rtl');
        } else {
            var linkRTL = document.getElementById('style-rtl');
            var userLinkRTL = document.getElementById('user-style-rtl');
            linkRTL.setAttribute('disabled', true);
            userLinkRTL.setAttribute('disabled', true);
        }
    </script>
</head>


<body>

    <!-- ===============================================-->
    <!--    Main Content-->
    <!-- ===============================================-->
    <main class="main" id="top">
        <div class="container" data-layout="container">
            <script>
                var container = document.querySelector('[data-layout]');
                container.classList.remove('container');
                container.classList.add('container-fluid');
            </script>
            <uc1:PanelSuperior runat="server" ID="PanelSuperior" />
            <%--ATAJOS--%>
            <form runat="server">
                <asp:TextBox ID="tx_IdObra" runat="server" Visible =" false"></asp:TextBox>
                <asp:TextBox ID="tx_id" runat="server" Visible =" false"></asp:TextBox>
                <br />
                <div class="row g-3 mb-3 justify-content-center">
                    <div class="col-lg-8">
                        <div class="card h-100" dir="ltr">
                            <div class="rounded-top-lg banner-titulo">
                                    <%--<div class="col-auto align-self-center">
                                        <h5 class="mb-0" style="color: white">Seleccione servicio extra para la obra: </h5>
                                    </div>--%>
                                    <asp:Label ID="LblTitulo" runat="server" Style="color: white; font-style: initial; font-size: x-large" Text="Ingrese codigos de facturacion para la obra: "></asp:Label>
                                    <asp:Label ID="lblObra" runat="server" Text="" Style="color: white; font-style: initial; font-size: x-large"></asp:Label>
                                
                            </div>
                            <div class="card-body bg-light">
                                <div class="row g-12  justify-content-center" style="overflow-y: scroll; height: 700px; width: 1200px;">
                                    <div class="col-1">
                                        <asp:Label ID="lblID" runat="server" Text="ID"></asp:Label>
                                        <hr />
                                        <asp:Panel ID="PanelID" runat="server"></asp:Panel>
                                    </div>
                                    <div class="col-8">
                                        <asp:Label ID="lblServicio" runat="server" Text="Servicio"></asp:Label>
                                        <hr />
                                        <asp:Panel ID="Panellbl" runat="server"></asp:Panel>
                                    </div>
                                    <div class="col-2">
                                        <asp:Label ID="lblPeso" runat="server" Text="Agregar codigo:"></asp:Label>
                                        <hr />
                                        <asp:Panel ID="Paneltb" runat="server"></asp:Panel>
                                    </div>
                                    <div class="col-3">
                                        <asp:Button ID="btnGrabar" CssClass="form-control btn btn-primary me-1" runat="server" Text="Grabar" />
                                    </div>
                                    <div class="col-3">
                                        <asp:Button ID="btnVolver" CssClass="form-control btn btn-primary me-1" runat="server" Text="Volver" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <br />
                    <br />
                </div>
            </form>
        </div>
    </main>
    <br />
    <br />
    <!-- ===============================================-->
    <!--    End of Main Content-->
    <!-- ===============================================-->
    <footer class="footer">
        <div class="row g-0 justify-content-between fs--1 mt-4 mb-3">
            <div class="col-12 col-sm-auto text-center">
            </div>
            <div class="col-12 col-sm-auto text-center">
                <p class="mb-0 text-600">P.A.G.O v1.0.0</p>
            </div>
        </div>
    </footer>
    <!-- ===============================================-->
    <!--    JavaScripts-->
    <!-- ===============================================-->
    <script src="Complementos/vendors/popper/popper.min.js"></script>
    <script src="Complementos/vendors/bootstrap/bootstrap.min.js"></script>
    <script src="Complementos/vendors/anchorjs/anchor.min.js"></script>
    <script src="Complementos/vendors/is/is.min.js"></script>
    <script src="Complementos/vendors/echarts/echarts.min.js"></script>
    <script src="Complementos/vendors/fontawesome/all.min.js"></script>
    <script src="Complementos/vendors/lodash/lodash.min.js"></script>
    <script src="https://polyfill.io/v3/polyfill.min.js?features=window.scroll"></script>
    <script src="Complementos/vendors/list.js/list.min.js"></script>
    <script src="Complementos/js/theme.js"></script>
</body>

</html>
