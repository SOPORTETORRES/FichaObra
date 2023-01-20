Public Class Login
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    End Sub

    Protected Sub btnIngresar_Click(sender As Object, e As EventArgs) Handles btnIngresar.Click
        ValidarUsuario()
    End Sub

    Public Function ValidarUsuario() As Boolean
        Dim ldal As New Datos(), lTbl As New DataTable, lSql As String
        lSql = String.Concat("  SP_Consultas_FichaObra  11 ,'", txtUsuario.Text, "','", txtPass.Text, "','','','','','','','',''")
        Try
            lTbl = ldal.CargaTabla(lSql, "L")
            If (lTbl.Rows.Count > 0) Then
                Session("UsuarioLogueado") = lTbl.Rows(0)("Usuario").ToString()
                Session("idUsuario") = lTbl.Rows(0)("Id").ToString()
                Response.Redirect("FichaObra.aspx")
                Return True
            Else
                lblError.Text = "Usuario o Contrasena no valido"
                Return False
            End If


        Catch ex As Exception
            'lblError.Text = ex.Message
            Return False
        Finally
            'conn.Close()
        End Try
    End Function
End Class