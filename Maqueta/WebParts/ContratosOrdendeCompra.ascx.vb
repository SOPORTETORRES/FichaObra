Public Class ContratosOrdendeCompra
    Inherits System.Web.UI.UserControl

    Dim dtContrato As New DataTable
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            CargaTablaContratos()
        End If
    End Sub

    Private Sub CargaTablaContratos()
        Dim lDal As New Datos, lIdObra As String = ""
        lIdObra = Session("obra")
        dtContrato = lDal.CargaTabla_OC(lIdObra)
        gvContratos.DataSource = dtContrato
        gvContratos.DataBind()
    End Sub
End Class