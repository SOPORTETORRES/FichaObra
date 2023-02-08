Imports System.Data.SqlClient
Imports System.Configuration.ConfigurationManager

Public Class Datos

    Public Function CargaTabla(ByVal isql As String, iTipo As String) As Data.DataTable
        Dim lCnnstr As String = "" ' ObtenerCnn()
        'Dim lCnn As New SqlConnection(lCnnstr)

        Dim lTabla As New Data.DataTable
        Try
            If iTipo.ToUpper.Equals("L") Then
                lCnnstr = ObtenerCnn_Local()
            Else
                lCnnstr = ObtenerCnn()
            End If
            Dim lCnn As New SqlConnection(lCnnstr)
            Dim lAdp As New SqlDataAdapter(isql, lCnn)

            If (isql.Length > 5) Then
                lAdp.SelectCommand.CommandTimeout = 200
                lAdp.Fill(lTabla)
            End If
        Catch ex As Exception
            Dim lErrror As String = "ClsDatos.CargaTabla " & ex.Message.ToString & " sql: " & isql
            'RegistraError(lErrror)
        End Try

        Return lTabla
    End Function



#Region "Metodos Privados"
    Public Function ObtenerCnn() As String
        'Return New BussinesObjects.Clases.Cls_Datos().ObtenerCnnStr
        Dim lCnn As String = AppSettings.Get("Cnn_Local").ToString

        Return lCnn

    End Function

    Public Function ObtenerCnn_Local() As String
        'Return New BussinesObjects.Clases.Cls_Datos().ObtenerCnnStr
        Dim lCnn As String = AppSettings.Get("Cnn").ToString

        Return lCnn

    End Function
#End Region

#Region " Metodos Publicos que sera usados desde  los Controles de Usuario"
#Region " Observaciones  "
    Public Function CargaTablaObs(IdObra As String) As DataTable

        Dim lTblRes As New DataTable, ldal As New Datos, lSql As String = ""
        lSql = String.Concat("  SP_Consultas_FichaObra  2 ,'", IdObra, "','','','','','','','','',''")
        lTblRes = ldal.CargaTabla(lSql, "L")
        Return lTblRes

    End Function

    Public Function GrabaObs(IdObra As String, iObs As String, iDepto As String, iIdUsuario As String) As DataTable

        Dim lTblRes As New DataTable, ldal As New Datos, lSql As String = ""
        lSql = String.Concat("  SP_Consultas_FichaObra  3 ,'", IdObra, "','", iObs, "','", iDepto, "','", iIdUsuario, "','','','','','',''")
        lTblRes = ldal.CargaTabla(lSql, "L")
        Return lTblRes

    End Function



#End Region
#Region " Contactos "
    Public Function GrabaContacto(iNombre As String, iEmail As String, IdObra As String, iObs As String, iUsuario As String, iTelefono As String, iDepartamento As String) As DataTable

        Dim lTblRes As New DataTable, ldal As New Datos, lSql As String = ""
        lSql = String.Concat("  SP_Consultas_FichaObra  5 ,'", iNombre, "','", iEmail, "','", IdObra, "','", iUsuario, "','", iTelefono, "','", iDepartamento, "','", iObs, "','','',''")
        lTblRes = ldal.CargaTabla(lSql, "L")
        Return lTblRes

    End Function


    Public Function CargaTablaContacto(IdObra As String) As DataTable

        Dim lTblRes As New DataTable, ldal As New Datos, lSql As String = ""
        lSql = String.Concat("  SP_Consultas_FichaObra  6 ,'", IdObra, "','','','','','','','','',''")
        lTblRes = ldal.CargaTabla(lSql, "L")
        Return lTblRes

    End Function



#End Region

