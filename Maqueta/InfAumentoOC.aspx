<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="InfAumentoOC.aspx.vb" Inherits="Maqueta.InfAumentoOC" %>

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
    <title>CUBIGEST | Informe aumento O.C</title>


    <!-- ===============================================-->
    <!--    Favicons-->
    <!-- ===============================================-->
    <link rel="manifest" href="../assets/img/favicons/manifest.json">
    <meta name="msapplication-TileImage" content="../assets/img/favicons/mstile-150x150.png">
    <meta name="theme-color" content="#ffffff">
    <script src="Complementos/js/config.js"></script>
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
            <%--<nav class="navbar navbar-light navbar-glass navbar-top navbar-expand-lg">
                <div class="collapse navbar-collapse scrollbar" id="navbarStandard">
                    <ul class="nav">
                        <li class="nav-item">
                            <a class="nav-link" href="General.aspx">
                                <h5>General</h5>
                                <span class="sr-only"></span></a>
                        </li>
                        
                        <li class="nav-item">
                            <a class="nav-link" href="OficinaTecnica.aspx">
                                <h5>Oficina Tecnica</h5>
                            </a>
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
                </div>
            </nav>--%>
            <form runat="server">
                <br />
                <div class="row g-3 mb-3 justify-content-center">
                    <div class="col-lg-5">
                        <div class="card h-100" dir="ltr">
                            <div class="rounded-top-lg banner-titulo">
                                <div class="row flex-between-end2">
                                    <div class="col-auto align-self-center">
                                        <h5 class="mb-0" style="color: white">Listado de clientes que aumentaron los kilos contratados durante el mes actual</h5>
                                    </div>
                                </div>
                            </div>
                            <div class="card-body bg-light">
                                <div class="row g-3 justify-content-center">
                                    <div class="col-6">
                                        <label class="form-label" for="peso">Seleccione mes a consultar</label>
                                        <asp:DropDownList ID="Cmb_Mes" runat="server" class="form-select js-choice">
                                            <asp:ListItem>Seleccione:</asp:ListItem>
                                        </asp:DropDownList>
                                        <br />
                                        <asp:Button ID="Btn_Buscar" runat="server" Text="Buscar" CssClass="btn btn-primary me-1" />
                                    </div>
                                    <hr />
                                    <div class="col-12">
                                        <asp:GridView ID="Gr_AumentosOC" runat="server" class="table table-striped table-bordered" BorderStyle="None" AutoGenerateColumns="False">
                                            <Columns>
                                                <asp:BoundField DataField="Id" HeaderText="IdObra" />
                                                <asp:BoundField DataField="Empresa" HeaderText="Empresa" />
                                                <asp:BoundField DataField="Cliente" HeaderText="Cliente" />
                                                <asp:BoundField DataField="Obra" HeaderText="Obra" />
                                                <asp:BoundField DataField="KgsAgregados" HeaderText="Kgs agregados" />
                                                <asp:BoundField DataField="Periodo" HeaderText="Periodo" />
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                </form>
                <br />
                <br />
        </div>
               
                    <br />
                    <br />
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
