Public Class General
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsNothing(Session("obra")) Then
            Response.Redirect("FichaObra.aspx")
        Else
            PermisosGEN()
            Dim obra As Integer = Session("obra")
            If IsPostBack = False Then
                Session("Pestaña") = "General"
                CargaDatosObra(obra)
            End If
        End If
    End Sub

    Private Function CargaDatosObra(obra As Integer)
        Dim lresultado As Boolean, lDAtos As New Datos
        Dim ldal As New Datos
        Dim lSql As String = ""



        Try
            Dim lTabla As New Data.DataTable, rut As String, partes() As String, valoruf As Integer, dts As New PX_Facturacion.ListaDataSet
            Dim lproxy As New PX_Facturacion.FacturacionSoapClient, rutInet As String, lcuso As Integer, lcuso2 As Integer
            Dim lcAprobada As Integer, lcDisponible As Integer, lcporcentaje As Integer



            lTabla = lDAtos.CargaTabla_DatosObra(obra)
            '  lTabla = ldal.CargaTabla(lSql, "L")
            If lTabla.Rows.Count > 0 Then
                '----------------- DATOS DE SOLICITUD ------------------------------
                txtNombreObra.Text = lTabla.Rows(0)("Nombre").ToString()
                txtSigla.Text = lTabla.Rows(0)("SiglaObra").ToString()
                txtEstado.Text = lTabla.Rows(0)("EstadoAlta").ToString()
                txtDireccion.Text = lTabla.Rows(0)("Dir").ToString()
                txtComuna.Text = lTabla.Rows(0)("Comuna").ToString()
                txtCiudad.Text = lTabla.Rows(0)("Ciudad").ToString()
                txtSucursal.Text = lTabla.Rows(0)("Sucursal").ToString()
                txtAdm.Text = lTabla.Rows(0)("Encargado").ToString()
                txtReajuste.Text = lTabla.Rows(0)("tipoReajuste").ToString()
                'txtFonoContactoObra.Text = lTabla.Rows(0)("Telefono").ToString()
                txtCantidadKG.Text = Format(Val(lTabla.Rows(0)("Cantidad").ToString().ToString), "#,##0")
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
                                    Case >= 31
                                        Literal1.Text = "<span Class=""badge badge rounded-pill d-block p-2 badge-soft-success"">" & lcporcentaje & " %" & "<data-fa-transform=""shrink-2""></span>"

                                End Select
                            End If
                        Catch ex As Exception
                            'error
                        End Try
                    Else
                        'Validar sin informacion
                    End If
                End If
            End If
            lTabla = ldal.CargaTabla_Sucursal(obra)
            For Each row In lTabla.Rows
                txtSucursal.Text = String.Concat(txtSucursal.Text, row(0).ToString, ", ")
            Next
            If txtSucursal.Text.Length > 1 Then
                txtSucursal.Text = txtSucursal.Text.Substring(0, txtSucursal.Text.Length - 2)
            End If
        Catch ex As Exception
            'lblError.Text = ex.ToString
        Finally
        End Try
        Return lresultado
    End Function

    Protected Sub btnGrabar_Click(sender As Object, e As EventArgs) Handles btnGrabar.Click
        Dim lDal As New Datos, lRes As String = "", Valida As Boolean = True
        If txtDireccion.Text.Length = 0 Then
            'alerta debe introducir dato
            Valida = False
        End If
        If txtComuna.Text.Length = 0 Then
            'alerta debe introducir dato
            Valida = False
        End If
        If txtCiudad.Text.Length = 0 Then
            'alerta debe introducir dato
            Valida = False
        End If
        If Valida = True Then
            lRes = lDal.ActualizaDatos_General(txtDireccion.Text, txtComuna.Text, txtCiudad.Text, Session("obra"))
            If lRes = "OK" Then
                ScriptManager.RegisterStartupScript(Me, Page.GetType, "Script", "GeneralOK();", True)
                'Inserto
            Else
                ScriptManager.RegisterStartupScript(Me, Page.GetType, "Script", "GeneralER();", True)
                'No inserto
            End If
        End If
    End Sub

    Private Sub PermisosGEN()
        Dim ldal As New Datos(), lTbl As New DataTable, lres As Boolean = False
        'lSql = String.Concat("  SP_Consultas_FichaObra  12 ,", Session("idUsuario"), ",79,'','','','','','','',''")
        lres = New Datos().PermisoModulos(Session("idUsuario"), 79)
        PanelGeneral.Visible = lres
        txtDireccion.Enabled = lres
        txtComuna.Enabled = lres
        txtCiudad.Enabled = lres
        btnGrabar.Visible = lres
    End Sub
End Class