#Region " Listado de Precios  "

    Public Function CargaTablaPrecios(IdObra As String) As DataTable
        Dim lTblRes As New DataTable, ldal As New Datos, lSql As String = ""
        lSql = String.Concat("  SP_Consultas_FichaObra  1 ,'", IdObra, "','','','','','','','','',''")
        lTblRes = ldal.CargaTabla(lSql, "L")
        Return lTblRes

    End Function

    Public Function CargaTablaPreciosCOF(IdObra As String) As DataTable

        Dim lTblRes As New DataTable, ldal As New Datos, lSql As String = ""
        lSql = String.Concat("SP_Consultas_FichaObra  16 ,'", IdObra, "','','','','','','','','',''")
        lTblRes = ldal.CargaTabla(lSql, "L")
        Return lTblRes

    End Function

    Public Function CargaTablaLotesPerdidos(IdObra As String) As DataTable
        Dim lTblRes As New DataTable, ldal As New Datos, lSql As String = ""
        lSql = String.Concat("SP_Consultas_FichaObra  23 ,'", IdObra, "','','','','','','','','',''")
        lTblRes = ldal.CargaTabla(lSql, "L")
        Return lTblRes
    End Function

    Public Function CargaTablaControlesObra(IdObra As String) As DataTable
        Dim lTblRes As New DataTable, ldal As New Datos, lSql As String = ""
        lSql = String.Concat("SP_Consultas_FichaObra  24 ,'", IdObra, "','','','','','','','','',''")
        lTblRes = ldal.CargaTabla(lSql, "L")
        Return lTblRes
    End Function

    Public Function CargaDatosDespacho(IDdespacho As Integer) As DataTable
        Dim lTblRes As New DataTable, ldal As New Datos, lSql As String = ""
        lSql = String.Concat("SP_Consultas_FichaObra  26 ,'", IDdespacho, "','','','','','','','','',''")
        lTblRes = ldal.CargaTabla(lSql, "L")
        Return lTblRes
    End Function

    Public Function CargaDatosGDE(IDdespacho As Integer) As DataTable
        Dim lTblRes As New DataTable, ldal As New Datos, lSql As String = ""
        lSql = String.Concat("SP_Consultas_FichaObra  27 ,'", IDdespacho, "','','','','','','','','',''")
        lTblRes = ldal.CargaTabla(lSql, "L")
        Return lTblRes
    End Function

    Public Function CargaDatosDespachoGeneral() As DataTable
        Dim lTblRes As New DataTable, ldal As New Datos, lSql As String = ""
        lSql = String.Concat("SP_Consultas_FichaObra  29 ,'','','','','','','','','',''")
        lTblRes = ldal.CargaTabla(lSql, "L")
        Return lTblRes
    End Function

    Public Function GrabaDatosDespacho(CostoFleteFalso As Integer, CostoNeto As Integer, Sobreestadia As Integer,
        IDGDE As String, Nfactura As String, Observacion As String, Usuario As String) As DataTable
        Dim lTblRes As New DataTable, ldal As New Datos, lSql As String = "", CostoTotal As Integer
        CostoTotal = CostoNeto + Sobreestadia + CostoFleteFalso
        lSql = String.Concat("SP_Consultas_FichaObra  28 ,'", CostoFleteFalso, "','", CostoNeto, "','", Sobreestadia, "','", IDGDE, "','", Nfactura, "','", Observacion, "','", Usuario, "','", CostoTotal, "','',''")
        lTblRes = ldal.CargaTabla(lSql, "L")
        Return lTblRes
    End Function



#End Region

