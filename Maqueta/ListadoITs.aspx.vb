Public Class ListadoITs
    Inherits System.Web.UI.Page

    Dim dtIT As New DataTable
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            CargaTablaIT()
        End If
    End Sub

    Private Sub CargaTablaIT()
        Dim lDal As New Datos, lIdObra As String = ""
        lIdObra = Session("obra")
        dtIT = lDal.CargaTabla_ITs(lIdObra)
        If dtIT.Rows.Count >= 1 Then
            gvITs.DataSource = dtIT
            gvITs.DataBind()
            gvITs.UseAccessibleHeader = True
            gvITs.HeaderRow.TableSection = TableRowSection.TableHeader
        End If
    End Sub

    Protected Sub btnVolver_Click(sender As Object, e As EventArgs) Handles btnVolver.Click
        Response.Redirect("OficinaTecnica.aspx")
    End Sub
End Class