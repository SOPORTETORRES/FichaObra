Imports System.Drawing
Imports System.IO
Imports System.Linq

Public Class IngresoOC
    Inherits System.Web.UI.Page

    Private ldal As New Datos, TotalServicios As Integer, ListadoID As New ArrayList
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim lIdObra As Integer = 0, lIdUser As String = ""
        lIdUser = Session("IdUsuario")
        If IsNumeric(lIdUser) AndAlso Val(lIdUser) > 0 Then
            ' CargaUsuario_y_Msgs(lIdUser)
        Else
            'Response.Redirect(New ClsDatos().ObtenerUrl_Inicio)
        End If
        If IsPostBack = False Then
            If IsNumeric(lIdUser) AndAlso Val(lIdUser) > 0 Then
                btnEliminar.Attributes.Add("OnClick", "return confirm('¿Esta seguro que desea Eliminar la Orden de Compra?');")
                'CargaUsuario_y_Msgs(lIdUser)
                lIdObra = Session("Obra")
                Me.tx_IdObra.Text = lIdObra
                'CargaServicio()
                CargarDatosOC(lIdObra)
            Else
            End If
        End If
        CargaServicio()
    End Sub

    Private Sub CargarDatosOC(ByVal iObra As Integer)
        Dim lSql As String = "", lTblRes As New DataTable, ldal As New Datos, ltabla As New DataTable
        Dim lFila As DataRow = Nothing, validar As Validar = New Validar
        Try
            lSql = String.Concat("Exec SP_CRUD_OC_INGRESADAS 0,'',0,'','',", iObra, ",0,'','',5")
            lTblRes = ldal.CargaTabla(lSql, "L")
            If lTblRes.Rows.Count > 0 Then
                lblObra.Text = lTblRes.Rows(0)("Nombre").ToString
                'Lbl_MsgGrilla.Text = "Detalle de Ordenes de Compra ingresadas para la Obra: " & lTblRes.Rows(0)("Nombre").ToString
            End If
            lSql = String.Concat("Exec SP_CRUD_OC_INGRESADAS 0,'',0,'','',", iObra, ",0,'','',4")
            lTblRes = ldal.CargaTabla(lSql, "L")
            If lTblRes.Rows.Count > 0 Then
                txtTotalKilosIngresados.Text = lTblRes.Rows(0)(0).ToString
            End If



            lSql = String.Concat("Exec SP_CRUD_OC_INGRESADAS 0,'',0,'','',", iObra, ",0,'','',2")
            lTblRes = ldal.CargaTabla(lSql, "L")
            ltabla.Columns.Add("Nº OC")
            ltabla.Columns.Add("Tipo OC")
            ltabla.Columns.Add("Peso (kg)")
            ltabla.Columns.Add("Total ($)")
            ltabla.Columns.Add("Archivo adjunto")
            ltabla.Columns.Add("Fecha ingreso")
            ltabla.Columns.Add("Usuario")
            ltabla.Columns.Add("ID")
            For i = 0 To lTblRes.Rows.Count - 1
                lFila = ltabla.NewRow()
                lFila("Nº OC") = lTblRes.Rows(i)("Numero_OC").ToString
                lFila("Tipo OC") = lTblRes.Rows(i)("TipoOC").ToString
                lFila("Peso (kg)") = lTblRes.Rows(i)("Peso").ToString
                lFila("Total ($)") = validar.formatPeso(lTblRes.Rows(i)("Precio_OC").ToString)
                lFila("Archivo adjunto") = lTblRes.Rows(i)("NombreArchivo").ToString
                lFila("Fecha ingreso") = lTblRes.Rows(i)("FechaRegistro").ToString
                lFila("Usuario") = lTblRes.Rows(i)("NombreUsuario").ToString
                lFila("Id") = lTblRes.Rows(i)("Id").ToString
                ltabla.Rows.Add(lFila)
            Next
            Grid_OC.DataSource = ltabla
            Grid_OC.DataBind()



        Catch ex As Exception
            'Dim lTraza As String = "", lDalERR As New ClsDatos
            'lTraza = "IngresoOC.CargarDatosOC  - Err: " & ex.Message.ToString
            'lDalERR.RegistraError(lTraza)
        End Try
    End Sub

    Private Function ValidarAntesDeGrabar() As Boolean
        Dim lres As Boolean = True, lMsg As String = "", ListadoIDS As New ArrayList, txt As String, lnotjs As String = ""

        If txtNumeroOC.Text.Trim.Length = 0 Then
            lMsg = " Debe Ingresar el Número de la OC "
            lres = False
            lnotjs = "NumeroOC()"
        Else
            If txtFechaOC.Text.Trim.Length = 0 Then
                lMsg = " Debe ingresar fecha de la OC"
                lres = False
                lnotjs = "FechaOC()"
            Else
                If (FileUpload1.HasFile = False) Then
                    lMsg = lMsg & "  - Debe Seleccionar el Archivo a Adjuntar"
                    lres = False
                    lnotjs = "FileOC()"
                Else
                    ListadoIDS = Session("ListaIDs")
                    For i = 0 To ListadoIDS.Count - 1
                        txt = Convert.ToString(Request.Form("TextBox_" & i + 1))
                        If txt = "" Then
                            txt = "0"
                        End If
                        If Not IsNumeric(txt) Then
                            lMsg = lMsg & "Se encontro un campo de peso con un caracter no permitido"
                            lres = False
                            lnotjs = "pesoOC()"
                        End If
                    Next
                End If
            End If
        End If
        'If Rb_CD.Checked = False And Rb_FE.Checked = False And Rb_Conectores.Checked = False Then
        '    lMsg = lMsg & "  - Debe Ingresar el Tipo de Orden de compra (Corte y Doblado o Fierro en Punta)"
        '    lres = False
        'End If



        'If Tx_PrecioOC.Text.Trim.Length = 0 Then
        '    lMsg = " Debe Ingresar el total ($) de la  O.C"
        '    lres = False
        'End If



        'If IsDate(Tx_FechaVigencia.Text) = False Then
        '    lMsg = " Debe Ingresar la Fecha de la OC"
        '    Tx_FechaVigencia.Focus()
        '    lres = False
        'End If



        'If lMsg.Trim.Length > 0 Then
        '    Lbl_Msg.Text = lMsg
        '    Lbl_Msg.Visible = True
        'End If
        If lres = False Then
            ScriptManager.RegisterStartupScript(Me, Page.GetType, "Script", lnotjs, True)
        End If
        Return lres
    End Function

    Private Function GuardarArchivo(ByVal iFile As HttpPostedFile) As String
        '// Se carga la ruta física de la carpeta temp del sitio
        Dim lruta As String = Server.MapPath("~/Archivos"), lError As String = "", lIdUser As String = "", lnotjs As String = ""
        Dim lSql As String = "", lTblRes As New DataTable, lNewIdOC As String = "0", lTipoOC As String = "", lNombreUser As String = ""
        Dim lRes As Boolean = True
        'Dim lDal2 As New
        Try
            'Return lRes
            'Exit Function
            '// Si el directorio no existe, crearlo
            If (Directory.Exists(lruta) = False) Then
                Directory.CreateDirectory(lruta)
            End If



            Dim archivo As String = String.Format("{0}\\{1}", lruta, iFile.FileName)
            lIdUser = Session("IdUsuario")


            '// Verificar que el archivo no exista
            If (File.Exists(archivo)) Then
                'Lbl_Msg.Text = "Ya existe un  Archivo con el  nombre: " & iFile.FileName
                lRes = False
            Else
                Dim ListadoIDS As New ArrayList, IDservicio As Integer, txt As String, ltemporal As String
                ListadoIDS = Session("ListaIDs")
                lNombreUser = "Pruebas"
                For i = 0 To ListadoIDS.Count - 1
                    'Dim idServicio As String = Convert.ToString(Request.Form("txtID_" & i))
                    IDservicio = ListadoIDS.Item(i)
                    txt = Val(Convert.ToString(Request.Form("TextBox_" & i + 1)))
                    If Val(txt) > 0 Then
                        ltemporal = String.Concat("ID = ", IDservicio, " Valor = ", txt)
                        lSql = String.Concat("Exec SP_CRUD_OC_INGRESADAS ", Val(tx_id.Text), ",'", txtNumeroOC.Text, "',")
                        lSql = String.Concat(lSql, txt, ",'", iFile.FileName.ToString, "','")
                        lSql = String.Concat(lSql, txtObservacionOC.Text, "',", tx_IdObra.Text, ",", lIdUser, ",'", lNombreUser, "','", IDservicio, "',1")
                        lTblRes = ldal.CargaTabla(lSql, "L")
                        ltemporal = ""
                    Else
                        ltemporal = ""
                    End If
                Next

                'lUserLog = ldal.ObtenerDetalleUsuarioLogeado(lIdUser)

                iFile.SaveAs(archivo)

                'REVISAR AQUI

                'If lTblRes.Rows.Count > 0 Then
                '    lNewIdOC = lTblRes.Rows(0)(0).ToString
                '    If Val(lNewIdOC > 0) Then
                '        'If Rb_CD.Checked = True Then lTipoOC = "CD"



                '        'If Rb_FE.Checked = True Then lTipoOC = "FE"



                '        'If Rb_Conectores.Checked = True Then lTipoOC = "CO"



                '        'lSql = String.Concat(" Update Oc_Ingresadas set TipoOC='", lTipoOC, "' , Precio_OC=", txtTotalOC.Text, "  Where id=", lNewIdOC)
                '        lTblRes = ldal.CargaTabla(lSql, "L")



                '        'Lbl_Msg.Text = "el Archivo con nombre: " & iFile.FileName & " Se ha subido Correctamente"
                '    End If
                'End If



                'CambiaEstadoEvaluarRN1(tx_IdObra.Text)



            End If
        Catch ex As Exception
            'lError = String.Concat("Ingresos_OC.GuardaArchivo:", ex.Message.ToString)
            'Dim lDalERR As New ClsDatos
            'lDalERR.RegistraError(lError)
            'Lbl_Msg.Text = ex.Message.ToString
            'Lbl_Msg.Visible = True
        End Try
        Return lRes
    End Function

    Protected Sub btnGrabar_Click(sender As Object, e As EventArgs) Handles btnGrabar.Click
        Dim lnotjs As String = "", lres As Boolean = False
        If ValidarAntesDeGrabar() = True Then
            If GuardarArchivo(FileUpload1.PostedFile) = True Then
                'lnotjs = "IngresoOCOK()"
                'ScriptManager.RegisterStartupScript(Me, Page.GetType, "Script", lnotjs, True)
                CargarDatosOC(tx_IdObra.Text)
                'Dim Dal As New ClsB_O
                'Dal.EvaluaReglasDeNegocio(tx_IdObra.Text, 1)
                'Dal.EvaluaReglasDeNegocio(tx_IdObra.Text, 2)
                'Dal.EvaluaReglasDeNegocio(tx_IdObra.Text, 3)
                'Dal.RevisaDesbloqueosAutomaticos(tx_IdObra.Text, 1)
                'Dal.RevisaIT_En_Estado_PRN(tx_IdObra.Text)
                btnEliminar.Enabled = False
                lres = True
            Else
                lnotjs = "ArchivoExiste()"
                ScriptManager.RegisterStartupScript(Me, Page.GetType, "Script", lnotjs, True)
            End If
        Else
            lnotjs = "IngresoOCER()"
            ScriptManager.RegisterStartupScript(Me, Page.GetType, "Script", lnotjs, True)
        End If
        If lres = True Then
            ScriptManager.RegisterStartupScript(Me, Page.GetType, "Script", "servicioextraTrue();", True)
        End If
    End Sub

    Protected Sub Grid_OC_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Grid_OC.SelectedIndexChanged
        Dim lIndex As Integer = Grid_OC.SelectedIndex, lPathArch As String = ConfigurationManager.AppSettings.Get("PathArchivos").ToString
        Dim ListadoOC As New ArrayList
        'Lnk_VerDoc.NavigateUrl = "../../Produccion/Archivos/" & tx_Archivo.Text
        Lnk_VerDoc.NavigateUrl = HttpUtility.HtmlDecode(String.Concat(lPathArch, tx_Archivo.Text))
        'Lnk_VerDoc.NavigateUrl = String.Concat("http://localhost/Produccion/Archivos/", tx_Archivo.Text)
        ''http://localhost/Produccion/Archivos/OC%20021181268.pdf
        btnGrabar.Enabled = False
        btnEliminar.Enabled = False
        btnActualizar.Enabled = True
        'Btn_Actualiza.Enabled = True
        Dim lSql As String = "", lTblRes As New DataTable, ldal As New Datos
        lSql = String.Concat("Exec  SP_Consultas_FichaObra  17 ,", Grid_OC.Rows(lIndex).Cells(1).Text.ToString, ",", Session("obra"), ",'','','','','','','',''")
        lTblRes = ldal.CargaTabla(lSql, "L")
        If lTblRes.Rows.Count > 0 Then
            PanelID.Controls.Clear()
            Panellbl.Controls.Clear()
            Paneltb.Controls.Clear()
            txtNumeroOC.Text = Grid_OC.Rows(lIndex).Cells(1).Text.ToString
            txtObservacionOC.Text = lTblRes.Rows(0)("Obs").ToString()
            tx_Archivo.Text = Grid_OC.Rows(lIndex).Cells(5).Text.ToString
            tx_id.Text = Grid_OC.Rows(lIndex).Cells(8).Text.ToString
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
                textbox.Width = 180
                textbox.Height = 23
                txtiD.Width = 55
                txtiD.Height = 23
                textbox.ID = "TextBox_" & (count + 1)
                lblID.ID = "txtID_" & (count + 1)
                ListadoOC.Add(lTblRes.Rows(i).Item(0).ToString)
                lblID.Text = lTblRes.Rows(i).Item(0).ToString
                lbl.Text = lTblRes.Rows(i).Item(5).ToString
                textbox.Text = lTblRes.Rows(i).Item(2).ToString
                PanelID.Controls.Add(lblID)
                PanelID.Controls.Add(hr)
                Panellbl.Controls.Add(lbl)
                Panellbl.Controls.Add(hr1)
                Paneltb.Controls.Add(textbox)
                Paneltb.Controls.Add(hr2)
                Session("ListaOC") = ListadoOC
            Next
            'Lbl_MsgGrilla.Text = "Detalle de Ordenes de Compra ingresadas para la Obra: " & lTblRes.Rows(0)("Nombre").ToString
        End If
    End Sub

    Protected Sub btnActualizar_Click(sender As Object, e As EventArgs) Handles btnActualizar.Click
        Dim ListadoOC As New ArrayList, IDservicio As Integer, txt As String, ltemporal As String, lIdObra As Integer
        Dim lSql As String = "", lTblRes As New DataTable, lresultado As Boolean = False
        ListadoOC = Session("ListaOC")
        For i = 0 To ListadoOC.Count - 1
            'Dim idServicio As String = Convert.ToString(Request.Form("txtID_" & i))
            IDservicio = ListadoOC.Item(i)
            txt = Val(Convert.ToString(Request.Form("TextBox_" & i + 1)))
            If Val(txt) > 0 Then
                ltemporal = String.Concat("ID = ", IDservicio, " Valor = ", txt)
                lSql = String.Concat("SP_Consultas_FichaObra  18 ,", txt, ",", IDservicio, ",", Session("obra"), ",'','','','','','',''")
                lTblRes = ldal.CargaTabla(lSql, "L")
                ltemporal = ""
                lresultado = True
            Else
                ltemporal = ""
            End If
        Next
        If lresultado = True Then
            ScriptManager.RegisterStartupScript(Me, Page.GetType, "Script", "GeneralOK();", True)
            PanelID.Controls.Clear()
            Panellbl.Controls.Clear()
            Paneltb.Controls.Clear()
            CargaServicio()
        Else
            ScriptManager.RegisterStartupScript(Me, Page.GetType, "Script", "GeneralER();", True)
        End If
    End Sub

    Private Sub CargaServicio()
        Dim ldal As New Datos, lSql As String = "", lTbl As New Data.DataTable, DetalleOC As String = ""
        'Cargamos datos de parametros
        lSql = String.Concat("SP_Consultas_FichaObra  8 ,", Session("obra"), ",'','','','','','','','',''")
        lTbl = ldal.CargaTabla(lSql, "L")
        For i As Integer = 0 To lTbl.Rows.Count - 1
            Dim lbl As New Label(), lblID As New Label(), breakTag As LiteralControl, br As LiteralControl, hr As LiteralControl
            Dim hr1 As LiteralControl, br2 As LiteralControl, hr2 As LiteralControl, textbox As New TextBox(), txtiD As New TextBox()
            breakTag = New LiteralControl("<br />")
            br = New LiteralControl("<br />")
            br2 = New LiteralControl("<br />")
            hr = New LiteralControl("<hr />")
            hr1 = New LiteralControl("<hr />")
            hr2 = New LiteralControl("<hr />")
            Dim count = Paneltb.Controls.OfType(Of TextBox)().ToList().Count
            textbox.Width = 180
            textbox.Height = 23
            txtiD.Width = 55
            txtiD.Height = 23
            textbox.ID = "TextBox_" & (count + 1)
            lblID.ID = "txtID_" & (count + 1)
            ListadoID.Add(lTbl.Rows(i).Item(0).ToString)
            lblID.Text = lTbl.Rows(i).Item(0).ToString
            lbl.Text = lTbl.Rows(i).Item(1).ToString & " " & lTbl.Rows(i).Item(2).ToString & " " & lTbl.Rows(i).Item(4).ToString
            PanelID.Controls.Add(lblID)
            PanelID.Controls.Add(hr)
            Panellbl.Controls.Add(lbl)
            Panellbl.Controls.Add(hr1)
            Paneltb.Controls.Add(textbox)
            Paneltb.Controls.Add(hr2)
            Session("txtdinamico") = Paneltb
            Session("ListaIDs") = ListadoID
        Next
    End Sub

    Protected Sub btnLimpiar_Click(sender As Object, e As EventArgs) Handles btnLimpiar.Click

    End Sub
End Class