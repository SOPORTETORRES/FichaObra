Public Class OrdenesCompravsDespachos
    Inherits System.Web.UI.UserControl

    Dim dtOC As New DataTable
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            'If ViewState("OC") Is Nothing Then
            '    dtOC.Columns.Add("Total kgs O.C")
            '    dtOC.Columns.Add("Total kgs cubicados")
            '    dtOC.Columns.Add("Total kgs despachados")
            '    dtOC.Columns.Add("Total kgs IT impresas")
            '    dtOC.Columns.Add("Total kgs para bloqueo")
            '    dtOC.Columns.Add("Estado reglas de negocio")
            '    dtOC.Columns.Add("Tipo de O.C")
            '    ViewState("OC") = dtOC
            'End If
            CargaTablaOC()
        End If
    End Sub

    Private Sub CargaTablaOC()
        Dim lDAtos As New Datos, lTblRes As New DataTable, lIdObra As String = ""
        lIdObra = Session("obra")
        lTblRes = lDAtos.OBtenerAvanceObra(lIdObra)
        gvOrdenCompra.DataSource = lTblRes
        gvOrdenCompra.DataBind()
    End Sub
End Class