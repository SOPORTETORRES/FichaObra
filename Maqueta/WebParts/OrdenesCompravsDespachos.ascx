<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="OrdenesCompravsDespachos.ascx.vb" Inherits="Maqueta.OrdenesCompravsDespachos" %>

<div class="col-lg-6">
    <div class="card h-100" dir="ltr">
        <div class="rounded-top-lg banner-titulo">
            <div class="row flex-between-end">
                <div class="col-auto align-self-center">
                    <h5 class="mb-0" style="color: white">Datos de orden de compra v/s despachos</h5>
                </div>
            </div>
        </div>
        <div class="card-body bg-light">
            <div style="overflow-y: scroll; height: 300px; width: 900px;">
                <asp:GridView ID="gvOrdenCompra" runat="server" class="table table-striped table-bordered" BorderStyle="None"></asp:GridView>
            </div>
        </div>
    </div>
</div>
