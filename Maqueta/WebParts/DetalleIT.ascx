<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="DetalleIT.ascx.vb" Inherits="Maqueta.DetalleIT" %>

<div class="col-lg-6">
    <div class="card h-100" dir="ltr">
        <div class="rounded-top-lg banner-titulo">
            <div class="row flex-between-end">
                <div class="col-auto align-self-center">
                    <h5 class="mb-0" style="color: white">IT's asociadas a la obra</h5>
                </div>
            </div>
        </div>
        <div class="card-body bg-light">
            <div style="overflow-y: scroll; height: 300px; width: 900px;">
                <asp:GridView ID="gvIT" runat="server" class="table table-striped table-bordered" BorderStyle="None" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="id" HeaderText="ID Viaje" />
                        <asp:BoundField DataField="codigo" HeaderText="Codigo" />
                        <asp:BoundField DataField="fechacreacion" HeaderText="Fecha creacion" />
                        <asp:BoundField DataField="estado" HeaderText="Estado" />
                        <asp:BoundField DataField="totalKgs" HeaderText="Total kgs" />
                        <asp:BoundField DataField="tipoguia_INET" HeaderText="Tipo guia INET" />
                        <asp:BoundField DataField="FechaDespacho" HeaderText="Fecha despacho" />
                    </Columns>
                </asp:GridView>
            </div>
            <br />
            <asp:Button ID="btnListadoITs" class="btn btn-primary" runat="server" Text="Ver listado completo" />
        </div>
    </div>
</div>
