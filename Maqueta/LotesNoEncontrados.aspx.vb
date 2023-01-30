Public Class LotesNoEncontrados
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CargaTablaLotesMissed()
    End Sub

    Private Sub CargaTablaLotesMissed()
        Dim lDal As New Datos, lIdObra As String = "", dtLotes As New DataTable
        lIdObra = Session("obra")
        dtLotes = lDal.CargaTablaObras()
        If dtLotes.Rows.Count >= 1 Then
            gvLotes.DataSource = dtLotes
            gvLotes.DataBind()
            gvLotes.UseAccessibleHeader = True
            gvLotes.HeaderRow.TableSection = TableRowSection.TableHeader
        End If
    End Sub

    Protected Sub btnVolver_Click(sender As Object, e As EventArgs) Handles btnVolver.Click
        Response.Redirect("Calidad.aspx")
    End Sub
End Class