#Region " Listado de Ordenes de compra v/s Despachos  "

    Public Function OBtenerAvanceObra(iIdObra As String) As DataTable
        'Cargamos los datos de req AdmObras 17/07/2013
        Dim lSql As String = "", lTblRes As New DataTable, i As Integer = 0, lTotal As Integer = 0
        Dim lUsados As Integer = 0, lSaldo As Integer = 0, lAvance As Double = 0, lTotalKgs As Integer = 0
        Dim lTotalOC As Integer = 0, lPorAvance As Double = 0, lTblFinal As New DataTable()
        Dim lFila As DataRow = Nothing

        lTblFinal.Columns.Add("Total_KgsOC")
        lTblFinal.Columns.Add("KgsCubicados")
        lTblFinal.Columns.Add("KgsDespachados")
        lTblFinal.Columns.Add("KgsItImpresas")
        lTblFinal.Columns.Add("KgsParaBloqueo")
        lTblFinal.Columns.Add("EstadoRN")


        lFila = lTblFinal.NewRow()

        lSql = String.Concat("Exec SP_CRUD_OC_INGRESADAS 0,'',0,'','',", iIdObra, ",0,'','',6")
        lTblRes = CargaTabla(lSql, "L")
        If lTblRes.Rows.Count > 0 Then
            lFila("KgsCubicados") = Format(Val(lTblRes.Rows(0)("TotalCubicado").ToString), "#,##0")
        Else
            lFila("KgsCubicados") = "0"
        End If

        lSql = String.Concat("Exec SP_CRUD_OC_INGRESADAS 0,'',0,'','',", iIdObra, ",0,'','',4")
        lTblRes = CargaTabla(lSql, "L")
        If lTblRes.Rows.Count > 0 Then
            lFila("Total_KgsOC") = Format(Val(lTblRes.Rows(0)(0).ToString), "#,##0")
        End If

        lSql = String.Concat("Exec SP_CRUD_OC_INGRESADAS 0,'',0,'','',", iIdObra, ",0,'','',8")
        lTblRes = CargaTabla(lSql, "L")
        If lTblRes.Rows.Count > 0 Then
            lFila("KgsDespachados") = Format(Val(lTblRes.Rows(0)("TotalDespachado").ToString), "#,##0")
            lFila("KgsItImpresas") = Format(Val(lTblRes.Rows(0)("TotalET_IMP").ToString), "#,##0")

            lTotalKgs = Val(lTblRes.Rows(0)("TotalDespachado").ToString) + Val(lTblRes.Rows(0)("TotalET_IMP").ToString)
            lTotalOC = Val(lTblRes.Rows(0)(0).ToString)

            lFila("KgsParaBloqueo") = Format(Val(lTotalKgs), "#,##0")

            lPorAvance = Math.Round(Val(lTotalKgs) * 100, 2)

            lSql = String.Concat("Exec SP_CRUD_BloqueosRN 0,", iIdObra, ",0,'',0,'','',9")
            lTblRes = CargaTabla(lSql, "L")
            If lTblRes.Rows.Count > 0 Then
                If (lTblRes.Rows(0)("NroRN_Bloqueo").ToString.Equals("10")) Then
                    lFila("EstadoRN") = String.Concat("Bloqueada Linea de Credito.")
                Else
                    lFila("EstadoRN") = String.Concat("Bloqueada por R.N.")
                End If
                ' Lbl_EstadoRN.BackColor = Drawing.Color.LightSalmon
            Else
                lFila("EstadoRN") = String.Concat("Sin Bloqueo ")
                'Lbl_EstadoRN.BackColor = Drawing.Color.LightGreen
            End If

            lTblFinal.Rows.Add(lFila)
            lFila = lTblFinal.NewRow()
            lFila("Total_KgsOC") = "Porcentajes"
            lPorAvance = Math.Round((Val(lTblFinal.Rows(0)("KgsCubicados").ToString.Replace(".", "").ToString()) / lTotalOC) * 100, 2)
            lFila("KgsCubicados") = String.Concat(lPorAvance.ToString, "%")
            lPorAvance = Math.Round((Val(lTblFinal.Rows(0)("KgsDespachados").ToString.Replace(".", "").ToString()) / lTotalOC) * 100, 2)
            lFila("KgsDespachados") = String.Concat(lPorAvance.ToString, "%")
            lPorAvance = Math.Round((Val(lTblFinal.Rows(0)("KgsItImpresas").ToString.Replace(".", "").ToString()) / lTotalOC) * 100, 2)
            lFila("KgsItImpresas") = String.Concat(lPorAvance.ToString, "%")
            lPorAvance = Math.Round((Val(lTotalKgs) / lTotalOC) * 100, 2)
            lFila("KgsParaBloqueo") = String.Concat(lPorAvance.ToString, "%")
            lTblFinal.Rows.Add(lFila)
        End If


        Return lTblFinal
    End Function

#End Region


#Region "  Listado de  Contratos   "

    Public Function CargaTabla_OC(IdObra As String) As DataTable

        Dim lTblRes As New DataTable, ldal As New Datos, lSql As String = "", i As Integer = 0, lPU As Double = 0
        lSql = String.Concat("  SP_Consultas_FichaObra  4 ,'", IdObra, "','','','','','','','','',''")
        lTblRes = ldal.CargaTabla(lSql, "L")
        For i = 0 To lTblRes.Rows.Count - 1
            lPU = Val(lTblRes.Rows(i)("En $$").ToString) / Val(lTblRes.Rows(i)("Kilos").ToString)
            lTblRes.Rows(i)("Kilos") = Format(Val(lTblRes.Rows(i)("Kilos").ToString), "#,##0")
            lTblRes.Rows(i)("En $$") = Format(Val(lTblRes.Rows(i)("En $$").ToString), "#,##0")
            lTblRes.Rows(i)("Precio Kgs") = Math.Round(lPU, 2)
        Next

        Return lTblRes

    End Function

