<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ServiciosExtra.aspx.vb" Inherits="Maqueta.ServiciosExtra" %>

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
                <br />
                <div class="row g-3 mb-3 justify-content-center">
                    <div class="col-lg-8">
                        <div class="card h-100" dir="ltr">
                            <div class="rounded-top-lg banner-titulo">
                                    <%--<div class="col-auto align-self-center">
                                        <h5 class="mb-0" style="color: white">Seleccione servicio extra para la obra: </h5>
                                    </div>--%>
                                    <asp:Label ID="LblTitulo" runat="server" Style="color: white; font-style: initial; font-size: x-large" Text="Seleccione servicio extra para la obra: "></asp:Label>
                                    <asp:Label ID="lblObra" runat="server" Text="" Style="color: white; font-style: initial; font-size: x-large"></asp:Label>
                                
                            </div>
                            <div class="card-body bg-light">
                                <div class="col-md-3">
                                    <asp:DropDownList ID="cbSeleccionables" runat="server" class="form-select js-choice" AutoPostBack="True">
                                    <asp:ListItem>Seleccione:</asp:ListItem>
                                    <asp:ListItem>1.- Suministro</asp:ListItem>
                                    <asp:ListItem>2.- Preparacion</asp:ListItem>
                                    <asp:ListItem>3.- Cubicacion</asp:ListItem>
                                    <asp:ListItem>4.- Alambre</asp:ListItem>
                                    <asp:ListItem>5.- Transporte</asp:ListItem>
                                    <asp:ListItem>6.- Otros</asp:ListItem>
                                </asp:DropDownList>
                                </div>
                                <br />
                                <br />
                                <div class="row g-3">
                                    <div class="col-md-2">
                                        <asp:Label ID="lblSuministros" runat="server" Text="Suministro" class="form-label" Font-Size="Medium" Visible="false"></asp:Label>
                                        <%--<b><label class="form-label" for="lblSuministro">Suministro</label></b>--%>
                                        <asp:DropDownList ID="cbSuministros" runat="server" class="form-select js-choice" Visible="false">
                                            <asp:ListItem>Seleccione:</asp:ListItem>
                                            <asp:ListItem>Fierro construccion</asp:ListItem>
                                            <asp:ListItem>Rollo acero</asp:ListItem>
                                            <asp:ListItem>Barra acero</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-md-2">
                                        <asp:Label ID="LblDiametro" runat="server" Text="Diametro (mm)" class="form-label" Font-Size="Medium" Visible="false"></asp:Label>
                                        <asp:DropDownList ID="dpDiametro" runat="server" class="form-select js-choice" Visible="false">
                                            <asp:ListItem>Seleccione:</asp:ListItem>
                                            <asp:ListItem>8 (mm)</asp:ListItem>
                                            <asp:ListItem>10 (mm) a 36 (mm)</asp:ListItem>
                                            <asp:ListItem>40 (mm)</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-md-2">
                                        <asp:Label ID="lblSucursal" runat="server" Text="Sucursal" class="form-label" Font-Size="Medium" Visible="false"></asp:Label>
                                        <asp:DropDownList ID="dpSucursal" runat="server" class="form-select js-choice" Visible="false">
                                            <asp:ListItem>Seleccione:</asp:ListItem>
                                            <asp:ListItem Value="4">Santiago</asp:ListItem>
                                            <asp:ListItem Value="1">Calama</asp:ListItem>
                                            <asp:ListItem Value="14">Coronel</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-2">
                                        <%--<label class="form-label" for="lblPrecio">Precio</label>--%>
                                        <asp:Label ID="lblPrecio" runat="server" Text="Precio" class="form-label" Font-Size="Medium" Visible="false"></asp:Label>
                                        <asp:TextBox ID="txtPrecioSuministro" CssClass="form-control" runat="server" type="decimal" Visible="false"></asp:TextBox>
                                    </div>
                                    <div class="col-md-2">
                                        <asp:Label ID="lblCalidadsum" Text="Calidad suministro" runat="server" class="form-label" Font-Size="Medium" Visible="false"></asp:Label>
                                        <asp:DropDownList ID="dpCalidads" runat="server" class="form-select js-choice" Visible="false">
                                            <asp:ListItem>Seleccione:</asp:ListItem>
                                            <asp:ListItem>A440-280H</asp:ListItem>
                                            <asp:ListItem>A630-420H</asp:ListItem>
                                            <asp:ListItem>A630-420HS</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-2">
                                        <%--<label class="form-label" for="btnSuministro">+</label>--%>
                                        <asp:Label ID="lblmas" runat="server" Text="+" class="form-label" Font-Size="Medium" Visible="false"></asp:Label>
                                        <asp:Button CssClass="form-control btn btn-primary me-1 mb-" ID="btnSuministro" runat="server" Text="añadir" Visible="false" />
                                    </div>
                                </div>
                                <div class="row g-3">
                                    <div class="col-6">
                                        <asp:Label ID="lblComodin" runat="server" Text="" class="form-label" Font-Size="Medium" Visible="false"></asp:Label>
                                        <asp:TextBox ID="txtComodin" CssClass="form-control" runat="server" type="text" Visible="false"></asp:TextBox>
                                    </div>
                                    <div class="col-2">
                                        <asp:Label ID="lblPrecioComodin" runat="server" Text="Precio" class="form-label" Font-Size="Medium" Visible="false"></asp:Label>
                                        <asp:TextBox ID="txtPrecioComodin" CssClass="form-control" runat="server" type="text" Visible="false"></asp:TextBox>
                                    </div>
                                    <div class="col-2">
                                        <asp:Label ID="lblunidad" runat="server" Text="Unidad" class="form-label" Font-Size="Medium" Visible="false"></asp:Label>
                                        <asp:DropDownList ID="dpUnidad" runat="server" class="form-select js-choice" Visible="false">
                                            <asp:ListItem>Seleccione:</asp:ListItem>
                                            <asp:ListItem>por unidad + IVA</asp:ListItem>
                                            <asp:ListItem>por Kg + IVA</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <br />
                                    <div class="col-2">
                                        <asp:Label ID="lblmas2" runat="server" Text="+" class="form-label" Font-Size="Medium" Visible="false"></asp:Label>
                                        <asp:Button CssClass="form-control btn btn-primary me-1 mb-" ID="btnComodin" runat="server" Text="añadir" Visible="false" />
                                    </div>
                                </div>
                                <div class="row g-3">
                                    <div class="col-3">
                                        <asp:Label ID="lblTransporte" runat="server" Text="Transporte" class="form-label" Font-Size="Medium" Visible="false"></asp:Label>
                                        <asp:DropDownList ID="cbTransporte" runat="server" CssClass="form-control" class="form-select js-choice" AutoPostBack="True" Visible="false">
                                            <asp:ListItem>Seleccione:</asp:ListItem>
                                            <asp:ListItem>Por kgs</asp:ListItem>
                                            <asp:ListItem>Por flete</asp:ListItem>
                                            <asp:ListItem>Por flete Santiago</asp:ListItem>
                                            <asp:ListItem Value="Cliente retira"></asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-3">
                                        <asp:Label ID="lblopciontransporte" runat="server" Text="Tipo camion" class="form-label" Font-Size="Medium" Visible="false"></asp:Label>
                                        <asp:DropDownList ID="dpOpcionesTransporte" runat="server" CssClass="form-control" class="form-select js-choice" Visible="false">
                                            <asp:ListItem>Seleccione:</asp:ListItem>
                                            <asp:ListItem>Camion rampla</asp:ListItem>
                                            <asp:ListItem>Camion 3/4</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-2">
                                        <asp:Label ID="lblPrecioTransporte" runat="server" Text="Precio" class="form-label" Font-Size="Medium" Visible="false"></asp:Label>
                                        <asp:TextBox ID="txtPrecioTransporte" CssClass="form-control" runat="server" type="text" Visible="false"></asp:TextBox>
                                    </div>
                                    <br />
                                    <div class="col-2">
                                        <asp:Label ID="lblmas3" runat="server" Text="+" class="form-label" Font-Size="Medium" Visible="false"></asp:Label>
                                        <asp:Button CssClass="form-control btn btn-primary me-1 mb-" ID="btnTransporte" runat="server" Text="añadir" Visible="false" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <br />
                    <br />
                </div>
                <br />
                <br />
                <div class="row g-3 mb-3 justify-content-center">
                    <div class="col-lg-8">
                        <div class="card h-100" dir="ltr">
                            <div class="rounded-top-lg banner-titulo">
                                <div class="row flex-between-end2">
                                    <div class="col-auto align-self-center">
                                        <h5 class="mb-0" style="color: white">Detalle cotizacion</h5>
                                    </div>
                                </div>
                            </div>
                            <div class="card-body bg-light">
                                <div class="row g-3">
                                    <div class="table-responsive scrollbar">
                                        <asp:GridView ID="gvDetalle" runat="server" CssClass="table table-responsive" BorderStyle="None" HorizontalAlign="Center" AutoGenerateDeleteButton="True">
                                            <AlternatingRowStyle BorderStyle="None" />
                                        </asp:GridView>
                                    </div>
                                </div>
                                <br />
                                <br />
                                <asp:Button ID="btnGrabar" CssClass="btn btn-primary me-1 mb-" runat="server" Text="Grabar" />
                                <asp:Button ID="btnVolver" CssClass="btn btn-primary me-1 mb-" runat="server" Text="Volver atras" />
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
