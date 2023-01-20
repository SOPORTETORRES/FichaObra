Imports System.Net

Public Class ServiciosExtra
    Inherits System.Web.UI.Page

    Dim dt As New DataTable
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            lblObra.Text = Session("NombreObra")
            CargaTablaPrecios()
            If ViewState("datos") Is Nothing Then
                dt.Columns.Add("Detalle")
                dt.Columns.Add("Diametro/s")
                dt.Columns.Add("Calidad")
                dt.Columns.Add("Sucursal")
                dt.Columns.Add("Precio")
                dt.Columns.Add("Unidad")
                ViewState("datos") = dt
            End If
        End If
    End Sub

    Protected Sub cbSeleccionables_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbSeleccionables.SelectedIndexChanged
        If cbSeleccionables.Text = "1.- Suministro" Then
            lblComodin.Visible = False
            txtComodin.Visible = False
            lblPrecioComodin.Visible = False
            txtPrecioComodin.Visible = False
            lblmas2.Visible = False
            btnComodin.Visible = False
            lblunidad.Visible = False
            dpUnidad.Visible = False
            lblTransporte.Visible = False
            cbTransporte.Visible = False
            lblPrecioTransporte.Visible = False
            txtPrecioTransporte.Visible = False
            btnTransporte.Visible = False
            lblmas3.Visible = False

            lblSuministros.Visible = True
            cbSuministros.Focus()
            cbSuministros.Visible = True
            lblSucursal.Visible = True
            dpSucursal.Visible = True
            LblDiametro.Visible = True
            dpDiametro.Visible = True
            lblPrecio.Visible = True
            txtPrecioSuministro.Visible = True
            lblCalidadsum.Visible = True
            dpCalidads.Visible = True
            lblmas.Visible = True
            btnSuministro.Visible = True
        ElseIf cbSeleccionables.Text = "2.- Preparacion" Then
            lblComodin.Text = "Preparación"
            txtComodin.Text = "Preparación REBAR"
            dpUnidad.SelectedIndex = 2
            activarcomodin()
        ElseIf cbSeleccionables.Text = "3.- Cubicacion" Then
            lblComodin.Text = "Cubicación"
            txtComodin.Text = "Cubicación REBAR"
            dpUnidad.SelectedIndex = 2
            activarcomodin()
        ElseIf cbSeleccionables.Text = "4.- Alambre" Then
            lblComodin.Text = "Alambre"
            txtComodin.Text = "Alambre #18 para amarras"
            dpUnidad.SelectedIndex = 2
            activarcomodin()
        ElseIf cbSeleccionables.Text = "6.- Otros" Then
            lblComodin.Text = "Otros"
            txtComodin.Text = ""
            dpUnidad.SelectedIndex = 0
            activarcomodin()
        ElseIf cbSeleccionables.Text = "5.- Transporte" Then
            lblSuministros.Visible = False
            cbSuministros.Visible = False
            lblSucursal.Visible = False
            dpSucursal.Visible = False
            LblDiametro.Visible = False
            dpDiametro.Visible = False
            lblPrecio.Visible = False
            txtPrecioSuministro.Visible = False
            lblCalidadsum.Visible = False
            dpCalidads.Visible = False
            lblmas.Visible = False
            btnSuministro.Visible = False
            lblComodin.Visible = False
            txtComodin.Visible = False
            lblPrecioComodin.Visible = False
            txtPrecioComodin.Visible = False
            lblmas2.Visible = False
            btnComodin.Visible = False
            lblunidad.Visible = False
            dpUnidad.Visible = False

            lblTransporte.Visible = True
            cbTransporte.Visible = True
            cbTransporte.Focus()
            lblPrecioTransporte.Visible = True
            txtPrecioTransporte.Visible = True
            btnTransporte.Visible = True
            lblmas3.Visible = True
            cbTransporte.SelectedItem.Text = "Seleccione:"
        End If
    End Sub

    Public Function activarcomodin()
        lblSuministros.Visible = False
        cbSuministros.Visible = False
        lblSucursal.Visible = False
        dpSucursal.Visible = False
        LblDiametro.Visible = False
        dpDiametro.Visible = False
        lblPrecio.Visible = False
        txtPrecioSuministro.Visible = False
        lblCalidadsum.Visible = False
        dpCalidads.Visible = False
        lblmas.Visible = False
        btnSuministro.Visible = False
        lblTransporte.Visible = False
        cbTransporte.Visible = False
        lblPrecioTransporte.Visible = False
        txtPrecioTransporte.Visible = False
        btnTransporte.Visible = False
        lblmas3.Visible = False

        If cbSeleccionables.Text = "6.- Otros" Then
            txtComodin.Focus()
        Else
            txtPrecioComodin.Focus()
        End If
        lblComodin.Visible = True
        txtComodin.Visible = True
        lblPrecioComodin.Visible = True
        txtPrecioComodin.Visible = True
        lblmas2.Visible = True
        btnComodin.Visible = True
        lblunidad.Visible = True
        dpUnidad.Visible = True
        Return True
    End Function

    Private Sub CargaTablaPrecios()
        Dim lDAtos As New Datos, lTblRes As New DataTable, lIdObra As String = ""
        lIdObra = Session("obra")
        lTblRes = lDAtos.CargaTablaPrecios(lIdObra)
        gvDetalle.DataSource = lTblRes
        ViewState("datos") = lTblRes
        gvDetalle.DataBind()
    End Sub

    Protected Sub btnVolver_Click(sender As Object, e As EventArgs) Handles btnVolver.Click
        Response.Redirect("COF.aspx")
    End Sub

    Protected Sub btnSuministro_Click(sender As Object, e As EventArgs) Handles btnSuministro.Click
        validarSuministro()
    End Sub

    Private Function validarSuministro() As Boolean
        Dim lresultado As Boolean
        Dim validar As Validar = New Validar
        validar.suministro = cbSuministros.Text
        validar.diametro = dpDiametro.Text
        validar.sucursal = dpSucursal.Text
        validar.preciosuministro = txtPrecioSuministro.Text
        validar.calidadsum = dpCalidads.Text
        If validar.Suministros = True Then
            Dim pt As Int64, pt_tx As String
            'pt = Convert.ToInt64(txtCantidadSuministro.Text) * Convert.ToInt64(txtPrecioSuministro.Text)
            pt_tx = Format(Val(pt.ToString), "#,##0")
            dt = CType(ViewState("datos"), DataTable)
            'lblvalues.Text = ""
            'Dim diametros As String = String.Join(",", checkDiametro.Items.OfType(Of ListItem)().Where(Function(r) r.Selected).[Select](Function(r) r.Text))
            'Dim Suministro = cbSuministros.Text + " " + cbCalidadAcero.Text + " en diametro " + dpDiametro.Text + " " + dpSucursal.Text
            'dt.Rows.Add(cbSuministros.Text, dpDiametro.Text, dpCalidads.Text, dpSucursal.Text, Format(CDbl(txtPrecioSuministro.Text), "#,##0"), " kg") 'validar.formatPeso(txtPrecioSuministro.Text)
            dt.Rows.Add("Suministro " + cbSuministros.Text, dpDiametro.Text, dpCalidads.Text, dpSucursal.SelectedItem, validar.formatPeso(txtPrecioSuministro.Text), " por Kg + IVA")
            gvDetalle.DataSource = dt
            gvDetalle.DataBind()
            cbSuministros.SelectedValue = "Seleccione:"
            dpDiametro.SelectedValue = "Seleccione:"
            dpSucursal.SelectedValue = "Seleccione:"
            dpCalidads.SelectedValue = "Seleccione:"
            txtPrecioSuministro.Text = ""
            cbSuministros.Focus()
        Else
            If validar.lnotificacion = 11 Then
                ScriptManager.RegisterStartupScript(Me, Page.GetType, "Script", "suministro();", True)
            Else
                If validar.lnotificacion = 12 Then
                    ScriptManager.RegisterStartupScript(Me, Page.GetType, "Script", "diametro();", True)
                Else
                    If validar.lnotificacion = 13 Then
                        ScriptManager.RegisterStartupScript(Me, Page.GetType, "Script", "sucursal();", True)
                    Else
                        If validar.lnotificacion = 14 Then
                            ScriptManager.RegisterStartupScript(Me, Page.GetType, "Script", "precioSuministro();", True)
                        End If
                    End If
                End If
            End If
        End If
        Return lresultado
    End Function

    Protected Sub btnComodin_Click(sender As Object, e As EventArgs) Handles btnComodin.Click
        validarComodin()
    End Sub

    Private Function validarComodin() As Boolean
        Dim lresultado As Boolean
        Dim validar As Validar = New Validar
        validar.txtcomodin = txtComodin.Text
        validar.preciocomodin = txtPrecioComodin.Text
        If validar.comodin = True Then
            Dim pt As Int64, pt_tx As String
            'pt = Convert.ToInt64(txtKgsComodin.Text) * Convert.ToInt64(txtPrecioComodin.Text)
            pt_tx = Format(Val(pt.ToString), "#,##0")
            dt = CType(ViewState("datos"), DataTable)
            dt.Rows.Add(txtComodin.Text, Server.HtmlDecode(""), Server.HtmlDecode(""), Server.HtmlDecode(""), validar.formatPeso(txtPrecioComodin.Text), dpUnidad.Text)
            gvDetalle.DataSource = dt
            gvDetalle.DataBind()
            txtComodin.Text = ""
            txtPrecioComodin.Text = ""
            txtComodin.Focus()
        Else
            If validar.lnotificacion = 31 Then
                ScriptManager.RegisterStartupScript(Me, Page.GetType, "Script", "txtcomodin();", True)
            Else
                If validar.lnotificacion = 32 Then
                    ScriptManager.RegisterStartupScript(Me, Page.GetType, "Script", "txtPrecioComodin();", True)
                End If
            End If
        End If
        Return lresultado
    End Function

    Protected Sub btnTransporte_Click(sender As Object, e As EventArgs) Handles btnTransporte.Click
        validarTransporte()
    End Sub

    Private Function validarTransporte() As Boolean
        Dim lresultado As Boolean
        Dim validar As Validar = New Validar
        validar.cbTransporte = cbTransporte.Text
        validar.txtPrecioTransporte = txtPrecioTransporte.Text
        If validar.flete = True Then
            If cbTransporte.SelectedValue = "Por kgs" Then
                dt = CType(ViewState("datos"), DataTable)
                dt.Rows.Add("Transporte:", Server.HtmlDecode(""), Server.HtmlDecode(""), Server.HtmlDecode(""), validar.formatPeso(txtPrecioTransporte.Text), "por kgs")
                gvDetalle.DataSource = dt
                gvDetalle.DataBind()
                cbTransporte.SelectedValue = "Seleccione:"
                txtPrecioTransporte.Text = ""
            ElseIf cbTransporte.SelectedValue = "Por flete" Then
                dt = CType(ViewState("datos"), DataTable)
                dt.Rows.Add("Transporte:", Server.HtmlDecode(""), Server.HtmlDecode(""), Server.HtmlDecode(""), validar.formatPeso(txtPrecioTransporte.Text), "por flete")
                gvDetalle.DataSource = dt
                gvDetalle.DataBind()
                cbTransporte.SelectedValue = "Seleccione:"
                txtPrecioTransporte.Text = ""
            ElseIf cbTransporte.SelectedValue = "Cliente retira" Then
                dt = CType(ViewState("datos"), DataTable)
                dt.Rows.Add("Transporte:", Server.HtmlDecode(""), Server.HtmlDecode(""), Server.HtmlDecode(""), Server.HtmlDecode("0"), Server.HtmlDecode("cliente retira desde nuestra sucursal"))
                gvDetalle.DataSource = dt
                gvDetalle.DataBind()
                cbTransporte.SelectedValue = "Seleccione:"
                txtPrecioTransporte.Text = ""
            ElseIf cbTransporte.SelectedValue = "Por flete Santiago" Then
                dt = CType(ViewState("datos"), DataTable)
                dt.Rows.Add("Transporte:", Server.HtmlDecode(""), Server.HtmlDecode(""), Server.HtmlDecode(""), Server.HtmlDecode(""), validar.formatPeso(txtPrecioTransporte.Text), dpOpcionesTransporte.Text)
                gvDetalle.DataSource = dt
                gvDetalle.DataBind()
                'cbTransporte.SelectedValue = "Seleccione:"
                txtPrecioTransporte.Text = ""
            End If
        Else
            If validar.lnotificacion = 33 Then
                ScriptManager.RegisterStartupScript(Me, Page.GetType, "Script", "cbTransporte();", True)
            Else
                If validar.lnotificacion = 35 Then
                    ScriptManager.RegisterStartupScript(Me, Page.GetType, "Script", "txtPrecioTransporte();", True)
                End If
            End If
        End If
        Return lresultado
    End Function

    Protected Sub cbTransporte_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cbTransporte.SelectedIndexChanged
        If cbTransporte.Text = "Por kgs" Then
            txtPrecioTransporte.Visible = True
            lblPrecioTransporte.Visible = True
            lblopciontransporte.Visible = False
            dpOpcionesTransporte.Visible = False
        ElseIf cbTransporte.Text = "Por flete" Then
            'lblTransporte.Text = "Cantidad viajes"
            txtPrecioTransporte.Focus()
            txtPrecioTransporte.Visible = True
            lblPrecioTransporte.Visible = True
            lblopciontransporte.Visible = False
            dpOpcionesTransporte.Visible = False
        ElseIf cbTransporte.Text = "Cliente retira" Then
            txtPrecioTransporte.Visible = False
            lblPrecioTransporte.Visible = False
            lblopciontransporte.Visible = False
            dpOpcionesTransporte.Visible = False
        ElseIf cbTransporte.Text = "Por flete Santiago" Then
            'lblTransporte.Text = "Cantidad viajes"
            lblopciontransporte.Visible = True
            dpOpcionesTransporte.Visible = True
            dpOpcionesTransporte.Focus()
            txtPrecioTransporte.Visible = True
            lblPrecioTransporte.Visible = True
        End If
    End Sub


    Protected Sub gvDetalle_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles gvDetalle.RowDataBound
        If e.Row.RowType = DataControlRowType.DataRow Then
            If e.Row.Cells(7).Text.IndexOf("&nbsp;") > -1 Then
                e.Row.BackColor = Drawing.Color.LightGreen
            Else
                e.Row.BackColor = Drawing.Color.Coral
            End If
        End If
    End Sub

    Protected Sub btnGrabar_Click(sender As Object, e As EventArgs) Handles btnGrabar.Click
        Dim salida As Boolean = False
        For Each row In gvDetalle.Rows
            If Val(WebUtility.HtmlDecode(row.Cells(7).Text)) = 0 Then
                Dim ldal As New Datos, lSql As String = "", lTbl As New Data.DataTable, idSucursal As Integer
                If WebUtility.HtmlDecode(row.Cells(2).Text).ToString.Trim.Length > 0 Then
                    Select Case row.Cells(4).Text
                        Case "Santiago"
                            idSucursal = 4
                        Case "Calama"
                            idSucursal = 1
                        Case "Coronel"
                            idSucursal = 14
                    End Select
                    lSql = String.Concat("SP_Consultas_FichaObra  13,", Session("obra"), ",'", row.Cells(1).Text, "','", row.Cells(5).Text, "','", Session("idUsuario"), "','S','", row.Cells(2).Text, "','", row.Cells(3).Text, "',", idSucursal, ",'", row.Cells(6).Text, "','N'")
                    lTbl = ldal.CargaTabla(lSql, "L")
                    salida = True
                Else
                    If row.Cells(1).Text.ToString.IndexOf("Transporte") > -1 Then
                        Select Case idSucursal
                            Case row.Cells(4).Text = "Santiago"
                                idSucursal = 4
                            Case row.Cells(4).Text = "Calama"
                                idSucursal = 1
                            Case row.Cells(4).Text = "Coronel"
                                idSucursal = 14
                        End Select
                        lSql = String.Concat("SP_Consultas_FichaObra  13,", Session("obra"), ",'", row.Cells(1).Text, "','", row.Cells(5).Text, "','", Session("idUsuario"), "','S','0','',", idSucursal, ",'", row.Cells(6).Text, "','S'")
                        lTbl = ldal.CargaTabla(lSql, "L")
                        salida = True
                    Else
                        Select Case idSucursal
                            Case row.Cells(4).Text = "Santiago"
                                idSucursal = 4
                            Case row.Cells(4).Text = "Calama"
                                idSucursal = 1
                            Case row.Cells(4).Text = "Coronel"
                                idSucursal = 14
                        End Select
                        lSql = String.Concat("SP_Consultas_FichaObra  13,", Session("obra"), ",'", WebUtility.HtmlDecode(row.Cells(1).Text), "','", row.Cells(5).Text, "','", Session("idUsuario"), "','S','0','',", idSucursal, ",'", row.Cells(6).Text, "','N'")
                        lTbl = ldal.CargaTabla(lSql, "L")
                        salida = True
                    End If
                End If
            End If
        Next
        If salida = True Then
            ScriptManager.RegisterStartupScript(Me, Page.GetType, "Script", "servicioextraTrue();", True)
        End If
    End Sub
End Class