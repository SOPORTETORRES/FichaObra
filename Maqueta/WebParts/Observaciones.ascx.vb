Public Class Observaciones
    Inherits System.Web.UI.UserControl

    'principal

    Dim dt As New DataTable
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            'If ViewState("datos") Is Nothing Then
            '    dt.Columns.Add("Usuario")
            '    dt.Columns.Add("Departamento")
            '    dt.Columns.Add("Fecha y hora")
            '    dt.Columns.Add("Observacion")
            '    ViewState("datos") = dt
            'End If
            CargaTablaObs()
        End If
        If Session("Pestaña") = "General" Then
            lblobs.Visible = False
            txtObservaciones.Visible = False
            btnSubirObs.Visible = False
        End If
    End Sub

    Protected Sub btnSubirObs_Click(sender As Object, e As EventArgs) Handles btnSubirObs.Click
        Dim lIdObra As String = "", lDatos As New Datos, lDepto As String = "", lIdUser As String = "1"
        If ValidarDatos() = True Then
            lIdObra = Session("obra")
            lDepto = Session("Pestaña")
            lDatos.GrabaObs(lIdObra, txtObservaciones.Text, lDepto, lIdUser)
            CargaTablaObs()
            txtObservaciones.Text = ""
        End If
    End Sub

    Private Function ValidarDatos() As Boolean
        Dim lMsg As String = "", lRes As Boolean = True, IdObra As String = ""
        If txtObservaciones.Text.Trim.Length < 1 Then
            lRes = False
            lMsg = "Debe Indcar una Observación  "
        End If
        IdObra = Val(Session("obra").ToString())
        If Val(IdObra) = 0 Then
            lRes = False
            lMsg = "La variable de session No esta especificada "
        End If
        Return lRes
    End Function

    Private Sub CargaTablaObs()
        Dim lDAtos As New Datos, lTblRes As New DataTable, lIdObra As String = ""
        lIdObra = Session("obra")
        lTblRes = lDAtos.CargaTablaObs(lIdObra)
        gvObservaciones.DataSource = lTblRes
        gvObservaciones.DataBind()
    End Sub
End Class