#End Region

#End Region

#Region " Metodos Publicos que sera usados desde  los Formularios "
    Public Function CargaTabla_DatosObra(IdObra As String) As DataTable



        Dim lTblRes As New DataTable, ldal As New Datos, lSql As String = ""
        lSql = String.Concat("  SP_Consultas_FichaObra  7 ,'", IdObra, "','','','','','','','','',''")
        lTblRes = ldal.CargaTabla(lSql, "L")
        Return lTblRes



    End Function



#End Region

#Region " Metodos Publicos que sera usados desde  los Formularios "
    Public Function CargaTabla_IT(IdObra As String) As DataTable
        Dim lTblRes As New DataTable, ldal As New Datos, lSql As String = ""
        lSql = String.Concat("  SP_Consultas_FichaObra  9 ,'", IdObra, "','','','','','','','','',''")
        lTblRes = ldal.CargaTabla(lSql, "L")
        Return lTblRes
    End Function
#End Region

#Region " Metodos Publicos que sera usados desde  los Formularios "
    Public Function CargaTabla_ITs(IdObra As String) As DataTable
        Dim lTblRes As New DataTable, ldal As New Datos, lSql As String = ""
        lSql = String.Concat("  SP_Consultas_FichaObra  10 ,'", IdObra, "','','','','','','','','',''")
        lTblRes = ldal.CargaTabla(lSql, "L")
        Return lTblRes
    End Function
