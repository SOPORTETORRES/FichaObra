<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="FichaObra.aspx.vb" Inherits="Maqueta.FichaObra" %>

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
    <title>P.A.G.O | Ficha obra</title>


    <!-- ===============================================-->
    <!--    Favicons-->
    <!-- ===============================================-->
    <link rel="manifest" href="../assets/img/favicons/manifest.json">
    <meta name="msapplication-TileImage" content="../assets/img/favicons/mstile-150x150.png">
    <meta name="theme-color" content="#ffffff">
    <script src="Complementos/js/config.js"></script>
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

                <%--<div class="row g-12 mb-12">
                    <div class="col-md-12 col-xxl-12">
                        <div class="card h-md-100 ecommerce-card-min-width">
                            <div class="card-header pb-0">
                                <h5 class="mb-0 mt-2 d-flex align-items-center">Datos de la obra</h5>
                            </div>
                            <div class="card-body d-flex flex-column justify-content-end">
                                <asp:GridView ID="gvObras" runat="server" AutoGenerateColumns="False" class="table table-striped table-bordered" BorderStyle="None" AllowSorting="True">
                                    <Columns>
                                        <asp:BoundField DataField="id" HeaderText="ID" />
                                        <asp:BoundField DataField="Nombre" HeaderText="Nombre obra" />
                                        <asp:BoundField DataField="Dir" HeaderText="Direccion" />
                                        <asp:BoundField DataField="Encargado" HeaderText="Encargado" />
                                        <asp:BoundField DataField="Telefono" HeaderText="Telefono" />
                                        <asp:BoundField DataField="Estado" HeaderText="Estado" />
                                        <asp:BoundField DataField="FechaCrea" HeaderText="Fecha creacion" />
                                        <asp:BoundField DataField="UsuarioCrea" HeaderText="Usuario" />
                                        <asp:BoundField DataField="Obs" HeaderText="Observacion" />
                                        <asp:BoundField DataField="PesoMaxIT" HeaderText="Peso Max IT" />
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>
                    </div>

                </div>--%>

                <div class="card mb-3">
                    <div class="card-header">
                        <div class="row flex-between-end">
                            <div class="col-auto align-self-center">
                                <h3 class="mb-0">Obras</h3>
                            </div>
                        </div>
                    </div>
                    <div class="card-body pt-0">
                        <div class="tab-content">
                            <div>
                                <div class="table-responsive scrollbar">
                                    <asp:GridView ID="gvObras" runat="server" AutoGenerateColumns="False" class="table table-striped table-bordered" BorderStyle="None" AllowSorting="True">
                                        <Columns>
                                            <asp:ButtonField CommandName="Select" Text="Seleccionar" />
                                            <asp:BoundField DataField="id" HeaderText="ID" />
                                            <asp:BoundField DataField="SiglaObra" HeaderText="Sigla" />
                                            <asp:BoundField DataField="Nombre" HeaderText="Nombre obra" />
                                            <asp:BoundField DataField="EstadoAlta" HeaderText="Estado" />
                                            <asp:BoundField DataField="Empresa" HeaderText="Empresa" />
                                            <asp:BoundField DataField="Dir" HeaderText="Direccion" />
                                            <asp:BoundField DataField="Encargado" HeaderText="Encargado" />
                                            <asp:BoundField DataField="Telefono" HeaderText="Telefono" />
                                            <asp:BoundField DataField="FechaCrea" HeaderText="Fecha creacion" />
                                            <asp:BoundField DataField="Usuario" HeaderText="Usuario" />
                                        </Columns>
                                    </asp:GridView>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <br />
                <br />
            </form>
        </div>
    </main>
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
            $('#<%=gvObras.ClientID%>').DataTable({
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
