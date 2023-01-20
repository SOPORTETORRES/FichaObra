Public Class CodigosParaFacturar
    Inherits System.Web.UI.Page

    Dim ListadoID As New ArrayList
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CargaTablaPrecios()
    End Sub

    Private Sub CargaTablaPrecios()
        Dim lDAtos As New Datos, lTblRes As New DataTable, lIdObra As String = ""
        lIdObra = Session("obra")
        lTblRes = lDAtos.CargaTablaPreciosCOF(lIdObra)
        lblObra.Text = Session("NombreObra")
        For i As Integer = 0 To lTblRes.Rows.Count - 1
            Dim lbl As New Label(), lblID As New Label(), breakTag As LiteralControl, br As LiteralControl, hr As LiteralControl
            Dim hr1 As LiteralControl, br2 As LiteralControl, hr2 As LiteralControl, textbox As New TextBox(), txtiD As New TextBox()
            breakTag = New LiteralControl("<br />")
            br = New LiteralControl("<br />")
            br2 = New LiteralControl("<br />")
            hr = New LiteralControl("<hr />")
            hr1 = New LiteralControl("<hr />")
            hr2 = New LiteralControl("<hr />")
            Dim count = Paneltb.Controls.OfType(Of TextBox)().ToList().Count
            textbox.Width = 200
            textbox.Height = 23
            txtiD.Width = 55
            txtiD.Height = 23
            textbox.ID = "TextBox_" & (count + 1)
            lblID.ID = "txtID_" & (count + 1)
            textbox.Text = lTblRes.Rows(i).Item(5).ToString
            ListadoID.Add(lTblRes.Rows(i).Item(0).ToString)
            lblID.Text = lTblRes.Rows(i).Item(0).ToString
            lbl.Text = lTblRes.Rows(i).Item(1).ToString & " " & lTblRes.Rows(i).Item(2).ToString & " " & lTblRes.Rows(i).Item(4).ToString
            PanelID.Controls.Add(lblID)
            PanelID.Controls.Add(hr)
            Panellbl.Controls.Add(lbl)
            Panellbl.Controls.Add(hr1)
            Paneltb.Controls.Add(textbox)
            Paneltb.Controls.Add(hr2)
            Session("ListaIDs") = ListadoID
        Next
    End Sub

    Protected Sub btnGrabar_Click(sender As Object, e As EventArgs) Handles btnGrabar.Click
        Dim ListadoIDS As New ArrayList, IDservicio As Integer, txt As String, ltemporal As String
        Dim lSql As String = "", ldal As New Datos, lTblRes As New Data.DataTable, lres As Boolean = False
        ListadoIDS = Session("ListaIDs")
        For i = 0 To ListadoIDS.Count - 1
            'Dim idServicio As String = Convert.ToString(Request.Form("txtID_" & i))
            IDservicio = ListadoIDS.Item(i)
            txt = Convert.ToString(Request.Form("TextBox_" & i + 1))
            If txt.Length > 0 Then
                If ldal.ExisteProductoEnINET(txt, "TO") = True Then
                    lSql = String.Concat("update ServiciosObra set Cod_ProdFact = '", txt, "' where id = '", IDservicio, "'")
                    lTblRes = ldal.CargaTabla(lSql, "L")
                    ltemporal = ""
                    lres = True
                Else
                    ltemporal = "Error de codigo inet"
                End If
            Else
                ltemporal = "Sin datos de codigo"
            End If
        Next
        If lres = True Then
            ScriptManager.RegisterStartupScript(Me, Page.GetType, "Script", "CodigosTrue();", True)
        Else
            ScriptManager.RegisterStartupScript(Me, Page.GetType, "Script", "CodigosFalse();", True)
        End If
    End Sub

    Protected Sub btnVolver_Click(sender As Object, e As EventArgs) Handles btnVolver.Click
        Response.Redirect("COF.aspx")
    End Sub


End Class