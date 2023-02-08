<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Logistica.aspx.vb" Inherits="Maqueta.Logistica" %>

<%@ Register Src="~/WebParts/PanelSuperior.ascx" TagPrefix="uc1" TagName="PanelSuperior" %>
<%@ Register Src="~/WebParts/Observaciones.ascx" TagPrefix="uc1" TagName="Observaciones" %>
<%@ Register Src="~/WebParts/ListadoPrecios.ascx" TagPrefix="uc1" TagName="ListadoPrecios" %>
<%@ Register Src="~/WebParts/OrdenesCompravsDespachos.ascx" TagPrefix="uc1" TagName="OrdenesCompravsDespachos" %>
<%@ Register Src="~/WebParts/Contactos.ascx" TagPrefix="uc1" TagName="Contactos" %>
<%@ Register Src="~/WebParts/ContratosOrdendeCompra.ascx" TagPrefix="uc1" TagName="ContratosOrdendeCompra" %>
<%@ Register Src="~/WebParts/DetaleCamionLogistica.ascx" TagPrefix="uc1" TagName="DetaleCamionLogistica" %>




<!DOCTYPE html>
<html lang="en-US" dir="ltr">

<head>
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">


    <!-- ===============================================-->
    <!--    Document Title-->
    <!-- ===============================================-->
    <title>P.A.G.O | Pestaña C.O.F</title>


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
                <a class="navbar-brand" style="color: dimgray">Pestaña Logística</a>
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
                                    <div class="col-2">
                                        <label class="form-label" for="lblNombreObra">Ubicacion</label>
                                        <asp:Button ID="btnUbicacion" class="btn btn-primary" runat="server" Text="Ver ubicacion" />
                                    </div>
                                    <div class="col-6">
                                        <label class="form-label" for="lblNombreObra">Direccion obra</label>
                                        <asp:TextBox ID="txtDireccion" CssClass="form-control" runat="server" Enabled="false"></asp:TextBox>
                                    </div>
                                    <div class="col-3">
                                        <label class="form-label" for="lblDireccionObra">Comuna</label>
                                        <asp:TextBox ID="txtComuna" CssClass="form-control" runat="server" Enabled="false"></asp:TextBox>
                                    </div>
                                    <div class="col-3">
                                        <label class="form-label" for="lblDireccionObra">Ciudad</label>
                                        <asp:TextBox ID="txtCiudad" CssClass="form-control" runat="server" Enabled="false"></asp:TextBox>
                                    </div>
                                    <div class="col-3">
                                        <label class="form-label" for="lblNombreObra">Tipo Camion</label>
                                        <asp:TextBox ID="txtTipoCamion" CssClass="form-control" runat="server" Text="Sin informacion" Enabled="false"></asp:TextBox>
                                    </div>
                                    <div class="col-3">
                                        <label class="form-label" for="lblNombreObra">Detalle camion</label>
                                        <button class="btn btn-primary" type="button" data-bs-toggle="modal" data-bs-target="#ModalLogistica">Ver detalle</button>
                                    </div>
                                    <div class="col-3">
                                        <label class="form-label" for="lblNombreObra">Tiempo desplazamiento</label>
                                        <asp:DropDownList ID="dpDesplazamiento" runat="server" class="form-select js-choice">
                                            <asp:ListItem>Seleccione:</asp:ListItem>
                                            <asp:ListItem Value="1">1 hora</asp:ListItem>
                                            <asp:ListItem Value="2">2 horas</asp:ListItem>
                                            <asp:ListItem Value="3">3 horas</asp:ListItem>
                                            <asp:ListItem Value="4">4 horas</asp:ListItem>
                                            <asp:ListItem Value="5">5 horas</asp:ListItem>
                                            <asp:ListItem Value="6">6 horas</asp:ListItem>
                                            <asp:ListItem Value="7 ">7 horas</asp:ListItem>
                                            <asp:ListItem Value="8">8 horas</asp:ListItem>
                                            <asp:ListItem Value="9">9 horas</asp:ListItem>
                                            <asp:ListItem Value="10">10 horas</asp:ListItem>
                                            <asp:ListItem Value="11">11 horas</asp:ListItem>
                                            <asp:ListItem Value="12">12 horas</asp:ListItem>
                                            <asp:ListItem Value="24">Hasta 24 horas</asp:ListItem>
                                            <asp:ListItem Value="48">Hasta 48 horas</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                    <div class="col-3">
                                    </div>
                                    <div class="col-6">
                                        <label class="form-label" for="lblNombreObra">Horario recepcion</label>
                                        <asp:TextBox ID="txtHoraRecepcion" CssClass="form-control" runat="server" Enabled="false" Text="Sin informacion"></asp:TextBox>
                                    </div>
                                    <div class="col-4">
                                        <label class="form-label" for="lblDireccionObra">Codigo despacho</label>
                                        <asp:TextBox ID="txtCodigo" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-2">
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
                                    <div class="col-12">
                                        <asp:Panel ID="PanelLOG" runat="server" Visible=" false">
                                            <asp:Button ID="btnGrabar" class="btn btn-primary" runat="server" Text="Grabar" />
                                            <asp:Button ID="btnAgregarDatos" runat="server" class="btn btn-primary" Text="Ingresar datos despacho" />
                                        </asp:Panel>
                                        <br />
                                        <uc1:Contactos runat="server" ID="Contactos" />
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
                    <%--TABLA CONTRATOS--%>
                    <uc1:ContratosOrdendeCompra runat="server" ID="ContratosOrdendeCompra" />
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
                                <asp:GridView ID="gvControlCosto" runat="server" class="table table-striped table-bordered" BorderStyle="None" AutoGenerateColumns="False">
                                    <Columns>
                                        <asp:BoundField HeaderText="Transportista" DataField="NombreTransporte" />
                                        <asp:BoundField HeaderText="Costo neto ($)" DataField="costoNeto" />
                                        <asp:BoundField HeaderText="Costo sobreestadia ($)" DataField="costosobreestadia" />
                                        <asp:BoundField HeaderText="Costo flete falso ($)" DataField="costofleteFalso" />
                                        <asp:BoundField HeaderText="Costo total ($)" DataField="CostoTotalTransporte" />
                                        <asp:BoundField HeaderText="Sucursal" DataField="Sucursal" />
                                        <asp:BoundField HeaderText="N° factura" DataField="NroFactura" />
                                        <asp:BoundField HeaderText="N° GDE" DataField="NroGDE" />
                                        <asp:BoundField HeaderText="GDE en servidor" DataField="GDE_En_Servidor" />
                                        <asp:BoundField HeaderText="Fecha GDE" DataField="FechaGDE" />
                                        <asp:BoundField HeaderText="Tipo GDE" DataField="TipoGuia" />
                                        <asp:BoundField HeaderText="Kilos GDE" DataField="KgsGDE" />
                                        <asp:BoundField HeaderText="Pago cliente" />
                                        <asp:BoundField HeaderText="Observacion" />
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>
                    <br />
                    <%--OBSERVACIONES--%>
                    <uc1:Observaciones runat="server" ID="Observaciones" />
                    <br />
                    <br />
                    <div class="modal fade" id="ModalLogistica" tabindex="-1" role="dialog" aria-hidden="true">
                        <div class="modal-dialog modal-dialog-centered" role="document" style="max-width: 1000px">
                            <div class="modal-content position-relative">
                                <div class="position-absolute top-0 end-0 mt-2 me-2 z-index-1">
                                    <button class="btn-close btn btn-sm btn-circle d-flex flex-center transition-base" data-bs-dismiss="modal" aria-label="Close"></button>
                                </div>
                                <div class="modal-body p-0">
                                    <div class="rounded-top-lg banner-titulo">
                                        <h5 class="mb-0" style="color: white">Detalle camion</h5>
                                    </div>
                                    <div class="p-4 pb-0">
                                        <div class="row g-3">
                                            <asp:Panel ID="PanelDetalle" runat="server">
                                                <div class="col-4">
                                                    <label class="form-label" for="lblNombreObra">Tipo Camion</label>
                                                    <asp:DropDownList ID="dpCamion" runat="server" class="form-select js-choice">
                                                        <asp:ListItem>Seleccione:</asp:ListItem>
                                                        <asp:ListItem>Camion</asp:ListItem>
                                                        <asp:ListItem>Rampla</asp:ListItem>
                                                        <asp:ListItem>Ambos</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                                <div class="col-12">
                                                    <label class="form-label" for="lblDireccionObra">Observacion asociada</label>
                                                    <asp:TextBox ID="txtObsCamion" CssClass="form-control" TextMode="MultiLine" Rows="3" runat="server"></asp:TextBox>
                                                </div>
                                                <div class="col-4">
                                                    <label class="form-label" for="lblNombreObra">Hora recepcion</label>
                                                    <asp:DropDownList ID="dpTipoRecepcion" runat="server" class="form-select js-choice">
                                                        <asp:ListItem>Seleccione:</asp:ListItem>
                                                        <asp:ListItem>Rango</asp:ListItem>
                                                        <asp:ListItem>Hora establecida</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                                <div class="col-8">
                                                </div>
                                                <div class="col-3">
                                                    <label class="form-label" for="lblNombreObra">Hora inicio</label>
                                                    <asp:DropDownList ID="DpHora1" runat="server" class="form-select js-choice">
                                                        <asp:ListItem>Seleccione:</asp:ListItem>
                                                        <asp:ListItem>06:00</asp:ListItem>
                                                        <asp:ListItem>07:00</asp:ListItem>
                                                        <asp:ListItem>08:00</asp:ListItem>
                                                        <asp:ListItem>09:00</asp:ListItem>
                                                        <asp:ListItem>10:00</asp:ListItem>
                                                        <asp:ListItem>11:00</asp:ListItem>
                                                        <asp:ListItem>12:00</asp:ListItem>
                                                        <asp:ListItem>13:00</asp:ListItem>
                                                        <asp:ListItem>14:00</asp:ListItem>
                                                        <asp:ListItem>15:00</asp:ListItem>
                                                        <asp:ListItem>16:00</asp:ListItem>
                                                        <asp:ListItem>17:00</asp:ListItem>
                                                        <asp:ListItem>18:00</asp:ListItem>
                                                        <asp:ListItem>19:00</asp:ListItem>
                                                        <asp:ListItem>20:00</asp:ListItem>
                                                        <asp:ListItem>21:00</asp:ListItem>
                                                        <asp:ListItem>22:00</asp:ListItem>
                                                        <asp:ListItem>23:00</asp:ListItem>
                                                        <asp:ListItem>00:00</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                                <div class="col-3">
                                                    <label class="form-label" for="lblNombreObra">Hora final</label>
                                                    <asp:DropDownList ID="DpHora2" runat="server" class="form-select js-choice">
                                                        <asp:ListItem>Seleccione:</asp:ListItem>
                                                        <asp:ListItem>06:00</asp:ListItem>
                                                        <asp:ListItem>07:00</asp:ListItem>
                                                        <asp:ListItem>08:00</asp:ListItem>
                                                        <asp:ListItem>09:00</asp:ListItem>
                                                        <asp:ListItem>10:00</asp:ListItem>
                                                        <asp:ListItem>11:00</asp:ListItem>
                                                        <asp:ListItem>12:00</asp:ListItem>
                                                        <asp:ListItem>13:00</asp:ListItem>
                                                        <asp:ListItem>14:00</asp:ListItem>
                                                        <asp:ListItem>15:00</asp:ListItem>
                                                        <asp:ListItem>16:00</asp:ListItem>
                                                        <asp:ListItem>17:00</asp:ListItem>
                                                        <asp:ListItem>18:00</asp:ListItem>
                                                        <asp:ListItem>19:00</asp:ListItem>
                                                        <asp:ListItem>20:00</asp:ListItem>
                                                        <asp:ListItem>21:00</asp:ListItem>
                                                        <asp:ListItem>22:00</asp:ListItem>
                                                        <asp:ListItem>23:00</asp:ListItem>
                                                        <asp:ListItem>00:00</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                                <br />
                                                <div class="col-12">
                                                    <asp:Button ID="brnGrabar" class="btn btn-primary" runat="server" Text="Grabar" />
                                                </div>
                                            </asp:Panel>
                                            <hr />
                                            <div style="overflow-y: scroll; height: 300px; width: 1000px;">
                                                <asp:GridView ID="gvDetalleCamion" runat="server" class="table table-striped table-bordered" BorderStyle="None">
                                                    <HeaderStyle CssClass="fixedHeader " />
                                                    <AlternatingRowStyle BorderStyle="None" />
                                                    <%--<Columns>
                                                            <asp:BoundField DataField="id" HeaderText="ID" />
                                                            <asp:BoundField DataField="TipoCamion" HeaderText="Tipo Camion" />
                                                            <asp:BoundField DataField="Observacion" HeaderText="Observacion" />
                                                            <asp:BoundField DataField="TipoRecepcion" HeaderText="Tipo recepcion" />
                                                            <asp:BoundField DataField="Empresa" HeaderText="Empresa" />
                                                            <asp:BoundField DataField="Dir" HeaderText="Direccion" />
                                                            <asp:BoundField DataField="Encargado" HeaderText="Encargado" />
                                                            <asp:BoundField DataField="Telefono" HeaderText="Telefono" />
                                                            <asp:BoundField DataField="FechaCrea" HeaderText="Fecha creacion" />
                                                            <asp:BoundField DataField="Usuario" HeaderText="Usuario" />
                                                        </Columns>--%>
                                                </asp:GridView>
                                            </div>
                                        </div>
                                        <br />
                                    </div>
                                </div>
                                <div class="modal-footer">
                                    <button class="btn btn-secondary" type="button" data-bs-dismiss="modal">Cerrar</button>
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

