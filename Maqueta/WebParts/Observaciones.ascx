<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="Observaciones.ascx.vb" Inherits="Maqueta.Observaciones" %>

<div class="col-lg-6">
    <div class="card h-100" dir="ltr">
        <div class="rounded-top-lg banner-titulo">
            <div class="row flex-between-end">
                <div class="col-auto align-self-center">
                    <h5 class="mb-0" style="color: white">Observaciones</h5>
                </div>
            </div>
        </div>
        <div class="card-body bg-light">
            <div style="overflow-y: scroll; height: 220px; width: 900px;">
                <asp:GridView ID="gvObservaciones" runat="server" class="table table-striped table-bordered" BorderStyle="None">
                </asp:GridView>
            </div>
            <div class="col-6">
                <asp:Label ID="lblobs" runat="server" Text="Ingresar observaciones" class="form-label"></asp:Label>
                <asp:TextBox ID="txtObservaciones" CssClass="form-control" runat="server" TextMode="MultiLine" Rows="3"></asp:TextBox>
            </div>
            <br />
            <div class="col-3">
                <asp:Button ID="btnSubirObs" runat="server" Text="Subir observacion" CssClass="form-control btn btn-primary me-1" />
            </div>
        </div>
    </div>
</div>
<script type="text/javascript">
        $(document).ready(function () {
            $('#<%=gvObservaciones.ClientID%>').DataTable({
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
