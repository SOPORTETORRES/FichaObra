Public Class ListadoPrecios
    Inherits System.Web.UI.UserControl

    Dim dtPrecios As New DataTable, PermisoCOF As Boolean = False, ListadoID As New ArrayList
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            CargaTablaPrecios()
        End If
    End Sub

    Private Sub PermisosCOF()
        Dim ldal As New Datos(), lTbl As New DataTable, lSql As String
        lSql = String.Concat("  SP_Consultas_FichaObra  12 ,", Session("idUsuario"), ",79,'','','','','','','',''")
        lTbl = ldal.CargaTabla(lSql, "L")
        If (lTbl.Rows.Count > 0) Then
            PermisoCOF = True
        End If
    End Sub

    Private Sub CargaTablaPrecios()
        Dim lDAtos As New Datos, lTblRes As New DataTable, lIdObra As String = ""
        lIdObra = Session("obra")
        PermisosCOF()
        If PermisoCOF = True Then
            If Session("Pestaña") = "C.O.F" Then
                PanelCOF.Visible = True
            End If
            lTblRes = lDAtos.CargaTablaPreciosCOF(lIdObra)
            gvPrecios.DataSource = lTblRes
            gvPrecios.DataBind()
        Else
            lTblRes = lDAtos.CargaTablaPrecios(lIdObra)
            gvPrecios.DataSource = lTblRes
            gvPrecios.DataBind()
        End If
    End Sub



    Protected Sub btnGrabar2_Click(sender As Object, e As EventArgs) Handles btnGrabar2.Click
        Response.Redirect("CodigosParaFacturar.aspx")
        'Dim ListadoIDS As New ArrayList, IDservicio As Integer, txt As String, ltemporal As String
        'Dim lSql As String = "", ldal As New Datos, lTblRes As New Data.DataTable
        'ListadoIDS = Session("ListaIDs")
        'For i = 0 To ListadoIDS.Count - 1
        '    'Dim idServicio As String = Convert.ToString(Request.Form("txtID_" & i))
        '    IDservicio = ListadoIDS.Item(i)
        '    txt = Val(Convert.ToString(Request.Form("TextBox_" & i + 1)))
        '    If Val(txt) > 0 Then
        '        lSql = String.Concat("update ServiciosObra set Cod_ProdFact = '", txt, "' where id = '", IDservicio, "'")
        '        lTblRes = ldal.CargaTabla(lSql, "L")
        '        ltemporal = ""
        '    Else
        '        ltemporal = ""
        '    End If
        'Next
    End Sub



End Class