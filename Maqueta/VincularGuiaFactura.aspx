<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="VincularGuiaFactura.aspx.vb" Inherits="Maqueta.VincularGuiaFactura" %>

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
            <form runat="server">
                <br />
                <div class="row g-3 mb-3 justify-content-center">
                    <div class="col-lg-6">
                        <div class="card h-100" dir="ltr">
                            <div class="rounded-top-lg banner-titulo">
                                <div class="row flex-between-end2">
                                    <div class="col-auto align-self-center">
                                        <h5 class="mb-0" style="color: white">Formulario de Vinculacion de Guías a Facturas</h5>
                                    </div>
                                </div>
                            </div>
                            <div class="card-body bg-light">
                                <div class="row g-3 justify-content-center">
                                    <div class="col-3">
                                        <label class="form-label" for="lblNombreObra">Ingrese la factura a vincular</label>
                                        <asp:TextBox ID="Tx_NroFacturaINET" runat="server" CssClass="form-control"></asp:TextBox>
                                    </div>
                                    <div class="col-3">
                                        <label class="form-label" for="lblNombreObra">Empresa</label>
                                        <asp:DropDownList ID="Cmb_Empresa" runat="server" class="form-select js-choice"
                                            DataTextField="Nombre" DataValueField="Id" AutoPostBack="True">
                                            <asp:ListItem>TO</asp:ListItem>
                                            <asp:ListItem>TOSOL</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-3">
                                        <label class="form-label" for="lblNombreObra">Rut cliente</label>
                                        <asp:Label ID="Lbl_RutCliente" runat="server" Font-Bold="True"></asp:Label>
                                    </div>
                                    <div class="col-3 ">
                                        <label class="form-label" for="lblNombreObra">Nombre cliente</label>
                                        <asp:Label ID="Lbl_NombreCl" runat="server" Font-Bold="True"></asp:Label>
                                    </div>
                                    <div class="col-4">
                                        <label class="form-label" for="lblNombreObra">Fecha doc.</label>
                                        <asp:Label ID="Lbl_FechaFact" runat="server" Font-Bold="True"></asp:Label>
                                    </div>
                                    <div class="col-4">
                                        <label class="form-label" for="lblNombreObra">Kgs factura</label>
                                        <asp:Label ID="Lbl_Kgs" runat="server" Font-Bold="True"></asp:Label>
                                    </div>
                                    <div class="col-3">
                                        <label class="form-label" for="lblNombreObra">+</label>
                                        <asp:Button ID="Btn_BuscaFactura" runat="server" Text="Buscar" CssClass="form-control btn btn-warning" />
                                    </div>
                                    <div class="col-6">
                                        <label class="form-label" for="lblNombreObra">Seleccione la Obra de la Guía</label>
                                        <asp:DropDownList ID="Cmb_Obras" runat="server" class="form-select js-choice"
                                            DataTextField="Nombre" DataValueField="Id" AutoPostBack="True">
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-3">
                                        <label class="form-label" for="lblNombreObra">Código Guía INET</label>
                                        <asp:Label ID="Lbl_CodGuiaINET" runat="server" Font-Bold="True"></asp:Label>
                                    </div>
                                    <div class="col-3">
                                        <label class="form-label" for="lblNombreObra">Código Guía</label>
                                        <asp:Label ID="Lbl_CodGuia" runat="server" Font-Bold="True"></asp:Label>
                                    </div>
                                    <div class="col-12">
                                        <asp:RadioButton ID="Rb_SinVincular" runat="server" Checked="True" GroupName="Guias" Text="Guías sin Vincular" />
                                        <asp:RadioButton ID="Rb_Vinculadas" runat="server" GroupName="Guias" Text="Guías Vinculadas" />
                                        <asp:RadioButton ID="Rb_Todas" runat="server" GroupName="Guias" Text="Todas" />
                                    </div>
                                    <div class="col-12">
                                        <asp:Label ID="lbl_msg" runat="server" ForeColor="#0033CC" Visible="False"></asp:Label>
                                    </div>
                                    <div class="col-12">
                                        <asp:GridView ID="Grd_Guias" runat="server" EnableModelValidation="True" AutoGenerateColumns="False">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Select">
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="Seleccionado" runat="server" />
                                                    </ItemTemplate>
                                                    <HeaderStyle Font-Size="Small" />
                                                    <ItemStyle HorizontalAlign="Center" Font-Size="Small" />
                                                </asp:TemplateField>

                                                <asp:BoundField DataField="atenum" HeaderText="Nro. Guía"></asp:BoundField>
                                                <asp:BoundField DataField="Kgs" HeaderText="Kgs. Guía"></asp:BoundField>
                                                <asp:BoundField DataField="FechaAtencion" HeaderText="Fecha Atención"></asp:BoundField>
                                                <asp:BoundField DataField="AteObsDos" HeaderText="Viajes "></asp:BoundField>
                                                <asp:BoundField DataField="NroFactura" HeaderText="Nro. Factura"></asp:BoundField>
                                            </Columns>
                                        </asp:GridView>
                                    </div>
                                    <div class="col-2">
                                        <asp:Button ID="Btn_Grabar" runat="server" Text="Grabar" CssClass="form-control btn btn-warning"/>
                                    </div>
                                    <div class="col-2">
                                        <asp:Button ID="Btn_Marcar" runat="server" Text="Marcar Todas" CssClass="form-control btn btn-warning"/>
                                    </div>
                                    <div class="col-3">
                                        <asp:Button ID="Btn_desmarcar" runat="server" Text="DesMarcar Todas" CssClass="form-control btn btn-warning"/>
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
