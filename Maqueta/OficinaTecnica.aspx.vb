Public Class OficinaTecnica
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsNothing(Session("obra")) Then
            Response.Redirect("FichaObra.aspx")
        Else
            If IsPostBack = False Then
                PermisosOT()
                Session("Pestaña") = "Oficina Tecnica"
                Dim obra As Integer = Session("obra")
                CargaAdministradores()
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
                txtEmpresa.Text = lTabla.Rows(0)("Empresa").ToString()
                txtTipoObra.Text = lTabla.Rows(0)("TipoO").ToString()
                txtFacturacion.Text = lTabla.Rows(0)("TipoFac").ToString()
                If lTabla.Rows(0)("Encargado").ToString().Length > 0 Then
                    dpAdministradores.SelectedValue = lTabla.Rows(0)("IdUserEncargado").ToString()
                End If
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

    Private Sub CargaAdministradores()
        Dim ldal As New Datos, lSql As String = "", lTbl As New Data.DataTable
        'Cargamos datos de parametros
        lSql = String.Concat("SP_Consultas_FichaObra  14 ,'','','','','','','','','',''")
        lTbl = ldal.CargaTabla(lSql, "L")
        Dim lFila As DataRow = lTbl.NewRow
        lFila("NombreCompleto") = "Seleccione:"
        lTbl.Rows.Add(lFila)
        lFila = lTbl.NewRow
        dpAdministradores.DataSource = lTbl
        dpAdministradores.DataTextField = "NombreCompleto"
        dpAdministradores.DataValueField = "Id"
        dpAdministradores.DataBind()
        dpAdministradores.SelectedIndex = lTbl.Rows.Count - 1
    End Sub

    Protected Sub btnGrabar_Click(sender As Object, e As EventArgs) Handles btnGrabar.Click
        Dim ldal As New Datos, lSql As String = "", lTbl As New Data.DataTable
        lSql = String.Concat("SP_Consultas_FichaObra  22 ,", Session("obra"), ",", dpAdministradores.SelectedValue, ",'", dpAdministradores.SelectedItem, "','','','','','','',''")
        lTbl = ldal.CargaTabla(lSql, "L")
        If (lTbl.Rows.Count > 0) Then
            'grabo bien
            ScriptManager.RegisterStartupScript(Me, Page.GetType, "Script", "AddAdminOK();", True)
        Else
            'Error
            ScriptManager.RegisterStartupScript(Me, Page.GetType, "Script", "AddAdminER();", True)
        End If
    End Sub

    Protected Sub btnExcel_Click(sender As Object, e As EventArgs) Handles btnExcel.Click
        Dim lDal As New Datos, lTbl As New DataTable, lStr As String = ""
        Dim lNombre As String = "" 'String.Concat(iIdObra, ".csv")
        Dim i As Integer = 0, j As Integer = 0, lIdObra As String = "0"



        ' Establecemos el Nombre del archivo a descargar
        lNombre = String.Concat("pruebas", ".csv")
        Response.AddHeader("content-disposition", "attachment; filename=" & lNombre)
        ' Especificamos el tipo de salida.                
        Response.ContentType = "application/octet-stream"
        ' Asociamos la salida con la codificación UTF7 (para poder visualizar los acentos correctamente)
        Response.ContentEncoding = System.Text.Encoding.UTF8
        Response.Charset = ""
        Me.EnableViewState = False
        Dim tw As New System.IO.StringWriter



        lTbl = New Datos().ObtenerSqlExportaPaquetesExcel(5)
        For i = 0 To lTbl.Columns.Count - 1
            lStr = lStr & lTbl.Columns(i).Caption & ";"
        Next
        lStr = lStr & vbCrLf
        For i = 0 To lTbl.Rows.Count - 1
            If i > 0 Then
                lStr = ""
            End If
            For j = 0 To lTbl.Columns.Count - 1
                lStr = lStr & lTbl.Rows(i)(j).ToString & ";"
            Next
            lStr = lStr & vbCrLf
            'Escribimos el HTML en el Explorador
            Response.Write(lStr)
        Next
        ' Terminamos el Response.
        Response.End()
    End Sub

    Private Sub PermisosOT()
        Dim ldal As New Datos(), lTbl As New DataTable, lSql As String, lres As Boolean = False
        'lSql = String.Concat("  SP_Consultas_FichaObra  12 ,", Session("idUsuario"), ",79,'','','','','','','',''")
        lres = New Datos().PermisoModulos(Session("idUsuario"), 1079)
        PanelOT.Visible = lres
    End Sub
End Class