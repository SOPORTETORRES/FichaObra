Public Class COF
    Inherits System.Web.UI.Page

    Dim dtPrecios As New DataTable
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsNothing(Session("obra")) Then
            Response.Redirect("FichaObra.aspx")
        Else
            If IsPostBack = False Then
                Dim obra As Integer = Session("obra")
                lblID.Text = obra
                Session("Pestaña") = "C.O.F"
                PermisosCOF()
                CargaDatosIniciales()
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
                dpEstado.SelectedValue = lTabla.Rows(0)("EstadoAlta").ToString()
                txtNombreCliente.Text = lTabla.Rows(0)("Cliente").ToString()
                txtRutCliente.Text = lTabla.Rows(0)("RutCliente").ToString()
                dpEmpresa.SelectedValue = lTabla.Rows(0)("Empresa").ToString()
                rut = lTabla.Rows(0)("RutCliente").ToString()
                txtCantidadKG.Text = Format(Val(lTabla.Rows(0)("Cantidad").ToString().ToString), "#,##0")
                txtReajuste.Text = lTabla.Rows(0)("TipoReajuste").ToString()
                txtCentroCosto.Text = lTabla.Rows(0)("CentroCosto").ToString()
                dpTipoFacturacion.SelectedValue = lTabla.Rows(0)("TipoFacturacion").ToString()
                dpCondicionPago.SelectedValue = lTabla.Rows(0)("CondicionPago").ToString()
                dpTipoGuia.SelectedValue = lTabla.Rows(0)("TipoGuia").ToString()
                dpCodigoFacturar.SelectedValue = lTabla.Rows(0)("CodigoFacturar").ToString()
                partes = rut.Split("-")
                If partes.Length = 2 Then
                    rutInet = partes(0).ToString
                    Session("RutClte") = rutInet
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

    Protected Sub btnServicioExtra_Click(sender As Object, e As EventArgs) Handles btnServicioExtra.Click
        Response.Redirect("ServiciosExtra.aspx")
    End Sub

    Private Sub PermisosCOF()
        Dim ldal As New Datos(), lTbl As New DataTable, lSql As String, lres As Boolean = False
        lSql = String.Concat("  SP_Consultas_FichaObra  12 ,", Session("idUsuario"), ",79,'','','','','','','',''")
        lres = New Datos().PermisoModulos(Session("idUsuario"), 79)
        PanelCOF.Visible = lres
    End Sub

    Private Function ValidarDatos() As String
        ' Validamos que todos los datos que se van actualizar estan listos para grabar



        Dim lMsg As String = "", lRes As Boolean = True, IdObra As String = "", lTmpStr As String = "", lDal As New Datos, lnotjs As String = ""



        If txtNombreObra.Text.Trim.Length < 1 Then
            lRes = False
            lMsg = "Debe Indicar El Nombre de la Obra"
            lnotjs = "NombreObra()"
        End If
        IdObra = Val(Session("obra").ToString())
        If dpCondicionPago.SelectedValue.ToString.Equals("Seleccione:") AndAlso lRes = True Then
            lRes = False
            lMsg = "Debe Indicar la condición de Pago"
            lnotjs = "CondicionPago()"
        End If



        If dpTipoFacturacion.SelectedValue.ToString.Equals("Seleccione:") AndAlso lRes = True Then
            lRes = False
            lMsg = "Debe Indicar el tipo de facturación "
            lnotjs = "TipoFacturacion()"
        End If


        If lRes = True Then
            lMsg = lDal.ExisteSiglaObra(txtSigla.Text, IdObra)
        End If

        If lMsg.Length > 0 AndAlso lRes = True Then
            lRes = False
            lMsg = "Debe Indicar el nombre de sigla"
            lnotjs = "SiglaObra()"
        End If


        If (dpEstado.Text <> "PreAlta" And dpEstado.Text <> "Alta") AndAlso lRes = True Then
            lRes = False
            lMsg = "El estado ingresado no es válido"
            lnotjs = "EstadoObra()"
        End If



        If (dpEmpresa.Text <> "TO" And dpEmpresa.Text <> "TOSOL") AndAlso lRes = True Then
            lRes = False
            lMsg = "La Empresa no es válida"
            lnotjs = "EmpresanoValida()"
        End If



        If txtNombreCliente.Text.Trim.Length < 1 AndAlso lRes = True Then
            lRes = False
            lMsg = "Debe Indicar El Nombre del Cliente "
            lnotjs = "NombreCliente()"
        End If



        If txtRutCliente.Text.Trim.Length < 1 AndAlso lRes = True Then
            lRes = False
            lMsg = "Debe Indicar El RUT del Cliente "
            lnotjs = "RutCliente()"
        End If
        If txtCentroCosto.Text.Trim.Length < 1 AndAlso lRes = True Then
            lRes = False
            lMsg = "Debe Indicar el Centro de Costo  "
            lnotjs = "CentroCosto()"
        End If



        If dpTipoGuia.SelectedValue.ToString.Equals("Seleccione:") AndAlso lRes = True Then
            lRes = False
            lMsg = "Debe Indicar el   Tipo de Guia de despacho "
            lnotjs = "TipoGuiaDespacho()"
        End If

        If dpCodigoFacturar.SelectedValue.ToString.Equals("Seleccione:") AndAlso lRes = True Then
            lRes = False
            lMsg = "Debe Indicar el   Código "
            lnotjs = "CodigoFacturar()"
        End If




        If Val(IdObra) = 0 AndAlso lRes = True Then
            lRes = False
            lMsg = "La variable de session No esta especificada "
            lnotjs = "idObra()"
        End If

        If dpTipoFacturacion.SelectedValue.ToString.Equals("Seleccione:") AndAlso lRes = True Then
            lRes = False
            lMsg = "Debe seleccionar una opcion valida"
            lnotjs = "tipoFacturacion()"
        End If


        If lRes = False Then
            ScriptManager.RegisterStartupScript(Me, Page.GetType, "Script", lnotjs, True)
        End If
        Return lMsg
    End Function







    Private Sub CargaDatosIniciales()
        Dim ldal As New Datos, lSql As String = "", lTblDatos As New Data.DataTable, lVista1 As DataView
        Dim lFila As DataRow, lVista2 As DataView, lVista3 As DataView, lVista4 As DataView, lVista5 As DataView, lVista6 As DataView
        'Cargamos datos de parametros
        lTblDatos = ldal.CargaTablaParametros()
        'Cargamos cada uno los Desplagables
        '**CargaTipoGuia********
        lFila = lTblDatos.NewRow
        lFila("par1") = "Seleccione:" : lFila("Subtabla") = "TipoGuiaDespacho" : lTblDatos.Rows.Add(lFila)
        lVista1 = New DataView(lTblDatos, "Subtabla='TipoGuiaDespacho'", "", DataViewRowState.CurrentRows)
        dpTipoGuia.DataSource = lVista1
        dpTipoGuia.DataTextField = "Par1"
        dpTipoGuia.DataValueField = "Par1"
        dpTipoGuia.DataBind()
        dpTipoGuia.SelectedIndex = lVista1.Count - 1
        '**CargaTipoGuia********
        lFila = lTblDatos.NewRow
        lFila("par1") = "Seleccione:" : lFila("Subtabla") = "CodParaFacturar" : lTblDatos.Rows.Add(lFila)
        lVista2 = New DataView(lTblDatos, "Subtabla='CodParaFacturar'", "", DataViewRowState.CurrentRows)
        dpCodigoFacturar.DataSource = lVista2
        dpCodigoFacturar.DataTextField = "Par1"
        dpCodigoFacturar.DataValueField = "Par1"
        dpCodigoFacturar.DataBind()
        dpCodigoFacturar.SelectedIndex = lVista2.Count - 1
        '**EmpresaFacturar********
        lFila = lTblDatos.NewRow
        lFila("par1") = "Seleccione:" : lFila("Subtabla") = "EmpresaFacturar" : lTblDatos.Rows.Add(lFila)
        lVista3 = New DataView(lTblDatos, "Subtabla='EmpresaFacturar'", "", DataViewRowState.CurrentRows)
        dpEmpresa.DataSource = lVista3
        dpEmpresa.DataTextField = "Par1"
        dpEmpresa.DataValueField = "Par1"
        dpEmpresa.DataBind()
        dpEmpresa.SelectedIndex = lVista3.Count - 1
        '**EstadoObra********
        lFila = lTblDatos.NewRow
        lFila("par1") = "Seleccione:" : lFila("Subtabla") = "EstadoObra" : lTblDatos.Rows.Add(lFila)
        lVista4 = New DataView(lTblDatos, "Subtabla='EstadoObra'", "", DataViewRowState.CurrentRows)
        dpEstado.DataSource = lVista4
        dpEstado.DataTextField = "Par1"
        dpEstado.DataValueField = "Par1"
        dpEstado.DataBind()
        dpEstado.SelectedIndex = lVista4.Count - 1
        '**TipoFacturacionCOF********
        lFila = lTblDatos.NewRow
        lFila("par1") = "Seleccione:" : lFila("Subtabla") = "TipoFacturacionCOF" : lTblDatos.Rows.Add(lFila)
        lVista5 = New DataView(lTblDatos, "Subtabla='TipoFacturacionCOF'", "", DataViewRowState.CurrentRows)
        dpTipoFacturacion.DataSource = lVista5
        dpTipoFacturacion.DataTextField = "Par1"
        dpTipoFacturacion.DataValueField = "Par1"
        dpTipoFacturacion.DataBind()
        dpTipoFacturacion.SelectedIndex = lVista5.Count - 1
        '**TipoFacturacionCOF********
        lFila = lTblDatos.NewRow
        lFila("par1") = "Seleccione:" : lFila("Subtabla") = "CondicionPagoCOF" : lTblDatos.Rows.Add(lFila)
        lVista6 = New DataView(lTblDatos, "Subtabla='CondicionPagoCOF'", "", DataViewRowState.CurrentRows)
        dpCondicionPago.DataSource = lVista6
        dpCondicionPago.DataTextField = "Par1"
        dpCondicionPago.DataValueField = "Id"
        dpCondicionPago.DataBind()
        dpCondicionPago.SelectedIndex = lVista6.Count - 1





    End Sub

    Protected Sub btnGrabar_Click(sender As Object, e As EventArgs) Handles btnGrabar.Click
        Dim lDal As New Datos, IdObra As String = "", lMsg As String = "", lResultado As String = ""
        lMsg = ValidarDatos()
        If lMsg.Length = 0 Then
            IdObra = Val(Session("obra").ToString())
            lResultado = lDal.ActualizaDatos_COF(txtSigla.Text, dpEstado.Text, txtCentroCosto.Text, dpCodigoFacturar.Text, IdObra, dpEmpresa.Text, txtNombreCliente.Text, dpTipoFacturacion.SelectedValue.ToString, dpTipoGuia.SelectedValue.ToString, dpCondicionPago.SelectedValue.ToString)
            If lResultado = "OK" Then
                ScriptManager.RegisterStartupScript(Me, Page.GetType, "Script", "updateOKs();", True)
            Else
                ScriptManager.RegisterStartupScript(Me, Page.GetType, "Script", "updateER();", True)
            End If
            ' se debe visualizar el Error
        End If
    End Sub

    Protected Sub btnObrasF_Click(sender As Object, e As EventArgs) Handles btnObrasF.Click
        Response.Redirect("ObrasFinalizadas.aspx")
    End Sub
End Class