#End Region

    Public Function ActualizaDatos_COF(iSigla As String, iEstado As String, iCC As String, iCodGuiaInte As String, IdObra As String, iEmpresa As String, iNombre As String, iTipoFac As String, iTipoGD As String, iCondicionPago As String) As String
        Dim lTblRes As New DataTable, ldal As New Datos, lSql As String = "", lRes As String = ""
        lSql = String.Concat("    update Obras set SiglaObra='", iSigla, "' , EstadoAlta ='", iEstado, "', CentroCosto='", iCC, "' ,")
        lSql = String.Concat(lSql, " CodigoGuia_INET = '", iTipoGD, "' , Empresa='", iEmpresa, "', Cliente='", iNombre.TrimEnd, "' , ")
        lSql = String.Concat(lSql, "  TipoFacturacion='", iTipoFac, "' ,CodigoFacturar='", iCodGuiaInte, "'    where id =", IdObra, "   Select @@ROWCOUNT    ")
        lTblRes = ldal.CargaTabla(lSql, "L")
        If Val(lTblRes.Rows(0)(0).ToString) > 0 Then
            lSql = String.Concat("SP_Consultas_FichaObra  19 ,'", IdObra, "','", iCondicionPago, "','','','','','','','',''")
            lTblRes = ldal.CargaTabla(lSql, "L")
            If Val(lTblRes.Rows(0)(0).ToString) > 0 Then
                lRes = "OK"
            End If
        Else
            lRes = "ER"
        End If
        Return lRes
    End Function

    Public Function ExisteSiglaObra(iSigla As String, iIdObra As String) As String
        Dim lTblRes As New DataTable, ldal As New Datos, lSql As String = "", Res As String = ""
        lSql = String.Concat("  Select  count(1) ,nombre   from Obras where SiglaObra ='", iSigla, "' and id <> ", iIdObra, "  group by nombre  ")
        lTblRes = ldal.CargaTabla(lSql, "L")
        If lTblRes.Rows.Count > 0 Then
            If Val(lTblRes.Rows(0)(0).ToString) > 0 Then
                Res = String.Concat(" La sigla Ingresada (", iSigla, ") ya ha sido utilizada en la Obra ", lTblRes.Rows(0)("Nombre").ToString)
            End If
        End If
        Return Res
    End Function

    Public Function CargaTablaParametros() As DataTable
        Dim ldal As New Datos, lSql As String = "", lTblDatos As New Data.DataTable
        'Cargamos datos de parametros
        lSql = String.Concat("select SubTabla ,Par1, Id from to_parametros where SubTabla in ( 'TipoGuiaDespacho','CodParaFacturar' ")
        lSql = String.Concat(lSql, ",'EmpresaFacturar','EstadoObra','TipoFacturacionCOF','CondicionPagoCOF')  ")



        lTblDatos = ldal.CargaTabla(lSql, "L")



        Return lTblDatos
    End Function

    Public Function ActualizaDatos_General(iDireccion As String, iComuna As String, iCiudad As String, IdObra As String)
        Dim lTblRes As New DataTable, ldal As New Datos, lSql As String = "", lRes As String = ""
        lSql = String.Concat("    update Obras set Dir='", iDireccion, "' , Comuna ='", iComuna, "', Ciudad='", iCiudad, "'")
        lSql = String.Concat(lSql, " where id =", IdObra, "   Select @@ROWCOUNT    ")
        lTblRes = ldal.CargaTabla(lSql, "L")
        If Val(lTblRes.Rows(0)(0).ToString) > 0 Then
            lRes = "OK"
        Else
            lRes = "ER"
        End If
        Return lRes
    End Function

    Public Function CargaTabla_Sucursal(IdObra As String) As DataTable
        Dim lTblRes As New DataTable, ldal As New Datos, lSql As String = ""
        lSql = String.Concat("SP_Consultas_FichaObra  15 ,'", IdObra, "','','','','','','','','',''")
        lTblRes = ldal.CargaTabla(lSql, "L")
        Return lTblRes
    End Function

    Public Function IngresaOBSCamionLogistica(iTipoCamion As String, iObsCamion As String, iTipoRecepcion As String, iHora1 As String, iHora2 As String, iUsuario As String, IdObra As String, iEstado As String)
        Dim lTblRes As New DataTable, ldal As New Datos, lSql As String = "", lRes As String = ""
        If iTipoRecepcion = "Rango" Then
            lSql = String.Concat("  SP_Consultas_FichaObra  20 ,'", iTipoCamion, "','", iObsCamion, "','", iTipoRecepcion, "','", iHora1, "','", iHora2, "','", iUsuario, "','", iEstado, "',", IdObra, ",'',''")
        Else
            lSql = String.Concat("  SP_Consultas_FichaObra  20 ,'", iTipoCamion, "','", iObsCamion, "','", iTipoRecepcion, "','", iHora1, "','N/A','", iUsuario, "','", iEstado, "',", IdObra, ",'',''")
        End If
        lTblRes = ldal.CargaTabla(lSql, "L")
        If Val(lTblRes.Rows(0)(0).ToString) > 0 Then
            lRes = "OK"
        Else
            lRes = "ER"
        End If
        Return lRes
    End Function

    Public Function ObtenerSqlExportaPaquetesExcel(ByVal iIdObra As Integer) As DataTable
        Dim lsql As String = "", ltbl As New DataTable, ldal As New Datos




        lsql = String.Concat("  exec SP_Consultas_WS 47,'", iIdObra, "','','','','','',''")
        ltbl = ldal.CargaTabla(lsql, "L")


        Return ltbl
    End Function

    Public Function ExisteProductoEnINET(ByVal iCodProducto As String, iEmpresa As String) As Boolean
        Dim lsql As String = "", lTbl As DataTable, lRes As Boolean = False, ldal As New Datos
        Select Case iEmpresa
            Case "TO"
                lsql = String.Concat("  Select 1 from Tocaranza.dbo.PRODVENT (nolock)  Where BarCod  ='", iCodProducto, "'")
            Case "TOSOL"
                lsql = String.Concat("  Select 1 from TSOLDABLES.dbo.PRODVENT (nolock)  Where BarCod  ='", iCodProducto, "'")
            Case "TOMAE"
                lsql = String.Concat("  Select 1 from TOMAE.dbo.PRODVENT (nolock)  Where BarCod  ='", iCodProducto, "'")
        End Select
        ' lsql = String.Concat("  Select 1 from PRODVENT (nolock)  Where BarCod  ='", iCodProducto, "'")
        lTbl = ldal.CargaTabla(lsql, "L")
        If lTbl.Rows.Count > 0 Then
            lRes = True
        End If
        Return lRes

    End Function

    Public Function PermisoModulos(idUsuario As Integer, idModulo As Integer) As Boolean
        Dim ldal As New Datos(), lTbl As New DataTable, lSql As String
        lSql = String.Concat("  SP_Consultas_FichaObra  12 ,", idUsuario, ",", idModulo, ",'','','','','','','',''")
        lTbl = ldal.CargaTabla(lSql, "L")
        If (lTbl.Rows.Count > 0) Then
            Return True
        Else
            Return False
        End If
    End Function
End Class
