Public Class Detalle_LC
    Inherits System.Web.UI.Page


    Dim lIdUser As String = ""
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim lRut As String = "" ' "76080944",
        lIdUser = Session("idUsuario")
        'If IsNumeric(lIdUser) AndAlso Val(lIdUser) > 0 Then
        '    CargaUsuario_y_Msgs(lIdUser)
        'Else
        '    Response.Redirect(mUrlLogin) 'New ClsDatos().ObtenerUrl_Inicio)
        'End If
        If IsPostBack = False Then
            lRut = Session("RutClte") '.Substring(0, Request.QueryString("Clte").ToString.Length - 2)
            If IsNothing(lRut) = False Then
                CargaDatos(lRut)
            End If
        End If
    End Sub

    Private Sub CargaDatos(iRut As String)
        Dim lSql As String = "", lDal2 As New Datos(), lTblRes As New DataTable
        Dim lRes As PX_Facturacion.ListaDataSet, lTotal As Double = 0, lValorUf As Double = 0
        Dim LC_AprPesos As Double = 0, lXFacPesos As String = "", lTotalAjuste As Integer = 0
        Dim lproxy As New PX_Facturacion.FacturacionSoapClient

        Tx_rut.Text = iRut
        lRes = lproxy.ObtenerDatosLN_Cliente(iRut)
        If (lRes.MensajeError.Equals("")) AndAlso (IsNothing(lRes.DataSet) = False) Then
            If (lRes.DataSet.Tables.Count > 0) AndAlso (lRes.DataSet.Tables(0).Rows.Count > 0) Then



                Lbl_FacPesos.Text = Format(Val(lRes.DataSet.Tables(0).Rows(0)(1).ToString()), "#,##0")
                Lbl_ProxDesp.Text = Format(Val(lRes.DataSet.Tables(0).Rows(0)(2).ToString()), "#,##0")



                ' lTotalAjuste = New ClsDatos().ObtenerAjusteObra(iRut)
                Lbl_XFacPesos.Text = Format(Val(lRes.DataSet.Tables(0).Rows(0)(3).ToString()), "#,##0")
                lXFacPesos = Val(lRes.DataSet.Tables(0).Rows(0)(3).ToString()) - Val(lTotalAjuste)



                Lbl_XFacPesos.Text = Format(Val(lXFacPesos), "#,##0")
                lblObra.Text = lRes.DataSet.Tables(0).Rows(0)(0).ToString()
                ' Por incidecncia  0002769: Sistema Linea de Credito , el total de la LC no considere el Programa
                ' lTotal = Val(lRes.DataSet.Tables(0).Rows(0)(1).ToString()) + Val(lRes.DataSet.Tables(0).Rows(0)(2).ToString()) + Val(lRes.DataSet.Tables(0).Rows(0)(3).ToString())



                lTotal = Val(lRes.DataSet.Tables(0).Rows(0)(1).ToString()) + Val(lXFacPesos)



            End If
        End If



        'Cargamos la UF 
        lSql = String.Concat(" select * from PARAMETRO where PAR_TABLA ='LC_VALORUF' ") ' @RUT
        lTblRes = lDal2.CargaTabla(lSql, "L")
        If (lTblRes.Rows.Count > 0) Then
            Lbl_ValorUf.Text = lTblRes.Rows(0)("Par_Alf1").ToString()
            Lbl_FechaUF.Text = lTblRes.Rows(0)("Par_Alf2").ToString()
            lValorUf = CDbl(Lbl_ValorUf.Text)
        End If



        ' Cargamos los datos de la linea  de Credito
        lSql = String.Concat(" Select *  From VW_LINEA_CREDITO    Where RUT like '%", iRut, "%' ") ' @RUT
        lTblRes = lDal2.CargaTabla(lSql, "L")
        If (lTblRes.Rows.Count > 0) Then
            ' LC_AprPesos = CDbl(lTblRes.Rows(0)("Monto_Linea_Aprobada").ToString())
            lbl_lc_Uf.Text = Format(Val(lTblRes.Rows(0)("Monto_Linea_Aprobada").ToString()), "#,##0")
            LC_AprPesos = CDbl(lbl_lc_Uf.Text) * lValorUf
            lbl_lc_Pesos.Text = Format(Val(LC_AprPesos.ToString()), "#,##0") 'lValorUf * Val(lbl_lc_Uf.Text)
        End If



        Lbl_LC_OcupadaPesos.Text = lTotal
        Lbl_LC_OcupadaUf.Text = Math.Round((lTotal / lValorUf), 0)



        Lbl_LC_DispPesos.Text = CDbl(lbl_lc_Pesos.Text) - CDbl(Lbl_LC_OcupadaPesos.Text)
        Lbl_LC_DispUF.Text = String.Concat(Math.Round((CDbl(Lbl_LC_DispPesos.Text) / lValorUf), 0), " UF")



        If (CDbl(lbl_lc_Pesos.Text) > 0) Then
            Lbl_PorUso.Text = Math.Round(CDbl(Lbl_LC_DispPesos.Text) / CDbl(lbl_lc_Pesos.Text), 2) * 100
        Else
            Lbl_PorUso.Text = "0"
        End If
        'Lbl_PorUso.Text = Math.Round(CDbl(Lbl_LC_DispPesos.Text) / CDbl(lbl_lc_Pesos.Text), 2) * 100



        Lbl_LC_DispPesos.Text = Format(Val(Lbl_LC_DispPesos.Text), "#,##0")
        Lbl_LC_DispUF.Text = Format(Val(Lbl_LC_DispUF.Text), "#,##0")



        Lbl_LC_OcupadaPesos.Text = Format(Val(Lbl_LC_OcupadaPesos.Text), "#,##0")
        Lbl_LC_OcupadaUf.Text = Format(Val(Lbl_LC_OcupadaUf.Text), "#,##0")



        Lbl_FacUF.Text = Math.Round((CDbl(Lbl_FacPesos.Text) / lValorUf), 0)
        Lbl_FacUF.Text = Format(Val(Lbl_FacUF.Text), "#,##0")



        Lbl_ProgUF.Text = Math.Round((CDbl(Lbl_ProxDesp.Text) / lValorUf), 0)
        Lbl_ProgUF.Text = Format(Val(Lbl_ProgUF.Text), "#,##0")



        Lbl_XFacUF.Text = Math.Round((CDbl(Lbl_XFacPesos.Text) / lValorUf), 0)
        Lbl_XFacUF.Text = Format(Val(Lbl_XFacUF.Text), "#,##0")

    End Sub

    Public Function ObtenerDetalleFacturasPendientes(iRut As String, itipo As String) As DataTable
        Dim lRes As String = "0", lDal As New Datos, lTbl As New DataTable
        Dim lSql As String = String.Concat(" SP_Consultas_WS  188,'", iRut, "','','','','','',''")
        Dim i As Integer = 0, lTotal As Integer = 0, lFila As DataRow = Nothing



        lTbl = lDal.CargaTabla(lSql, "L")
        If lTbl.Rows.Count > 0 Then




            If itipo = "SP" Then
                lTbl = EliminaFacturasPagadas(lTbl)



                For i = 0 To lTbl.Rows.Count - 1
                    lTotal = lTotal + Val(lTbl.Rows(i)("Importe").ToString())



                Next



                lFila = lTbl.NewRow
                lFila("NombreDoc") = "Totales"
                lFila("Importe") = lTotal
                lTbl.Rows.Add(lFila)
            End If



            For i = 0 To lTbl.Rows.Count - 1
                lTbl.Rows(i)("Importe") = Format(Val(lTbl.Rows(i)("Importe").ToString()), "#,##0")



            Next



        End If



        Return lTbl



    End Function

    Private Function EliminaFacturasPagadas(iTbl As DataTable) As DataTable
        Dim lTblRes As New DataTable, i As Integer = 0, lFactProcesadas As String = ""
        Dim lFacActual As String = "", lVista As DataView = Nothing, lWheres As String = ""
        Dim lSaldo As Double = 0, k As Integer = 0, lFila As DataRow = Nothing, lCols As Integer = 0
        Dim lTblResDos As New DataTable



        lTblRes = iTbl.Copy
        lTblRes.Clear()



        For i = 0 To iTbl.Rows.Count - 1
            lFacActual = Val(iTbl.Rows(i)("NroDoc").ToString)
            If lFactProcesadas.IndexOf(lFacActual) = -1 Then
                'No ha sido Procesada
                lSaldo = 0
                lWheres = String.Concat(" NroDoc=", lFacActual)
                lVista = New DataView(iTbl, lWheres, "", DataViewRowState.CurrentRows)
                If lVista.Count > 0 Then
                    For k = 0 To lVista.Count - 1
                        lSaldo = lSaldo + CDbl(lVista(k)("Importe").ToString)
                    Next
                    If lSaldo <> 0 Then
                        For k = 0 To lVista.Count - 1
                            lFila = lTblRes.NewRow
                            For lCols = 0 To iTbl.Columns.Count - 1
                                lFila(lCols) = lVista(k)(lCols).ToString()
                            Next
                            lTblRes.Rows.Add(lFila)
                            'lSaldo = lSaldo + CDbl(lVista(k)("Importe").ToString)
                        Next
                    End If
                End If
                lFactProcesadas = String.Concat(lFactProcesadas, " | ", lFacActual)
            End If
        Next





        Return lTblRes
    End Function

    Public Function ObtenerDetalleDespachoSiguienteSemana(iRut As String) As DataTable
        Dim lRes As String = "0", lDal As New Datos, lTbl As New DataTable
        Dim lSql As String = ""
        Dim lDiaSem As Date, lDiaTmp As String = "", lPuedeSeguir As Boolean = True



        'Debemos Obtener la fecha del proximo Lunes FechaInicio, luego la fecha del proximo sabado Fecha Fin
        'Con eso  realizamos  la busqueda



        'Nueva definicion: se deben tomar todos los despachos de la siguiente semana en adelante
        ' condicion: Etiqueta Impresa



        lDiaSem = Now.Date





        Dim lFechaIni As String = String.Concat(lDiaSem.ToShortDateString, " 00:00:01"), i As Integer = 0, lTotal As Integer = 0
        Dim lFechaFin As String = String.Concat(DateAdd(DateInterval.Day, 7, lDiaSem).ToShortDateString, " 23:59:59")
        Dim lFila As DataRow = Nothing



        lSql = String.Concat(" SP_Consultas_WS  154,'%", iRut, "%','", lFechaIni, "','", lFechaFin, "','','','',''")
        lTbl = lDal.CargaTabla(lSql, "L")
        If lTbl.Rows.Count > 0 Then
            For i = 0 To lTbl.Rows.Count - 1
                lTotal = lTotal + Val(lTbl.Rows(i)("TotalImporteKgs").ToString())
            Next



        End If
        lRes = lTotal



        lFila = lTbl.NewRow
        lFila("Nombre") = "Totales"
        lFila("TotalImporteKgs") = lRes



        lTbl.Rows.Add(lFila)



        For i = 0 To lTbl.Rows.Count - 1
            lTbl.Rows(i)("TotalImporteKgs") = Format(Val(lTbl.Rows(i)("TotalImporteKgs").ToString()), "#,##0")
            lTbl.Rows(i)("Kgs") = Format(Val(lTbl.Rows(i)("Kgs").ToString()), "#,##0")
        Next




        Return lTbl



    End Function

    Public Function ObtenerDetalleDespachadoSinFacturar(iRut As String) As DataTable
        Dim lRes As String = "0", lDal As New Datos, lTbl As New DataTable
        Dim lSql As String = "", i As Integer = 0, lTotalXFacAutom As Integer = 0
        Dim lTotal As Int64 = 0, lTotalXFac_EP As Integer = 0, lTotaConlIva As Int64 = 0
        Dim lTblAjustesObra As New DataTable, iFila As DataRow = Nothing
        Try
            'Debemos evaluar las obras tipo 331 Facturacion directa
            lSql = String.Concat(" SP_Consultas_WS  159,'", iRut, "','','','','','',''")
            lTbl = lDal.CargaTabla(lSql, "L")
            'For i = 0 To lTbl.Rows.Count - 1
            '    If (Val(lTbl.Rows(i)("VAlorKgs").ToString) > 0) AndAlso Val(lTbl.Rows(i)("AteProCan").ToString) > 0 Then
            '        lTotalXFacAutom = lTotalXFacAutom + (Val(lTbl.Rows(i)("VAlorKgs")) * Val(lTbl.Rows(i)("AteProCan")))
            '    End If
            'Next



            'Luego las obras tipo 330 Facturacion Por E.P
            lSql = String.Concat(" SP_Consultas_WS  185,'", iRut, "','','','','','',''")
            lTbl.Merge(lDal.CargaTabla(lSql, "L"))



            lTbl.Columns.Add("TotalGuia", Type.GetType("System.String"))
            lTbl.Columns.Add("TotalGuiaIva", Type.GetType("System.String"))



            'Por nueva funcionalidad de Ajustes Obra     0002769: Sistema Linea de Credito
            lSql = String.Concat(" select a. * from AjusteObras a, Obras o   where idObra=o.id and rutcliente like '%")
            lSql = String.Concat(lSql, iRut, "%'")
            lTblAjustesObra = lDal.CargaTabla(lSql, "L")



            For i = 0 To lTblAjustesObra.Rows.Count - 1
                iFila = lTbl.NewRow
                'lfila("ValorKgs") = "" TotalGuia
                iFila("AteObsUno") = lTblAjustesObra.Rows(i)("Obs").ToString()
                iFila("AteObsDos") = " Ajuste de Obra "
                iFila("AteProCan") = Val(lTblAjustesObra.Rows(i)("ImporteAjuste").ToString())
                iFila("VAlorKgs") = (-1)
                iFila("AteNum") = lTblAjustesObra.Rows(i)("Id").ToString()
                iFila("AteFchAte") = lTblAjustesObra.Rows(i)("FechaGrabacion").ToString()
                iFila("TotalGuia") = 0 '(lTblAjustesObra.Rows(i)("ImporteAjuste").ToString()) * -1
                lTbl.Rows.Add(iFila)
            Next



            For i = 0 To lTbl.Rows.Count - 1
                'lTbl.Rows(i)("TotalGuia") = Val(lTbl.Rows(i)("ImporteGuia").ToString) ' * Val(lTbl.Rows(i)("AteProCan").ToString)
                lTbl.Rows(i)("TotalGuia") = Val(lTbl.Rows(i)("ValorKgs").ToString) * Val(lTbl.Rows(i)("AteProCan").ToString)
                lTotal = lTotal + Val(lTbl.Rows(i)("TotalGuia").ToString)
                lTbl.Rows(i)("TotalGuiaIva") = Val(lTbl.Rows(i)("TotalGuia")) + Math.Round(Val(lTbl.Rows(i)("TotalGuia")) * 19 / 100, 0)
                lTotaConlIva = lTotaConlIva + Val(lTbl.Rows(i)("TotalGuiaIva").ToString)
            Next




            iFila = lTbl.NewRow
            iFila("AteGlo") = "Totales"
            iFila("TotalGuia") = lTotal
            iFila("TotalGuiaIva") = lTotaConlIva
            lTbl.Rows.Add(iFila)



            For i = 0 To lTbl.Rows.Count - 1
                lTbl.Rows(i)("TotalGuia") = Format(Val(lTbl.Rows(i)("TotalGuia").ToString()), "#,##0")
                lTbl.Rows(i)("TotalGuiaIva") = Format(Val(lTbl.Rows(i)("TotalGuiaIva").ToString()), "#,##0")
            Next



            'lTotal = lTotalXFacAutom + lTotalXFac_EP




        Catch ex As Exception



        End Try




        Return lTbl



    End Function

    Private Sub CargaDetalle(iTipo As String)
        Dim lDal As New PX_Facturacion.FacturacionSoapClient, lTbl As New DataTable
        Select Case iTipo.ToUpper
            Case "FP"  'FActuras pendientes de Pago
                lTbl = ObtenerDetalleFacturasPendientes(Tx_rut.Text, "SP")
                lbl_tituloDetalle.Text = " Detalle de Linea Ocupada en Facturado por Cobrar"
                GR_DetalleFac.DataSource = lTbl
                GR_DetalleFac.DataBind()
                GR_DetalleFac.Visible = True
                GR_DetalleProxD.Visible = False
                GR_DetalleGuias.Visible = False



            Case "PD"  'Proximos despachos
                lTbl = ObtenerDetalleDespachoSiguienteSemana(Tx_rut.Text)
                lbl_tituloDetalle.Text = " Detalle de Linea Ocupada en Próximos despachos"
                GR_DetalleProxD.DataSource = lTbl
                GR_DetalleProxD.DataBind()
                GR_DetalleFac.Visible = False
                GR_DetalleGuias.Visible = False
                GR_DetalleProxD.Visible = True



            Case "GF"   ' Guias sin FActura
                lTbl = ObtenerDetalleDespachadoSinFacturar(Tx_rut.Text)
                lbl_tituloDetalle.Text = " Detalle de Linea Ocupada en Guías sin Facturar"
                GR_DetalleGuias.DataSource = lTbl
                GR_DetalleGuias.DataBind()
                GR_DetalleFac.Visible = False
                GR_DetalleProxD.Visible = False
                GR_DetalleGuias.Visible = True



        End Select
    End Sub


    Protected Sub Btn_DetFac_Click(sender As Object, e As EventArgs) Handles Btn_DetFac.Click
        CargaDetalle("FP")
    End Sub

    Protected Sub Btn_DetProg_Click(sender As Object, e As EventArgs) Handles Btn_DetProg.Click
        CargaDetalle("PD")
    End Sub

    Protected Sub Btn_DetXFac_Click(sender As Object, e As EventArgs) Handles Btn_DetXFac.Click
        CargaDetalle("GF")
    End Sub

End Class