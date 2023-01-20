<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="Contactos.ascx.vb" Inherits="Maqueta.Contactos" %>


<button class="btn btn-primary" type="button" data-bs-toggle="modal" data-bs-target="#error-modal">Ver contactos</button>
<div class="modal fade" id="error-modal" tabindex="-1" role="dialog" aria-hidden="true">
    <div class="modal-dialog modal-dialog-centered" role="document" style="max-width: 1000px">
        <div class="modal-content position-relative">
            <div class="position-absolute top-0 end-0 mt-2 me-2 z-index-1">
                <button class="btn-close btn btn-sm btn-circle d-flex flex-center transition-base" data-bs-dismiss="modal" aria-label="Close"></button>
            </div>
            <div class="modal-body p-0">
                <div class="rounded-top-lg banner-titulo">
                    <h5 class="mb-0" style="color: white">Contactos</h5>
                </div>
                <div class="p-4 pb-0">
                    <form>
                        <div class="row g-3">
                            <div class="col-4">
                                <label class="form-label" for="lblDireccionObra">Nombre contacto</label>
                                <asp:TextBox ID="txtNombreContacto" CssClass="form-control" runat="server" Text=""></asp:TextBox>
                            </div>
                            <div class="col-4">
                                <label class="form-label" for="lblDireccionObra">Correo contacto</label>
                                <asp:TextBox ID="txtCorreoContacto" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-4">
                                <label class="form-label" for="lblDireccionObra">Numero contacto</label>
                                <asp:TextBox ID="txtNumeroTelefono" CssClass="form-control" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-12">
                                <label class="form-label" for="lblDireccionObra">Observacion</label>
                                <asp:TextBox ID="txtObsContacto" CssClass="form-control" TextMode="MultiLine" Rows="3" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-2">
                                <asp:Button ID="brnGrabarContacto" class="btn btn-primary" runat="server" Text="Grabar contacto" />
                            </div>
                            <hr />
                            <div style="overflow-y: scroll; height: 300px; width: 1000px;">
                            <asp:GridView ID="gvContactos" runat="server" class="table table-striped table-bordered" BorderStyle="None">                                
                                <HeaderStyle CssClass="fixedHeader " />
                                <AlternatingRowStyle BorderStyle="None" />
                            </asp:GridView>
                            </div>
                        </div>
                    </form>
                    <br />
                </div>
            </div>
            <div class="modal-footer">
                <button class="btn btn-secondary" type="button" data-bs-dismiss="modal">Cerrar</button>
            </div>
        </div>
    </div>
</div>
<script src="https://code.jquery.com/jquery-3.5.1.js"></script>
<script src="https://cdn.datatables.net/1.12.1/js/jquery.dataTables.min.js"></script>
<script src="https://cdn.datatables.net/1.12.1/js/dataTables.bootstrap4.min.js"></script>
<link href="../Complementos/css/estilos.css" rel="stylesheet" />
<script type="text/javascript">
        $(document).ready(function () {
            $('#<%=gvContactos.ClientID%>').DataTable({
                //para cambiar el lenguaje a español
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
