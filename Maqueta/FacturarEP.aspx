<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="FacturarEP.aspx.vb" Inherits="Maqueta.FacturarEP" %>

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
                    <div class="col-lg-4">
                        <div class="card h-100" dir="ltr">
                            <div class="rounded-top-lg banner-titulo">
                                <div class="row flex-between-end2">
                                    <div class="col-auto align-self-center">
                                        <h5 class="mb-0" style="color: white">Registro de Facturación de Estados de Pago</h5>
                                    </div>
                                </div>
                            </div>
                            <div class="card-body bg-light">
                                <div class="row g-3">
                                    <div class="col-6">
                                        <label class="form-label" for="lblNombreObra">Cliente</label>
                                        <asp:TextBox ID="txtNumeroOC" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-6">
                                        <label class="form-label" for="peso">Obra</label>
                                        <asp:TextBox ID="txtPesoOC" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-6">
                                        <label class="form-label" for="peso">Importe total EP ($)</label>
                                        <asp:TextBox ID="TextBox2" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-6">
                                        <label class="form-label" for="lblDireccionObra">Importe Facturado (S)</label>
                                        <asp:TextBox ID="TextBox3" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-12">
                                        <asp:Label ID="Lbl_SaldoFac" runat="server" Font-Bold="True" Font-Names="Arial" ForeColor="Red" Text="Saldo Pendiente de Facturar"></asp:Label>
                                    </div>
                                    <div class="col-4">
                                        <label class="form-label" for="lblDireccionObra">EP para facturar</label>
                                        <asp:DropDownList ID="Cmb_EPFact" runat="server" AutoPostBack="True" class="form-select js-choice"></asp:DropDownList>
                                    </div>
                                    <div class="col-4">
                                        <label class="form-label" for="lblDireccionObra">Facturas a generar</label>
                                        <asp:TextBox ID="Tx_FacturasAGenerar" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                    <div class="col-4">
                                        <label class="form-label" for="lblDireccionObra">Importe factura</label>
                                        <asp:TextBox ID="Tx_ImporteFactura" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                    <div class="col-3">
                                        <label class="form-label" for="lblDireccionObra">Nro factura</label>
                                        <asp:TextBox ID="Tx_NroFactura" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                    <div class="col-5">
                                        <label class="form-label" for="lblDireccionObra">Fecha vencimiento factura</label>
                                        <asp:TextBox ID="Tx_VencFactura" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                    <div class="col-4">
                                        <label class="form-label" for="lblDireccionObra">+</label>
                                        <asp:Button ID="btnLimpiar" CssClass="form-control btn btn-warning" runat="server" Text="Graba factura" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <br />
                <br />
                <div class="row g-3 mb-3 justify-content-center">
                    <div class="col-lg-4">
                        <div class="card h-100" dir="ltr">
                            <div class="rounded-top-lg banner-titulo">
                                <div class="row flex-between-end2">
                                    <div class="col-auto align-self-center">
                                        <h5 class="mb-0" style="color: white">Detalle de facturas generadas</h5>
                                    </div>
                                </div>
                            </div>
                            <div class="card-body bg-light">
                                <div class="row g-3">
                                    <div class="col-6">
                                        <asp:GridView ID="Gr_Ep_Facturas" runat="server" AutoGenerateColumns="False" BorderStyle="None" EnableModelValidation="True">
                                            <Columns>
                                                <asp:CommandField HeaderText="Seleccionar" ShowSelectButton="True" />
                                                <asp:BoundField DataField="NroFactura" HeaderText="Nro. Factura"></asp:BoundField>
                                                <asp:BoundField DataField="Id_ep" HeaderText="Nro. de E.P."></asp:BoundField>
                                                <asp:BoundField DataField="ImporteFactura" HeaderText="Importe Factura"></asp:BoundField>
                                                <asp:BoundField DataField="Vencimiento" HeaderText="Vencimiento "></asp:BoundField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                    <div class="col-12">
                                        <asp:Label ID="lbl_msg" runat="server" ForeColor="#0033CC" Visible="False"></asp:Label>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <br />
                <br />
                <div class="row g-3 mb-3 justify-content-center">
                    <div class="col-lg-4">
                        <div class="card h-100" dir="ltr">
                            <div class="rounded-top-lg banner-titulo">
                                <div class="row flex-between-end2">
                                    <div class="col-auto align-self-center">
                                        <h5 class="mb-0" style="color: white">Informe de estados de pago emitidos</h5>
                                    </div>
                                </div>
                            </div>
                            <div class="card-body bg-light">
                                <div class="row g-3">
                                    <div class="col-12">
                                        <asp:GridView ID="Gr_EP" runat="server" BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" CellPadding="4" EnableModelValidation="True" Width="100%" AutoGenerateColumns="False">
                                            <Columns>
                                                <asp:BoundField DataField="Empresa" HeaderText="Empresa"></asp:BoundField>
                                                <asp:BoundField DataField="Ep_Id" HeaderText="Id EP"></asp:BoundField>
                                                <asp:BoundField DataField="Año" HeaderText="Año"></asp:BoundField>
                                                <asp:BoundField DataField="Mes" HeaderText="Mes"></asp:BoundField>
                                                <asp:BoundField DataField="EP_Fecha_Creacion_Fact_Inet" HeaderText="Fecha Facturación"></asp:BoundField>
                                                <asp:BoundField DataField="Cliente" HeaderText="Cliente"></asp:BoundField>
                                                <asp:BoundField DataField="Nombre" HeaderText="Obra"></asp:BoundField>
                                                <asp:BoundField DataField="EP_CORRELATIVO" HeaderText="EP"></asp:BoundField>
                                                <asp:BoundField DataField="Estado" HeaderText="Estado"></asp:BoundField>
                                                <asp:BoundField DataField="MontoTotal" HeaderText="Monto Total"></asp:BoundField>
                                                <asp:BoundField DataField="EP_Usuario" HeaderText="Responsable"></asp:BoundField>
                                                <asp:BoundField DataField="Dias_del_Envio" HeaderText="Dias en VB"></asp:BoundField>
                                                <asp:BoundField DataField="EP_numero_Fact_Inet" HeaderText="Nro. Factura"></asp:BoundField>
                                                <asp:BoundField DataField="EP_Fecha_Venc_fact_Clte" HeaderText="Vencimiento Factura"></asp:BoundField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                    <div class="col-12">
                                        <asp:Label ID="lbl_NroPiezas" runat="server" ForeColor="#0033CC"></asp:Label>
                                    </div>
                                    <div class="col-2">
                                        <asp:Button ID="Btn_Grabar" runat="server" Text="Grabar" CssClass="form-control btn btn-warning"/>
                                    </div>
                                    <div class="col-4">
                                        <asp:Button ID="Btn_Marcar" runat="server" Text="Marcar Todas" CssClass="form-control btn btn-warning"/>
                                    </div>
                                    <div class="col-4">
                                        <asp:Button ID="Btn_desmarcar" runat="server" Text="DesMarcar Todas" CssClass="form-control btn btn-warning"/>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
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
