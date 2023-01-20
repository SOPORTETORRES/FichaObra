<%@ Control Language="vb" AutoEventWireup="false" CodeBehind="ListadoPrecios.ascx.vb" Inherits="Maqueta.ListadoPrecios" %>

<div class="col-lg-6">
    <div class="card h-100" dir="ltr">
        <div class="rounded-top-lg banner-titulo">
            <div class="row flex-between-end">
                <div class="col-auto align-self-center">
                    <h5 class="mb-0" style="color: white">Precios ingresados</h5>
                </div>
            </div>
        </div>
        <div class="card-body bg-light">
            <asp:Label ID="lblID" runat="server" Text="" Visible =" false"></asp:Label>
            <div style="overflow-y: scroll; height: 450px; width: 900px;">
                <asp:GridView ID="gvPrecios" runat="server" class="table table-striped table-bordered" BorderStyle="None" AllowPaging="True" PageSize="25"></asp:GridView>
            </div>
            <br />
            <asp:Panel ID="PanelCOF" runat="server" Visible =" false">
                <br />
                <asp:Button ID="btnGrabar2" runat="server" Text="Grabar codigos facturacion" class="btn btn-primary" />
            </asp:Panel>
        </div>
    </div>
</div>