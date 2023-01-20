<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="IngresoOC.aspx.vb" Inherits="Maqueta.IngresoOC" %>

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
    <title>CUBIGEST | Ingreso orden de compra</title>


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
                <asp:TextBox ID="tx_IdObra" runat="server" Visible=" false"></asp:TextBox>
                <asp:TextBox ID="tx_id" runat="server" Visible=" false"></asp:TextBox>
                <br />
                <div class="row g-3 mb-3 justify-content-center">
                    <div class="col-lg-8">
                        <div class="card h-100" dir="ltr">
                            <div class="rounded-top-lg banner-titulo">
                                <asp:Label ID="LblTitulo" runat="server" Style="color: white; font-style: initial; font-size: x-large" Text="Ingreso de datos de ordenes de compra para la obra: "></asp:Label>
                                <asp:Label ID="lblObra" runat="server" Text="" Style="color: white; font-style: initial; font-size: x-large"></asp:Label>
                            </div>
                            <div class="card-body bg-light">
                                <div class="row g-12  justify-content-center">
                                    <div class="col-3">
                                        <label class="form-label" for="lblNombreObra">Numero O.C</label>
                                        <asp:TextBox ID="txtNumeroOC" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-3">
                                        <label class="form-label" for="fecha">Fecha O.C</label>
                                        <asp:TextBox ID="txtFechaOC" CssClass="form-control" runat="server" type="date"></asp:TextBox>
                                    </div>
                                    <div class="col-6">
                                        <label class="form-label" for="archivo">Adjuntar archivo</label>
                                        <asp:FileUpload ID="FileUpload1" runat="server" CssClass="form-control" />
                                        <br />
                                        <br />
                                    </div>
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
                                        <asp:Label ID="lblPeso" runat="server" Text="Peso (kg) / unidad"></asp:Label>
                                        <hr />
                                        <asp:Panel ID="Paneltb" runat="server"></asp:Panel>
                                    </div>
                                    <div class="col-12">
                                        <label class="form-label" for="lblDireccionObra">Observacion</label>
                                        <asp:TextBox ID="txtObservacionOC" CssClass="form-control" runat="server" TextMode="MultiLine" Rows="3"></asp:TextBox>
                                        <br />
                                        <br />
                                    </div>
                                    <div class="col-6">
                                        <asp:Label ID="Label2" runat="server" Text="Total kilos ingresados para la obra:"></asp:Label>
                                        <%--<label class="form-label" for="lblDireccionObra">Total kilos ingresados para la obra:</label>--%>
                                        <asp:TextBox ID="txtTotalKilosIngresados" CssClass="form-control" runat="server" Enabled="false"></asp:TextBox>
                                    </div>
                                    <div class="col-6">
                                        <%--<label class="form-label" for="lblDireccionObra">Ver documento</label>--%>
                                        <asp:HyperLink ID="Lnk_VerDoc" runat="server" Target="_blank">Ver documento</asp:HyperLink>
                                        <asp:TextBox ID="tx_Archivo" CssClass="form-control" runat="server" Enabled="false"></asp:TextBox>
                                        <br />
                                    </div>
                                    <br />
                                    <div class="col-3">
                                        <asp:Button ID="btnGrabar" CssClass="form-control btn btn-primary me-1" runat="server" Text="Grabar" />
                                    </div>
                                    <div class="col-3">
                                        <asp:Button ID="btnEliminar" CssClass="form-control btn btn-primary me-1" runat="server" Text="Eliminar" />
                                    </div>
                                    <div class="col-3">
                                        <asp:Button ID="btnActualizar" CssClass="form-control btn btn-primary me-1" runat="server" enabled ="false" Text="Actualizar" />
                                    </div>
                                    <div class="col-3">
                                        <asp:Button ID="btnLimpiar" CssClass="form-control btn btn-primary me-1" runat="server" Text="Limpiar" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <br />
                    <br />
                </div>
                <div class="row g-3 mb-3 justify-content-center">
                    <div class="col-lg-8">
                        <div class="card h-100" dir="ltr">
                            <div class="rounded-top-lg banner-titulo">
                                <div class="row flex-between-end2">
                                    <div class="col-auto align-self-center">
                                        <h5 class="mb-0" style="color: white">Detalle de ordenes de compra</h5>
                                    </div>
                                </div>
                            </div>
                            <div class="card-body bg-light">
                                <div class="row g-3 table-responsive">
                                    <asp:GridView ID="Grid_OC" runat="server" BorderStyle="None" CssClass="table table-responsive" AutoGenerateColumns="True" AutoGenerateSelectButton="True">
                                       <%-- <Columns>
                                            <asp:BoundField HeaderText="Nº OC" DataField="Numero_OC" />
                                            <asp:BoundField DataField="TipoOC" HeaderText="Tipo OC" />
                                            <asp:BoundField HeaderText="Peso (Kg)" DataField="Peso" />
                                            <asp:BoundField DataField="Precio_OC" HeaderText="Total ($)" />
                                            <asp:BoundField HeaderText="Archivo Adjunto" DataField="NombreArchivo" />
                                            <asp:BoundField HeaderText="Fecha Ingreso" DataField="FechaRegistro" />
                                            <asp:BoundField HeaderText="Usuario" DataField="NombreUsuario" />
                                            <asp:BoundField DataField="Id" HeaderText="Id" />
                                        </Columns>--%>
                                        <AlternatingRowStyle BorderStyle="None" />
                                    </asp:GridView>
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
