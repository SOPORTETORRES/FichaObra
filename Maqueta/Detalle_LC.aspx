<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Detalle_LC.aspx.vb" Inherits="Maqueta.Detalle_LC" %>

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
                    <div class="col-lg-6">
                        <div class="card h-100" dir="ltr">
                            <div class="rounded-top-lg banner-titulo">
                                <div class="row flex-between-end2">
                                    <div class="col-auto align-self-center">
                                        <asp:Label ID="LblTitulo" runat="server" Style="color: white; font-style: initial; font-size: larger" Text="Detalle linea de crédito del cliente: "></asp:Label>
                                        <asp:Label ID="lblObra" runat="server" Text="" Style="color: white; font-style: initial; font-size: larger"></asp:Label>
                                        <%--<asp:Label ID="Lbl_Cabecera" runat="server" Text="Label"></asp:Label>--%>
                                    </div>
                                </div>
                            </div>
                            <div class="card-body bg-light">
                                <div class="row g-3">
                                    <table class="auto-style1" border="0">

                                        <tr>
                                            <td colspan="2">
                                                <asp:Label ID="Label47" runat="server" Text="Valor UF "></asp:Label>
                                            </td>
                                            <td colspan="2">
                                                <asp:Label ID="Lbl_ValorUf" runat="server" Text="Valor UF "></asp:Label>
                                            </td>
                                            <td colspan="2">
                                                <asp:Label ID="Label48" runat="server" Text="Fecha UF"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Lbl_FechaUF" runat="server" Text="Fecha UF"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">&nbsp;</td>
                                            <td colspan="2">&nbsp;</td>
                                            <td colspan="2">&nbsp;</td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <asp:Label ID="Label39" runat="server" Text="Línea Crédito Aprobada" Font-Bold="True"></asp:Label>
                                            </td>
                                            <td colspan="2">
                                                <asp:Label ID="Label41" runat="server" Text="Línea Crédito  en Uso" Font-Bold="True"></asp:Label>
                                            </td>
                                            <td colspan="2">
                                                <asp:Label ID="Label43" runat="server" Text="Línea Crédito  Disponible" Font-Bold="True"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Label44" runat="server" Text="% Utilizado" Font-Bold="True"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lbl_lc_Pesos0" runat="server" Text="En $$"></asp:Label>
                                            </td>
                                            <td class="auto-style2">
                                                <asp:Label ID="lbl_lc_Uf0" runat="server" Text="En UF"></asp:Label>
                                            </td>
                                            <td class="auto-style4">
                                                <asp:Label ID="lbl_lc_Pesos1" runat="server" Text="En $$"></asp:Label>
                                            </td>
                                            <td class="auto-style5">
                                                <asp:Label ID="lbl_lc_Uf1" runat="server" Text="0"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lbl_lc_Pesos2" runat="server" Text="En $$"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lbl_lc_Uf2" runat="server" Text="0"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lbl_lc_Uf3" runat="server" Text="0"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lbl_lc_Pesos" runat="server" Text="0"></asp:Label>
                                            </td>
                                            <td class="auto-style2">
                                                <asp:Label ID="lbl_lc_Uf" runat="server" Text="0"></asp:Label>
                                            </td>
                                            <td class="auto-style4">
                                                <asp:Label ID="Lbl_LC_OcupadaPesos" runat="server" Text="0"></asp:Label>
                                            </td>
                                            <td class="auto-style5">
                                                <asp:Label ID="Lbl_LC_OcupadaUf" runat="server" Text="0"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Lbl_LC_DispPesos" runat="server" Text="0"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Lbl_LC_DispUF" runat="server" Text="0"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Lbl_PorUso" runat="server" Text="0"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td class="auto-style2">&nbsp;</td>
                                            <td colspan="2">&nbsp;</td>
                                            <td colspan="3">&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <asp:Label ID="Label30" runat="server" Text="Línea Ocupada en $ FACTURADO" Font-Bold="True"></asp:Label>
                                            </td>
                                            <td colspan="2">
                                                <asp:Label ID="Label31" runat="server" Text="Línea Ocupada en $ PROX. DESP" Font-Bold="True"></asp:Label>
                                            </td>
                                            <td colspan="3">
                                                <asp:Label ID="Label32" runat="server" Text="Línea Ocupada en $  POR FACTURAR" Font-Bold="True"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="lbl_lc_Pesos3" runat="server" Text="En $$"></asp:Label>
                                            </td>
                                            <td class="auto-style2">
                                                <asp:Label ID="lbl_lc_Uf4" runat="server" Text="En UF"></asp:Label>
                                            </td>
                                            <td class="auto-style4">
                                                <asp:Label ID="lbl_lc_Pesos4" runat="server" Text="En $$"></asp:Label>
                                            </td>
                                            <td class="auto-style5">
                                                <asp:Label ID="lbl_lc_Uf7" runat="server" Text="En UF"></asp:Label>
                                            </td>
                                            <td colspan="2">
                                                <asp:Label ID="lbl_lc_Pesos5" runat="server" Text="En $$"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lbl_lc_Uf8" runat="server" Text="En UF"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:Label ID="Lbl_FacPesos" runat="server" Text="0"></asp:Label>
                                            </td>
                                            <td class="auto-style2">
                                                <asp:Label ID="Lbl_FacUF" runat="server" Text="0"></asp:Label>
                                            </td>
                                            <td class="auto-style4">
                                                <asp:Label ID="Lbl_ProxDesp" runat="server" Text="0"></asp:Label>
                                            </td>
                                            <td class="auto-style5">
                                                <asp:Label ID="Lbl_ProgUF" runat="server" Text="0"></asp:Label>
                                            </td>
                                            <td colspan="2">
                                                <asp:Label ID="Lbl_XFacPesos" runat="server" Text="0"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="Lbl_XFacUF" runat="server" Text="0"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <asp:Button ID="Btn_DetFac" runat="server" Text="Ver Detalle" CssClass="btn btn-primary me-1" />
                                            </td>
                                            <td colspan="2">
                                                <asp:Button ID="Btn_DetProg" runat="server" Text="Ver Detalle" CssClass="btn btn-primary me-1" />
                                            </td>
                                            <td colspan="2">
                                                <asp:Button ID="Btn_DetXFac" runat="server" Text="Ver Detalle" CssClass="btn btn-primary me-1" />
                                                <asp:TextBox ID="Tx_rut" runat="server" ReadOnly="True" Width="75px" Visible="False"></asp:TextBox>
                                            </td>
                                        </tr>
                                    </table>
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
                            <div class="card-body bg-light">
                                <div class="row g-3">
                                    <table align="center" width="100%">
                                        <tr>
                                            <td align="center" bgcolor="#eb702c">
                                                <asp:Label ID="lbl_tituloDetalle" runat="server" Text="" Style="color: white; font-style: initial; font-size: larger"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                    <asp:GridView ID="GR_DetalleFac" class="table table-striped table-bordered" runat="server" AutoGenerateColumns="False">
                                                        <Columns>
                                                            <asp:BoundField DataField="CodDoc" HeaderText="Cod. doc.">
                                                                <ItemStyle HorizontalAlign="Right" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="NombreDoc" HeaderText="Nombre documento">
                                                                <ItemStyle HorizontalAlign="Right" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="NroDoc" HeaderText="Nro. Doc">
                                                                <ItemStyle HorizontalAlign="Right" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Importe" HeaderText="Valor($)">
                                                                <ItemStyle HorizontalAlign="Right" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Glosa" HeaderText="Glosa">
                                                                <ItemStyle HorizontalAlign="Right" />
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Empresa" HeaderText="Empresa">
                                                                <ItemStyle HorizontalAlign="Right" />
                                                            </asp:BoundField>
                                                        </Columns>
                                                    </asp:GridView>
                                            </td>
                                        </tr>
                                    </table>
                                        <asp:GridView ID="GR_DetalleProxD" class="table table-striped table-bordered" runat="server" AutoGenerateColumns="False">
                                            <Columns>
                                                <asp:BoundField DataField="Nombre" HeaderText="Obra">
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Codigo" HeaderText="IT">
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="TotalImporteKgs" HeaderText="Total It ($)">
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Kgs" HeaderText="Kilos IT">
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="ImporteKgs" HeaderText="Importe Kgs">
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="FechaDespacho" HeaderText="Fecha Despacho">
                                                    <ItemStyle HorizontalAlign="Right" />
                                                </asp:BoundField>
                                            </Columns>
                                        </asp:GridView>
                                    <br />
                                        <asp:GridView ID="GR_DetalleGuias" class="table table-striped table-bordered" runat="server" AutoGenerateColumns="False">
                                            <Columns>
                                                <asp:BoundField DataField="ValorKgs" HeaderText="Valor Kgs"></asp:BoundField>
                                                <asp:BoundField DataField="AteObsUno" HeaderText="Obs Uno"></asp:BoundField>
                                                <asp:BoundField DataField="AteObsDos" HeaderText="Obs dos"></asp:BoundField>
                                                <asp:BoundField DataField="AteGlo" HeaderText="Glosa"></asp:BoundField>
                                                <asp:BoundField DataField="AteNum" HeaderText="Nro. Guía"></asp:BoundField>
                                                <asp:BoundField DataField="AteFchAte" HeaderText="Fecha Atención"></asp:BoundField>
                                                <asp:BoundField DataField="AteProCan" HeaderText="Kilos Guía"></asp:BoundField>
                                                <asp:BoundField DataField="TotalGuia" HeaderText="Total Guía ($)"></asp:BoundField>
                                                <asp:BoundField DataField="TotalGuiaIVA" HeaderText="Total Guia c/Iva"></asp:BoundField>
                                                <asp:BoundField DataField="Empresa" HeaderText="Empresa"></asp:BoundField>
                                            </Columns>
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
