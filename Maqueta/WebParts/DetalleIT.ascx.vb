Public Class DetalleIT
    Inherits System.Web.UI.UserControl

    Dim dtIT As New DataTable
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            CargaTablaIT()
        End If
    End Sub

    Private Sub CargaTablaIT()
        Dim lDal As New Datos, lIdObra As String = ""
        lIdObra = Session("obra")
        dtIT = lDal.CargaTabla_IT(lIdObra)
        gvIT.DataSource = dtIT
        gvIT.DataBind()
    End Sub

    Protected Sub btnListadoITs_Click(sender As Object, e As EventArgs) Handles btnListadoITs.Click
        Response.Redirect("ListadoITs.aspx")
    End Sub
End Class