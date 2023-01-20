<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Calidad.aspx.vb" Inherits="Maqueta.Calidad" %>

<%@ Register Src="~/WebParts/PanelSuperior.ascx" TagPrefix="uc1" TagName="PanelSuperior" %>
<%@ Register Src="~/WebParts/Observaciones.ascx" TagPrefix="uc1" TagName="Observaciones" %>
<%@ Register Src="~/WebParts/Contactos.ascx" TagPrefix="uc1" TagName="Contactos" %>








<!DOCTYPE html>
<html lang="en-US" dir="ltr">

<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">


    <!-- ===============================================-->
    <!--    Document Title-->
    <!-- ===============================================-->
    <title>P.A.G.O | Pestaña Calidad</title>


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
    <style>
        .tabla{
        background-color: lightgray;
        }
    </style>
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
            <nav class="navbar navbar-expand-md navbar-light bg-faded">
                <a class="navbar-brand" style="color: dimgray">Pestaña Calidad</a>
                <ul class="navbar-nav mx-auto">
                    <li class="nav-item">
                        <a class="nav-link" href="General.aspx">
                            <h5>General</h5>
                            <span class="sr-only"></span></a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="COF.aspx">
                            <h5>C.O.F</h5>
                            <span class="sr-only"></span></a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="OficinaTecnica.aspx">
                            <h5>Oficina Tecnica</h5>
                            <span class="sr-only"></span></a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="Logistica.aspx">
                            <h5>Logistica</h5>
                            <span class="sr-only"></span></a>
                    </li>
                    <li class="nav-item">
                        <a class="nav-link" href="Calidad.aspx">
                            <h5>Calidad</h5>
                            <span class="sr-only"></span></a>
                    </li>
                </ul>
                <ul class="navbar-nav navbar-nav-icons ms-auto flex-row align-items-center">
                    <li class="nav-item dropdown"></li>
                    <!-- ===============================================-->
                    <!--    Usuario-->
                    <!-- ===============================================-->
                    <li class="nav-item dropdown"><a class="nav-link pe-0" id="DPopcionesCOF" href="#" role="button" data-bs-toggle="dropdown" aria-haspopup="true" aria-expanded="false">
                        <div class="avatar avatar-xl">
                            <img src="complementos/img/menu.png" alt="" />
                        </div>
                    </a>
                        <div class="dropdown-menu dropdown-menu-end py-0" aria-labelledby="DPopcionesCOF">
                            <div class="bg-white dark__bg-1000 rounded-2 py-2">
                                <a class="dropdown-item" href="IngresoOC.aspx">Ingreso O.C</a>
                                <a class="dropdown-item" href="IngresoPrecioServicios.aspx">Precio servicios</a>
                                <a class="dropdown-item" href="Detalle_LC.aspx">Linea de credito</a>
                                <a class="dropdown-item" href="#">Cambio precios</a>
                            </div>
                        </div>
                    </li>
                </ul>
            </nav>
            <form runat="server">
                <div class="row g-3 mb-3">
                    <div class="col-lg-6">
                        <div class="card h-100" dir="ltr">
                            <div class="rounded-top-lg banner-titulo">
                                <div class="row flex-between-end2">
                                    <div class="col-auto align-self-center">
                                        <h5 class="mb-0" style="color: white">Datos de la obra</h5>
                                    </div>
                                </div>
                            </div>
                            <div class="card-body bg-light">
                                <div class="row g-3">
                                    <div class="col-6">
                                        <label class="form-label" for="lblNombreObra">Nombre obra</label>
                                        <asp:TextBox ID="txtNombreObra" CssClass="form-control" runat="server" Enabled="false"></asp:TextBox>
                                    </div>
                                    <div class="col-2">
                                        <label class="form-label" for="lblDireccionObra">Sigla</label>
                                        <asp:TextBox ID="txtSigla" CssClass="form-control" runat="server" Enabled="false"></asp:TextBox>
                                    </div>
                                    <div class="col-2">
                                        <label class="form-label" for="lblDireccionObra">Estado</label>
                                        <asp:TextBox ID="txtEstado" CssClass="form-control" runat="server" Enabled="false"></asp:TextBox>
                                    </div>
                                    <div class="col-3">
                                        <label class="form-label" for="lblNombreObra">Bloqueo de certificados:</label>
                                        <asp:TextBox ID="txtBloqueo" CssClass="form-control" runat="server" Enabled="false"></asp:TextBox>
                                    </div>
                                    <div class="col-6">
                                        <label class="form-label" for="lblNombreObra">Observacion bloqueo</label>
                                        <asp:TextBox ID="txtObs" CssClass="form-control" runat="server" Enabled="false"></asp:TextBox>
                                    </div>
                                    <%--<div class="col-4">
                                        <label class="form-label" for="lbl_lcAprobada">Viajes despachados</label>
                                        <div class="col-12">
                                            <asp:Label ID="lblDespachado" class="form-range" runat="server" Text="Sin datos"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="col-4">
                                        <div class="col-12">
                                            <label class="form-label" for="lbl_lcUso">Viajes certificados</label>
                                        </div>
                                        <div class="col-12">
                                            <asp:Label ID="lblCertificados" class="form-range" runat="server" Text="Sin datos"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="col-4">
                                        <label class="form-label" for="lbl_lcDisponible">% total</label>
                                        <div class="col-12">
                                            <asp:Label ID="lblPorcentaje" class="form-range" runat="server" Text="Sin datos"></asp:Label>
                                        </div>
                                    </div>--%>
                                    <div class="col-12">
                                        <%--<asp:Button ID="btnGrabar" runat="server" Text="Grabar" class="btn btn-primary" />--%>
                                        <uc1:Contactos runat="server" ID="Contactos" />
                                        <asp:Button ID="btnExportar" runat="server" Text="Exportar a Excel" class="btn btn-primary" />
                                        <asp:Button ID="BtnCuadroProg" runat="server" Text="Cuadro programacion" class="btn btn-primary" />
                                        <asp:Button ID="btnPantallaCamiones" runat="server" Text="Resumen despacho" class="btn btn-primary" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <br />
                    <%--RESUMEN DE CERTIFICACIONES--%>
                    <div class="col-lg-6">
                        <div class="card h-100" dir="ltr">
                            <div class="rounded-top-lg banner-titulo">
                                <div class="row flex-between-end">
                                    <div class="col-auto align-self-center">
                                        <h5 class="mb-0" style="color: white">Resumen de certificacion de la obra</h5>
                                    </div>
                                </div>
                            </div>
                            <div class="card-body bg-light">
                                <table class="table table-striped table-bordered accordion-header">
                                    <tbody>
                                        <tr>
                                            <th>Viajes despachados</th>
                                            <th>Viajes certificados</th>
                                            <th>% certificado</th>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lblDespachado" class="form-range" runat="server" Text="Sin datos"></asp:Label></td>
                                            <td>
                                                <asp:Label ID="lblCertificado" class="form-range" runat="server" Text="Sin datos"></asp:Label></td>
                                            <td>
                                                <asp:Label ID="lblPorcentaje" class="form-range" runat="server" Text="Sin datos"></asp:Label></td>
                                        </tr>
                                    </tbody>
                                </table>
                            </div>
                        </div>
                    </div>
                    <%--RESUMEN DE LOTES NO ENCONTRADOS--%>
                    <div class="col-lg-6">
                        <div class="card h-100" dir="ltr">
                            <div class="rounded-top-lg banner-titulo">
                                <div class="row flex-between-end">
                                    <div class="col-auto align-self-center">
                                        <h5 class="mb-0" style="color: white">Resumen de lotes no encontrados</h5>
                                    </div>
                                </div>
                            </div>
                            <div class="card-body bg-light">
                                <div style="overflow-y: scroll; height: 300px; width: 900px;">
                                    <asp:GridView ID="gvLotesMissed" runat="server" class="table table-bordered" BorderStyle="None">
                                    </asp:GridView>
                                </div>
                                <br />
                                <asp:Button ID="btnListado" runat="server" Text="Ver listado completo" class="btn btn-primary" />
                            </div>
                        </div>
                    </div>
                    <%--RESUMEN DE CONTROLES DE OBRA--%>
                    <div class="col-lg-6">
                        <div class="card h-100" dir="ltr">
                            <div class="rounded-top-lg banner-titulo">
                                <div class="row flex-between-end">
                                    <div class="col-auto align-self-center">
                                        <h5 class="mb-0" style="color: white">Ultimos controles realizados a la obra</h5>
                                    </div>
                                </div>
                            </div>
                            <div class="card-body bg-light">
                                <div style="overflow-y: scroll; height: 300px; width: 900px;">
                                    <asp:GridView ID="gvControl" runat="server" class="table table-bordered" BorderStyle="None">
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>
                    </div>
                    <%--OBSERVACIONES--%>
                    <uc1:Observaciones runat="server" ID="Observaciones" />
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
