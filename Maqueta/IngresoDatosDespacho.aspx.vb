Public Class IngresoDatosDespacho
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CargaDatosDespacho()
    End Sub

    Protected Sub btnVolver_Click(sender As Object, e As EventArgs) Handles btnVolver.Click
        Response.Redirect("Logistica.aspx")
    End Sub

    Protected Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        If txtGDE.Text.Length >= 0 Then
            BuscarGDE()
        Else

        End If
    End Sub

    Private Sub BuscarGDE()
        Dim lDAtos As New Datos, lTblRes As New DataTable, IDdespacho As String = ""
        IDdespacho = txtGDE.Text
        lTblRes = lDAtos.CargaDatosGDE(IDdespacho)
        If (lTblRes.Rows.Count > 0) Then
            txtCodigoProducto.Text = lTblRes.Rows(0)("Codigo_INET").ToString()
            txtObra.Text = lTblRes.Rows(0)("Nombre").ToString()
            txtCentroCosto.Text = lTblRes.Rows(0)("centroCosto").ToString()
            txtSucursal.Text = lTblRes.Rows(0)("Sucursal").ToString()
            txtFechaGDE.Text = lTblRes.Rows(0)("FechaGDE").ToString()
            txtTipoGDE.Text = lTblRes.Rows(0)("TipoGuia").ToString()
            txtPagoCliente.Text = "343434"
        Else
            ScriptManager.RegisterStartupScript(Me, Page.GetType, "Script", "GDEER();", True)
            txtGDE.Text = ""
        End If
    End Sub

    Protected Sub btnGrabar_Click(sender As Object, e As EventArgs) Handles btnGrabar.Click
        Dim validar As New Validar, salida As String = "", lTblRes As New DataTable, lDAtos As New Datos
        salida = validar.ValidaCostoDespacho(Convert.ToInt32(txtCostoNeto.Text), Convert.ToInt32(txtSobreestadia.Text), Convert.ToInt32(txtCostoFalso.Text), txtNFactura.Text)
        If salida = "OK" Then
            lTblRes = lDAtos.GrabaDatosDespacho(txtCostoFalso.Text, txtCostoNeto.Text, txtSobreestadia.Text, txtGDE.Text, txtNFactura.Text, txtObs.Text, Session("UsuarioLogueado"))
            If (lTblRes.Rows.Count > 0) Then
                'GRABO
                ScriptManager.RegisterStartupScript(Me, Page.GetType, "Script", "DatoDespachoOK();", True)
                txtGDE.Text = ""
                txtCostoNeto.Text = ""
                txtSobreestadia.Text = ""
                txtCostoFalso.Text = ""
                txtNFactura.Text = ""
                txtObs.Text = ""
                txtCodigoProducto.Text = ""
                txtObra.Text = ""
                txtCentroCosto.Text = ""
                txtSucursal.Text = ""
                txtFechaGDE.Text = ""
                txtTipoGDE.Text = ""
                txtPagoCliente.Text = ""
            Else
                'ERROR
                ScriptManager.RegisterStartupScript(Me, Page.GetType, "Script", "DatoDespachoER();", True)
            End If
        Else
            'Mensdaje validacion invalida
            ScriptManager.RegisterStartupScript(Me, Page.GetType, "Script", salida, True)
        End If
    End Sub

    Private Sub CargaDatosDespacho()
        Dim lDAtos As New Datos, lTblRes As New DataTable, IdObra As String = ""
        IdObra = Session("obra")
        lTblRes = lDAtos.CargaDatosDespachoGeneral()
        gvControlCosto.DataSource = lTblRes
        gvControlCosto.DataBind()
        If (lTblRes.Rows.Count > 0) Then
            gvControlCosto.UseAccessibleHeader = True
            gvControlCosto.HeaderRow.TableSection = TableRowSection.TableHeader
        End If
    End Sub

    Protected Sub gvControlCosto_SelectedIndexChanged(sender As Object, e As EventArgs) Handles gvControlCosto.SelectedIndexChanged
        'Dim solicitud = HttpUtility.HtmlDecode(gvControlCosto.SelectedRow.Cells.Item(0).Text.ToString)
        Response.Redirect("Logistica.aspx")
    End Sub
End Class