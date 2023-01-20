<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="General.aspx.vb" Inherits="Maqueta.General" %>
<%@ Register Src="~/WebParts/PanelSuperior.ascx" TagPrefix="uc1" TagName="PanelSuperior" %>
<%@ Register Src="~/WebParts/Observaciones.ascx" TagPrefix="uc1" TagName="Observaciones" %>
<%@ Register Src="~/WebParts/ListadoPrecios.ascx" TagPrefix="uc1" TagName="ListadoPrecios" %>
<%@ Register Src="~/WebParts/OrdenesCompravsDespachos.ascx" TagPrefix="uc1" TagName="OrdenesCompravsDespachos" %>

<!DOCTYPE html>
<html lang="en-US" dir="ltr">

<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">


    <!-- ===============================================-->
    <!--    Document Title-->
    <!-- ===============================================-->
    <title>P.A.G.O | Pestaña general</title>


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
            <nav class="navbar navbar-expand-md navbar-light bg-faded">
                <a class="navbar-brand" style="color: dimgray">Pestaña General</a>
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
                                        <label class="form-label" for="lblDireccionObra">Sigla obra</label>
                                        <asp:TextBox ID="txtSigla" CssClass="form-control" runat="server" Enabled="false"></asp:TextBox>
                                    </div>
                                    <div class="col-2">
                                        <label class="form-label" for="lblDireccionObra">Estado</label>
                                        <asp:TextBox ID="txtEstado" CssClass="form-control" runat="server" Enabled="false"></asp:TextBox>
                                    </div>
                                    <div class="col-2">
                                        <label class="form-label" for="lblCantidadKG">KGs total obra</label>
                                        <asp:TextBox ID="txtCantidadKG" CssClass="form-control" runat="server" Enabled="false"></asp:TextBox>
                                    </div>
                                    <div class="col-6">
                                        <label class="form-label" for="lblDireccionObra">Direccion obra</label>
                                        <asp:TextBox ID="txtDireccion" CssClass="form-control" runat="server" Enabled =" false"></asp:TextBox>
                                    </div>
                                    <div class="col-3">
                                        <label class="form-label" for="lblDireccionObra">Comuna</label>
                                        <asp:TextBox ID="txtComuna" CssClass="form-control" runat="server" Enabled="false"></asp:TextBox>
                                    </div>
                                    <div class="col-3">
                                        <label class="form-label" for="lblDireccionObra">Ciudad</label>
                                        <asp:TextBox ID="txtCiudad" CssClass="form-control" runat="server" Enabled="false"></asp:TextBox>
                                    </div>
                                    <div class="col-4">
                                        <label class="form-label" for="lblDireccionObra">Sucursal</label>
                                        <asp:TextBox ID="txtSucursal" CssClass="form-control" runat="server" Enabled="false"></asp:TextBox>
                                    </div>
                                    <div class="col-4">
                                        <label class="form-label" for="lblDireccionObra">Administrador</label>
                                        <asp:TextBox ID="txtAdm" CssClass="form-control" runat="server" Enabled="false"></asp:TextBox>
                                    </div>
                                    <div class="col-4">
                                        <label class="form-label" for="lblDireccionObra">Tipo reajuste</label>
                                        <asp:TextBox ID="txtReajuste" CssClass="form-control" runat="server" Enabled="false"></asp:TextBox>
                                    </div>
                                    <div class="col-3">
                                        <label class="form-label" for="lbl_lcAprobada">Linea credito aprobada:</label>
                                        <div class="col-12">
                                            <asp:Label ID="lbl_lcDatoAprobada" class="form-range" runat="server" Text="Sin datos"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="col-3">
                                        <div class="col-12">
                                            <label class="form-label" for="lbl_lcUso">Linea credito usada:</label>
                                        </div>
                                        <div class="col-12">
                                            <asp:Label ID="lbl_lcDatoUso" class="form-range" runat="server" Text="Sin datos"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="col-3">
                                        <label class="form-label" for="lbl_lcDisponible">Linea credito disponible:     </label>
                                        <div class="col-12">
                                            <asp:Label ID="lbl_lcDatoDisponible" class="form-range" runat="server" Text="Sin datos"></asp:Label>
                                        </div>
                                    </div>
                                    <div class="col-3">
                                        <div class="col-12">
                                            <label class="form-label" for="lbl_lcPorcentajeUso">Porcentaje disponible:</label>
                                        </div>
                                        <div class="col-2">
                                            <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                                        </div>
                                    </div>
                                    <div class="col-3">
                                        <asp:Panel ID="PanelGeneral" runat="server" Visible="false">
                                            <asp:Button ID="btnGrabar" CssClass="btn btn-primary" runat="server" Text="Grabar" Visible="false" />
                                        </asp:Panel>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <br />
                    <%--TABLA DE PRECIOS--%>
                    <uc1:ListadoPrecios runat="server" ID="ListadoPrecios" />
                    <br />
                    <br />
                    <%--TABLA ORDENES DE COMPRA--%>
                    <uc1:OrdenesCompravsDespachos runat="server" ID="OrdenesCompravsDespachos" />     
                    <br />
                    <%--OBSERVACIONES--%>
                    <uc1:Observaciones runat="server" id="Observaciones" />
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
