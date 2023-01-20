Public Class ObrasFinalizadas
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        cargaObrasFinalizadas()
    End Sub

    Private Sub cargaObrasFinalizadas()
        Dim ldal As New Datos
        Dim lSql As String = ""
        lSql = String.Concat("Exec SP_CONSULTAS_GENERALES_ADM_OBRAS 0,0,'','','','',18")
        Try
            Dim lTabla As New Data.DataTable
            lTabla = ldal.CargaTabla(lSql, "L")
            gvObrasFinalizadas.DataSource = lTabla
            gvObrasFinalizadas.DataBind()
            gvObrasFinalizadas.UseAccessibleHeader = True
            gvObrasFinalizadas.HeaderRow.TableSection = TableRowSection.TableHeader
        Catch ex As Exception
            'lblError.Text = ex.ToString
        Finally

        End Try
    End Sub

    Protected Sub gvObrasFinalizadas_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gvObrasFinalizadas.SelectedIndexChanged
        Dim lIndex As Integer = gvObrasFinalizadas.SelectedIndex
        'Dim lObra As New BussinesObjects.Tipos.Tipo_Obra
        'lObra = lListObras(lIndex)
        Tx_Id.Text = gvObrasFinalizadas.Rows(lIndex).Cells(1).Text.ToString
        Tx_Nombre.Text = gvObrasFinalizadas.Rows(lIndex).Cells(2).Text.ToString
    End Sub

    Protected Sub Btn_ReAbrirObra_Click(sender As Object, e As EventArgs) Handles Btn_ReAbrirObra.Click
        Dim lIdUser As String = Session("IdUsuario")
        RE_ABRIR_Obra(Tx_Id.Text, lIdUser)
    End Sub

    Private Sub RE_ABRIR_Obra(ByVal iIdObra As String, ByVal iIdUser As String)
        Dim lSql As String = "", lTbl As New DataTable, lTmp As String = ""
        Dim lRes As String = "", lDal As New Datos
        Dim lEnviarMail As Boolean = False
        ''Actualizamos la taba Obra
        lSql = String.Concat("exec SP_CRUD_OBRA ", iIdObra, ",'','','','','','','','", iIdUser, "','',")
        lSql = String.Concat(lSql, "'','','','','','','','','','','','','','',6")
        lTbl = lDal.CargaTabla(lSql, "L")
        If lTbl.Rows.Count > 0 Then
            If lTbl.Rows(0)(0).ToString.ToUpper.Equals("OK") Then
                ScriptManager.RegisterStartupScript(Me, Page.GetType, "Script", "ReabrirOK();", True)
                Tx_Id.Text = ""
                Tx_Nombre.Text = ""
            Else
                ScriptManager.RegisterStartupScript(Me, Page.GetType, "Script", "ReabrirER();", True)
            End If
        End If
    End Sub

    Protected Sub btnVolver_Click(sender As Object, e As EventArgs) Handles btnVolver.Click
        Response.Redirect("COF.aspx")
    End Sub
End Class