<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="DetaleCamionLogistica.ascx.vb" Inherits="Maqueta.DetaleCamionLogistica" %>

<button class="btn btn-primary" type="button" data-bs-toggle="modal" data-bs-target="#ModalLogistica">Ver detalle</button>
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
                    <form>
                        <div class="row g-3">
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
                                <asp:TextBox ID="txtObsContacto" CssClass="form-control" TextMode="MultiLine" Rows="3" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-4">
                                <label class="form-label" for="lblNombreObra">Hora recepcion</label>
                                <asp:DropDownList ID="dpTipoRecepcion" runat="server" class="form-select js-choice">
                                    <asp:ListItem>Seleccione:</asp:ListItem>
                                    <asp:ListItem>Entre horas</asp:ListItem>
                                    <asp:ListItem>Hora establecida</asp:ListItem>
                                </asp:DropDownList>
                                <br />
                                <asp:TextBox ID="Hora1" CssClass="form-control" runat="server" Visible="false"></asp:TextBox>
                                <asp:TextBox ID="Hora2" CssClass="form-control" runat="server" Visible="false"></asp:TextBox>
                            </div>
                            <div class="col-12">
                                <asp:Button ID="brnGrabarContacto" class="btn btn-primary" runat="server" Text="Grabar" />
                            </div>
                            <hr />
                            <div style="overflow-y: scroll; height: 300px; width: 1000px;">
                            <asp:GridView ID="gvDetalleCamion" runat="server" class="table table-striped table-bordered" BorderStyle="None">                                
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
