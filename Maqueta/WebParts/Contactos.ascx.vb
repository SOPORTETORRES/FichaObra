Public Class Contactos
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            CargaTablaContactos()
        End If
    End Sub

    Private Function ValidarDatos() As Boolean
        Dim lMsg As String = "", lRes As Boolean = True, IdObra As String = ""
        If txtNombreContacto.Text.Trim.Length < 1 Then
            lRes = False
            lMsg = "Debe Indicar una Observación  "
        End If
        IdObra = Val(Session("obra").ToString())
        If txtCorreoContacto.Text.Trim.Length < 1 Then
            lRes = False
            lMsg = "Debe Indicar el Correo electrónico  "
        End If
        If txtNumeroTelefono.Text.Trim.Length < 1 Then
            lRes = False
            lMsg = "Debe Indicar el  número de Teléfono  "
        End If
        If txtObsContacto.Text.Trim.Length < 1 Then
            lRes = False
            lMsg = "Debe Indicar una Observación  "
        End If


        If Val(IdObra) = 0 Then
            lRes = False
            lMsg = "La variable de session No esta especificada "
        End If

        Return lRes
    End Function

    Private Sub LimpiaForm()
        txtNombreContacto.Text = ""
        txtCorreoContacto.Text = ""
        txtNumeroTelefono.Text = ""
        txtObsContacto.Text = ""
    End Sub

    Public Sub CargaTablaContactos()
        Dim lDAtos As New Datos, lTblRes As New DataTable, lIdObra As String = ""
        lIdObra = Session("obra")
        lTblRes = lDAtos.CargaTablaContacto(lIdObra)
        If lTblRes.Rows.Count >= 1 Then
            gvContactos.DataSource = lTblRes
            gvContactos.DataBind()
            gvContactos.UseAccessibleHeader = True
            gvContactos.HeaderRow.TableSection = TableRowSection.TableHeader
        End If
    End Sub

    Protected Sub brnGrabarContacto_Click(sender As Object, e As EventArgs) Handles brnGrabarContacto.Click
        Dim lIdObra As String = "", lDatos As New Datos, lDepto As String = "", lIdUser As String = "1"
        If ValidarDatos() = True Then
            lIdObra = Session("obra")
            lDepto = Session("Pestaña")
            lDatos.GrabaContacto(txtNombreContacto.Text, txtCorreoContacto.Text, lIdObra, txtObsContacto.Text, lIdUser, txtNumeroTelefono.Text, lDepto)
            CargaTablaContactos()
            LimpiaForm()
        End If
    End Sub
End Class