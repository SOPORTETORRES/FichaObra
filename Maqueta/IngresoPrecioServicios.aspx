<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="IngresoPrecioServicios.aspx.vb" Inherits="Maqueta.IngresoPrecioServicios" %>

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
    <title>CUBIGEST | Camnbio de precios </title>


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
            <form runat="server">
                <br />
                <div class="row g-3 mb-3 justify-content-center">
                    <div class="col-lg-6">
                        <div class="card h-100" dir="ltr">
                            <div class="rounded-top-lg banner-titulo">
                                <div class="row flex-between-end2">
                                    <div class="col-auto align-self-center">
                                        <h5 class="mb-0" style="color: white">Cambio de precio para la obra: </h5>
                                    </div>
                                </div>
                            </div>
                            <div class="card-body bg-light">
                                <div class="row g-3">
                                    <div class="col-5">
                                        <label class="form-label" for="lblNombreObra">Valores actuales por servicio: </label>
                                    </div>
                                    <div class="col-2">
                                        <asp:TextBox ID="txtValorServicio" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-5">
                                        
                                    </div>
                                    <div class="col-md-2">
                                        <label class="form-label" for="peso">Suministro</label>
                                        <asp:TextBox ID="txtSuministro" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-2">
                                        <label class="form-label" for="lblCantidadKG">Preparación</label>
                                        <asp:TextBox ID="txtPreparacion" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-3">
                                        <label class="form-label" for="lblCantidadKG">Pre-armado pilotes</label>
                                        <asp:TextBox ID="txtPrearmado" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-2">
                                        <label class="form-label" for="lblCantidadKG">Instalación</label>
                                        <asp:TextBox ID="txtInstalacion" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-2">
                                        <label class="form-label" for="lblCantidadKG">Total servicios ($)</label>
                                        <asp:TextBox ID="txtTotalServicios" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <hr />
                                    <div class="col-12">
                                        <label class="form-label" for="lblNombreCliente">Servicio al cual se cambiara el precio</label>
                                    </div>
                                    <div class="col-3">
                                        <label class="form-label" for="lblDireccionObra">Servicio</label>
                                        <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control">
                                            <asp:ListItem>Seleccione:</asp:ListItem>
                                            <asp:ListItem>Suministro</asp:ListItem>
                                            <asp:ListItem>Preparacion</asp:ListItem>
                                            <asp:ListItem>Pre-armado</asp:ListItem>
                                            <asp:ListItem>Instalacion</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-2">
                                        <label class="form-label" for="lblCantidadKG">Nuevo importe $</label>
                                        <asp:TextBox ID="txtNuevoImporte" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-2">
                                        <label class="form-label" for="lblCantidadKG">Fecha vigencia</label>
                                        <asp:TextBox ID="txtFechaVigencia" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-3">
                                        <label class="form-label" for="lblCantidadKG">Adjuntar archivos</label>
                                        <asp:FileUpload ID="FileUpload1" runat="server" />
                                    </div>
                                    <div class="col-12">
                                        <label class="form-label" for="lblDireccionObra">Observacion</label>
                                        <asp:TextBox ID="txtObservacion" CssClass="form-control" runat="server" TextMode="MultiLine" Rows="3"></asp:TextBox>
                                    </div>
                                    <div class="col-3">
                                        <asp:Button ID="Button1" runat="server" Text="Grabar" CssClass="form-control btn btn-primary me-1"/>
                                    </div>
                                    <hr />
                                    <%--DETALLE DE KILOS ACTUAL--%>
                                    <div class="col-12">
                                        <label class="form-label" for="lblNombreObra">Detalle de kilos actual: </label>
                                    </div>
                                    <div class="col-md-2">
                                        <label class="form-label" for="peso">Kilos disponibles</label>
                                        <asp:TextBox ID="TextBox2" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-2">
                                        <label class="form-label" for="lblCantidadKG">Precio actual</label>
                                        <asp:TextBox ID="TextBox3" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-2">
                                        <label class="form-label" for="lblCantidadKG">$$ total proyecto</label>
                                        <asp:TextBox ID="TextBox4" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-2">
                                        <label class="form-label" for="lblCantidadKG">Kgs despachados</label>
                                        <asp:TextBox ID="TextBox5" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-2">
                                        <label class="form-label" for="lblCantidadKG">$$ despacho</label>
                                        <asp:TextBox ID="TextBox6" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-2">
                                        <label class="form-label" for="lblCantidadKG">+</label>
                                        <asp:Button ID="Button2" runat="server" Text="Simular" CssClass="form-control btn btn-primary me-1"/>
                                    </div>
                                    <hr />
                                   <%--DETALLE DE KILOS CON EL NUEVO PRECIO--%>
                                    <%--<div class="col-12">
                                        <label class="form-label" for="lblNombreObra">Detalle de kilos con el nuevo precio: </label>
                                    </div>
                                    <div class="col-md-2">
                                        <label class="form-label" for="peso">Kilos disponibles</label>
                                        <asp:TextBox ID="TextBox1" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-2">
                                        <label class="form-label" for="lblCantidadKG">Precio actual</label>
                                        <asp:TextBox ID="TextBox7" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-2">
                                        <label class="form-label" for="lblCantidadKG">$$ total proyecto</label>
                                        <asp:TextBox ID="TextBox8" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-2">
                                        <label class="form-label" for="lblCantidadKG">Kgs despachados</label>
                                        <asp:TextBox ID="TextBox9" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-2">
                                        <label class="form-label" for="lblCantidadKG">$$ despacho</label>
                                        <asp:TextBox ID="TextBox10" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-md-2">
                                        <label class="form-label" for="lblCantidadKG">+</label>
                                        <asp:Button ID="Button3" runat="server" Text="Simular" CssClass="form-control btn btn-primary me-1"/>
                                    </div>
                                    <hr />--%>
                                </div>
                            </div>
                        </div>
                    </div>
                    <br />
                    <br />
                </div>
                                <div class="row g-3 mb-3 justify-content-center">
                    <div class="col-lg-4">
                        <div class="card h-100" dir="ltr">
                            <div class="rounded-top-lg banner-titulo">
                                <div class="row flex-between-end2">
                                    <div class="col-auto align-self-center">
                                        <h5 class="mb-0" style="color: white">Detalle de ordenes de compra para la obra: </h5>
                                    </div>
                                </div>
                            </div>
                            <div class="card-body bg-light">
                                <div class="row g-3">
                                    <asp:GridView ID="GridView1" runat="server"></asp:GridView>
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
