Public Class FichaObra
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        cargarCotizaciones()
    End Sub

    Private Function cargarCotizaciones() As Boolean
        Dim lresultado As Boolean
        Dim ldal As New Datos
        Dim lSql As String = ""
        lSql = String.Concat("select o.Id, SiglaObra,  o.Nombre, EstadoAlta, o.Empresa, o.Dir, Encargado, Telefono,
        FechaCrea, u.Usuario as usuario from Obras O, to_Usuarios U where EstadoAlta <> 'FIN' and o.empresa = 'TO' and o.UsuarioCrea = u.Id")
        Try
            Dim lTabla As New Data.DataTable
            lTabla = ldal.CargaTabla(lSql, "L")
            gvObras.DataSource = lTabla
            gvObras.DataBind()
            gvObras.UseAccessibleHeader = True
            gvObras.HeaderRow.TableSection = TableRowSection.TableHeader
        Catch ex As Exception
            'lblError.Text = ex.ToString
        Finally

        End Try
        Return lresultado
    End Function

    Protected Sub gvObras_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gvObras.SelectedIndexChanged
        Dim obra = HttpUtility.HtmlDecode(gvObras.SelectedRow.Cells.Item(1).Text.ToString)
        Dim nombreobra As String = HttpUtility.HtmlDecode(gvObras.SelectedRow.Cells.Item(2).Text.ToString)
        Session("obra") = obra
        Session("NombreObra") = nombreobra
        Response.Redirect("General.aspx?idObra=" + obra)
    End Sub
End Class