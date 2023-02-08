<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="IngresoDatosDespacho.aspx.vb" Inherits="Maqueta.IngresoDatosDespacho" %>

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
    <title>CUBIGEST | Ingreso datos despacho </title>


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
            <form runat="server">
                <br />
                <div class="row g-3 mb-3 justify-content-center">
                    <div class="col-lg-6">
                        <div class="card h-100" dir="ltr">
                            <div class="rounded-top-lg banner-titulo">
                                <div class="row flex-between-end2">
                                    <div class="col-auto align-self-center">
                                        <h5 class="mb-0" style="color: white">Ingreso de datos despacho</h5>
                                    </div>
                                </div>
                            </div>
                            <div class="card-body bg-light">
                                <div class="row g-6">
                                    <div class="col-4">
                                        <label class="form-label" for="lblNombreObra">Introducir N° guia despacho</label>
                                        <asp:TextBox ID="txtGDE" CssClass="form-control" runat="server"></asp:TextBox>
                                        <br />
                                        <asp:Button ID="btnBuscar" runat="server" class="btn btn-primary form-control" Text="Buscar" />
                                        <br />
                                        <br />
                                        <label class="form-label" for="peso">Costo Neto Transporte ($)</label>
                                        <asp:TextBox ID="txtCostoNeto" CssClass="form-control" runat="server"></asp:TextBox>
                                        <label class="form-label" for="lblCantidadKG">Costo sobreestadia ($)</label>
                                        <asp:TextBox ID="txtSobreestadia" CssClass="form-control" runat="server"></asp:TextBox>
                                        <label class="form-label" for="lblCantidadKG">Costo flete falso ($)</label>
                                        <asp:TextBox ID="txtCostoFalso" CssClass="form-control" runat="server"></asp:TextBox>
                                        <label class="form-label" for="lblCantidadKG">N° Factura</label>
                                        <asp:TextBox ID="txtNFactura" CssClass="form-control" runat="server"></asp:TextBox>
                                        <label class="form-label" for="lblCantidadKG">Transportista</label>
                                        <asp:DropDownList ID="dpTransportista" runat="server" class="form-select js-choice">
                                            <asp:ListItem>Seleccione:</asp:ListItem>
                                            <asp:ListItem>Btrans</asp:ListItem>
                                            <asp:ListItem>Farias</asp:ListItem>
                                        </asp:DropDownList>
                                        <label class="form-label" for="lblCantidadKG">Observacion</label>
                                        <asp:TextBox ID="txtObs" CssClass="form-control" runat="server" TextMode="MultiLine" Rows="3"></asp:TextBox>
                                        <br />
                                        <asp:Button ID="btnGrabar" runat="server" class="btn btn-primary form-control" Text="Grabar datos" />
                                    </div>
                                    <div class="col-1">
                                    </div>
                                    <div class="col-6">
                                        <label class="form-label" for="peso">Codigo producto</label>
                                        <asp:TextBox ID="txtCodigoProducto" CssClass="form-control" runat="server" Enabled ="false"></asp:TextBox>
                                        <label class="form-label" for="lblCantidadKG">Nombre obra</label>
                                        <asp:TextBox ID="txtObra" CssClass="form-control" runat="server" Enabled ="false"></asp:TextBox>
                                        <label class="form-label" for="lblCantidadKG">Centro de costo</label>
                                        <asp:TextBox ID="txtCentroCosto" CssClass="form-control" runat="server" Enabled ="false"></asp:TextBox>
                                        <label class="form-label" for="lblCantidadKG">Sucursal</label>
                                        <asp:TextBox ID="txtSucursal" CssClass="form-control" runat="server" Enabled ="false"></asp:TextBox>
                                        <label class="form-label" for="lblCantidadKG">Fecha GDE</label>
                                        <asp:TextBox ID="txtFechaGDE" CssClass="form-control" runat="server" Enabled ="false"></asp:TextBox>
                                        <label class="form-label" for="lblCantidadKG">Tipo GDE</label>
                                        <asp:TextBox ID="txtTipoGDE" CssClass="form-control" runat="server" Enabled ="false"></asp:TextBox>
                                        <label class="form-label" for="lblCantidadKG">Pago Cliente</label>
                                        <asp:TextBox ID="txtPagoCliente" CssClass="form-control" runat="server" Enabled ="false"></asp:TextBox>
                                    </div>
                                    <div class="col-3">
                                        <asp:Button ID="btnVolver" runat="server" class="btn btn-primary" Text="Volver" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <br />
                    <div class="col-lg-12">
                        <div class="card h-100" dir="ltr">
                            <div class="rounded-top-lg banner-titulo">
                                <div class="row flex-between-end">
                                    <div class="col-auto align-self-center">
                                        <h5 class="mb-0" style="color: white">Control costo transporte</h5>
                                    </div>
                                </div>
                            </div>
                            <div class="card-body bg-light">
                                <div style="overflow-x:auto;width:auto">
                                <asp:GridView ID="gvControlCosto" runat="server" class="table table-striped table-bordered" BorderStyle="None" AutoGenerateColumns="False">
                                    <Columns>
                                        <asp:BoundField HeaderText="Codigo" DataField="Codigo_INET" >
                                        <ItemStyle Font-Size="Smaller" />
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="Nombre obra" DataField="Nombre" >
                                        <ItemStyle Font-Size="Smaller" />
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="Centro costo" DataField="centroCosto" />
                                        <asp:BoundField HeaderText="Transportista" DataField="NombreTransporte" />
                                        <asp:BoundField HeaderText="Neto ($)" DataField="costoNeto" >
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="Sobreestadia ($)" DataField="costosobreestadia" >
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="Flete falso ($)" DataField="costofleteFalso" >
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="Total ($)" DataField="CostoTotalTransporte" >
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="Sucursal" DataField="Sucursal" />
                                        <asp:BoundField HeaderText="N° factura" DataField="NroFactura" />
                                        <asp:BoundField HeaderText="N° GDE" DataField="NroGDE" />
                                        <asp:BoundField HeaderText="GDE en Serv" DataField="GDE_En_Servidor" />
                                        <asp:BoundField HeaderText="Fecha GDE" DataField="FechaGDE" >
                                        <HeaderStyle Width="120px" />
                                        </asp:BoundField>
                                        <asp:BoundField HeaderText="Tipo GDE" DataField="TipoGuia" />
                                        <asp:BoundField HeaderText="Kilos GDE" DataField="KgsGDE" />
                                        <asp:BoundField HeaderText="Pago cliente" />
                                        <asp:ButtonField HeaderText="Obs" CommandName="Select" Text="Ver obs" />
                                    </Columns>
                                </asp:GridView>
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
                <%--<p class="mb-0 text-600">P.A.G.O v1.0.0</p>--%>
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
    <script src="https://code.jquery.com/jquery-3.5.1.js"></script>
    <script src="https://cdn.datatables.net/1.12.1/js/jquery.dataTables.min.js"></script>
    <script src="https://cdn.datatables.net/1.12.1/js/dataTables.bootstrap4.min.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            $('#<%=gvControlCosto.ClientID%>').DataTable({
                //para cambiar el lenguaje a español
                order: [[0, 'asc']],
                "language": {
                    "lengthMenu": "Mostrar _MENU_ registros",
                    "zeroRecords": "No se encontraron resultados",
                    "info": "Mostrando registros del _START_ al _END_ de un total de _TOTAL_ registros",
                    "infoEmpty": "Mostrando registros del 0 al 0 de un total de 0 registros",
                    "infoFiltered": "(filtrado de un total de _MAX_ registros)",
                    "sSearch": "Buscar:",
                    "oPaginate": {
                        "sFirst": "Primero",
                        "sLast": "Último",
                        "sNext": "Siguiente",
                        "sPrevious": "Anterior"
                    },
                    "sProcessing": "Procesando...",
                }
            });
        });
    </script>
</body>

</html>
