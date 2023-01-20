Public Class DetaleCamionLogistica
    Inherits System.Web.UI.UserControl

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub dpTipoRecepcion_SelectedIndexChanged(sender As Object, e As EventArgs) Handles dpTipoRecepcion.SelectedIndexChanged
        If dpTipoRecepcion.Text = "Entre horas" Then
            Hora1.Visible = True
            Hora2.Visible = True
        Else
            Hora1.Visible = True
            Hora2.Visible = False
        End If
    End Sub
End Class