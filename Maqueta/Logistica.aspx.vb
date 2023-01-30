
Public Class Logistica
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsNothing(Session("obra")) Then
            Response.Redirect("FichaObra.aspx")
        Else
            If IsPostBack = False Then
                PermisosLOG()
                Dim obra As Integer = Session("obra")
                Session("Pestaña") = "Logistica"
                CargaDatosCamion()
                CargaDatosObra(obra)
            End If
        End If
    End Sub

    Private Function CargaDatosObra(IdOBra As String)
        Dim lresultado As Boolean
        Dim ldal As New Datos
        Dim lSql As String = ""
        Try
            Dim lTabla As New Data.DataTable, rut As String, partes() As String, valoruf As Integer, dts As New PX_Facturacion.ListaDataSet
            Dim lproxy As New PX_Facturacion.FacturacionSoapClient, rutInet As String, lcuso As Integer, lcuso2 As Integer
            Dim lcAprobada As Integer, lcDisponible As Integer, lcporcentaje As Integer
            lTabla = ldal.CargaTabla_DatosObra(IdOBra)
            If lTabla.Rows.Count > 0 Then
                '----------------- DATOS DE SOLICITUD ------------------------------
                txtNombreObra.Text = lTabla.Rows(0)("Nombre").ToString()
                txtSigla.Text = lTabla.Rows(0)("SiglaObra").ToString()
                txtEstado.Text = lTabla.Rows(0)("EstadoAlta").ToString()
                txtDireccion.Text = lTabla.Rows(0)("Dir").ToString()
                txtCiudad.Text = lTabla.Rows(0)("Ciudad").ToString()
                txtComuna.Text = lTabla.Rows(0)("Comuna").ToString()
                dpDesplazamiento.SelectedValue = lTabla.Rows(0)("TiempoDesplazamiento").ToString()
                txtCodigo.Text = lTabla.Rows(0)("Codigo_INET").ToString()
                rut = lTabla.Rows(0)("RutCliente").ToString()
                partes = rut.Split("-")
                If partes.Length = 2 Then
                    rutInet = partes(0).ToString
                    lSql = String.Concat("SELECT * FROM PARAMETRO     WHERE PAR_TABLA   like '%UF%'")
                    Try
                        Dim lTabla3 As New Data.DataTable
                        lTabla3 = ldal.CargaTabla(lSql, "L")
                        If lTabla3.Rows.Count > 0 Then
                            valoruf = lTabla3.Rows(0)("PAR_ALF1").ToString()
                        End If
                    Catch ex As Exception
                        'VALIDAR ERROR
                    End Try
                    dts = lproxy.ObtenerDatosLN_Cliente(rutInet) '%", rutInet, "%'
                    If dts.MensajeError.Trim.Length = 0 Then
                        lTabla = dts.DataSet.Tables(0).Copy
                        If lTabla.Rows.Count > 0 Then
                            lcuso = Val(lTabla.Rows(0)("F_PP").ToString()) + Val(lTabla.Rows(0)("D_ProximaSem").ToString()) + Val(lTabla.Rows(0)("D_SinFact").ToString())
                            lcuso2 = lcuso / valoruf
                            lbl_lcDatoUso.Text = Format(Val(lcuso2), "#,##0") & " UF"
                        End If
                        lSql = String.Concat("Select *  From VW_LINEA_CREDITO    Where RUT like '%", rutInet, "%'")
                        Try
                            Dim lTabla2 As New Data.DataTable
                            lTabla2 = ldal.CargaTabla(lSql, "L")
                            If lTabla2.Rows.Count > 0 Then
                                lcAprobada = lTabla2.Rows(0)("MONTO_LINEA_APROBADA").ToString()
                                lbl_lcDatoAprobada.Text = Format(Val(lcAprobada), "#,##0") & " UF"
                                lcDisponible = lcAprobada - lcuso2
                                lbl_lcDatoDisponible.Text = Format(Val(lcDisponible), "#,##0") & " UF"
                                lcporcentaje = Math.Round((lcDisponible * 100) / lcAprobada)
                                Select Case lcporcentaje
                                    Case <= 10
                                        Literal1.Text = "<span Class=""badge badge rounded-pill d-block p-2 badge-soft-danger"">" & lcporcentaje & " %" & "<data-fa-transform=""shrink-2""></span>"
                                    Case 11 To 30
                                        Literal1.Text = "<span Class=""badge badge rounded-pill d-block p-2 badge-soft-warning"">" & lcporcentaje & " %" & "<data-fa-transform=""shrink-2""></span>"
                                    Case 31 To 100
                                        Literal1.Text = "<span Class=""badge badge rounded-pill d-block p-2 badge-soft-success"">" & lcporcentaje & " %" & "<data-fa-transform=""shrink-2""></span>"
                                End Select
                            End If
                        Catch ex As Exception
                            'error
                        End Try
                    Else
                        'Validar sin informacion
                    End If
                Else
                    'Validar sin informacion



                End If
            End If
        Catch ex As Exception
            'lblError.Text = ex.ToString
        Finally
        End Try
        Return lresultado
    End Function

    Protected Sub btnUbicacion_Click(sender As Object, e As EventArgs) Handles btnUbicacion.Click
        Dim url As String = "https://www.google.cl/maps/@-36.9879534,-73.170072,16z"
        Dim s As String = "window.open('" & url & "', '_blank');"
        Page.ClientScript.RegisterStartupScript(Me.GetType(), "alertscript", s, True)
    End Sub

    Private Function ValidarDatos() As String
        ' Validamos que todos los datos que se van actualizar estan listos para grabar



        Dim lMsg As String = "", lRes As Boolean = True, IdObra As String = "", lTmpStr As String = "", lDal As New Datos, lnotjs As String = ""
        Dim ValidaHora2 As Boolean = True

        IdObra = Val(Session("obra").ToString())
        If dpCamion.SelectedValue.ToString.Equals("Seleccione:") AndAlso lRes = True Then
            lRes = False
            lnotjs = "TipoCamion()"
        End If

        If txtObsCamion.Text.Trim.Length < 1 Then
            lRes = False
            lMsg = "Debe Indicar El Nombre de la Obra"
            lnotjs = "ObsCamion()"
        End If

        If dpTipoRecepcion.SelectedValue.ToString.Equals("Seleccione:") AndAlso lRes = True Then
            lRes = False
            lnotjs = "TipoRecepcion()"
        End If

        If dpTipoRecepcion.SelectedValue.ToString.Equals("Hora establecida") AndAlso lRes = True Then
            ValidaHora2 = False
        End If

        If DpHora1.SelectedValue.ToString.Equals("Seleccione:") AndAlso lRes = True Then
            lRes = False
            lnotjs = "Hora1()"
        End If

        If ValidaHora2 = True Then
            If DpHora2.SelectedValue.ToString.Equals("Seleccione:") AndAlso lRes = True Then
                lRes = False
                lnotjs = "Hora2()"
            End If
        End If

        If lRes = False Then
            ScriptManager.RegisterStartupScript(Me, Page.GetType, "Script", lnotjs, True)
        End If
        Return lMsg
    End Function

    Protected Sub brnGrabar_Click(sender As Object, e As EventArgs) Handles brnGrabar.Click
        Dim lDal As New Datos, IdObra As String = "", lMsg As String = "", lResultado As String = "", Usuario As String = "", Estado As String = ""
        lMsg = ValidarDatos()
        If lMsg.Length = 0 Then
            IdObra = Val(Session("obra").ToString())
            Usuario = (Session("UsuarioLogueado").ToString())
            Estado = "S"
            lResultado = lDal.IngresaOBSCamionLogistica(dpCamion.Text, txtObsCamion.Text, dpTipoRecepcion.Text, DpHora1.Text, DpHora2.Text, Usuario, IdObra, Estado)
            If lResultado = "OK" Then
                ScriptManager.RegisterStartupScript(Me, Page.GetType, "Script", "DetalleCamionOK();", True)
            Else
                ScriptManager.RegisterStartupScript(Me, Page.GetType, "Script", "DetalleCamionER();", True)
            End If
            ' se debe visualizar el Error
        End If
    End Sub

    Private Sub CargaDatosCamion()
        Dim ldal As New Datos(), lTbl As New DataTable, lSql As String
        lSql = String.Concat("  SP_Consultas_FichaObra  21 ,", Session("obra"), ",'','','','','','','','',''")
        lTbl = ldal.CargaTabla(lSql, "L")
        If (lTbl.Rows.Count > 0) Then
            gvDetalleCamion.DataSource = lTbl
            gvDetalleCamion.DataBind()
            txtTipoCamion.Text = lTbl.Rows(0)("TipoCamion").ToString()
            If lTbl.Rows(0)("TipoRecepcion").ToString = "Rango" Then
                txtHoraRecepcion.Text = "Entre las " & lTbl.Rows(0)("Hora1").ToString & " y las " & lTbl.Rows(0)("Hora2").ToString & " horas."
            Else
                txtHoraRecepcion.Text = "A las " & lTbl.Rows(0)("Hora1").ToString & " horas"
            End If
        Else
        End If
    End Sub

    Protected Sub btnGrabar_Click(sender As Object, e As EventArgs) Handles btnGrabar.Click
        Dim lSql As String = "", ldal As New Datos, lTblRes As New Data.DataTable, ltemporal As String = "", lres As Boolean = False
        Dim codigo As String = "", lVal As New Validar, Resultado As String = "", idObra As String = ""
        codigo = txtCodigo.Text
        Resultado = lVal.ValidaLogistica(codigo, dpDesplazamiento.Text)
        idObra = Val(Session("obra").ToString())
        If Resultado = "OK" Then
            If ldal.ExisteProductoEnINET(codigo, "TO") = True Then
                lSql = String.Concat("update Obras set Codigo_INET = '", codigo, "', TiempoDesplazamiento = '", dpDesplazamiento.SelectedValue, "' where id = '", idObra, "'")
                lTblRes = ldal.CargaTabla(lSql, "L")
                ltemporal = ""
                lres = True
                ScriptManager.RegisterStartupScript(Me, Page.GetType, "Script", "CodigoOK();", True)
            Else
                ScriptManager.RegisterStartupScript(Me, Page.GetType, "Script", "CodigoEr();", True)
            End If
        ElseIf Resultado = "CodigoEr" Then
            ScriptManager.RegisterStartupScript(Me, Page.GetType, "Script", "CodigoEmpty();", True)
        ElseIf Resultado = "TiempoDespEr" Then
            ScriptManager.RegisterStartupScript(Me, Page.GetType, "Script", "TiempoDesp();", True)
        End If
    End Sub

    Private Sub PermisosLOG()
        Dim ldal As New Datos(), lTbl As New DataTable, lres As Boolean = False
        'lSql = String.Concat("  SP_Consultas_FichaObra  12 ,", Session("idUsuario"), ",79,'','','','','','','',''")
        lres = New Datos().PermisoModulos(Session("idUsuario"), 1085)
        PanelLOG.Visible = lres
        PanelDetalle.Visible = lres
    End Sub
End Class