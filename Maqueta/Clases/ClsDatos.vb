Imports Microsoft.VisualBasic
Imports System.Configuration.ConfigurationManager
Imports System.Data.SqlClient
Imports System.Data
Imports System
Imports System.Collections.Generic
Imports System.Collections

Public Class ClsDatos
    'Private lCnnStr As String = "Data Source=62.149.153.14;Initial Catalog=MSSql26898;Integrated Security=False;User ID=MSSql26898;Password=59f78752;Connect Timeout=0;Encrypt=False;Packet Size=4096"
    'Private lCnnStr As String = "Data Source=localhost\SQLExpress;Initial Catalog=CubiCad;User id=CnnCubicad;Password=t.o2011;"
    'Private lCnnStr As String = "Data Source=200.63.96.140;Initial Catalog=DbCubigest;Integrated Security=False;User ID=Usr.T0;Password=t0rr3s.ss1ng3st;Connect Timeout=0;Encrypt=False;Packet Size=4096"
    Public Function ObtenerCnn() As String
        'Return New BussinesObjects.Clases.Cls_Datos().ObtenerCnnStr
        Dim lCnn As String = AppSettings.Get("Cnn").ToString

        Return lCnn

    End Function


    Public Function ObtenerAjusteObra(iRutClte As String) As String
        Dim lSql As String = "", lDal As New ClsDatos(), lTblRes As New DataTable, lRes As String = "0"
        'Por nueva funcionalidad de Ajustes Obra 	0002769: Sistema Linea de Credito
        lSql = String.Concat(" select  isnull(sum(ImporteAjuste),0)   from AjusteObras a, Obras o   where idObra=o.id and rutcliente like '%")
        lSql = String.Concat(lSql, iRutClte, "%'")
        lTblRes = lDal.CargaTabla(lSql)

        If lTblRes.Rows.Count > 0 Then
            lRes = lTblRes.Rows(0)(0).ToString()
            If lRes = "" Then
                lRes = 0
            End If
        End If

        Return lRes

    End Function
    Public Function ObtenerAjusteObra_PorIdObra(idobra As String) As String
        Dim lSql As String = "", lDal As New ClsDatos(), lTblRes As New DataTable, lRes As String = "0"
        'Por nueva funcionalidad de Ajustes Obra 	0002769: Sistema Linea de Credito
        lSql = String.Concat(" select  isnull(sum(ImporteAjuste),0)   from AjusteObras a, Obras o   where idObra=o.id ")
        lSql = String.Concat(lSql, "and O.id ='", idobra, "'")
        lTblRes = lDal.CargaTabla(lSql)

        If lTblRes.Rows.Count > 0 Then
            lRes = lTblRes.Rows(0)(0).ToString()
            If lRes = "" Then
                lRes = 0
            End If
        End If

        Return lRes

    End Function

    Public Function ObtenerCnnINET() As String
        'Return New BussinesObjects.Clases.Cls_Datos().ObtenerCnnStr
        Dim lStr As String = ""
        Dim lServer As String = AppSettings.Get("Ip_Server").ToString

        lStr = String.Concat("Data Source=", lServer, ";Initial Catalog=TORRESOCARANZA;Integrated Security=False;User ID=informat;Password=centauro;Connect Timeout=0;Encrypt=False;Packet Size=4096")

        Return lStr

    End Function

    Public Function ObtenerCnnINET(ByVal iBD As String) As String
        'Return New BussinesObjects.Clases.Cls_Datos().ObtenerCnnStr
        Dim lStr As String = ""
        Dim lServer As String = AppSettings.Get("Ip_Server").ToString

        lStr = String.Concat("Data Source=", lServer, ";Initial Catalog=", iBD, ";Integrated Security=False;User ID=informat;Password=centauro;Connect Timeout=0;Encrypt=False;Packet Size=4096")

        Return lStr

    End Function
    Public Function ObtenerUrl_Inicio() As String
        'Return New BussinesObjects.Clases.Cls_Datos().ObtenerCnnStr
        Dim lUrl As String = AppSettings.Get("URL_Inicio").ToString
        lUrl = "~/login.aspx"
        Return lUrl

    End Function

    Public Function ObtenerDatos(ByVal ipar1 As String) As DataSet
        Dim lTbl As New DataSet, lDal As New ClsDatos
        Try
            lTbl.Tables.Add(lDal.CargaTabla(ipar1))
        Catch ex As Exception
            'lTbl.Error = ex.Message.ToString
        End Try
        Return lTbl
    End Function


    Public Function ObtenerAccesosRRHHPorId(ByVal iIdUser As String) As DataTable
        Dim lSql As String = "", lTabla As New DataTable
        lSql = String.Concat("SP_Consultas_RRHH 21,'','", iIdUser, "','','',''")
        lTabla = CargaTabla(lSql)

        Return lTabla

    End Function

    Public Function ObtenerDatosFacturacionPorCamion(ByVal CodigoViaje As String, ByVal IdRespINET As Integer, ByVal iBd As String) As DataSet
        Dim lDal As New ClsDatos, lSql As String = "", lData As New DataSet, lTabla As New DataTable
        Dim lDespachos As String = "", lPatente As String = "", i As Integer = 0

        lSql = "   select patente from viaje where codigo='" & CodigoViaje & "'"
        lTabla = lDal.CargaTabla(lSql)
        If lTabla.Rows.Count > 0 Then
            lPatente = lTabla.Rows(0)(0).ToString
            lSql = "   select IdDespachoCamion from viaje where patente='" & lPatente & "' and  IdRespuestaINET=" & IdRespINET
            lTabla = lDal.CargaTabla(lSql)
            For i = 0 To lTabla.Rows.Count - 1
                lDespachos = String.Concat(lDespachos, lTabla.Rows(i)(0).ToString, ",")
            Next
            If lDespachos.Length > 3 Then
                lDespachos = lDespachos.Substring(0, lDespachos.Length - 1)
            End If


            lSql = "   select Codigo, isnull(round(SUM (d.KgsPaquete),0),0)  KilosCargados  "
            lSql = String.Concat(lSql, " from DESPACHO_CAMION  , PIEZA_PRODUCCION pp,DetallePaquetesPieza d, Piezas p, Viaje v ")
            lSql = String.Concat(lSql, " where DES_CAM_ID  in (", lDespachos, ")   and PIE_DESPACHO_CAMION =DES_CAM_ID ")
            lSql = String.Concat(lSql, " and pp.PIE_ESTADO ='O60' and d.Id=pp.PIE_ETIQUETA_PIEZA ")
            lSql = String.Concat(lSql, " and p.Id =d.IdPieza and p.Estado <>'00'  and v.Id=d.idviaje  ")
            lSql = String.Concat(lSql, " group by Codigo")

            lTabla = lDal.CargaTabla(lSql)
            lTabla.TableName = "Detalle"

            lData.Merge(lTabla)


            '// Obtenemos la guia de INET a partir de un despacho
            Dim lGuiaINET As String = "", lPartes() As String = Nothing, lPx As New ClsB_O
            lPartes = lDespachos.Split(",")
            lGuiaINET = Val(lPx.ObtenerNroDesdeINET_PorIdDespacho(CodigoViaje, iBd))


            lSql = "   select convert(varchar(10),MAX(des_cam_fecha),103) FechaDespacho, MAX(des_cam_camion) Patente , " & lGuiaINET & " as GuiaINET "
            lSql = String.Concat(lSql, " from DESPACHO_CAMION  , PIEZA_PRODUCCION pp,DetallePaquetesPieza d, Piezas p, Viaje v ")
            lSql = String.Concat(lSql, " where DES_CAM_ID  in (", lDespachos, ")   and PIE_DESPACHO_CAMION =DES_CAM_ID ")
            lSql = String.Concat(lSql, " and pp.PIE_ESTADO ='O60' and d.Id=pp.PIE_ETIQUETA_PIEZA ")
            lSql = String.Concat(lSql, " and p.Id =d.IdPieza and p.Estado <>'00'  and v.Id=d.idviaje  ")
            lTabla = New DataTable()
            lTabla = lDal.CargaTabla(lSql)
            lTabla.TableName = "Cabecera"

            lData.Merge(lTabla)
        End If
        Return lData

    End Function
    Public Function ObtenerParametro(ByVal ipar1 As String) As ListaDataSet
        Dim lTbl As New DataSet, lDal As New ClsDatos, lRes As New ListaDataSet
        Dim lQuery As String = ""
        Try
            lQuery = " select * from to_parametros where  subtabla='" & ipar1 & "' order by  par1"
            lTbl.Tables.Add(lDal.CargaTabla(lQuery))
        Catch ex As Exception
            lRes.MensajeError = ex.Message.ToString

        End Try
        lRes.DataSet = lTbl

        Return lRes
    End Function
    Public Function ObtenerParametros(ByVal ipar1 As String, ipar2 As String) As DataSet
        Dim lTbl As New DataSet, lDal As New ClsDatos
        Dim lSql As String = ""
        Try
            lSql = String.Concat(" select * from to_parametros where  subtabla='", ipar1, "'")
            lSql = String.Concat(lSql, " and par2='", ipar2, "'")

            'order by  par1"
            lTbl.Tables.Add(lDal.CargaTabla(lSql))
        Catch ex As Exception
            Dim lErrror As String = "ClsDatos.ObtenerParametro. " & ex.Message.ToString & "SQL:  " & lSql
            RegistraError(lErrror)
        End Try
        Return lTbl
    End Function

    Public Function ObtenerParametros(ByVal ipar1 As String) As DataSet
        Dim lTbl As New DataSet, lDal As New ClsDatos
        Dim lQuery As String = ""
        Try
            lQuery = " select * from to_parametros where  subtabla='" & ipar1 & "' order by  par1"
            lTbl.Tables.Add(lDal.CargaTabla(lQuery))
        Catch ex As Exception
            Dim lErrror As String = "ClsDatos.ObtenerParametro. " & ex.Message.ToString & "SQL: " & lQuery
            RegistraError(lErrror)
        End Try
        Return lTbl
    End Function
    'IdObra - IdPiezaTipoB - PesoAsignado  - NroAsignadas
    Public Function CalcularNroPaquetes(ByVal iMov As TipoMov, ByVal iLargo As Integer, ByVal iDiam As Integer) As TipoMov
        Dim lTraza As String = "INICIO"
        Dim lRes As String = "", lPartes() As String = Nothing, lVista As DataView = Nothing
        Dim lObra As String = iMov.IdObra, lIdForma As String = ""
        Dim lKgs As New Cls_DatosInformes, lSql As String = "", lTbl As DataTable, lAsigTmp As String = ""
        Dim lLargo As String = "", lDiam As String = 0, lPesoUnaPieza As Integer = 0, mTipoObra As String = ""
        Try

            If IsNumeric(iMov.Asignadas) = False Then
                If IsNumeric(iMov.PesoAsignado) Then
                    lSql = "Select Idforma  from  piezasTipoB p, hojadespiece hd  where "
                    lSql = lSql & " p.id_hd = hd.id And idObra = " & iMov.IdObra & " And p.Id = " & iMov.idPiezaTipoB
                    lTbl = New ClsDatos().CargaTabla(lSql)
                    If Not lTbl Is Nothing AndAlso lTbl.Rows.Count > 0 Then
                        lIdForma = lTbl.Rows(0)("Idforma")
                    End If
                    lLargo = iLargo
                    lDiam = lDiam
                    mTipoObra = lKgs.ObtenerTipoObraPorIdObra(iMov.IdObra)
                    '26/08/2012
                    'Como siempre se calcula segun peso bechtell se deja hasta que se verifique por T.O
                    lPesoUnaPieza = lKgs.CalcularPesoBetchell_PorObra(lLargo, lDiam, 1, iMov.IdObra, lIdForma) 'lSaldoPiezas * lKilosxPieza
                    lAsigTmp = iMov.PesoAsignado / lPesoUnaPieza

                    If lAsigTmp.IndexOf(",") > 0 Then lPartes = lAsigTmp.Split(",")
                    If lAsigTmp.IndexOf(".") > 0 Then lPartes = lAsigTmp.Split(".")

                    If lPartes.Length = 2 Then
                        'Tx_Asigmadas.Text = lPartes(0)
                        iMov.Asignadas = lPartes(0)
                    End If
                Else
                    iMov.Errores = "Para poder realizar el cálculo debe ingresar el campo Asignadas o Peso Asignadas"
                End If
            End If
            If IsNumeric(iMov.Asignadas) = True Then
                lRes = New ClsDatos().ObtenerDatosViaje(iMov.PiezasTotales, iMov.KilosTotales, iMov.Asignadas, iMov.Marca, iMov.Plano, iMov.IdObra, Val(iMov.Factor), Val(iMov.idPiezaTipoB))
                lTraza = lTraza & "Depues de ObtenerDatos valor: " & lRes
                lPartes = lRes.Split("|")
                Dim lpartes2() As String
                If lPartes.Length > 0 Then
                    If iMov.Factor.ToString.Trim.Length = 0 Then
                        lpartes2 = lPartes(7).Split("(")
                        If lpartes2.Length > 0 Then
                            iMov.Factor = lpartes2(0)
                        End If
                    End If
                    lTraza = lTraza & "Al inicio de la vista " & lRes
                    iMov.PesoAsignado = Math.Round(Val(lPartes(1).ToString), 0)
                    iMov.Saldo = lPartes(2).ToString
                    iMov.PesoSaldo = Math.Round(Val(lPartes(3).ToString), 0)
                    iMov.NroPaquetes = lPartes(4).ToString
                    If Val(iMov.NroPaquetes) = 1 Then
                        iMov.PiezasXPaquete = String.Concat("0/", lPartes(6).ToString)
                    Else
                        iMov.PiezasXPaquete = String.Concat(lPartes(5).ToString, "/", Val(lPartes(7).ToString))
                    End If
                    iMov.Factor = lPartes(8).ToString
                End If
            End If
        Catch ex As Exception
            lTraza = lTraza & " Errr: " & ex.Message
            iMov.Errores = lTraza
            Dim lErrror As String = "ClsDatos.CalcularNroPaquetes. " & lTraza
            RegistraError(lErrror)
        End Try
        Return iMov
    End Function
    'Public Function PersisteMovimiento(ByVal imov As TipoMov) As TipoMov
    '    Dim lMov As New TipoMov, lRes As String = "", lDal As New ClsDatos, lTmp As Integer = 0, lPartes() As String = Nothing
    '    Dim lUsuarioModifico As Boolean = False, lVarTmp As String = "", lMsg As String = ""
    '    lPartes = imov.PiezasXPaquete.ToString.Split("/")  'Tx_PiezasPaq.Text.Split("/")
    '    If lPartes.Length = 2 Then
    '        If Val(imov.NroPaquetes) > 1 Then 'If Val(Tx_NroPaquetes.Text) > 1 Then
    '            lTmp = (Val(imov.NroPaquetes) - 1) * lPartes(0)
    '            lTmp = lTmp + lPartes(1)
    '        Else
    '            lTmp = (Val(imov.NroPaquetes)) * lPartes(1)
    '        End If
    '        If lTmp <> Val(imov.Asignadas) Then 'If lTmp <> Val(Tx_Asigmadas.Text) Then
    '            lMsg = " Error: Las Piezas asignadas (" & imov.Asignadas & ") no corresponden con los calculada por paquetes (" & lTmp.ToString & "), REVISAR"
    '            ' Lbl_Msg.Visible = True
    '        Else
    '            'lMov.IdObra = Cmb_Obras.SelectedValue
    '            'lMov.KilosTotales = Tx_kilosTotales.Text
    '            'lMov.Marca = Tx_Marca.Text
    '            'lMov.NroPaquetes = Tx_NroPaquetes.Text
    '            'lMov.PesoAsignado = Tx_PesoAsignado.Text
    '            'lMov.PesoSaldo = Tx_PasoSaldo.Text
    '            'lMov.PiezasTotales = Tx_PiezasTotales.Text
    '            'lMov.PiezasXPaquete = Tx_PiezasPaq.Text
    '            'lMov.Plano = Cmb_Plano.SelectedValue.ToString
    '            'If lMov.Plano.ToUpper.Equals("SELECCIONAR") Then
    '            '    lMov.Plano = ObtenerPlano(Val(Tx_IdPiezaTipoB.Text))
    '            'End If
    '            'lMov.Asignadas = Val(Tx_Asigmadas.Text)
    '            'lMov.Usuario = lIdUser
    '            'lMov.idPiezaTipoB = Val(Tx_IdPiezaTipoB.Text)
    '            lVarTmp = lMov.NroPaquetes & "-" & lMov.PiezasXPaquete     ' lVarTmp = Tx_NroPaquetes.Text & "-" & Tx_PiezasPaq.Text
    '            'Lo marcamos como digitado
    '            imov.Tipo = "D"

    '            'If lVarTmp <> mPiezasCalculadas Then  ''El Usuario modifico
    '            '    lUsuarioModifico = True
    '            '    lMov.Tipo = "D"
    '            'Else
    '            '    lUsuarioModifico = False
    '            '    lMov.Tipo = "C"
    '            'End If
    '            'mPiezasCalculadas = Tx_NroPaquetes.Text & "-" & Tx_PiezasPaq.Text
    '            'debemos validar que no exista otro movimientos para la marca que este sin viaje
    '            If lDal.ExisteMov_SinViaje(lMov) = False Then
    '                lRes = lDal.InsertaMov(lMov)
    '                If Val(lRes) > 0 Then
    '                    lRes = lDal.InsertaPiezaDesdeBechtell(lMov.Marca, Cmb_Plano.SelectedValue, Cmb_Obras.SelectedValue, lMov.Asignadas, lMov.PesoAsignado, lRes, lIdUser, Val(Tx_IdPiezaTipoB.Text))
    '                    If Val(lRes) > 0 Then
    '                        'Lbl_Msg.Text = "Datos grabados correctamente "
    '                        'Lbl_Msg.Visible = True
    '                        'If mBuscar = True Then
    '                        '    Limpiar()
    '                        '    Btn_Buscar_Click(Nothing, Nothing)
    '                        'End If
    '                    Else
    '                        Lbl_Msg.Text = "Error al grabar los Datos, por favor repita el proceso ."
    '                        Lbl_Msg.Visible = True
    '                    End If
    '                End If
    '            Else
    '                Lbl_Msg.Text = " La Marca " & lMov.Marca & " Tiene creada una PreIT sin viaje asociado, Revisar "
    '                Lbl_Msg.Visible = True
    '            End If
    '            Lbl_Factor.Visible = False
    '        End If
    '    Else
    '        Lbl_Msg.Text = " El campo Piezas x paquete tiene un error,  revisar "
    '        Lbl_Msg.Visible = True
    '    End If

    'End Function

    Private Function ObtenerDatosPorCodigo(iSucursal As String, iCod As String) As String
        Dim lsql As String = "", lDal As New ClsDatos, lTbl As New DataTable, i As Integer = 0
        Dim lTotalKgs As Long = 0, lsaldo As Long = 0, lsaldoINET As Long = 0, lTemp As String = ""
        lsql = String.Concat("  SP_ConsultasGenerales  157,'", iSucursal, "','", iCod, "','','',''")
        lTbl = lDal.CargaTabla(lsql)

        For i = 0 To lTbl.Rows.Count - 1
            lTotalKgs = lTotalKgs + Long.Parse(lTbl.Rows(i)("TotalKgs").ToString())
            lsaldo = lsaldo + Long.Parse(lTbl.Rows(i)("Saldo").ToString())
            If (lTbl.Rows(i)("SaldoINET").ToString() <> "") Then
                lsaldoINET = Long.Parse(lTbl.Rows(i)("SaldoINET").ToString())
            End If

        Next

        lTemp = String.Concat(lTotalKgs, "|", lsaldo, "|", lsaldoINET)

        Return lTemp.ToString()
    End Function
    Public Function ObtenerStockPorSucursal(iSucursal As String) As DataTable
        Dim lsql As String = "", lTbl As New DataTable, lSucursal As String = ""
        Dim lTblFinal As New DataTable, i As Integer = 0, lcont As Integer = 0, lFila As DataRow = Nothing
        Dim lStr As String = "", lPartes() As String = Nothing


        lsql = String.Concat("  SP_ConsultasGenerales  156,'", iSucursal, "',' ','','',''")
        lTbl = CargaTabla(lsql)
        lTblFinal = lTbl.Copy()
        lTblFinal.Clear()
        For i = 0 To lTbl.Rows.Count - 1
            lFila = lTblFinal.NewRow()
            lFila("Codigo") = lTbl.Rows(i)("Codigo").ToString()
            lFila("Sucursal") = lTbl.Rows(i)("Sucursal").ToString()
            lFila("Descripcion") = lTbl.Rows(i)("Descripcion").ToString()
            lStr = ObtenerDatosPorCodigo(iSucursal, lTbl.Rows(i)("Codigo").ToString())
            lPartes = lStr.Split("|")
            If lPartes.Length > 2 Then
                lFila("TotalKgs") = lPartes(0).ToString()
                lFila("KgsProducidos") = lPartes(1).ToString()
                lFila("Saldo") = Long.Parse(lFila("TotalKgs")) - Long.Parse(lFila("KgsProducidos"))
                lFila("SaldoINET") = lPartes(2).ToString()
            End If
            lTblFinal.Rows.Add(lFila)
        Next

        Return lTblFinal

    End Function


    Friend Function EliminaColadas(ByVal iIdColada As String) As String
        Dim lSql As String = "", lres As String = "", lTbl As New DataTable

        'a medida qua avance la fase 2 de cubigest hay que validar antes de eliminar que la colada no este
        'utilizada, de momento 

        lSql = " delete from colada where Id=" & iIdColada & ""
        lres = Val(EjecutaDML(lSql))

        Return lres
    End Function
    Public Function ObtenerTblDetallePreIt(ByVal iPlano As String, ByVal iIdObra As String, ByVal iMarca As String, ByVal iIdPezaTipoB As String) As DataTable
        Dim lSql As String = "", lDal As New ClsDatos, i As Integer = 0, lTbl As New DataTable
        Dim lLista As New List(Of TipoMov), lMov As TipoMov = Nothing
        lSql = "Select 	m.Id IdMov, IdObra,	Plano,Marca,PiezasTotales,Asignadas,PesoAsignado, PiezasTotales-Asignadas Saldo,PesoSaldo,NroPaquetes,"
        lSql = lSql & " PiezasXPaquete,	KilosTotales,Fecha,CodViaje  from  movimientos m where IdObra=" & iIdObra
        lSql = lSql & "   and Marca='" & iMarca & "' and estado<>'00' and IdPiezaTipoB=" & iIdPezaTipoB
        Return lDal.CargaTabla(lSql)
    End Function
    Public Function ObtenerTblDetallePreIt(ByVal iIdPezaTipoB As String) As DataTable
        Dim lSql As String = "", lDal As New ClsDatos, i As Integer = 0, lTbl As New DataTable
        Dim lLista As New List(Of TipoMov), lMov As TipoMov = Nothing
        lSql = "Select 	m.Id IdMov, IdObra,	Plano,Marca,PiezasTotales,Asignadas,PesoAsignado, PiezasTotales-Asignadas Saldo,PesoSaldo,NroPaquetes,"
        lSql = lSql & " PiezasXPaquete,	KilosTotales,Fecha,CodViaje  from  movimientos m where "
        lSql = lSql & "   IdPiezaTipoB=" & iIdPezaTipoB
        Return lDal.CargaTabla(lSql)
    End Function
    Public Function Obtener_ListObjPreIt(ByVal iPlano As String, ByVal iIdObra As String, ByVal iMarca As String, ByVal iIdPezaTipoB As String) As List(Of TipoMov)
        Dim lSql As String = "", lDal As New ClsDatos, i As Integer = 0, lTbl As New DataTable
        Dim lLista As New List(Of TipoMov), lMov As TipoMov = Nothing
        'lSql = "Select * from Piezas p, movimientos m where m.plano='" & iPlano & "' and IdObra=" & iIdObra
        'lSql = lSql & " and p.marca='" & iMarca & "' AND p.marca=m.marca "
        lSql = "Select 	m.Id IdMov, IdObra,	Plano,Marca,PiezasTotales,Asignadas,PesoAsignado, PiezasTotales-Asignadas Saldo,PesoSaldo,NroPaquetes,"
        lSql = lSql & " PiezasXPaquete,	KilosTotales,Fecha,CodViaje,  "
        lSql = lSql & " (Select Id from Piezas p where IdMov=m.Id and p.estado<>'00')  IdPieza"
        lSql = lSql & "    from  movimientos m where IdObra=" & iIdObra
        lSql = lSql & "   and Marca='" & iMarca & "' and estado<>'00' and IdPiezaTipoB=" & iIdPezaTipoB
        lTbl = lDal.CargaTabla(lSql)
        For i = 0 To lTbl.Rows.Count - 1
            lMov = New TipoMov
            lMov.Asignadas = lTbl.Rows(i)("Asignadas")
            lMov.id = lTbl.Rows(i)("IdMov")
            lMov.IdObra = lTbl.Rows(i)("IdObra")
            lMov.idPiezaTipoB = iIdPezaTipoB
            'lPieza.PathImg = "~/imagen.aspx?IdImg=" & lPieza.IdPieza
            lMov.Imagen = "~/imagen.aspx?IdImg=" & iIdPezaTipoB 'lTbl.Rows(i)("IdPieza")
            lMov.KilosTotales = lTbl.Rows(i)("KilosTotales")
            lMov.Marca = lTbl.Rows(i)("Marca")
            lMov.NroPaquetes = lTbl.Rows(i)("NroPaquetes")
            lMov.PesoAsignado = lTbl.Rows(i)("PesoAsignado")
            lMov.PesoSaldo = lTbl.Rows(i)("PesoSaldo")
            lMov.PiezasTotales = lTbl.Rows(i)("PiezasTotales")
            lMov.PiezasXPaquete = lTbl.Rows(i)("PiezasXPaquete")
            lMov.Plano = lTbl.Rows(i)("Plano")

            lMov.Saldo = lTbl.Rows(i)("saldo")
            lMov.Fecha = lTbl.Rows(i)("Fecha")
            lMov.CodViaje = lTbl.Rows(i)("CodViaje").ToString
            lLista.Add(lMov)
        Next
        Return lLista
    End Function


    Public Function ObtenerPermisosUsuario(ByVal IdUser As String) As DataTable
        Dim lSql As String = "", lTbl As New DataTable
        lSql = "  select * from accesos_usuarios AU, Modulos m where IdUsuario=" & IdUser & " and m.tipo='W'"
        lSql = lSql & "  and AU.IdModulo= m.Id  "
        lTbl = CargaTabla(lSql)

        Return lTbl
    End Function


    Public Function ObtenerHojaDespiecePorIdP(ByVal iIdP As String) As BussinesObjects.Tipos.Tipo_Hd
        Dim lHd As New BussinesObjects.Tipos.Tipo_Hd
        Dim lSql As String = "", lTbl As New DataTable
        Try
            lSql = "  select hd.* from HojaDespiece Hd, PiezasTipoB p where Id_hd=Hd.id "
            lSql = lSql & " and  p.Id=" & iIdP
            lTbl = CargaTabla(lSql)
            If lTbl.Rows.Count > 0 Then
                lHd.EstadoOp = lTbl.Rows(0)("EstadoOp")
                lHd.Figura = lTbl.Rows(0)("Figura")
                lHd.Id = lTbl.Rows(0)("Id")
                lHd.IdObra = lTbl.Rows(0)("IdObra")
                lHd.Obra = lTbl.Rows(0)("Obra")
                lHd.OC = lTbl.Rows(0)("Oc")
                lHd.Plano = lTbl.Rows(0)("plano")
                lHd.Sector = lTbl.Rows(0)("Sector")
                lHd.Ubicacion = lTbl.Rows(0)("Ubicacion")
            End If
        Catch ex As Exception
            lHd.Error = ex.Message.ToString
            Dim lErrror As String = "ClsDatos.ObtenerHojaDespiecePorIdP. " & ex.Message.ToString
            RegistraError(lErrror)
        End Try
        Return lHd
    End Function
    Public Function ExistePieza(ByVal IdPieza As String, ByVal iIdHD As String, ByVal iIdObra As String) As Boolean
        Dim lRes As Boolean = False
        Dim lSql As String = "", lTbl As New DataTable
        Try
            lSql = "  select 1 from piezasTipoB p, HojaDespiece hd where p.id=" & IdPieza & " and Id_Hd=hd.Id "
            lSql = lSql & "  and IdObra=" & iIdObra & "  and Id_Hd=" & iIdHD
            lTbl = CargaTabla(lSql)
            If lTbl.Rows.Count > 0 Then
                lRes = True
            End If
        Catch ex As Exception
            Dim lErrror As String = "ClsDatos.ExistePieza. " & ex.Message.ToString
            RegistraError(lErrror)
        End Try
        Return lRes
    End Function
    Public Function ObtenerHojaDespiecePorId(ByVal iIdHD As String) As BussinesObjects.Tipos.Tipo_Hd
        Dim lHd As New BussinesObjects.Tipos.Tipo_Hd
        Dim lSql As String = "", lTbl As New DataTable
        Try
            lSql = "  select * from HojaDespiece where id=" & iIdHD
            lTbl = CargaTabla(lSql)
            If lTbl.Rows.Count > 0 Then
                lHd.EstadoOp = lTbl.Rows(0)("EstadoOp")
                lHd.Figura = Replace(lTbl.Rows(0)("Figura"), "'", "''")
                lHd.Id = lTbl.Rows(0)("Id")
                lHd.IdObra = lTbl.Rows(0)("IdObra")
                lHd.Obra = lTbl.Rows(0)("Obra")
                lHd.OC = lTbl.Rows(0)("Oc")
                lHd.Plano = Replace(lTbl.Rows(0)("plano"), "'", "''")
                lHd.Sector = Replace(lTbl.Rows(0)("Sector"), "'", "''")
                lHd.Ubicacion = Replace(lTbl.Rows(0)("Ubicacion"), "'", "''")
            End If
        Catch ex As Exception
            lHd.Error = ex.Message.ToString
            Dim lErrror As String = "ClsDatos.ObtenerHojaDespiecePorId. " & ex.Message.ToString
            RegistraError(lErrror)
        End Try
        Return lHd
    End Function


    Friend Function ObtenerColadas() As DataSet
        Dim lSql As String = "", lRes As New DataSet, lTbl As New DataTable
        lSql = "Select * from colada "
        lRes.Tables.Add(CargaTabla(lSql))

        Return lRes
    End Function
    Friend Function KilosEntregadosPorItem_Oc(ByVal iItem_Oc As String, ByVal iCodViaje As String) As Integer
        Dim lSql As String = "", lRes As Integer = 0
        Dim lTbl2 As New DataTable

        lSql = "  exec SP_Consultas_ActaEntrega 9,'" & iItem_Oc & "','" & iCodViaje & "','','','','',''"
        lTbl2 = CargaTabla(lSql)
        If lTbl2.Rows.Count > 0 Then
            lRes = Val(lTbl2.Rows(0)(0).ToString)
        End If
        Return lRes
    End Function
    Friend Function Obtener_OC_Ingresadas(ByVal iCodViaje As String) As DataSet
        Dim lSql As String = "", lRes As New DataSet, lTbl As New DataTable
        Dim i As Integer = 0


        lSql = "Select Id,Item_Oc, KilosActa,KilosOC, KilosEntregados, PesoAsignado, Saldo_OC,Diametro, "
        lSql = lSql & "  CodViaje,  IdObra,  NroColada, (select descripcion from oc o where o.rel_item=Item_Oc) descripcion "
        lSql = lSql & " from   entregas_oc where CodViaje='" & iCodViaje & "'"

        lSql = "  exec SP_Consultas_ActaEntrega 8,'" & iCodViaje & "','','','','','',''"
        lTbl = CargaTabla(lSql)
        'lRes.Tables.Add(CargaTabla(lSql))
        For i = 0 To lTbl.Rows.Count - 1
            lTbl.Rows(i).Item("KilosEntregados") = KilosEntregadosPorItem_Oc(lTbl.Rows(i).Item("Item_Oc"), iCodViaje)
        Next
        lRes.Tables.Add(lTbl)
        Return lRes
    End Function
    Friend Function Obtener_OC(ByVal iIdObra As String) As DataSet
        Dim lSql As String = "", lRes As New DataSet, lTbl As New DataTable
        'lSql = "Select * from oc where IdObra=" & iIdObra
        lSql = "  exec SP_Consultas_ActaEntrega 5,'" & iIdObra & "','','','','','',''"
        lRes.Tables.Add(CargaTabla(lSql))
        Return lRes
    End Function
    Public Function ActualizaOrdenPorViaje(ByVal iCodviaje As String) As String
        Dim lSql As String = "", lRes As String = "0", lTbl As New DataTable, i As Integer = 0
        lSql = "Select p.Id IdPieza  from Piezas p , Viaje v  where IdViaje=v.id and codigo='" & iCodviaje & "' Order by P.Id asc "
        lTbl = CargaTabla(lSql)
        For i = 0 To lTbl.Rows.Count - 1
            lSql = "Update piezas set orden=" & i + 1 & "  where Id=" & lTbl.Rows(i)("IdPieza")
            lRes = EjecutaDML(lSql)
        Next
        Return lRes
    End Function
    Friend Function EliminaActaEntrega(ByVal CodViaje As String) As String
        Dim lSql As String = "", lres As String = "", lTbl As New DataTable

        lSql = " delete from ActaEntrega where CodViaje='" & CodViaje & "'"
        lres = Val(EjecutaDML(lSql))

        lSql = " delete from entregas_oc  where CodViaje='" & CodViaje & "'"
        lres = Val(EjecutaDML(lSql))

        Return lres
    End Function
    Friend Function GrabarActaEntrega(ByVal iActaEntrega As TipoActaEntrega) As TipoActaEntrega
        Dim lSql As String = "", lres As String = "", lTbl As New DataTable
        If iActaEntrega.id > 0 Then
            'debemos actualizar 
            'lSql = " Update ActaEntrega set (CodViaje,OC, IdColada,NroCertificado,TotalKgs ) values ('"
            'lSql = lSql & iActaEntrega.CodViaje & "','" & iActaEntrega.OC & "'," & iActaEntrega.IdColada
            'lSql = lSql & ",'" & iActaEntrega.NroCertificado & "'," & iActaEntrega.TotalKgs & ")"

        Else  'debemos Insertar
            lSql = "Insert Into ActaEntrega  (CodViaje,OC, IdColada,NroCertificado,TotalKgs,NroActa,archivo ) values ('"
            lSql = lSql & iActaEntrega.CodViaje & "','" & iActaEntrega.OC & "'," & iActaEntrega.IdColada
            lSql = lSql & ",'" & iActaEntrega.NroCertificado & "'," & iActaEntrega.TotalKgs & ",'"
            lSql = lSql & iActaEntrega.NroActa & "','" & iActaEntrega.Archivo & "')"
            lres = EjecutaDML(lSql)
            If Val(lres) > 0 Then
                lTbl = CargaTabla("Select Max(id) from ActaEntrega ")
                If lTbl.Rows.Count > 0 Then
                    iActaEntrega.id = lTbl.Rows(0)(0)
                End If
            End If
        End If
        Return iActaEntrega
    End Function
    Friend Function ObtenerActaEntregaPorCodViaje(ByVal iCodViaje As String) As TipoActaEntrega
        Dim lSql As String = "", lres As String = "", lTbl As New DataTable
        Dim iActaEntrega As New TipoActaEntrega
        lSql = " Select * from ActaEntrega where CodViaje='" & iCodViaje & "'"
        lTbl = CargaTabla(lSql)
        If lTbl.Rows.Count > 0 Then
            iActaEntrega.id = lTbl.Rows(0)("Id")
            iActaEntrega.CodViaje = lTbl.Rows(0)("CodViaje").ToString
            iActaEntrega.OC = lTbl.Rows(0)("OC").ToString
            iActaEntrega.IdColada = lTbl.Rows(0)("IdColada")
            iActaEntrega.NroCertificado = lTbl.Rows(0)("NroCertificado").ToString
            iActaEntrega.TotalKgs = lTbl.Rows(0)("TotalKgs").ToString
            iActaEntrega.NroActa = lTbl.Rows(0)("NroActa").ToString
            iActaEntrega.Archivo = lTbl.Rows(0)("Archivo").ToString
        End If
        Return iActaEntrega
    End Function

    Friend Function GrabarColada(ByVal iColada As TipoColada) As TipoColada
        Dim lSql As String = "", lRes As Integer = 0, lTbl As New DataTable
        If iColada.Id = 0 Then
            lSql = "Insert Into colada ( Diametro, NroColada,NroCertificado, Largo,fechaIngreso, "
            lSql = lSql & " procedencia,NroGuiaDesp, kilos ) values ("
            'NroGuiaDesp  en Base de datos es Varchar(50)
            lSql = lSql & iColada.Diametro & ",'" & iColada.NroColada & "','" & iColada.NroCertificado
            lSql = lSql & "','" & iColada.Largo & "', getdate(),'" & iColada.Procedencia & "','"
            lSql = lSql & iColada.NroGuiaDespacho & "'," & iColada.Kilos & " )"
            lRes = EjecutaDML(lSql)
            If lRes > 0 Then
                lSql = " Select max(id) from colada "
                lTbl = CargaTabla(lSql)
                If lTbl.Rows.Count > 0 Then
                    iColada.Id = lTbl.Rows(0)(0)
                End If
            End If
        Else
            lSql = " UPDATE  colada SET Diametro=" & iColada.Diametro & ", NroColada='" & iColada.NroColada
            lSql = lSql & "',NroCertificado='" & iColada.NroCertificado & "',Largo='" & iColada.Largo
            lSql = lSql & "', procedencia='" & iColada.Procedencia & "', NroGuiaDesp='" & iColada.NroGuiaDespacho & "'"
            lSql = lSql & ", kilos=" & iColada.Kilos & " where Id=" & iColada.Id
            lRes = EjecutaDML(lSql)
        End If
        Return iColada
    End Function



    Friend Function GrabarOC(ByVal iOC As TipoOC) As TipoOC
        Dim lSql As String = "", lRes As Integer = 0, lTbl As New DataTable
        If iOC.id = 0 Then
            '  
            lSql = "Insert Into OC ( REl_Item,Bl_Item,Peso_TN,Descripcion,Diam, IdObra,Fechacreacion ) values ('" '
            lSql = lSql & iOC.Item_OC & "','" & iOC.Item_OC & "'," & iOC.Peso & ",'" & iOC.Descripcion
            lSql = lSql & "'," & iOC.Diametro & "," & iOC.IdObra & ", getdate() )"
            lRes = EjecutaDML(lSql)
            If lRes > 0 Then
                lSql = " Select max(id) from colada "
                lTbl = CargaTabla(lSql)
                If lTbl.Rows.Count > 0 Then
                    iOC.id = lTbl.Rows(0)(0)
                End If
            End If
        Else
            lSql = " UPDATE  OC  SET REl_Item='" & iOC.Item_OC & "', Bl_Item='" & iOC.Item_OC
            lSql = lSql & "' ,Peso_TN=" & iOC.Peso & ",Descripcion='" & iOC.Descripcion
            lSql = lSql & "' ,Diam=" & iOC.Diametro & ",IdObra=" & iOC.IdObra & ", FechaCreacion=getdate() "
            lSql = lSql & " where Id=" & iOC.id
            lRes = EjecutaDML(lSql)
        End If
        Return iOC
    End Function

    Public Function ObtenerResumenPiezasDigitadas(ByVal iIdObra As String) As DataSet
        Dim lTbl As New DataTable, lDts As New DataSet, lSql As String = ""
        '         select Plano,  convert(varchar,hd.fecha,103) FechaIngreso,   
        'count(1)  NroPiezas,  
        'sum(TotalKgs)Kilos 
        'from hojadespiece hd , Piezas p where idobra=17  
        'and hd.id=p.Id_Hd and p.Estado not in ('00')
        'group by plano,  convert(varchar,hd.fecha,103)   
        'order by convert(varchar,hd.fecha,103) desc 
        lSql = " select Plano,  convert(varchar,hd.fecha,103) FechaIngreso,  "
        lSql = lSql & " count(1)  NroPiezas,   "
        lSql = lSql & " sum(TotalKgs)Kilos  "
        lSql = lSql & " from  hojadespiece hd , PiezasTipoB p  where idobra=" & iIdObra & " and hd.id=p.Id_Hd "
        lSql = lSql & "  and p.Estado not in ('00') group by plano,  convert(varchar,hd.fecha,103)    "
        lSql = lSql & "  order by convert(varchar,hd.fecha,103) desc "
        lTbl = CargaTabla(lSql)
        lDts.Tables.Add(lTbl)
        Return lDts
    End Function

#Region "Consulta para ver AUDITORIAS  a las tablas "
    Public Function ObtenerAuditoriasPor_IdPieza(ByVal iIdPieza As String) As DataSet
        Dim lTbl As New DataTable, lDts As New DataSet, lSql As String = ""
        Dim iIdMov As String = "", iIdIT As String = "", iIdViaje As String = ""

        lSql = " Select ID_It, IdMov, IdViaje  from Piezas where Id=" & iIdPieza
        lTbl = CargaTabla(lSql)
        If Not lTbl Is Nothing AndAlso lTbl.Rows.Count > 0 Then
            iIdMov = lTbl.Rows(0)("IdMov").ToString : iIdIT = lTbl.Rows(0)("ID_It").ToString
            iIdViaje = lTbl.Rows(0)("IdViaje").ToString

            '--Piezas
            lSql = " select Id,IdForma,Marca,Cantidad,Diametro,Largo,TotalKgs,Estado,Fecha,Id_It,IdViaje,IdPiezaTipoB,"
            lSql = lSql & " IdMov,UserMod,FechaMod, Accion from Mov_piezas where Id=" & iIdPieza & " order by FechaMod "
            lTbl = CargaTabla(lSql) : lTbl.TableName = "Piezas" : lDts.Tables.Add(lTbl.Copy)
            '--Cotas
            lSql = "select Id,IdForma,IdPieza,a,b,c,d,e,f,g,h,i,j,k,l,m,n,Tipo,UserMod,FechaMod,Accion "
            lSql = lSql & " from Mov_DetalleForma where IdPieza=" & iIdPieza & " order by FechaMod "
            lTbl = CargaTabla(lSql) : lTbl.TableName = "Cotas" : lDts.Tables.Add(lTbl.Copy)
            '--PreIT
            lSql = "select Id,Plano,Marca,PiezasTotales,Asignadas,PesoAsignado,Saldo,PesoSaldo,NroPaquetes,PiezasXPaquete,KilosTotales,"
            lSql = lSql & " Fecha,Usuario, Estado,CodViaje,Tipo,FechaMod,Accion from Mov_movimientos where Id=" & iIdMov & " order by FechaMod"
            lTbl = CargaTabla(lSql) : lTbl.TableName = "Movimientos" : lDts.Tables.Add(lTbl.Copy)
            '--IT
            lSql = "select Id,EntragadoA,EntregadoPor,FechaEntrega,FechaDespacho,CodigoIt,IdObra,FechaCreacion,IdViaje,TipoIt,TotalKgs,"
            lSql = lSql & "  ImporteKgs,TotalImporteKgs,Estado,NroIt,UserMod,FechaMod,Accion  from Mov_IT"
            lSql = lSql & "  Where Id=" & Val(iIdIT) & " order by FechaMod "
            lTbl = CargaTabla(lSql) : lTbl.TableName = "IT" : lDts.Tables.Add(lTbl.Copy)
            '--Viaje
            lSql = " select  Id, FechaCreacion, Codigo, TotalKgs,NroLaminas,Estado,UserCrea, NroDespacho,FechaViaje,"
            lSql = lSql & " Obs, IdIt,FechaMod from Mov_viaje Where Id=" & Val(iIdViaje) & "  order by FechaMod "
            lTbl = CargaTabla(lSql) : lTbl.TableName = "Viaje" : lDts.Tables.Add(lTbl.Copy)
        End If
        Return lDts

    End Function
#End Region

#Region "BECHTELL"
    Public Function InsertaPiezaDesdeBechtell(ByVal iMarca As String, ByVal iPlano As String, ByVal iIdObra As String, ByVal iAsignadas As String, ByVal iKgsAsig As String, ByVal IdMov As String, ByVal iIdUser As String, ByVal IdPiezaTipoB As Integer) As String
        Dim lRes As String = "", lSql As String = "", lTbl As New DataTable
        lSql = "insert into piezas  ([Correlativo],[EsVariable],[Pieza],[IdForma],[Marca],[Cantidad],[Diametro],[Largo]"
        lSql = lSql & ",[TotalKgs],[Estado],[IdImagen],[IdDetalleForma] ,[Fecha],[Id_Hd] ,[Ubicacion] ,[Id_It] ,[Valores]"
        lSql = lSql & ",[UbicacionFull] ,[IdViaje] ,[Origen],[IdPiezaTipoB],[IdMov],[UserMod],[largoReal],[PesoReal],[KgsNorma353]) "
        lSql = lSql & " select [Correlativo],[EsVariable],[Pieza],[IdForma],[Marca],"
        lSql = lSql & iAsignadas & " ,[Diametro],[Largo],p.TotalKgs,5,[IdImagen],[IdDetalleForma] ,P.Fecha ,[Id_Hd] ,P.Ubicacion "
        lSql = lSql & " ,[Id_It] ,[Valores] ,[UbicacionFull] ,[IdViaje] ,'Di' ,p.Id, " & IdMov & ", " & iIdUser & ", "
        lSql = lSql & " convert(real,dbo.fnc_ObtenerLargoReal(p.IdForma,p.Diametro, p.Largo )) /1000 ,"
        'lSql = lSql & " round(dbo.fnc_ObtenerPeso(p.Diametro, p.Cantidad, Convert(real, dbo.fnc_ObtenerLargoReal(p.IdForma, p.Diametro, p.Largo)) / 1000), 0)"
        lSql = lSql & "  p.TotalKgs , p.KgsNorma353  "
        lSql = lSql & " from  piezastipob p, Hojadespiece hd   where marca='" & iMarca & "'"
        lSql = lSql & " and hd.id=p.Id_hd  and p.estado <> '00' and hd.idObra=" & iIdObra
        lSql = lSql & " and p.Id=" & IdPiezaTipoB  'and hd.plano='" & iPlano & "' 
        lSql = lSql & "   select @@identity  "
        lTbl = CargaTabla(lSql)
        If lTbl.Rows.Count > 0 Then
            lRes = lTbl.Rows(0)(0).ToString()
        End If

        Return lRes
    End Function

    Public Function EliminarPiezas(ByVal iIdsPiezas As String, ByVal lIdUser As Integer) As String
        Dim lRes As String = "", i As Integer = 0, lWheres As String = "", lSql As String = ""
        Dim lPartes() As String = iIdsPiezas.Split(",")

        For i = 0 To lPartes.Length - 1 'iIdsPiezas.Count - 1
            lWheres = String.Concat(lWheres, lPartes(i), ",")
        Next
        If lWheres.Length > 1 Then
            lWheres = lWheres.Substring(0, lWheres.Length - 1)
        End If

        'lSql = "Delete from PiezasTipoB where Id in (" & lWheres & ") "
        'lSql = lSql & " and Id not in ( select IdPiezaTipoB from piezas where IdPiezaTipoB=PiezasTipoB.id) "
        'cAMBIAMOS EL ESTADO A PiezaTipoB
        lSql = "Update  PiezasTipoB set Estado='00', FechaMod=getdate(), UserMod=" & lIdUser & " where Id in (" & lWheres & ") "
        lSql = lSql & " and Id not in ( select IdPiezaTipoB from piezas where IdPiezaTipoB=PiezasTipoB.id and estado<>'00') "

        Return EjecutaDML(lSql).ToString

    End Function

    Public Function SumarKilos(ByVal iViaje As String, ByVal iNroRep As Integer) As Boolean
        Dim lRes As Boolean = True, lpartes() As String = iViaje.Split("/")

        If lpartes.Length = 2 Then
            If Val(lpartes(1).ToString) > 1 Then
                'es saldo
                If Val(iNroRep) = 0 Then
                    'NO Se ha reprogramado
                    lRes = False
                End If
            End If
        End If

        Return lRes
    End Function

    Public Function IncluyeViajeEnExcelDescargable(ByVal iViaje As String) As Boolean ', ByVal iNroRep As Integer) As Boolean
        Dim lRes As Boolean = True, lpartes() As String = iViaje.Split("/"), iNroRep As Integer = 0
        Dim lTabla As New DataTable, lSql As String = ""
        If lpartes.Length = 2 Then
            If Val(lpartes(1).ToString) > 1 Then    'es saldo
                'Verificamos si se ha reprogramado la IT
                lSql = " Select isnull(count(1),0) NroRep  from Reprogramar_IT r, IT , viaje v"
                lSql = String.Concat(lSql, "  where r.IdIT =it.id  and it.Id=v.idit and codigo='", iViaje, "'")
                lTabla = CargaTabla(lSql)
                If Not lTabla Is Nothing AndAlso lTabla.Rows.Count > 0 Then
                    If Val(lTabla.Rows(0)(0).ToString) > 0 Then
                        lRes = False
                    End If

                End If
            End If
        End If
        Return lRes
    End Function


    Public Function ExisteMov_SinViaje(ByVal itipoMov As TipoMov) As Boolean
        Dim lSql As String = "", lTabla As New DataTable, lRes As Boolean = False
        lSql = " Select * from Movimientos where idObra=" & itipoMov.IdObra & " and plano='" & itipoMov.Plano.Replace("'", "''") & "'"
        lSql = lSql & " and Marca='" & itipoMov.Marca & "' and (CodViaje is Null or CodViaje='') and  Estado<>'00' "
        lSql = lSql & " and IdPiezaTipoB=" & itipoMov.idPiezaTipoB
        lTabla = CargaTabla(lSql)
        If Not lTabla Is Nothing AndAlso lTabla.Rows.Count > 0 Then
            lRes = True
        End If
        Return lRes
    End Function

    Public Function ModificaPreIT(ByVal iMov As TipoMov) As String
        Dim lResultado As String = "", lTbl As New DataTable
        Dim lRes As String = ""

        'Primero modificamos tabla Movimientos
        If Val((InsertaMov(iMov).ToString) > 0) Then
            'Ahora modificamos la Pieza asociada            
            lRes = " Update  piezas set cantidad=" & iMov.Asignadas & ",TotalKgs='" & iMov.PesoAsignado & "' "
            lRes = String.Concat(lRes, " Where IdMov=", iMov.id) '
            lResultado = EjecutaDML(lRes)

        End If
        Return lResultado


    End Function
    Public Function InsertaMov(ByVal iMov As TipoMov) As String
        Dim lResultado As String = "", lTbl As New DataTable
        Dim lRes As String = ""

        '  	ALTER   PROCEDURE [dbo].[SP_CRUD_MOVIMIENTOS]
        '@Id int,                       '@IdObra int ,	                        '@Plano nvarchar(300) ,
        '@Marca nvarchar(50) ,          '@PiezasTotales int,                    '@Asignadas int,
        '@PesoAsignado real,            '@Saldo int,                            '@PesoSaldo real,
        '@NroPaquetes int,              '@PiezasXPaquete nvarchar(50) ,         '@KilosTotales real ,
        '@Usuario nvarchar(50) ,        '@Estado nvarchar(50) ,                 '@CodViaje varchar(20) ,
        '@Tipo varchar(1) ,             '@IdPiezaTipoB int,                     '@FactorPaquetes int,
        '@OPCION int
        lRes = String.Concat(" EXEC SP_CRUD_MOVIMIENTOS ", Val(iMov.id), ",", Val(iMov.IdObra), ",'", iMov.Plano, "','")
        lRes = String.Concat(lRes, iMov.Marca, "',", Val(iMov.PiezasTotales), ",", iMov.Asignadas, ",'")
        lRes = String.Concat(lRes, iMov.PesoAsignado, "',", Val(iMov.Saldo), ",'", iMov.PesoSaldo, "',")
        lRes = String.Concat(lRes, iMov.NroPaquetes, ",'", iMov.PiezasXPaquete, "','", iMov.KilosTotales, "','")
        lRes = String.Concat(lRes, iMov.Usuario, "','", Val(iMov.Estado), "','", iMov.CodViaje, "','")
        lRes = String.Concat(lRes, iMov.Tipo, "',", Val(iMov.idPiezaTipoB), ",", Val(iMov.Factor), ",1")
        lTbl = CargaTabla(lRes)
        If Not lTbl Is Nothing AndAlso lTbl.Rows.Count > 0 Then
            lResultado = lTbl.Rows(0)(0).ToString
        End If

        'SE COMENTA YA QUE SE PASA A PROCEDIMIENTO ALMACENADO
        'lRes = " Select 1 from Movimientos  where Id=" & Val(iMov.id)
        'lTbl = CargaTabla(lRes)
        'If lTbl.Rows.Count > 0 Then
        '    lRes = " Update  Movimientos set Asignadas=" & iMov.Asignadas & ",PesoAsignado='" & iMov.PesoAsignado & "',"
        '    lRes = lRes & "Saldo=" & Val(iMov.Saldo) & ",PesoSaldo= '" & iMov.PesoSaldo & "', NroPaquetes=" & iMov.NroPaquetes & ","
        '    lRes = String.Concat(lRes, " PiezasXPaquete='" & iMov.PiezasXPaquete & "',Tipo='D' ")
        '    lRes = String.Concat(lRes, " Where Id=", iMov.id)
        '    lResultado = EjecutaDML(lRes)
        '    lResultado = iMov.id
        'Else
        '    lRes = " INSERT INTO Movimientos ([IdObra] ,[Plano],[Marca],[PiezasTotales],[Asignadas],[PesoAsignado],"
        '    lRes = lRes & "[Saldo] ,[PesoSaldo] ,[NroPaquetes]  ,[PiezasXPaquete] ,[KilosTotales],[Fecha] ,[Usuario]"
        '    lRes = String.Concat(lRes, " ,[Estado],[Tipo],[IdPiezaTipoB],[FactorPaquetes])   VALUES (", iMov.IdObra, ",'", iMov.Plano.Replace("'", "''"), "','")
        '    lRes = String.Concat(lRes, iMov.Marca, "',", iMov.PiezasTotales, ",", Val(iMov.Asignadas), ",'")
        '    lRes = String.Concat(lRes, iMov.PesoAsignado, "',", Val(iMov.Saldo), ",'", iMov.PesoSaldo, "',", iMov.NroPaquetes, ",'")
        '    lRes = String.Concat(lRes, iMov.PiezasXPaquete, "',", iMov.KilosTotales, ",getdate(),'", iMov.Usuario, "','")
        '    lRes = String.Concat(lRes, iMov.Estado, "','", iMov.Tipo, "',", iMov.idPiezaTipoB, ",", iMov.Factor, ")")
        '    lResultado = EjecutaDML(lRes)
        '    If Val(lResultado) > 0 Then
        '        lRes = " Select max(id) from Movimientos "
        '        lTbl = CargaTabla(lRes)
        '        If Not lTbl Is Nothing AndAlso lTbl.Rows.Count > 0 Then
        '            lResultado = lTbl.Rows(0)(0).ToString
        '        End If
        '    End If
        'End If

        Return lResultado
    End Function


    Public Function InsertaTieneAngulo90(ByVal iSubTabla As String, ByVal iDes As String, ByVal iPar1 As String, ByVal iPar2 As String) As String
        Dim lRes As String = ""
        Try
            lRes = InsertaParametroGeneral(iSubTabla, iDes, iPar1, iPar2)
        Catch ex As Exception
            RegistraError("ClsDatos.InsertaTieneAngulo90, err: " & ex.Message)
        End Try
        Return lRes
    End Function

    Public Function ObtenerParametrosGenerales(ByVal iSubTabla As String, ByVal iTipo As String) As DataTable
        Dim lDal As New ClsDatos, lTbl As New DataTable, lSql As String = ""
        '       ALTER  PROCEDURE [dbo].[SP_GrabaEnParametro]
        '@SubTabla nvarchar(50),	--to_parametros--
        '   @Descripcion nvarchar(max),
        '   @Par1 nvarchar(50),
        '@Par2  nvarchar(50),	
        '@OPCION INT

        Try
            Select Case iTipo.ToUpper
                Case "SUBTABLA"
                    lSql = String.Concat(" SP_GrabaEnParametro '','','','',2 ")
                Case Else
                    lSql = String.Concat(" SP_GrabaEnParametro '", iSubTabla, "','','','',3 ")
            End Select
            lTbl = lDal.CargaTabla(lSql)
            lTbl.TableName = "SubTabla"

        Catch ex As Exception
            lDal.RegistraError("ClsDatos.ObtenerParametrosGenerales, err: " & ex.Message & " - Sql: " & lSql)

        End Try
        Return lTbl
    End Function

    Public Function InsertaParametroGeneral(ByVal iSubTabla As String, ByVal iDes As String, ByVal iPar1 As String, ByVal iPar2 As String) As String
        Dim lTbl As New DataTable, lRes As String = ""
        Dim lSql As String = ""
        Try
            lSql = String.Concat("'", iSubTabla, "', '", iDes, "','", iPar1 & "','")
            lSql = lSql & iPar2 & "',4"
            lSql = "SP_GrabaEnParametro " & lSql
            lTbl = CargaTabla(lSql)
            If lTbl.Rows.Count > 0 Then
                lRes = lTbl.Rows(0)(0)
            Else
                lRes = " El SP de Insert no Retorno la Identidad "
            End If
        Catch ex As Exception
            RegistraError("ClsDatos.InsertaParametroGeneral, err: " & ex.Message)
        End Try
        Return lRes
    End Function

    Public Function ObtenerParametrosTextoImg() As String
        Dim lTbl As New DataTable, lRes As String = ""
        Dim lSql As String = ""
        Try
            lSql = " Select Par1 from To_Parametros where SubTabla='TipoLetra'"
            lTbl = CargaTabla(lSql)
            If lTbl.Rows.Count > 0 Then
                lRes = "TL:" & lTbl.Rows(0)(0).ToString
            End If

            lSql = " Select Par1 from To_Parametros where SubTabla='Negrita'"
            lTbl = CargaTabla(lSql)
            If lTbl.Rows.Count > 0 Then
                lRes = lRes & "|N:" & lTbl.Rows(0)(0).ToString
            End If

            lSql = " Select Par1 from To_Parametros where SubTabla='TamañoLetra'"
            lTbl = CargaTabla(lSql)
            If lTbl.Rows.Count > 0 Then
                lRes = lRes & "|TM:" & lTbl.Rows(0)(0).ToString
            End If
        Catch ex As Exception
            RegistraError("ClsDatos.ObtenerParametrosTextoImg, err: " & ex.Message & " - Sql: " & lSql)
        End Try
        Return lRes
    End Function

    Public Function Inserta_DetallePaquetesPieza(ByVal iDet As TipoDetallePaquetesPieza) As TipoDetallePaquetesPieza
        Dim lTbl As New DataTable  'lResultado As TipoDetallePaquetesPieza =
        Dim lSql As String = ""
        'lLstDts = CargaTabla("SP_GeneraDetallePaquetesPieza " +
        Try
            lSql = String.Concat(iDet.Id, ", ", iDet.IdPieza, ",", iDet.IdMov & ",")
            lSql = lSql & iDet.NroPaq & ",'" & iDet.TotalPaq & "','" & iDet.KgsPaquete & "','" & iDet.Estado & "'," & iDet.NroPiezas & ", 1"
            lSql = "SP_GeneraDetallePaquetesPieza " & lSql
            lTbl = CargaTabla(lSql)
            If lTbl.Rows.Count > 0 Then
                iDet.Id = lTbl.Rows(0)(0)
            Else
                iDet.Err = " El SP de Insert no Retorno la Identidad "
            End If
        Catch ex As Exception
            RegistraError("ClsDatos.Inserta_DetallePaquetesPieza, err: " & ex.Message & " - Sql: " & lSql)
        End Try
        Return iDet
    End Function

    Public Function ObtenerPiezasPorPlano(ByVal iIdObra As String, ByVal iPlano As String) As DataTable
        Dim lTbl As New DataTable, i As Integer = 0, lTbl2 As New DataTable, lFila As DataRow = Nothing
        Dim lTotalDigitado As Integer = 0, j As Integer = 0, lKgsDigitado As Double = 0
        Dim lTotalPiezas As Integer = 0, lTotalKgs As Integer = 0
        Dim lSql As String = " select  marca, Cantidad, ROUND(totalKgs,0), totalKgs, p.Id IdPiezaTipoB FROM piezastipob p, hojadespiece hd "
        lSql = lSql & " where hd.id=p.id_hd  and plano='" & iPlano.Replace("'", "''") & "' and p.estado<>'00' and idObra =" & iIdObra

        lSql = lSql & " order by p.id asc "
        lTbl = CargaTabla(lSql)
        lTbl.Columns.Add("PiezasAsig", Type.GetType("System.String"))
        lTbl.Columns.Add("PesoAsig", Type.GetType("System.String"))
        lTbl.Columns.Add("SaldoPiezas", Type.GetType("System.String"))
        lTbl.Columns.Add("SaldoKgs", Type.GetType("System.String"))
        lTbl.Columns.Add("NroPaquetes", Type.GetType("System.String"))
        lTbl.Columns.Add("PiezasXPaquete", Type.GetType("System.String"))
        lTotalPiezas = 0
        lTotalPiezas = 0
        For i = 0 To lTbl.Rows.Count - 1
            lTotalPiezas = lTotalPiezas + Val(lTbl.Rows(i)("Cantidad").ToString)
            lTotalKgs = lTotalKgs + Val(lTbl.Rows(i)("totalKgs").ToString)
            lSql = "Select * from Movimientos Where IdObra=" & iIdObra
            lSql = lSql & " and Plano='" & iPlano & "' and Marca='" & lTbl.Rows(i)("Marca").ToString & "' and estado<>'00'"
            lSql = lSql & " and IdPiezaTipoB=" & lTbl.Rows(i)("IdPiezaTipoB").ToString
            lTbl2 = CargaTabla(lSql)
            If lTbl2.Rows.Count > 0 Then
                lTotalDigitado = 0 : lKgsDigitado = 0
                For j = 0 To lTbl2.Rows.Count - 1
                    lTotalDigitado = lTotalDigitado + Val(lTbl2.Rows(j)("Asignadas").ToString)
                    lKgsDigitado = lKgsDigitado + Val(lTbl2.Rows(j)("PesoAsignado").ToString)
                Next
                lTbl.Rows(i)("Cantidad") = Val(lTbl.Rows(i)("Cantidad")) - lTotalDigitado
                lTbl.Rows(i)("TotalKgs") = Double.Parse(lTbl.Rows(i)("TotalKgs").ToString) - lKgsDigitado
                lTbl.Rows(i)("PiezasAsig") = "" 'lTbl2.Rows(0)("Asignadas")
                lTbl.Rows(i)("PesoAsig") = "" 'lTbl2.Rows(0)("PesoAsigando")
                lTbl.Rows(i)("SaldoPiezas") = "" 'lTbl2.Rows(0)("Saldo")
                lTbl.Rows(i)("SaldoKgs") = "" ' lTbl2.Rows(0)("PesoSaldo")
                lTbl.Rows(i)("NroPaquetes") = "" 'lTbl2.Rows(0)("NroPaquetes")
                lTbl.Rows(i)("PiezasXPaquete") = "" 'lTbl2.Rows(0)("PiezasXPaquete")
            End If
        Next
        If lTbl.Rows.Count > 0 Then
            lFila = lTbl.NewRow
            lFila("Marca") = "Tot."
            lFila("Cantidad") = lTotalPiezas
            lFila("TotalKgs") = lTotalKgs
            lTbl.Rows.Add(lFila)
        End If
        Return lTbl
    End Function
    Public Function ObtenerPiezasPorPlanoNew(ByVal iIdObra As String, ByVal iPlano As String, ByVal iFig As String, ByVal iUbic As String, ByVal iMarca As String, ByVal iDiam As String, ByVal iNivel As String, ByVal ielemento As String) As DataTable
        Dim lTbl As New DataTable, i As Integer = 0, lTbl2 As New DataTable, lFila As DataRow = Nothing
        Dim lTotalDigitado As Integer = 0, j As Integer = 0, lKgsDigitado As Double = 0, lTmp As String = ""
        Dim lTotalPiezas As Integer = 0, lTotalKgs As Integer = 0, lPartes() As String = Nothing, iaux As String = ""
        Dim lSaldoPiezas As Integer = 0, lSaldoKgs As Integer = 0
        Dim lSql As String = " " 'select  sector,  hd.ubicacion  referencia ,hd.Figura figura, marca, Cantidad,largo Largo, ROUND(totalKgs,0), totalKgs, p.Id IdPiezaTipoB ,Plano "
        'lSql = lSql & " FROM piezastipob p, hojadespiece hd  where hd.id=p.id_hd  and p.estado<>'00' and idObra =" & iIdObra


        lSql = "   select p.Id,Plano,Marca,sector ,figura,correlativo pieza ,cantidad, 0 saldo, diametro Diam, hd.ubicacion referencia, "
        lSql = lSql & " ROUND(totalKgs,0), 'Viaje',p.fecha, 'Imagen', totalKgs, p.Id IdPiezaTipoB ,Plano ,0 SaldoKgs , KgsNorma353 "
        lSql = lSql & " FROM piezastipob p, hojadespiece hd  where hd.id=p.id_hd  and p.estado<>'00' and idObra =" & iIdObra
        '****
        If iPlano.Length > 0 Then lSql = lSql & " and plano='" & iPlano.Replace("'", "''") & "'"

        If iNivel.Length = 0 Then
            iaux = ""
        Else
            iaux = iNivel
        End If
        If ielemento.Length = 0 Then
            'iaux = ""
            If iNivel.Length > 0 Then
                lSql = lSql & " and substring(sector,CharIndex('+',sector)+1,len(sector))='" & iNivel.Replace("'", "''") & "'"
            End If

        Else
            iaux = ielemento & "+" & iaux
        End If

        If iaux.Length > 0 Then lSql = lSql & "and sector like '%" & iaux.Replace("'", "''") & "%' "

        If iFig.Length > 0 Then lSql = lSql & " And Figura='" & iFig.Replace("'", "''") & "'"

        If iUbic.Length > 0 Then lSql = lSql & " And hd.Ubicacion='" & iUbic.Replace("'", "''") & "'"

        If iMarca.Length > 0 Then lSql = lSql & " And Marca='" & iMarca & "'"

        If iDiam.Length > 0 Then lSql = lSql & " And diametro='" & iDiam & "'"


        '        and sector like '%4 piso%'
        'and substring(sector,CharIndex('+',sector)+1,len(sector))='4 piso'
        'iMarca iDiam 
        '****
        lSql = lSql & " order by p.id asc "
        lTbl = CargaTabla(lSql)
        lTbl.Columns.Add("Nivel", Type.GetType("System.String"))
        lTbl.Columns.Add("Elemento", Type.GetType("System.String"))
        lTbl.Columns.Add("SaldoPiezas", Type.GetType("System.String"))
        lTbl.Columns.Add("Viaje", Type.GetType("System.String"))
        'lTbl.Columns.Add("SaldoPiezas", Type.GetType("System.String"))
        'lTbl.Columns.Add("SaldoKgs", Type.GetType("System.String"))
        'lTbl.Columns.Add("NroPaquetes", Type.GetType("System.String"))
        'lTbl.Columns.Add("PiezasXPaquete", Type.GetType("System.String"))
        lTotalPiezas = 0
        lTotalPiezas = 0
        For i = 0 To lTbl.Rows.Count - 1
            lTotalPiezas = lTotalPiezas + Val(lTbl.Rows(i)("Cantidad").ToString)
            lTotalKgs = lTotalKgs + Val(lTbl.Rows(i)("totalKgs").ToString)
            lSql = "Select * from Movimientos Where IdObra=" & iIdObra
            lSql = lSql & " and plano='" & lTbl.Rows(i)("Plano").ToString.Replace("'", "''") & "'"
            lSql = lSql & " and marca ='" & lTbl.Rows(i)("Marca").ToString.Replace("'", "''") & "' and estado<>'00'"
            lSql = lSql & " and IdPiezaTipoB=" & lTbl.Rows(i)("IdPiezaTipoB").ToString
            lTbl2 = CargaTabla(lSql)
            lTotalDigitado = 0 : lKgsDigitado = 0
            If lTbl2.Rows.Count > 0 Then
                lTotalDigitado = 0 : lKgsDigitado = 0
                For j = 0 To lTbl2.Rows.Count - 1
                    lTotalDigitado = lTotalDigitado + Val(lTbl2.Rows(j)("Asignadas").ToString)
                    lKgsDigitado = lKgsDigitado + Val(lTbl2.Rows(j)("PesoAsignado").ToString)
                Next

                'lTbl.Rows(i)("PesoAsig") = "" 'lTbl2.Rows(0)("PesoAsigando")
                'lTbl.Rows(i)("SaldoPiezas") = "" 'lTbl2.Rows(0)("Saldo")               
                'lTbl.Rows(i)("NroPaquetes") = "" 'lTbl2.Rows(0)("NroPaquetes")
                'lTbl.Rows(i)("PiezasXPaquete") = "" 'lTbl2.Rows(0)("PiezasXPaquete")
            End If

            lTbl.Rows(i)("Cantidad") = Val(lTbl.Rows(i)("Cantidad"))
            lTbl.Rows(i)("SaldoPiezas") = Val(lTbl.Rows(i)("Cantidad")) - lTotalDigitado
            lTbl.Rows(i)("TotalKgs") = Double.Parse(lTbl.Rows(i)("TotalKgs").ToString) '- lKgsDigitado
            lTbl.Rows(i)("SaldoKgs") = Double.Parse(lTbl.Rows(i)("TotalKgs").ToString) - lKgsDigitado
            'calculamos el saldo de las piezas 
            lSaldoPiezas = lSaldoPiezas + Val(lTbl.Rows(i)("SaldoPiezas").ToString)
            lSaldoKgs = lSaldoKgs + Val(lTbl.Rows(i)("SaldoKgs").ToString)

            lSql = "Select * from viaje v, Piezas p  Where IdViaje=v.id and p.IdPiezaTipoB=" & lTbl.Rows(i)("IdPiezaTipoB").ToString
            lSql = lSql & " and  p.estado<>'00'  "
            lTbl2 = CargaTabla(lSql)
            iaux = ""
            If lTbl2.Rows.Count > 0 Then
                For j = 0 To lTbl2.Rows.Count - 1
                    iaux = String.Concat(iaux, lTbl2.Rows(j)("Codigo").ToString, "-")
                Next
            End If
            lTbl.Rows(i)("Viaje") = iaux
            lPartes = lTbl.Rows(i)("Sector").ToString.Split("+")
            If lPartes.Length > 1 Then
                lTbl.Rows(i)("Nivel") = lPartes(1).ToString
                lTbl.Rows(i)("Elemento") = lPartes(0).ToString
            End If
        Next
        If lTbl.Rows.Count > 0 Then
            lFila = lTbl.NewRow
            lFila("Marca") = "Tot."
            lFila("SaldoPiezas") = lSaldoPiezas
            lFila("SaldoKgs") = lSaldoKgs
            lTbl.Rows.Add(lFila)
        End If
        Return lTbl
    End Function
    Public Function ObtenerPerfilUsuario(ByVal iIdUser As Integer) As String
        Dim lRes As String = "", lSql As String = "", lTbl As New DataTable
        lSql = " select Par1 as Perfil from to_usuarios u, to_parametros p  where u.Id=" & iIdUser
        lSql = lSql & " and subtabla='Perfil' and u.perfil=p.id "
        lTbl = CargaTabla(lSql)
        If Not lTbl Is Nothing AndAlso lTbl.Rows.Count > 0 Then
            lRes = lTbl.Rows(0)("Perfil").ToString
        End If
        Return lRes
    End Function

    Public Function ObtenerDatosHdPorIdPiezaTipoB(ByVal iIdPiezaTipoB As Integer) As DataTable
        Dim lRes As String = "", lSql As String = "", lTbl As New DataTable
        lSql = " select * from hojadespiece hd, PiezasTipoB p where hd.id = p.Id_Hd And p.id =" & iIdPiezaTipoB
        lTbl = CargaTabla(lSql)
        Return lTbl
    End Function

    Public Function ObtenerPiezaTipoB_PorId(ByVal iIdPiezaTipoB As String) As DataSet
        Dim lRes As String = "", lSql As String = "", lTbl As New DataTable, lDts As New DataSet
        lSql = " select * from PiezasTipoB  where id =" & iIdPiezaTipoB
        lTbl = CargaTabla(lSql)
        lDts.Tables.Add(lTbl)
        lSql = "select * from DETALLEFORMA where IdPieza=" & iIdPiezaTipoB
        lTbl = CargaTabla(lSql)
        lDts.Tables.Add(lTbl)
        Return lDts
    End Function

    Public Function ObtenerPiezasParaMod(ByVal iIdObra As String, ByVal iPlano As String, ByVal iUbica As String, ByVal iFigura As String, ByVal iSector As String, ByVal iMarca As String) As DataTable
        Dim lTbl As New DataTable, lTblTmp As New DataTable, i As Integer = 0, j As Integer = 0, lStr As String = ""
        Dim lSql As String = "  select p.IdForma, correlativo Item,Cantidad,Marca,EsVariable Tipo,largo *1000 Long, "

        '----
        lSql = lSql & "  diametro Diam,a,b,c,d,e,f,g,h,i,j,k,l,m,n,p.Totalkgs,p.Ubicacion,  "
        lSql = lSql & "  valores ValoresVar, p.Id IdPiezaTipoB, ''  as Viaje,  ''  as IdMov,NroPiezasVar, NroCotasVar "
        lSql = lSql & "  FROM piezastipob p, hojadespiece hd ,detalleforma df      "
        lSql = lSql & " where hd.id=p.id_hd  and   df.idPieza=p.Id  "
        If iPlano.Length > 0 Then lSql = lSql & "and plano='" & iPlano.Replace("'", "''") & "' "

        If iUbica.Length > 0 Then lSql = lSql & "and hd.ubicacion ='" & iUbica.Replace("'", "''") & "' "

        If iFigura.Length > 0 Then lSql = lSql & "and figura ='" & iFigura.Replace("'", "''") & "' "

        If iSector.Length > 0 Then lSql = lSql & "and sector like '%" & iSector.Replace("'", "''") & "%' "

        If iMarca.Length > 0 Then lSql = lSql & "and Marca='" & iMarca & "' "

        lSql = lSql & " and idObra =" & iIdObra
        lSql = lSql & " and p.estado<>'00'  order by p.id desc "
        lTbl = CargaTabla(lSql)

        For i = 0 To lTbl.Rows.Count - 1
            lSql = " select * from piezas p1, Viaje v  where p1.IdpiezaTipoB=" & lTbl.Rows(i)("IdPiezaTipoB").ToString
            lSql = lSql & "  and IdViaje=v.id  and v.estado<>'AN' and P1.estado<>'00' "
            lTblTmp = CargaTabla(lSql)
            lStr = ""
            For j = 0 To lTblTmp.Rows.Count - 1
                lStr = lStr & lTblTmp.Rows(j)("COdigo").ToString & ","
            Next
            If lStr.Length > 0 Then
                lTbl.Rows(i)("VIaje") = lStr.Substring(0, lStr.Length - 1)
            End If

            lSql = " Select Id from movimientos  where IdpiezaTipoB=" & lTbl.Rows(i)("IdPiezaTipoB").ToString
            lSql = lSql & " and Estado<>'00' "
            lTblTmp = CargaTabla(lSql)
            If lTblTmp.Rows.Count > 0 Then
                lTbl.Rows(i)("IdMov") = lTblTmp.Rows(0)(0).ToString
            End If
        Next
        Return lTbl
    End Function
    Public Function ObtenerPiezasPorPlanoParaEliminar(ByVal iIdObra As String, ByVal iPlano As String, ByVal iUbica As String, ByVal iFigura As String, ByVal iSector As String, ByVal iMarca As String) As DataTable
        Dim lTbl As New DataTable, lTblTmp As New DataTable, i As Integer = 0, j As Integer = 0, lStr As String = ""
        Dim lSql As String = " select p.Id IdPiezaDig, ''  as Viaje, "
        lSql = lSql & " Correlativo, Pieza, Marca, Cantidad, Diametro, Largo, TotalKgs, Estado, "
        lSql = lSql & "  p.fecha,Id_Hd " ', (select pb.Id from piezas pb where pb.IdpiezaTipoB=p.Id) as IdPieza "
        lSql = lSql & "  FROM piezastipob p, hojadespiece hd   "
        lSql = lSql & " where hd.id=p.id_hd  "
        If iPlano.Length > 0 Then lSql = lSql & "and plano='" & iPlano.Replace("'", "''") & "' "

        If iUbica.Length > 0 Then lSql = lSql & "and hd.ubicacion ='" & iUbica.Replace("'", "''") & "' "

        If iFigura.Length > 0 Then lSql = lSql & "and figura ='" & iFigura.Replace("'", "''") & "' "

        If iSector.Length > 0 Then lSql = lSql & "and sector like '%" & iSector.Replace("'", "''") & "%' "

        If iMarca.Length > 0 Then lSql = lSql & "and Marca='" & iMarca & "' "

        lSql = lSql & " and idObra =" & iIdObra
        lSql = lSql & " and p.estado<>'00'  order by p.id desc "
        lTbl = CargaTabla(lSql)

        For i = 0 To lTbl.Rows.Count - 1
            lSql = " select * from piezas p1, Viaje v  where p1.IdpiezaTipoB=" & lTbl.Rows(i)("IdPiezaDig").ToString
            lSql = lSql & "  and IdViaje=v.id  and v.estado<>'AN' and P1.estado<>'00' "
            lTblTmp = CargaTabla(lSql)
            lStr = ""
            For j = 0 To lTblTmp.Rows.Count - 1
                lStr = lStr & lTblTmp.Rows(j)("COdigo").ToString & ","
            Next
            If lStr.Length > 0 Then
                lTbl.Rows(i)("VIaje") = lStr.Substring(0, lStr.Length - 1)
            End If

        Next
        Return lTbl
    End Function

    Private Function ObtenerFactorKilos(ByVal iLargo As Single, ByVal iTipoForma As Integer) As Integer
        Dim lRes As Integer = 1000
        Select Case iLargo
            Case 9, 12, 15, 18
                If iTipoForma = 1 Then
                    lRes = 2000
                End If
        End Select
        Return lRes
    End Function

    Private Function ObtenerFactorKilosPorDiametro(ByVal iLargo As Single, ByVal iTipoForma As Integer, iDiametro As Integer, iAsigandas As Integer, iCantTotal As Integer, iKilosTotal As Integer, iObra As Integer) As Integer
        '*** Obtenemos los kilos de 1 Pieza  Kg 1Pieza= KgsTotales/NroPiezasTotales
        '1) Cuando es por unidad ==> Nro Piezas * Kilos Por 1 Pieza 
        '2) cuando es por Kilo   ==>  No se hace Nada
        Dim lKgsXPieza As Double = Math.Round((iKilosTotal / iCantTotal), 3), lNroPiezas As Integer = 0
        Dim lRes As Double = 1000, llDts As New DataSet, lTblObrasQB As New DataTable, lVista As DataView = Nothing, lTipo As String = "N"
        '02/08/2019 
        ' se agrega una division especial para  las obras de quebrada Blanca mantis 1259
        llDts = ObtenerParametros("ObrasQB")
        If llDts.Tables.Count > 0 Then
            lTblObrasQB = llDts.Tables(0)
            lVista = New DataView(lTblObrasQB, String.Concat("PAr1='", iObra, "'"), "", DataViewRowState.CurrentRows)
            If lVista.Count > 0 Then
                lTipo = "Q"
            End If
        End If

        If lTipo = "N" Then
            Select Case iTipoForma
         'Tipo 4 en Unidades Diam 8,10,12 =>50 piezas, Diam 16,18=>25, Diam 22,25,28=>20 diam 32, 36=>15 por paquete
                Case 4
                    lNroPiezas = 0
                    Select Case iDiametro
                        Case 8, 10, 12 : lNroPiezas = 50
                        Case 16, 18 : lNroPiezas = 25
                        Case 22, 25, 28 : lNroPiezas = 20
                        Case 32, 36 : lNroPiezas = 15
                    End Select
                    lRes = Math.Round((lKgsXPieza * lNroPiezas), 0)
                Case 5, 60, 102
                    'Tipo 5 en Unidades Diam 8,10,12 =>80 piezas, Diam 16,18=>60, Diam 22,25,28=>40 diam 32, 36=>25 por paquete
                    'caso 0001149 mantis agregar a la tabla de cantidades y formas por paquete las barras tipo 60 y 102 (ambas trabas)
                    'y aplicar cantidades y diámetros similar a los de las barra tipo 5.
                    lNroPiezas = 0
                    Select Case iDiametro
                        Case 8, 10, 12 : lNroPiezas = 80
                        Case 16, 18 : lNroPiezas = 60
                        Case 22, 25, 28 : lNroPiezas = 40
                        Case 32, 36 : lNroPiezas = 25
                    End Select
                    lRes = Math.Round((lKgsXPieza * lNroPiezas), 0)
                Case 1, 2
                    'Tipo 1 y 2 en Kilos, para todos los diam 1000Kgs por paquete
                    lRes = 1000
                Case 3
                    If iLargo < 7 Then
                        'Tipo 3 de 1 a 6 mts de Largo 
                        'Diam 8, 10, 12,16, 18 >= 80, Diam 22, 25, 28 >= 50 diam 32=>30 diam  36 >= 25 por paquete
                        Select Case iDiametro
                            Case 8, 10, 12, 16, 18 : lNroPiezas = 80
                            Case 22, 25, 28 : lNroPiezas = 50
                            Case 32 : lNroPiezas = 30
                            Case 36 : lNroPiezas = 25
                        End Select
                        lRes = Math.Round((lKgsXPieza * lNroPiezas), 0)
                    Else
                        'Tipo 3 de 7 a 12 mts de Largo  en Kilos por Paquete
                        'Diam 8 10, 12,16 => 500 Kgs, Diam 18,22, 25  >= 1000 Kgs diam 28, 32, 36 => 800 Kgs  por paquete
                        Select Case iDiametro
                            Case 8, 10, 12, 16 : lRes = 500
                            Case 18, 22, 25 : lRes = 1000
                            Case 28, 32, 36 : lRes = 800
                        End Select
                    End If
                Case 30
                    'Tipo 30 en Unidades Diam 8=>40, diam 10=>30 Diam 12,16,18 =>25 diam 22,25,28=>20 diam 32, 36=>15 por paquete
                    Select Case iDiametro
                        Case 8 : lNroPiezas = 40
                        Case 10 : lNroPiezas = 30
                        Case 12, 16, 18 : lNroPiezas = 25
                        Case 22, 25, 28 : lNroPiezas = 20
                        Case 32, 36 : lNroPiezas = 15
                    End Select
                    lRes = Math.Round((lKgsXPieza * lNroPiezas), 0)
                Case 78  'Segun req de Darek T  mantis:0001045
                    'se requiere que la forma tipo 78 no tenga restricción de kilos al generar los paquetes en la pre-IT
                    lRes = iKilosTotal + 100

                Case 214   ' Segun Mantis 0001214, G. Bobadilla
                    '5-6-8-11-12-13-14-15-16-17-18-60-61-70-72-73-74-77-100-101-102-103-105-106-107-108-115-123-127-128-
                    '130-144-149-161-163-171-174-187-202-203-204-211-212-213-214
                    Select Case iDiametro
                        Case 8, 10, 12 : lNroPiezas = 50
                        Case 16, 18 : lNroPiezas = 25
                        Case 22, 25, 28 : lNroPiezas = 20
                        Case 32, 36 : lNroPiezas = 15
                    End Select
                    lRes = Math.Round((lKgsXPieza * lNroPiezas), 0)
                Case Else
                    lRes = 1000
            End Select
        Else
            '02/08/2019 
            ' se agrega una division especial para  las obras de quebrada Blanca mantis 1259
            Select Case iTipoForma
                Case 4, 5, 6, 8, 11, 12, 13, 14, 15, 16, 17, 18, 30, 51, 60, 61, 69, 70, 72, 73, 74, 77, 100, 101, 102, 103, 105, 106, 107, 108, 115, 123, 127, 128, 130, 144, 149, 161, 163, 171, 174, 187, 202, 203, 204, 211, 212, 213, 214
                    Select Case iDiametro
                        Case 8, 10, 12 : lNroPiezas = 50
                        Case 16, 18 : lNroPiezas = 25
                        Case 22, 25, 28 : lNroPiezas = 20
                        Case 32, 36 : lNroPiezas = 15
                    End Select
                    lRes = Math.Round((lKgsXPieza * lNroPiezas), 0)
                Case Else
                    lRes = 1000
            End Select

        End If

        '******El factor de calculo sera en Kilos

        'Select Case iLargo
        '    Case 9, 12, 15, 18
        '        If iTipoForma = 1 Then
        '            lRes = 2000
        '        End If
        'End Select
        Return lRes
    End Function

    Public Function ObtenerDatosViaje(ByVal iPiezasT As String, ByVal iKilosT As String, ByVal iAsigandas As String, ByVal iMarca As String, ByVal iPlano As String, ByVal iObra As String, ByVal iFActor As Integer, ByVal IdPiezaTipoB As Integer) As String
        Dim lRes As String = "", lR As Integer = 1000, lG As Integer = 0, lKilosAsignados As Double = 0
        Dim lv As Integer = 0, lH1 As Double = 0, lH2 As Integer = 0, lKilosxPieza As Double = 0, lTotalPieza As Double = 0
        Dim lSaldoPiezas As Integer = 0, lKilosSaldo As Double = 0, lPartes() As String = Nothing
        Dim lTmp As Double = 0, lKgs As New Cls_DatosInformes, lsql As String = "", lTbl As New DataTable
        Dim lLargo As Single = 0, iDiam As String = "", lLog As String = "", lIdForma As Integer = 0, lKgsNorma353 As Double = 0
        Dim lTipoObra As String = "N", iCant As Integer = 0, iTotalKgs As Integer = 0, iNorma353 As String = "N"
        '(C*R)/D = H1		Aproximar H1 hacia abajo	
        Try
            'lsql = "Select Largo,Diametro , IdForma from  piezasTipoB p, hojadespiece hd  where Plano='" & iPlano & "' and MArca='"
            lsql = "Select Largo,Diametro , IdForma, cantidad, totalKgs,  isnull(o.norma353,'N')  as norma353  from  piezasTipoB p, hojadespiece hd, obras o   where  MArca='"
            lsql = lsql & iMarca.Replace("'", "''") & "' and   p.id_hd=hd.id  and idObra=" & iObra & " and o.id= idobra   and p.Id=" & IdPiezaTipoB
            lTbl = CargaTabla(lsql)
            If Not lTbl Is Nothing AndAlso lTbl.Rows.Count > 0 Then
                lLargo = lTbl.Rows(0)("Largo")
                iDiam = lTbl.Rows(0)("Diametro")
                lIdForma = lTbl.Rows(0)("IdForma")
                iCant = lTbl.Rows(0)("cantidad")
                iTotalKgs = lTbl.Rows(0)("totalKgs")
                iNorma353 = lTbl.Rows(0)("norma353")
            End If
            ' Se agrega linea segun Req
            lR = ObtenerFactorKilosPorDiametro(lLargo, lIdForma, iDiam, iAsigandas, iCant, iTotalKgs, iObra)
            'If iFActor = 0 Then
            '    'lR = ObtenerFactorKilos(lLargo, lIdForma)
            '    lR = ObtenerFactorKilosPorDiametro(lLargo, lIdForma, iDiam, iAsigandas, iCant, iTotalKgs)
            'Else
            '    lR = iFActor
            'End If
            lLog = " Asig:" & iAsigandas & " Largo:" & lLargo & "Diam : " & iDiam
            'lTipoObra = lKgs.ObtenerTipoObraPorIdObra(iObra)
            'If lTipoObra.ToUpper.Equals("B") Then
            lLargo = lLargo '* 100
            lKilosxPieza = lKgs.CalcularPesoPorObra(lLargo, iDiam, iAsigandas, iObra) 'Val(iKilosT) / (iPiezasT)
            ' Debemos verificar si la obra es norma353
            If iNorma353 = "S" Then
                If AgregarUnoPorciento(lIdForma, lLargo) = True Then
                    lKgsNorma353 = Math.Round(lKilosxPieza * (1 / 100), 3)
                    lTotalPieza = lKilosxPieza
                    lTotalPieza = lKilosxPieza + lKgsNorma353
                    lTotalPieza = Math.Round(CDbl(lTotalPieza), 0)
                    lKilosxPieza = lTotalPieza
                End If
            End If

            lKilosAsignados = lKilosxPieza 'lKilosxPieza * iAsigandas
            lSaldoPiezas = iPiezasT - iAsigandas
            If lSaldoPiezas <> 0 Then
                lKilosSaldo = lKgs.CalcularPesoPorObra(lLargo, iDiam, lSaldoPiezas, iObra) 'lSaldoPiezas * lKilosxPieza
            Else
                lKilosSaldo = 0
            End If
            lH1 = Val(iAsigandas) * lR / lKilosAsignados

            'lLog = "Despues de calcular H1"

            If lH1.ToString.IndexOf(",") > -1 Then
                lPartes = lH1.ToString.Split(",")
            End If
            If lH1.ToString.IndexOf(".") > -1 Then
                lPartes = lH1.ToString.Split(".")
            End If
            If Not lPartes Is Nothing Then
                lH1 = lPartes(0)
            End If
            'lLog = "Despues de Asignar H1"
            'lPartes = lH1.ToString.Split(",")
            If lH1 > 0 Then 'lPartes.Length > 0 Then
                lTmp = (Val(iAsigandas) / lH1)
                lPartes = Nothing
                ' lLog = "Despues de Asignar ltmp"
                If lTmp.ToString.IndexOf(",") > -1 Then
                    lPartes = lTmp.ToString.Split(",")
                End If
                If lTmp.ToString.IndexOf(".") > -1 Then
                    lPartes = lTmp.ToString.Split(".")
                End If
                'lLog = "antes de Asignar LG largo :" & lPartes.Length
                If Not lPartes Is Nothing AndAlso lPartes.Length > 1 Then
                    'lLog = " por verdarero largo :" & lPartes.Length
                    lG = lPartes(0) + 1
                Else
                    lLog = " por false lTmp Asig:" & iAsigandas & " H1:" & lH1 & "KilosPieza: " & lKilosxPieza & "  --"
                    lLog = " Largo" & lLargo & " iDiam:" & iDiam & "  --"
                    lG = lTmp  '0 'lPartes(0)
                End If
                'lG = (Val(iAsigandas) / lH1) '+ 1
                lLog = "Antes de Asignar lV"
                lv = (lG - 1) * lH1
                lH2 = iAsigandas - lv

            End If
            lRes = String.Concat(iAsigandas, "|", lKilosAsignados, "|", lSaldoPiezas, "|", lKilosSaldo, "|", lG, "|", lH1, "|", lH2, "|", lR, " (Largo:", lLargo, "-Forma:", lIdForma, ") |", lR)
            lLog = lRes
        Catch ex As Exception
            lRes = "E: " & lLog
            Dim lErrror As String = "ClsDatos.ObtenerDatosViaje. " & ex.Message.ToString
            RegistraError(lErrror)
        End Try
        Return lRes
    End Function
    Public Function AgregarUnoPorciento(iIdForma As String, iLargo As String) As Boolean
        Dim lRes As Boolean = True
        'Para piezas con ID=1 y "largo teórico"= 7, 8, 9, 10, 11 y 12 m, 
        'se debe mostrar solo el peso teórico habitual sin el 1% adicional.
        'A esta funcion llegan 2 tipos de valores en mm ej: 12000 y en Mts Ej:7,13

        If Val(iIdForma) = 1 Then
            Select Case CDbl(iLargo)
                Case 7000, 8000, 9000, 10000, 11000, 12000, 7, 8, 9, 10, 11, 12
                    lRes = False
            End Select
        End If

        Return lRes
    End Function
    Public Function ObtenerDatosViajePorIdMov(ByVal iPiezasT As String, ByVal iKilosT As String, ByVal iAsigandas As String, ByVal iIdMov As String, ByVal iFActor As Integer) As String
        Dim lRes As String = "", lR As Integer = 1000, lG As Integer = 0, lKilosAsignados As Double = 0
        Dim lv As Integer = 0, lH1 As Double = 0, lH2 As Integer = 0, lKilosxPieza As Double = 0
        Dim lSaldoPiezas As Integer = 0, lKilosSaldo As Double = 0, lPartes() As String = Nothing
        Dim lTmp As Double = 0, lKgs As New Cls_DatosInformes, lsql As String = "", lTbl As New DataTable
        Dim lLargo As Single = 0, iDiam As String = "", lLog As String = "", lIdForma As Integer = 0
        Dim lTipoObra As String = "N", lIdObra As String = ""
        '(C*R)/D = H1		Aproximar H1 hacia abajo	
        Try
            lsql = "Select Largo,Diametro , IdForma , m.idObra  from  piezasTipoB p, Movimientos m  where m.Id=" & iIdMov
            lsql = lsql & " and   m.IdPiezaTipoB=P.id and p.estado<>'00' and m.estado<>'00' " 'and idObra=" & iObra
            lTbl = CargaTabla(lsql)
            If Not lTbl Is Nothing AndAlso lTbl.Rows.Count > 0 Then
                lLargo = lTbl.Rows(0)("Largo")
                iDiam = lTbl.Rows(0)("Diametro")
                lIdForma = lTbl.Rows(0)("IdForma")
                lIdObra = lTbl.Rows(0)("IdObra")
            End If
            ' Se agrega linea segun Req
            If iFActor = 0 Then
                lR = ObtenerFactorKilos(lLargo, lIdForma)
            Else
                lR = iFActor
            End If
            lLog = " Asig:" & iAsigandas & " Largo:" & lLargo & "Diam : " & iDiam
            lKilosxPieza = lKgs.CalcularPesoBetchell_PorObra(lLargo, iDiam, lSaldoPiezas, lIdObra, lIdForma) 'Val(iKilosT) / (iPiezasT)
            'lLog = "Despues de calcular PEso"
            lKilosAsignados = lKilosxPieza 'lKilosxPieza * iAsigandas
            lSaldoPiezas = iPiezasT - iAsigandas
            If lSaldoPiezas <> 0 Then
                lKilosSaldo = lKgs.CalcularPesoBetchell_PorObra(lLargo, iDiam, lSaldoPiezas, lIdObra, lIdForma) 'lSaldoPiezas * lKilosxPieza
            Else
                lKilosSaldo = 0
            End If
            lH1 = Val(iAsigandas) * lR / lKilosAsignados

            'lLog = "Despues de calcular H1"

            If lH1.ToString.IndexOf(",") > -1 Then
                lPartes = lH1.ToString.Split(",")
            End If
            If lH1.ToString.IndexOf(".") > -1 Then
                lPartes = lH1.ToString.Split(".")
            End If
            If Not lPartes Is Nothing Then
                lH1 = lPartes(0)
            End If
            'lLog = "Despues de Asignar H1"
            'lPartes = lH1.ToString.Split(",")
            If lH1 > 0 Then 'lPartes.Length > 0 Then
                lTmp = (Val(iAsigandas) / lH1)
                lPartes = Nothing
                ' lLog = "Despues de Asignar ltmp"
                If lTmp.ToString.IndexOf(",") > -1 Then
                    lPartes = lTmp.ToString.Split(",")
                End If
                If lTmp.ToString.IndexOf(".") > -1 Then
                    lPartes = lTmp.ToString.Split(".")
                End If
                'lLog = "antes de Asignar LG largo :" & lPartes.Length
                If Not lPartes Is Nothing AndAlso lPartes.Length > 1 Then
                    'lLog = " por verdarero largo :" & lPartes.Length
                    lG = lPartes(0) + 1
                Else
                    lLog = " por false lTmp Asig:" & iAsigandas & " H1:" & lH1 & "KilosPieza: " & lKilosxPieza & "  --"
                    lLog = " Largo" & lLargo & " iDiam:" & iDiam & "  --"
                    lG = lTmp  '0 'lPartes(0)
                End If
                'lG = (Val(iAsigandas) / lH1) '+ 1
                lLog = "Antes de Asignar lV"
                lv = (lG - 1) * lH1
                lH2 = iAsigandas - lv

            End If
            lRes = String.Concat(iAsigandas, "|", lKilosAsignados, "|", lSaldoPiezas, "|", lKilosSaldo, "|", lG, "|", lH1, "|", lH2, "|", lR, " (Largo:", lLargo, "-Forma:", lIdForma, ")")
            lLog = lRes
        Catch ex As Exception
            lRes = "E: " & lLog
            Dim lErrror As String = "ClsDatos.ObtenerDatosViajePorIdMov. " & ex.Message.ToString
            RegistraError(lErrror)
        End Try
        Return lRes
    End Function

#End Region


    Public Function CargaTabla(ByVal isql As String) As Data.DataTable
        Dim lCnnstr As String = ObtenerCnn()
        'Dim lCnn As New SqlConnection(lCnnStr)
        Dim lCnn As New SqlConnection(lCnnstr)
        Dim lAdp As New SqlDataAdapter(isql, lCnn)
        Dim lTabla As New Data.DataTable
        Try
            If (isql.Length > 5) Then
                lAdp.SelectCommand.CommandTimeout = 200
                lAdp.Fill(lTabla)
            End If
        Catch ex As Exception
            Dim lErrror As String = "ClsDatos.CargaTabla " & ex.Message.ToString & " sql: " & isql
            RegistraError(lErrror)
        End Try

        Return lTabla
    End Function


    Public Function CargaTipoTabla(ByVal isql As String) As TipoTabla
        Dim lCnnstr As String = ObtenerCnn()
        'Dim lCnn As New SqlConnection(lCnnStr)
        Dim lCnn As New SqlConnection(lCnnstr)
        Dim lAdp As New SqlDataAdapter(isql, lCnn)
        Dim lTabla As New Data.DataTable, lRes As New TipoTabla
        Try
            lAdp.Fill(lTabla)
            lRes.Tabla = lTabla.Copy
        Catch ex As Exception
            Dim lErrror As String = "ClsDatos.CargaTabla " & ex.Message.ToString & " sql: " & isql
            lRes.Errors = lErrror
            RegistraError(lErrror)
        End Try

        Return lRes
    End Function

    Public Function GrabaLogImpresion(ByVal iModulo As String, ByVal iUser As String, ByVal iObs As String, ByVal iCodViaje As String) As String
        Dim lRes As Integer = 0
        Dim lSql As String = "Insert Into LogImpresion (Modulo, Usuario, Fecha, Obs , CodViaje) Values ('"
        lSql = String.Concat(lSql, iModulo, "','", iUser, "',getdate(),'", iObs, "','", iCodViaje & "')")
        lRes = EjecutaDML(lSql)
        If lRes > 0 Then
            Return "OK"
        Else
            Return "ERROR"
        End If
    End Function

    Public Function ObtenerUsuario(ByVal iUser As String, ByVal iPass As String) As DataSet
        Dim lDts As New DataSet, lTbl As New DataTable, lPerfil As String = ""
        Dim lres As String = " select Id,Dir,Fono2,FonoMovil,Mail,Nombre,Apellidos,Perfil,Usuario, Vigente, RecibeMsg,Empresa, "
        lres = lres & "(Select Par1 from to_parametros p  where p.id=Perfil)  DescPerfil  "
        lres = lres & " From to_usuarios where Usuario='" & iUser & "' and Pass='" & iPass & "'"
        lTbl = CargaTabla(lres) : lTbl.TableName = "Usuario"
        lDts.Tables.Add(lTbl)
        If lTbl.Rows.Count > 0 Then
            lPerfil = lTbl.Rows(0)("Perfil").ToString
            'lres = " select * from AccesosModulo am, Modulos m where idPerfil=" & lPerfil
            'lres = lres & " and m.id=am.IdModulo "
            lres = " select AU.*,m.descripcion,m.Tipo,m.Codigo  from accesos_usuarios AU, to_usuarios U ,modulos m "
            lres = lres & " where u.id=AU.IdUsuario and u.Id=" & lTbl.Rows(0)("Id")
            lres = lres & "  and m.id=AU.IdModulo  "
            lTbl = CargaTabla(lres) : lTbl.TableName = "Accesos"
            lDts.Tables.Add(lTbl)
        End If
        Return lDts
    End Function

    Public Function ObtenerUsuarioTOSOL(ByVal iUser As String, ByVal iPass As String) As DataSet
        Dim lDts As New DataSet, lTbl As New DataTable, lPerfil As String = ""
        Dim lres As String = " select Id,Dir,Fono2,FonoMovil,Mail,Nombre,Apellidos,Perfil,Usuario, Vigente, RecibeMsg,Empresa "
        lres = lres & " From to_usuarios where Usuario='" & iUser & "' and Pass='" & iPass & "' and Empresa='TOSOL'"
        lTbl = CargaTabla(lres) : lTbl.TableName = "Usuario"
        lDts.Tables.Add(lTbl)
        If lTbl.Rows.Count > 0 Then
            lPerfil = lTbl.Rows(0)("Perfil").ToString
            'lres = " select * from AccesosModulo am, Modulos m where idPerfil=" & lPerfil
            'lres = lres & " and m.id=am.IdModulo "
            lres = " select AU.*,m.descripcion,m.Tipo,m.Codigo  from accesos_usuarios AU, to_usuarios U ,modulos m "
            lres = lres & " where u.id=AU.IdUsuario and u.Id=" & lTbl.Rows(0)("Id")
            lres = lres & "  and m.id=AU.IdModulo  "
            lTbl = CargaTabla(lres) : lTbl.TableName = "Accesos"
            lDts.Tables.Add(lTbl)
        End If
        Return lDts
    End Function


    Public Function ObtenerResumenEtiquetasPorViaje(ByVal iIdViaje As String) As DataTable
        Dim lSql As String = " select diametro, count (1) Cantidad ,round(sum(p.TotalKgs),0) Peso"
        lSql = lSql & " from piezas p , Viaje v  where p.Estado<>'00' and  p.IdViaje=v.Id and  Codigo='" & iIdViaje & "' group by diametro"
        Dim lTbl As New DataTable
        ' Dim lDts As New DataSet
        lTbl = CargaTabla(lSql)
        lTbl.TableName = "ResumenDesp"
        Return lTbl
    End Function

    Public Function ObtenerCorrelativoIT(ByVal iIdObra As String) As String
        Dim lSql As String = " select max(nroIt) from it where idObra=" & iIdObra & " and estado not in ('AN','00')"
        Dim lTbl As New DataTable, lRes As String = ""
        lTbl = CargaTabla(lSql)
        If lTbl.Rows.Count > 0 Then
            lRes = Val(lTbl.Rows(0)(0).ToString) + 1
        Else
            lRes = 1
        End If

        Return lRes
    End Function

    Public Function ObtenerTipoIt(ByVal iFechaDespacho As Date, ByVal iFechaActual As Date) As String
        Dim lDifDias As Integer = Math.Abs(DateDiff("D", iFechaActual, iFechaDespacho))
        Dim lRes As String = "", lTblTipos As New DataTable, lDias As Integer = 0
        Dim lFilas() As DataRow = Nothing
        lTblTipos = CargaTabla("Select * from To_parametros where SubTabla='TipoIT'")
        If Not lTblTipos Is Nothing AndAlso lTblTipos.Rows.Count > 0 Then
            lDias = Val(lTblTipos.Rows(0)("Par2").ToString)
            If lDias > 0 Then
                If lDifDias < lDias Then
                    lFilas = lTblTipos.Select("Par1='-'", "")
                Else
                    lFilas = lTblTipos.Select("Par1='+'", "")
                End If
                If lFilas.Length > 0 Then
                    lRes = lFilas(0)("Descripcion").ToString
                End If
            End If
        End If
        Return lRes
    End Function

    Public Function ObtenerUsuarios(ByVal iEmpresa As String) As List(Of BussinesObjects.Tipos.Tipo_Usuario)
        Dim lDAl As New BussinesObjects.Clases.Cls_Datos
        Return lDAl.ConsultaUsuarios(New BussinesObjects.Tipos.Tipo_Usuario, iEmpresa)
    End Function
    Public Function ObtenerObras(Optional ByVal iTodasLasObras As Boolean = False) As List(Of BussinesObjects.Tipos.Tipo_Obra)
        Dim lDAl As New ClsB_O
        Return lDAl.ConsultaObras(New BussinesObjects.Tipos.Tipo_Obra, iTodasLasObras)
    End Function
    Public Function ObtenerObras(idUser As Integer, Optional ByVal iTodasLasObras As Boolean = False) As List(Of BussinesObjects.Tipos.Tipo_Obra)
        Dim lDAl As New ClsB_O
        Return lDAl.ConsultaObras(New BussinesObjects.Tipos.Tipo_Obra, idUser, iTodasLasObras)
    End Function

#Region "Obtener Nombre de obra  "
    Public Function ObtenerNombreObraPorId(ByVal iIdObra As String) As String
        Dim lDal As New ClsDatos, lTbl As New DataTable, lRes As String = "0"
        Dim lSql As String = "Select Nombre from obras where Id=" & iIdObra
        lTbl = lDal.CargaTabla(lSql)
        If Not lTbl Is Nothing AndAlso lTbl.Rows.Count > 0 Then
            lRes = lTbl.Rows(0)(0).ToString
        End If
        Return lRes
    End Function
#End Region

    Public Function ObtenerObrasParaImprimir(ByVal iUser As String) As DataTable

        Dim lsql As String = "", lTblObras As New DataTable
        lsql = "Exec SP_CONSULTAS_GENERALES_ADM_OBRAS 0,0,'','','','',16"
        lTblObras = CargaTabla(lsql)

        If lTblObras.Rows.Count > 0 Then
            Dim lFila As DataRow = lTblObras.NewRow
            lFila(0) = "0"
            lFila(1) = "Todas"
            lTblObras.Rows.Add(lFila)
        End If
        Return lTblObras
    End Function
    Public Function ObtenerPerfiles() As Data.DataTable
        Dim lDAl As New BussinesObjects.Clases.Cls_Datos
        Return lDAl.ObtenerPerfiles()
    End Function

    Public Function ObtenerDetalleUsuarioLogeado(ByVal iIdUser As String) As BussinesObjects.Tipos.Tipo_UserLogeado
        Dim lDAl As New BussinesObjects.Clases.Cls_Datos
        Return lDAl.ObtenerUltimoAcceso(iIdUser)
        Return Nothing
    End Function

    Public Function MensajesUsuario(ByVal iIdUser As String) As String
        Dim lDAl As New BussinesObjects.Clases.Cls_Datos
        Return lDAl.TieneMensajes(iIdUser)
    End Function
    Public Function TextosMensajesUsuario(ByVal iIdUser As String, ByVal iTipo As String) As List(Of BussinesObjects.Tipos.TipoMsgUser)
        Dim lDAl As New BussinesObjects.Clases.Cls_Datos
        Return lDAl.ObtenerMensajesPorUser(iIdUser, iTipo)
    End Function
    'ObtenerMensajesPorUser
    Public Function ObtenerObrasVigentes() As DataTable
        'Dim lSql As String = "select Id, Nombre  from obras where estado in ('3','S') "
        Dim lSql As String = "select Id, Nombre, TipoObra  from obras where estado in ('3','S')  and EstadoAlta not in ('FIN' ) order by nombre asc "
        Return CargaTabla(lSql)
    End Function
    Public Function ObtenerViajesVigentes(ByVal iIdObra As String) As DataTable
        'Dim lSql As String = "select Id, Nombre  from obras where estado in ('3','S') "
        Dim lSql As String = "select * from viaje v, It where v.IdIt=It.id and v.Estado<>'00' and IdObra=" & iIdObra
        Return CargaTabla(lSql)
    End Function
    Public Function ObtenerPlanosBetchtell(ByVal iIdObra As String) As DataTable
        Dim lSql As String = "select distinct plano from  hojadespiece hd, obras o"
        lSql = lSql & "  where  IdObra=O.id and O.Id=" & iIdObra 'and tipoObra='B'  
        lSql = lSql & " and Vigente='S'  Order by plano asc  "
        Return CargaTabla(lSql)
    End Function
    Public Function ObtenerObrasCivilesVigentes() As DataTable
        Dim lSql As String = "select Id, Nombre  from obras where estado=3 and TipoObra='C' "
        Return CargaTabla(lSql)
    End Function
    Public Function ObtenerDiametros() As DataTable
        Dim lSql As String = "select par1 as diametro from to_parametros where SubTabla='Diametro'"
        Return CargaTabla(lSql)
    End Function
    Public Function ObtenerFormas() As DataTable
        Dim lSql As String = "Select distinct IdForma from imagenformas where IdForma>0 order by  IdForma "
        Return CargaTabla(lSql)
    End Function
    '
    Public Function ObtenerFormasSinVerificar() As DataTable
        Dim lSql As String = "select par1 as idForma from to_parametros where SubTabla='NoEvaluar'"
        Return CargaTabla(lSql)
    End Function
    Public Function ObtenerTamañoFuenteImagenForma() As DataTable
        Dim lSql As String = "select * from to_parametros where subTabla='Fuente' "
        Return CargaTabla(lSql)
    End Function

    Public Function ObtenerFormasVariables() As DataTable
        Dim lSql As String = "select *  from formasVariables "
        Return CargaTabla(lSql)
    End Function


    Public Function ObtenerFormasConHilos() As DataTable
        Dim lSql As String = "  select * from to_parametros where subTabla='Hilos'  "
        Return CargaTabla(lSql)
    End Function

    Public Function ObtenerObrasConHilos() As DataTable
        Dim lSql As String = "  select * from to_parametros where subTabla='ObrasHilos'  "
        Return CargaTabla(lSql)
    End Function

    Public Function ObtenerPiezaPorObra(ByVal iIdObra As String) As DataTable
        Dim lSql As String = " select distinct pieza from hojadespiece hd,piezas p where p.estado<>'00' and IdObra=" & iIdObra & " and p.Id_hd=hd.id"
        Return CargaTabla(lSql)
    End Function

    Public Function ObtenerTiposCamion() As DataTable
        Dim lSql As String = " select * from to_parametros where subtabla='PesoCamion' "
        Return CargaTabla(lSql)
    End Function




    Public Function InsertaAcceso(ByVal iIdUser As String) As String
        Dim lDAl As New BussinesObjects.Clases.Cls_Datos
        Return lDAl.InsertaAcceso(iIdUser)
    End Function

    Public Function ObtenerDatosParaArbol(ByVal iIdObra As String, ByVal iTipo As String) As DataTable
        'Dim lSql As String = "select obra, p.ubicacion ubicacion ,hd.ubicacion ubicacion1, count (1) from piezas p, hojadespiece hd  "
        'lSql = String.Concat(lSql, " where p.Id_Hd = hd.Id And estado = '3'  group by  obra, p.ubicacion , hd.ubicacion")

        Dim lSql As String = ""
        Select Case iTipo
            Case "T"
                lSql = "select obra, p.ubicacion ,count (1), round(sum(Totalkgs),0) Kilos, IdObra  from piezas p, hojadespiece hd  "
                lSql = String.Concat(lSql, " where p.Estado<>'00' and  p.Id_Hd = hd.Id And estado = '3' group by  obra,IdObra, p.ubicacion,figura ")
                lSql = String.Concat(lSql, " order by  p.ubicacion  ")
            Case "TP"
                lSql = "select obra, p.ubicacion ,count (1), round(sum(Totalkgs),0) Kilos, IdObra  from piezas p, hojadespiece hd  "
                lSql = String.Concat(lSql, " where p.Estado<>'00' and  p.Id_Hd = hd.Id And estado in ('40','3') group by  obra,IdObra, p.ubicacion")
                lSql = String.Concat(lSql, " order by  p.ubicacion ")
            Case Else
                lSql = "select obra, p.ubicacion ,figura, count (1), round(sum(Totalkgs),0) Kilos, IdObra  from piezas p, hojadespiece hd  "
                lSql = String.Concat(lSql, " where p.Estado<>'00' and  p.Id_Hd = hd.Id And estado in('3','I','5') and IdObra=" & iIdObra & "  group by  obra,IdObra, p.ubicacion,figura ")
                lSql = String.Concat(lSql, " order by  p.ubicacion,figura  ")
        End Select
        Return CargaTabla(lSql)
        'iTipo
    End Function

#Region "Obtener Nro de Kilos Maximos por obra "
    Public Function ObtenerPesoMaxPorObra(ByVal iIdObra As String) As String
        Dim lTabla As New DataTable
        Dim lRes As String = ""
        Dim lsql As String = "select PesoMaxObra from Obras where nombre='" & iIdObra.Trim & "'"
        lTabla = CargaTabla(lsql)
        If lTabla.Rows.Count > 0 Then
            lRes = lTabla.Rows(0)(0).ToString
        End If
        Return lRes
    End Function
#End Region


    ''' <summary>
    ''' Obtiene las piezas que se asociaran a una IT
    ''' </summary>
    ''' <param name="iObras"> String con las obras Seleccionadas </param>
    ''' <param name="iUbicaciones">Ubicaciones  seleccionadas </param>
    ''' <param name="iElementos">  Elementos  seleccionadas </param>
    ''' <returns>Un Objeto datatable </returns>
    ''' <remarks></remarks>    
    Public Function ObtenerPiezasParaIT(ByVal iObras As String, ByVal iUbicaciones As String, ByVal iElementos As String, ByVal iUbic2 As String, ByVal lIdsGr As ArrayList) As DataTable
        Dim lTabla As New DataTable, i As Integer = 0, lTblUb As New DataTable, lTblEl As New DataTable
        Dim lTblUbi2 As New DataTable
        Dim lObrasABuscar As String = "", lUbicABuscar As String = "", lElemABuscar As String = "", lUbic2ABuscar As String = ""
        Dim lPartes() As String = Nothing, lSql As String = ""
        'Dim lsqlGen As String = "   select p.Id IdPieza, sum(TotalKgs) Kgs, Diametro, count(1) NroLam  from piezas p, hojadespiece hd   "
        'lsqlGen = String.Concat(lsqlGen, " where p.Id_Hd = hd.Id And estado = '3'   ")
        'Dim lsqlGen As String = "   select p.Id IdPieza, round(TotalKgs,0) Kgs,ubicacionFull,  hd.Ubicacion Ubicacion  "
        Dim lsqlGen As String = "   select p.Id IdPieza, TotalKgs  Kgs,ubicacionFull,  hd.Ubicacion Ubicacion , Figura ,"
        lsqlGen = String.Concat(lsqlGen, " (Select Top 1 isnull(pb.EsvaPero_Nova,'N') from  piezastipob pb where pb.id=p.idpiezatipob ) 'TieneFC' ")
        lsqlGen = String.Concat(lsqlGen, " from piezas p, hojadespiece hd  where p.Estado<>'00' and  p.Id_Hd = hd.Id And estado in ('3','I','5')   ")

        'Primero las Obras 
        If iObras.Trim.Length > 0 Then
            lPartes = iObras.Split("|")
            For i = 0 To lPartes.Length - 1
                If lPartes(i).Trim.Length > 0 Then
                    lObrasABuscar = String.Concat(lObrasABuscar, "'", lPartes(i), "',")
                End If
            Next
            lObrasABuscar = lObrasABuscar.Substring(0, lObrasABuscar.Length - 1)
            lSql = String.Concat(lsqlGen, " and obra in (", lObrasABuscar, ")    ")
            lTabla = CargaTabla(lSql)
        End If
        ' Ahora las ubicaciones  'OBRA DE EJEMPLO/4 Subterráneo|
        If iUbicaciones.Trim.Length > 0 Then
            lPartes = iUbicaciones.Split("|")
            lUbicABuscar = "" : lSql = ""
            For i = 0 To lPartes.Length - 1
                If lPartes(i).Trim.Length > 0 Then
                    lUbicABuscar = String.Concat("'", lPartes(i).Replace("'", "''"), "%' or ")
                    lUbicABuscar = lUbicABuscar.Replace("/", "|")
                    lSql = String.Concat(lSql, " ubicacionFull like ", lUbicABuscar, "")
                End If
            Next
            lSql = String.Concat(lsqlGen, " and (", lSql.Substring(0, lSql.Length - 3), ")  ") ' group by p.diametro")          
            lTblUb = CargaTabla(lSql)
        End If
        'Ahora los Elementos OBRA DE EJEMPLO/1 Subterráneo/Viga|OBRA DE EJEMPLO/2 Subterráneo/Muro|
        If iElementos.Trim.Length > 0 Then
            Dim lPartesElem() As String = Nothing
            lElemABuscar = "" : lSql = ""
            lPartes = iElementos.Split("|")
            For i = 0 To lPartes.Length - 1
                If lPartes(i).Trim.Length > 0 Then
                    lPartesElem = lPartes(i).Split("/")
                    lElemABuscar = String.Concat("'", lPartesElem(0), "|", lPartesElem(1).Replace("'", "''"), "/", lPartesElem(2).Replace("'", "''"), "%' or ")
                    lSql = String.Concat(lSql, " ubicacionFull like ", lElemABuscar, "")
                    lSql = lSql.Replace("/", "\")
                End If
            Next
            lSql = String.Concat(lsqlGen, " and (", lSql.Substring(0, lSql.Length - 3), " )  ") ' group by p.diametro")          
            lTblEl = CargaTabla(lSql)
        End If

        If Not iUbic2 Is Nothing AndAlso iUbic2.Trim.Length > 0 Then
            Dim lPartesElem() As String = Nothing
            lUbic2ABuscar = "" : lSql = ""
            lPartes = iUbic2.Split("|")
            lSql = ""
            For i = 0 To lPartes.Length - 1
                If lPartes(i).Trim.Length > 0 Then
                    lPartesElem = lPartes(i).Split("/")
                    If lPartesElem.Length = 4 Then
                        lUbic2ABuscar = String.Concat("'", lPartesElem(0), "|", lPartesElem(1).ToString.Replace("'", "''"), "/", lPartesElem(2).ToString.Replace("'", "''"), "%' ")
                        lSql = String.Concat(" ubicacionFull like ", lUbic2ABuscar, "")
                        lSql = lSql.Replace("/", "\")
                        lSql = String.Concat(" and (", lSql, ") and (")
                        lSql = String.Concat(lSql, "  hd.FIGURA='", lPartesElem(3).ToString.Replace("'", "''"), "')")
                        lSql = String.Concat(lsqlGen, lSql, " --group by p.diametro")
                    Else
                        lUbic2ABuscar = String.Concat("'", lPartesElem(0), "|", lPartesElem(1).Replace("'", "''"), "/", lPartesElem(2).Replace("'", "''"), "%' ")
                        lSql = String.Concat(" ubicacionFull like ", lUbic2ABuscar, "")
                        lSql = lSql.Replace("/", "\")
                        lSql = String.Concat(" and (", lSql, ") and (")
                        lSql = String.Concat(lSql, " hd.FIGURA='", lPartesElem(3).ToString.Replace("'", "''"), "' and  hd.Ubicacion='", lPartesElem(4).ToString.Replace("'", "''"), "')")
                        lSql = String.Concat(lsqlGen, lSql, " --group by p.diametro")
                    End If
                    lTblUbi2.Merge(CargaTabla(lSql))
                End If
            Next
        End If

        If lTblUb.Rows.Count > 0 Then
            lTabla.Merge(lTblUb)
            'lTabla = AgregaDatosEnTabla(lTabla, lTblUb)
        End If
        If lTblEl.Rows.Count > 0 Then
            lTabla.Merge(lTblEl)
            'lTabla = AgregaDatosEnTabla(lTabla, lTblEl)
        End If
        If lTblUbi2.Rows.Count > 0 Then
            lTabla.Merge(lTblUbi2)
        End If
        'lTabla = AgregaDatosEnTabla(lTabla, lTblEl)
        Dim lTblGr As New DataTable
        Dim vSql As String = String.Concat(lsqlGen, " And p.Id in (")
        For i = 0 To lIdsGr.Count - 1
            vSql = String.Concat(vSql, lIdsGr(i).ToString, ",")
        Next
        If lIdsGr.Count > 0 Then
            vSql = String.Concat(vSql.Substring(0, vSql.Length - 1), ") ")
            lTblGr = CargaTabla(vSql)
            If lTblGr.Rows.Count > 0 Then
                lTabla.Merge(lTblGr)
            End If
        End If

        Return lTabla
    End Function

    Private Function AgregaDatosEnTabla(ByVal iTblFinal As DataTable, ByVal iTblAdd As DataTable) As DataTable
        Dim i As Integer = 0, lDiam As String = "", lFilas() As DataRow = Nothing
        Dim lTabla As New DataTable, lDiamProc As New ArrayList, lfila As DataRow = Nothing
        Dim j As Integer = 0, lTotalKgs As Double = 0, lNroLam As Integer = 0

        'lTabla = iTblAdd.Copy 'Copiamos la tabla 
        'lTabla.Clear() 'Borramos los datos y dejamos solo la estructura
        lTabla.Columns.Add("Diametro", Type.GetType("System.String"))
        lTabla.Columns.Add("Kgs", Type.GetType("System.String"))
        lTabla.Columns.Add("NroLam", Type.GetType("System.String"))

        For i = 0 To iTblFinal.Rows.Count - 1
            lDiam = iTblFinal.Rows(i)("Diametro").ToString
            lTotalKgs = 0 : lNroLam = 0
            If lDiamProc.IndexOf(lDiam) = -1 Then 'el diametro no ha sido procesado
                lFilas = iTblFinal.Select(" Diametro='" & lDiam & "'", "")
                lfila = lTabla.NewRow
                If lFilas.Length > 0 Then
                    For j = 0 To lFilas.Length - 1
                        lTotalKgs = lTotalKgs + CDbl(lFilas(j)("Kgs"))
                        '  lNroLam = lNroLam + Val(lFilas(j)("NroLam"))
                    Next
                    lfila("Diametro") = lDiam
                    lfila("Kgs") = lTotalKgs
                    '  lfila("NroLam") = lNroLam
                    lTabla.Rows.Add(lfila)
                    lDiamProc.Add(lDiam)
                End If
            End If
        Next

        Return lTabla
    End Function

    Public Function ObtenerIdsPiezasParaIT(ByVal iObras As String, ByVal iUbicaciones As String, ByVal iElementos As String) As DataTable
        Dim lTabla As New DataTable, i As Integer = 0, lTblUb As New DataTable, lTblEl As New DataTable
        Dim lObrasABuscar As String = "", lUbicABuscar As String = "", lElemABuscar As String = ""
        Dim lPartes() As String = Nothing, lSql As String = ""
        Dim lsqlGen As String = "   select P.Id IdPieza from piezas p, hojadespiece hd   "
        lsqlGen = String.Concat(lsqlGen, " where p.Id_Hd = hd.Id And estado = '3'   ")

        'Primero las Obras 
        If iObras.Trim.Length > 0 Then
            lPartes = iObras.Split("|")
            For i = 0 To lPartes.Length - 1
                If lPartes(i).Trim.Length > 0 Then
                    lObrasABuscar = String.Concat(lObrasABuscar, "'", lPartes(i), "',")
                End If
            Next
            lObrasABuscar = lObrasABuscar.Substring(0, lObrasABuscar.Length - 1)
            lSql = String.Concat(lsqlGen, " and obra in (", lObrasABuscar, ")  ")
            lTabla = CargaTabla(lSql)
        End If
        ' Ahora las ubicaciones  'OBRA DE EJEMPLO/4 Subterráneo|
        If iUbicaciones.Trim.Length > 0 Then
            lPartes = iUbicaciones.Split("|")
            lUbicABuscar = "" : lSql = ""
            For i = 0 To lPartes.Length - 1
                If lPartes(i).Trim.Length > 0 Then
                    lUbicABuscar = String.Concat("'", lPartes(i), "%' or ")
                    lUbicABuscar = lUbicABuscar.Replace("/", "|")
                    lSql = String.Concat(lSql, " ubicacionFull like ", lUbicABuscar, "")
                End If
            Next
            lSql = String.Concat(lsqlGen, " and (", lSql.Substring(0, lSql.Length - 3), ") ")
            lTblUb = CargaTabla(lSql)
        End If
        'Ahora los Elementos OBRA DE EJEMPLO/1 Subterráneo/Viga|OBRA DE EJEMPLO/2 Subterráneo/Muro|
        If iElementos.Trim.Length > 0 Then
            Dim lPartesElem() As String = Nothing
            lElemABuscar = "" : lSql = ""
            lPartes = iElementos.Split("|")
            For i = 0 To lPartes.Length - 1
                If lPartes(i).Trim.Length > 0 Then
                    lPartesElem = lPartes(i).Split("/")
                    lElemABuscar = String.Concat("'", lPartesElem(0), "|", lPartesElem(1), "/", lPartesElem(2), "%' or ")
                    lSql = String.Concat(lSql, " ubicacionFull like ", lElemABuscar, "")
                    lSql = lSql.Replace("/", "\")
                End If
            Next
            lSql = String.Concat(lsqlGen, " and (", lSql.Substring(0, lSql.Length - 3), ") ")
            lTblEl = CargaTabla(lSql)
        End If
        If lTblUb.Rows.Count > 0 Then
            lTabla.Merge(lTblUb)
        End If
        If lTblEl.Rows.Count > 0 Then
            lTabla.Merge(lTblEl)
        End If
        Return lTabla
    End Function

    Public Function ObtenerItPorId(ByVal iIdiT As String) As BussinesObjects.Tipos.Tipo_IT
        Return ObtenerIT(iIdiT)
    End Function
    Public Function ObtenerItPorCodigoViaje(ByVal iCodigoViaje As String) As BussinesObjects.Tipos.Tipo_IT
        Return ObtenerITPorCodViaje(iCodigoViaje)
    End Function

    Public Function ObtenerObsItAnular(ByVal iIdIt As String) As String
        Dim lsql As String = " select estado,count(1) from piezas where Estado<>'00' and  id_it=" & iIdIt & " group by estado"
        Dim lTabla As New DataTable, lRes As String = "", i As Integer = 0
        Dim ltotal As Integer = 0, lEnIt As Integer = 0, lAprobadas As Integer = 0
        lTabla = CargaTabla(lsql)
        For i = 0 To lTabla.Rows.Count - 1
            Select Case lTabla.Rows(i)("Estado").ToString
                Case "40" ' en It
                    lEnIt = lEnIt + Val(lTabla.Rows(i)(1).ToString)
                Case "46", "45" 'Aprobadas
                    lAprobadas = lAprobadas + Val(lTabla.Rows(i)(1).ToString)
            End Select
            ltotal = ltotal + Val(lTabla.Rows(i)(1).ToString)
        Next
        lRes = " De un total de " & ltotal & " piezas, hay " & lAprobadas & " aprobadas"
        Return lRes
    End Function



    Public Function ObtenerNombreUserPorId(ByVal iIdUser As String) As String
        Dim lsql As String = " Select Usuario from to_Usuarios where Id=" & iIdUser
        Dim lTabla As New DataTable, lRes As String = ""
        lTabla = CargaTabla(lsql)
        If lTabla.Rows.Count > 0 Then
            lRes = lTabla.Rows(0)(0).ToString
        End If
        Return lRes
    End Function


#Region "Estados de IT"
    Public Function ObtenerEstadoIT(ByVal iIt As String) As DataTable
        Dim lTbl As New DataTable
        Dim lsql As String = "Select * from It_Estados where idit=" & iIt & " and estado not in ('AN')"
        Return CargaTabla(lsql)
    End Function
#End Region

#Region "Informes "
    Public Function ResumenGeneral_Its_PorDiametros() As DataTable
        Dim lTabla As New DataTable, lFilas As DataRow = Nothing, lTotal As Double = 0
        Dim i As Integer = 0, lTotalPiezas As Integer = 0
        'En Estado En It
        Dim lSql As String = "  select it.id Nro_IT, It.FechaCreacion Fecha,p.Diametro Diam, round(sum(it.TotalKgs),2) TotalKgs,count(1) NroPiezas"
        lSql = String.Concat(lSql, " from piezas p, it where p.Id_IT = it.Id And estado = '40'  ")
        lSql = String.Concat(lSql, " group by  it.id,It.FechaCreacion,p.Diametro order by it.id")
        lTabla = CargaTabla(lSql)
        lFilas = lTabla.NewRow
        For i = 0 To lTabla.Rows.Count - 1
            lTotal = lTotal + Double.Parse(lTabla.Rows(i)("TotalKgs"))
            lTotalPiezas = lTotalPiezas + Double.Parse(lTabla.Rows(i)("NroPiezas"))
        Next
        'lFilas("Fecha") = "Totales"
        lFilas("TotalKgs") = lTotal
        lFilas("NroPiezas") = lTotalPiezas
        lTabla.Rows.Add(lFilas)
        Return lTabla
    End Function
    Public Function ResumenGeneral_Piezas_PorEstado(ByVal iCliente As String, ByVal iSucursal As String, ByVal iIdObra As String) As DataTable
        Dim lTabla As New DataTable, lFilas As DataRow = Nothing, lTotal As Double = 0, lKilos As Double = 0
        Dim i As Integer = 0
        '        select  Case estado        WHEN '3' THEN 'Importado CubiCad
        '         WHEN '40' THEN 'En Viaje'         
        '         ELSE 'Default'      END Estado,
        'count(1) NroPiezas  from piezas
        'group by estado

        If iCliente.Equals("0") Then
            iCliente = ""
        End If
        Dim lSql As String = " select  Case p.estado        WHEN '3' THEN 'Importado CubiCad' "
        lSql = String.Concat(lSql, "  WHEN '40' THEN 'En I.T' ")
        'lSql = String.Concat(lSql, "  WHEN '50' THEN 'En Viaje' ")
        lSql = String.Concat(lSql, "  WHEN '45' THEN 'IT Aprobada' ")
        lSql = String.Concat(lSql, "  WHEN '46' THEN 'IT Aprobado Parcial' ")
        lSql = String.Concat(lSql, "  WHEN '50' THEN 'IMPRESA PL' ")
        lSql = String.Concat(lSql, "  WHEN '51' THEN 'IMPRESA EN ETIQUETA' ")
        lSql = String.Concat(lSql, "  WHEN 'I' THEN 'Ingresada Manual' ")
        lSql = String.Concat(lSql, "  ELSE  p.Estado     END Estado,")
        lSql = String.Concat(lSql, " count(1) Nro, round(sum(totalKgs),0)  as Kilos  ") 'where  estado <> '00'")
        lSql = String.Concat(lSql, " from piezas  p , Hojadespiece hd, Obras O  ")
        lSql = String.Concat(lSql, "  Where Id_Hd=hd.id  and O.Id=hd.IdObra  ")

        If Val(iIdObra) > 0 Then lSql = String.Concat(lSql, "  and o.id=", iIdObra, "")

        If iCliente.Trim.Length > 0 Then lSql = String.Concat(lSql, "  and Cliente='", iCliente, "'")

        If iSucursal.Trim.Length > 0 Then lSql = String.Concat(lSql, "  and sucursal='", iSucursal, "'")

        lSql = String.Concat(lSql, "  group by p.estado  ")
        lTabla = CargaTabla(lSql)
        lFilas = lTabla.NewRow
        For i = 0 To lTabla.Rows.Count - 1
            lTotal = lTotal + Double.Parse(lTabla.Rows(i)("Nro"))
            lKilos = lKilos + Double.Parse(lTabla.Rows(i)("Kilos"))
        Next
        lFilas("Estado") = "Totales"
        lFilas("Nro") = lTotal : lFilas("Kilos") = lKilos
        lTabla.Rows.Add(lFilas)
        Return lTabla
    End Function
    Public Function ResumenItsPara_PL(ByVal iUser As String) As DataTable
        'Dim lTabla As New DataTable, lFilas As DataRow = Nothing, lTotal As Double = 0
        'Dim lSql As String = " Select it.Id NroIt,( Select Usuario from To_Usuarios t where t.Id=EntragadoA) Entregado_A, "
        'lSql = String.Concat(lSql, " ( Select Usuario from To_Usuarios t where t.Id=EntregadoPor) EntregadoPor,  ")
        'lSql = String.Concat(lSql, " FechaEntrega,FechaDespacho,codigoIT+'-'+convert(varchar,it.id) CodigoIt, ")
        'lSql = String.Concat(lSql, "(select Count(1) from piezas where Id_It=It.Id) NroPiezas, TipoIt  from it  ")
        ''lSql = String.Concat(lSql, " , it_estados ie where ie.IdIt=it.id and ie.estado in ('A','AP')")
        'lSql = String.Concat(lSql, " where estado in ('A','AP')")
        'lTabla = CargaTabla(lSql)
        Dim lDal As New ClsB_O
        Return lDal.ResumenDespachoPorIt(iUser)
    End Function
    Public Function ResumenItsPara_ImpLaminas(ByVal iTipo As String) As DataTable
        Dim lSql As String = ""
        Select Case iTipo
            Case "I"


                ' ALTER PROCEDURE [dbo].[SP_ConsultasGenerales]  '@Opcion INT,        @Par1 Varchar(100),
                '@Par2 Varchar(100),                         '@Par3 Varchar(100),
                '@Par4 Varchar(100),                          '@Par5 Varchar(100)

                lSql = " exec  SP_ConsultasGenerales 18,'','','','','' "

            Case "R"
                lSql = " Select it.Id NroIt,Codigo,( Select Usuario from To_Usuarios t where t.Id=EntragadoA) Entregado_A,  ( Select Usuario from To_Usuarios t where t.Id=EntregadoPor) EntregadoPor,   FechaEntrega,FechaDespacho,codigoIT+'-'+convert(varchar,it.id) CodigoIt,  ( Select Nombre from Obras o where o.Id=IdObra) Obra, it.FechaCreacion, " '(select Count(1) from piezas where Id_It=It.Id) NroPiezas, "
                lSql = String.Concat(lSql, " convert(varchar,(select Count(1) from piezas where Estado<>'00' and Id_It=It.Id and idViaje=viaje.id and piezas.estado in ('51'))) + '/' +  ")
                lSql = String.Concat(lSql, " convert(varchar,(select Count(1) from piezas where Estado<>'00' and Id_It=It.Id)) NroPiezas, TipoIt,")
                lSql = String.Concat(lSql, " it.estado , round(it.totalKgs,0) totalKgs , ")
                lSql = String.Concat(lSql, " convert(varchar,(select round(sum(TotalKgs),0) from piezas where  Estado<>'00' and Id_It=It.Id and idViaje=viaje.id ")
                lSql = String.Concat(lSql, " and piezas.estado in ('51'))) + ' / ' +   ")
                lSql = String.Concat(lSql, " convert(varchar,(select round(sum(TotalKgs),0) from piezas where Estado<>'00' and Id_It=It.Id)) ResKilos ")
                lSql = String.Concat(lSql, " from it  , viaje   where  it.id=idit  ") '-- it.estado in ('I')   and 
                lSql = String.Concat(lSql, " and viaje.estado  in ('IETS') order by It.Id,codigo ")
        End Select

        Return CargaTabla(lSql)
    End Function
    Public Function ResumenGeneral_ItsPorObra(ByVal iObra As String, ByVal iSucursal As String, ByVal iCliente As String) As DataTable
        Dim lTabla As New DataTable, lFilas As DataRow = Nothing, lTotal As Double = 0
        Dim i As Integer = 0, lEstado As String = "", lTblTmp As New DataTable, lTblFinal As New DataTable
        'Its

        If iCliente.Equals("0") Then
            iCliente = ""
        End If
        'CARGAMOS PRIMERO LAS IT ASOCIADAS A VIAJES 
        Dim lSql As String = " Select it.Id NroIt,( Select Usuario from To_Usuarios t where t.Id=EntragadoA) Entregado_A, "
        lSql = String.Concat(lSql, " ( Select Usuario from To_Usuarios t where t.Id=EntregadoPor) EntregadoPor, ")
        lSql = String.Concat(lSql, " FechaEntrega,FechaDespacho,codigoIT+'-'+convert(varchar,it.NroIT) CodigoIt, ")
        lSql = String.Concat(lSql, " o.Nombre Obra, it.FechaCreacion,")
        lSql = String.Concat(lSql, " convert(varchar,(select Count(1) from piezas where  Estado<>'00' and  Id_It=It.Id and idviaje=viaje.id)) + '/' + ")
        lSql = String.Concat(lSql, " convert(varchar,(select Count(1) from piezas where Estado<>'00' and  Id_It=It.Id))  NroPiezas , TipoIt, ")
        lSql = String.Concat(lSql, "  (Select round(sum(d.KgsPaquete),0) from piezas p, DetallePaquetesPieza d  where p.estado not in ('00') and d.IdViaje=Viaje .id  and p.Id =d.IdPieza )  TotalKgs , ") ' it.Estado ,")
        lSql = String.Concat(lSql, "   viaje.Estado , Viaje.Codigo, IdObra, cliente ")
        lSql = String.Concat(lSql, " from it, viaje , Obras o    Where  it.Estado not in ('AN','00','DCAM') ")
        lSql = String.Concat(lSql, " and idIt=It.Id   and o.Id=IdObra ")
        If Val(iObra) > 0 Then
            lSql = String.Concat(lSql, " and IdObra=", iObra)
        End If
        'Fltramos por sucursal
        If iSucursal.Trim.Length > 0 Then lSql = String.Concat(lSql, " and sucursal='", iSucursal, "'")
        'Fltramos por Cliente
        If iCliente.Trim.Length > 0 Then lSql = String.Concat(lSql, " and cliente ='", iCliente, "'")

        lTabla = CargaTabla(lSql)
        'CARGAMOS AHORA LAS IT PENDIENTES, SIN VIAJES ASOCIADOS
        lSql = "Select it.Id NroIt,( Select Usuario from To_Usuarios t where t.Id=EntragadoA) Entregado_A, "
        lSql = String.Concat(lSql, "   ( Select Usuario from To_Usuarios t where t.Id=EntregadoPor) EntregadoPor,   FechaEntrega,")
        lSql = String.Concat(lSql, " FechaDespacho,codigoIT+'-'+convert(varchar,it.NroIt) CodigoIt,  o.Nombre  Obra,")
        lSql = String.Concat(lSql, " FechaCreacion, convert(varchar,(select Count(1) from piezas p where p.Estado<>'00'  and  Id_It=It.Id and p.estado in ('40')))  ")
        lSql = String.Concat(lSql, " + '/' +  convert(varchar,(select Count(1) from   piezas p where p.Estado<>'00' and  Id_It=It.Id)) NroPiezas ,  TipoIt, ")
        lSql = String.Concat(lSql, " it.estado ,(select round(sum(totalKgs),0) from   piezas p where p.Estado<>'00' and  Id_It=It.Id) TotalKgs, '' Codigo,IdObra  ")
        lSql = String.Concat(lSql, "  from it , Obras o     ")
        lSql = String.Concat(lSql, "   where it.estado in ('APP', 'PDT') and IdObra=o.Id  ")
        If Val(iObra) > 0 Then
            lSql = String.Concat(lSql, " and IdObra=", iObra)
        End If

        'Fltramos por sucursal
        If iSucursal.Trim.Length > 0 Then lSql = String.Concat(lSql, " and sucursal='", iSucursal, "'")
        'Fltramos por Cliente
        If iCliente.Trim.Length > 0 Then lSql = String.Concat(lSql, " and cliente ='", iCliente, "'")

        lTblTmp = CargaTabla(lSql)

        'VERFICAMOS QUE TENGA DATOS EN LA TABLA CON VIAJES SI HAY LOS AGREGAMOS A LAS ITS SIN VIAJES
        If lTabla.Rows.Count > 0 Then ' SI EXISTEN IT CON VIAJES ASOCIADOS
            For i = 0 To lTblTmp.Rows.Count - 1
                lFilas = lTabla.NewRow
                lFilas("NroIt") = lTblTmp.Rows(i)("NroIt")
                lFilas("Codigo") = lTblTmp.Rows(i)("Codigo")
                lFilas("Entregado_A") = lTblTmp.Rows(i)("Entregado_A")
                lFilas("EntregadoPor") = lTblTmp.Rows(i)("EntregadoPor")
                lFilas("FechaDespacho") = lTblTmp.Rows(i)("FechaDespacho")
                lFilas("FechaEntrega") = lTblTmp.Rows(i)("FechaEntrega")
                lFilas("CodigoIt") = lTblTmp.Rows(i)("CodigoIt")
                lFilas("Obra") = lTblTmp.Rows(i)("Obra")
                lFilas("FechaCreacion") = lTblTmp.Rows(i)("FechaCreacion")
                lFilas("NroPiezas") = lTblTmp.Rows(i)("NroPiezas")
                lFilas("TipoIt") = lTblTmp.Rows(i)("TipoIt")
                lFilas("estado") = lTblTmp.Rows(i)("estado")
                lFilas("totalKgs") = lTblTmp.Rows(i)("totalKgs")
                lFilas("IdObra") = lTblTmp.Rows(i)("IdObra")
                lTabla.Rows.Add(lFilas)
            Next
        Else  'NO EXISTEN IT CON VIAJES ASOCIADOS
            lTabla = lTblTmp.Copy
        End If
        ' Cargamos la tabla de salida
        lTblFinal = lTabla.Copy

        Return lTblFinal
    End Function
    Public Function ResumenGeneral_Its() As DataTable
        Dim lTabla As New DataTable, lFilas As DataRow = Nothing, lTotal As Double = 0
        Dim i As Integer = 0, lEstado As String = "", lTblTmp As New DataTable, lTblFinal As New DataTable
        'Its
        'CARGAMOS PRIMERO LAS IT ASOCIADAS A VIAJES 
        Dim lSql As String = " Select it.Id NroIt,( Select Usuario from To_Usuarios t where t.Id=EntragadoA) Entregado_A, "
        lSql = String.Concat(lSql, " ( Select Usuario from To_Usuarios t where t.Id=EntregadoPor) EntregadoPor,  ")
        lSql = String.Concat(lSql, " FechaEntrega,FechaDespacho,codigoIT+'-'+convert(varchar,it.NroIT) CodigoIt, ")
        lSql = String.Concat(lSql, " ( Select Nombre from Obras o where o.Id=IdObra) Obra, it.FechaCreacion,")
        lSql = String.Concat(lSql, " convert(varchar,(select Count(1) from piezas where  Estado<>'00' and  Id_It=It.Id and idviaje=viaje.id)) + '/' + ")
        lSql = String.Concat(lSql, " convert(varchar,(select Count(1) from piezas where Estado<>'00' and  Id_It=It.Id))  NroPiezas , TipoIt, ")
        lSql = String.Concat(lSql, "  round(it.TotalKgs,0) TotalKgs , viaje.Estado ,") ' it.Estado ,")
        lSql = String.Concat(lSql, "   Viaje.Codigo, IdObra from it, viaje   Where  it.Estado not in ('AN','00') ")
        lSql = String.Concat(lSql, " and idIt=It.Id   ")
        lTabla = CargaTabla(lSql)
        'CARGAMOS AHORA LAS IT PENDIENTES, SIN VIAJES ASOCIADOS
        lSql = "Select it.Id NroIt,( Select Usuario from To_Usuarios t where t.Id=EntragadoA) Entregado_A, "
        lSql = String.Concat(lSql, "   ( Select Usuario from To_Usuarios t where t.Id=EntregadoPor) EntregadoPor,   FechaEntrega,")
        lSql = String.Concat(lSql, " FechaDespacho,codigoIT+'-'+convert(varchar,it.NroIt) CodigoIt,  ( Select Nombre from Obras o where o.Id=IdObra) Obra,")
        lSql = String.Concat(lSql, " FechaCreacion, convert(varchar,(select Count(1) from piezas where Estado<>'00'  and  Id_It=It.Id and estado in ('40')))  ")
        lSql = String.Concat(lSql, " + '/' +  convert(varchar,(select Count(1) from   piezas where Estado<>'00' and  Id_It=It.Id)) NroPiezas ,  TipoIt, ")
        lSql = String.Concat(lSql, " estado ,round(it.TotalKgs,0) TotalKgs, '' Codigo,IdObra  from it     where estado in ('APP', 'PDT') ")
        lTblTmp = CargaTabla(lSql)

        'VERFICAMOS QUE TENGA DATOS EN LA TABLA CON VIAJES SI HAY LOS AGREGAMOS A LAS ITS SIN VIAJES
        If lTabla.Rows.Count > 0 Then ' SI EXISTEN IT CON VIAJES ASOCIADOS
            For i = 0 To lTblTmp.Rows.Count - 1
                lFilas = lTabla.NewRow
                lFilas("NroIt") = lTblTmp.Rows(i)("NroIt")
                lFilas("Codigo") = lTblTmp.Rows(i)("Codigo")
                lFilas("Entregado_A") = lTblTmp.Rows(i)("Entregado_A")
                lFilas("EntregadoPor") = lTblTmp.Rows(i)("EntregadoPor")
                lFilas("FechaDespacho") = lTblTmp.Rows(i)("FechaDespacho")
                lFilas("FechaEntrega") = lTblTmp.Rows(i)("FechaEntrega")
                lFilas("CodigoIt") = lTblTmp.Rows(i)("CodigoIt")
                lFilas("Obra") = lTblTmp.Rows(i)("Obra")
                lFilas("FechaCreacion") = lTblTmp.Rows(i)("FechaCreacion")
                lFilas("NroPiezas") = lTblTmp.Rows(i)("NroPiezas")
                lFilas("TipoIt") = lTblTmp.Rows(i)("TipoIt")
                lFilas("estado") = lTblTmp.Rows(i)("estado")
                lFilas("totalKgs") = lTblTmp.Rows(i)("totalKgs")
                lFilas("IdObra") = lTblTmp.Rows(i)("IdObra")
                lTabla.Rows.Add(lFilas)
            Next
        Else  'NO EXISTEN IT CON VIAJES ASOCIADOS
            lTabla = lTblTmp.Copy
        End If
        ' Cargamos la tabla de salida
        lTblFinal = lTabla.Copy


        'lFilas("NroPiezas") = lTotal
        'lTabla.Rows.Add(lFilas)
        Return lTblFinal
    End Function


    Public Function ResumenGeneral_LogImpresion() As DataTable
        Dim lTabla As New DataTable, lFilas As DataRow = Nothing, lTotal As Double = 0
        Dim i As Integer = 0, lEstado As String = ""
        'Its
        Dim lSql As String = " select Modulo, Usuario, convert(varchar,fecha,103) Fecha , count(1) NroImpresiones"
        lSql = String.Concat(lSql, " from  logimpresion   ")
        lSql = String.Concat(lSql, " group by Modulo,Usuario, convert(varchar,fecha,103)")
        lTabla = CargaTabla(lSql)
        Return lTabla
    End Function

    Public Function ResumenDetalle_LogImpresion(ByVal iMod As String, ByVal iUser As String, ByVal iFecha As String) As DataTable
        Dim lTabla As New DataTable, lFilas As DataRow = Nothing, lTotal As Double = 0
        Dim i As Integer = 0, lEstado As String = ""
        'Its
        Dim lSql As String = " select * from logImpresion where Modulo='" & iMod & "' "
        lSql = String.Concat(lSql, " and usuario='" & iUser & "' and convert(varchar,fecha,103)='" & iFecha & "' ")
        lTabla = CargaTabla(lSql)
        Return lTabla
    End Function

    Public Function ObtenerEstado_ItEstado(ByVal iIdIt As String) As String
        'Dim lsql As String = "Select top 1 * from It_estados where IdIt=" & iIdIt & " order by id desc "
        Dim lsql As String = "Select * from It  where Id=" & iIdIt '& " order by id desc "
        Dim ltbl As New DataTable, lres As String = ""
        ltbl = CargaTabla(lsql)
        If ltbl.Rows.Count > 0 Then
            lres = ltbl.Rows(0)("Estado").ToString
        End If
        Return lres
    End Function

    Public Function ObtenerEstado_Viaje(ByVal iCodViaje As String) As String
        Dim lsql As String = "Select * from viaje where Codigo='" & iCodViaje & "'"
        Dim ltbl As New DataTable, lres As String = ""
        ltbl = CargaTabla(lsql)
        If ltbl.Rows.Count > 0 Then
            lres = ltbl.Rows(0)("Estado").ToString
        End If
        Return lres
    End Function
#End Region

    Public Function GrabarIT(ByVal iIt As BussinesObjects.Tipos.Tipo_IT, ByVal iIds As String, ByVal iUser As String) As BussinesObjects.Tipos.Tipo_IT
        Dim lQuery As New BussinesObjects.Clases.Cls_Sql, lSql As String = ""
        Dim lDal As New BussinesObjects.Clases.Cls_Datos
        Dim lRes As Integer = 0, lTbl As New DataTable, lIds As String = ""
        Dim lMsg As New BussinesObjects.Tipos.Tipo_Msg
        Try
            iIt.Error = "Antes Sql 1"
            lSql = lQuery.SqlInsertaIT(iIt)
            lRes = EjecutaDML(lSql)
            ' iIt.Error = "|" & iIt.Id & "|"
            If Val(lRes) > 0 Then
                iIt.Id = lDal.ObtenerUltimoId("IT")
                lIds = iIds.Substring(0, iIds.Length - 1)
                'iIt.Error = "Antes Sql 2"
                lSql = lQuery.SqlActualizaNroIt(iIt.Id, lIds, iUser)
                'iIt.Error = iIt.Error & "   " & lSql
                lRes = EjecutaDML(lSql)
                If Val(lRes) > 0 Then
                    'lSql = lQuery.SqlActualizaNroIt(iIt.Id, lIds)
                    'lMsg = CreaMensaje(iIt, "Crea I.T.")
                    'lMsg = GrabaMensaje(lMsg)
                    iIt.Error = lMsg.Error
                    '----------------------
                    'Asignamos a las etiquetas la sucursal del la IT
                    lSql = String.Concat(" exec SP_Consultas_WS  107,'", iIt.Id, "','','','','','','' ")
                    lRes = EjecutaDML(lSql)
                End If
            End If
        Catch ex As Exception
            iIt.Error = ex.Message
            Dim lErrror As String = "ClsDatos.GrabarIT. " & ex.Message.ToString
            RegistraError(lErrror)
            'Throw ex
        End Try
        Return iIt
    End Function


    Public Function ObtenerHorasMinutos() As DataSet
        Dim lTabla As New DataTable
        Dim lDts As New DataSet
        lTabla = CargaTabla("Select Id, PAr1 from To_Parametros where SubTabla='Horas' order by par1 ")
        lTabla.TableName = "Horas"
        lDts.Tables.Add(lTabla.Copy)
        lTabla = New DataTable
        lTabla = CargaTabla("Select Id, PAr1 from To_Parametros where SubTabla='Minutos'")
        lTabla.TableName = "Min"
        lDts.Tables.Add(lTabla.Copy)
        Return lDts
    End Function

    Public Function ObtenerUser(ByVal iTipo As String) As DataTable
        Dim lTabla As New DataTable
        Dim lSql As String = "select u.id idUser, usuario from to_usuarios u, to_parametros p where   u.perfil=p.id "
        Select Case iTipo
            Case "P"
                lSql = String.Concat(lSql, " and par1='Produccion' ")
            Case Else
                lSql = String.Concat(lSql, " and par1 IN ('Adm. Obras','Oficina Técnica') ")
        End Select
        lSql = String.Concat(lSql, " and u.vigente='S' ")
        lTabla = CargaTabla(lSql)
        Return lTabla
    End Function

    Public Function ObtenerTextoMsg(ByVal iIdUser As String, ByVal iIdMsg As String) As DataTable
        Dim lTabla As New DataTable
        Dim lSql As String = "Select * from  DestinatarioMsg Dm, Mensajes m"
        lSql = String.Concat(lSql, "  where m.Id=Dm.idmensaje and iduserdestino=")
        lSql = String.Concat(lSql, iIdUser, " and m.Id=", iIdMsg)
        lTabla = CargaTabla(lSql)
        Return lTabla
    End Function

    Public Function MarcaMsgComoLeido(ByVal lId As String, ByVal lIdUser As String) As String
        Dim ldal As New BussinesObjects.Clases.Cls_Datos
        Return ldal.MarcaMsgComoLeido(lId, lIdUser)
    End Function


    Public Function ObtenerBuscarPiezas(ByVal iSql As String) As List(Of BussinesObjects.Tipos.Tipo_Pieza)
        Dim lTbl As New DataTable, ldal As New ClsDatos, i As Integer = 0, lTblTmp As New DataTable
        Dim lPieza As BussinesObjects.Tipos.Tipo_Pieza = Nothing
        Dim lPiezas As New List(Of BussinesObjects.Tipos.Tipo_Pieza)
        Dim lTblDoblez As New DataTable, lDescuentoDiam As New DataTable, lSqlTmp As String = ""
        Dim lFilaD() As DataRow = Nothing, lFilaFactor() As DataRow = Nothing

        If iSql Is Nothing Then
            iSql = "Select id_it IdIt, * from piezas where  estado in ('3','I','5') "
        End If
        Try
            lSqlTmp = "Select * from doblezPiezas "
            lTblDoblez = ldal.CargaTabla(lSqlTmp)
            lSqlTmp = "select * from to_parametros where subTabla='Diametro' "
            lDescuentoDiam = ldal.CargaTabla(lSqlTmp)
            lTbl = ldal.CargaTabla(iSql)
            'llenamos una lista de piezas
            For i = 0 To lTbl.Rows.Count - 1
                lPieza = New BussinesObjects.Tipos.Tipo_Pieza()
                lPieza.Cantidad = lTbl.Rows(i)("Cantidad").ToString()
                lPieza.Correlativo = lTbl.Rows(i)("Correlativo").ToString()
                lPieza.DetallePieza = lTbl.Rows(i)("IdDetalleForma").ToString()
                lPieza.Diametro = lTbl.Rows(i)("Diametro").ToString()
                lPieza.Estado = lTbl.Rows(i)("Estado").ToString()
                'lPieza.EsVariable = lTbl.lTblDatos.Rows[i]["EsVariable"].ToString();
                lPieza.FechaCreacion = lTbl.Rows(i)("Fecha").ToString().Substring(0, 10)
                lPieza.IdForma = lTbl.Rows(i)("IdForma").ToString()
                lPieza.IdImagen = lTbl.Rows(i)("IdImagen").ToString()
                lPieza.IdPieza = lTbl.Rows(i)("Id").ToString()
                lPieza.Largo = Math.Round(lTbl.Rows(i)("Largo"), 2)
                lPieza.Marca = lTbl.Rows(i)("Marca").ToString()
                lPieza.Pieza = lTbl.Rows(i)("Pieza").ToString()
                lPieza.TotalKilos = Math.Round(lTbl.Rows(i)("TotalKgs"), 0)
                lPieza.Ubicacion = lTbl.Rows(i)("Ubicacion").ToString()
                lPieza.IdIt = lTbl.Rows(i)("IdIt").ToString()
                'Obtenermos el viaje
                lSqlTmp = " Select codigo from viaje where id=" & Val(lTbl.Rows(i)("IdViaje").ToString())
                lTblTmp = CargaTabla(lSqlTmp)
                If lTblTmp.Rows.Count > 0 Then
                    lPieza.CodViaje = lTblTmp.Rows(0)("Codigo").ToString()
                End If
                'La fecha de despacho Programada
                lSqlTmp = " Select FechaDespacho from IT where id=" & Val(lTbl.Rows(i)("IdIt").ToString())
                lTblTmp = CargaTabla(lSqlTmp)
                If lTblTmp.Rows.Count > 0 Then
                    lPieza.FechaDespacho = lTblTmp.Rows(0)("FechaDespacho").ToString()
                End If
                'La fecha de despacho Real
                lSqlTmp = " Select Pie_fecha_produccion from PIEZA_PRODUCCION pp, detallepaquetesPieza d where Pie_etiqueta_Pieza=d.idPieza "
                lSqlTmp = lSqlTmp & " and d.idPieza=" & Val(lTbl.Rows(i)("Id").ToString())
                lTblTmp = CargaTabla(lSqlTmp)
                If lTblTmp.Rows.Count > 0 Then
                    lPieza.FechaDespachoReal = lTblTmp.Rows(0)("Pie_fecha_produccion").ToString()
                End If
                'Obtenemos el plano
                lSqlTmp = " Select plano from hojadespiece where id=" & Val(lTbl.Rows(i)("Id_hd").ToString())
                lTblTmp = CargaTabla(lSqlTmp)
                If lTblTmp.Rows.Count > 0 Then
                    lPieza.Plano = lTblTmp.Rows(0)("plano").ToString()
                End If
                lPieza.PathImg = "~/imagen.aspx?IdImg=" & lTbl.Rows(i)("IdPiezaTipoB").ToString() 'lPieza.IdPieza
                ' "~/imgagen.aspx?id=" & tempRow.Item("imgID")
                'CAlculamos el descuento de la pieza
                lPieza.LargoDes = lPieza.Largo
                lFilaD = lTblDoblez.Select("idForma=" & lPieza.IdForma, "")
                If lFilaD.Length > 0 Then
                    Dim NroDobles As Integer = Val(lFilaD(0)("NroDoblez").ToString)
                    Dim CmPorDoblez As Integer = 0
                    If NroDobles > 0 Then
                        lFilaFactor = lDescuentoDiam.Select("Par1='" & lPieza.Diametro & "'", "")
                        If lFilaFactor.Length > 0 Then
                            CmPorDoblez = Val(lFilaFactor(0)("Par2").ToString)
                            'Si el largo esta en Metros hay que pasarlo a CM
                            lPieza.LargoDes = (lPieza.Largo * 100) - (NroDobles * CmPorDoblez)
                        End If
                    End If
                End If
                'lFilaD() As DataRow = Nothing, lFilaFactor() As DataRow = Nothing
                lPiezas.Add(lPieza)
            Next
        Catch ex As Exception
            Dim lErrror As String = "ClsDatos.ObtenerBuscarPiezas. " & ex.Message.ToString
            RegistraError(lErrror)
        End Try
        Return lPiezas
    End Function

    Public Function Revisa_Imagenes(ByVal iNroReg As String, ByVal iIdPiezaTipoB As String) As List(Of BussinesObjects.Tipos.TipoRevisaPiezas)
        Dim lTbl As New DataTable, ldal As New ClsDatos, i As Integer = 0, lTblTmp As New DataTable
        Dim lPieza As BussinesObjects.Tipos.TipoRevisaPiezas = Nothing
        Dim lPiezas As New List(Of BussinesObjects.Tipos.TipoRevisaPiezas)
        Dim lSqlTmp As String = "", lDatos As String = "", iSql As String = ""

        ' If iSql Is Nothing Then
        iSql = " select   top " & iNroReg & "  p.Id, Marca, largo, d.idForma,a,b,c,d,e,f,g,h,i,j,k,l,m,n"
        iSql = iSql & " from piezastipoB p ,detalleforma D" ' , imagenPiezas im"
        iSql = iSql & "  where d.IdPieza = P.Id " ' and im.IdPiezaTipoB=P.id  "

        If iIdPiezaTipoB.Length > 0 Then
            iSql = iSql & "   and p.Id in (" & iIdPiezaTipoB & ")"
        End If
        iSql = iSql & "   order by fecha desc "
        'and im.IdPiezaTipoB=im.IdPieza
        ' End If
        Try
            lTbl = ldal.CargaTabla(iSql)
            'llenamos una lista de piezas
            For i = 0 To lTbl.Rows.Count - 1
                lPieza = New BussinesObjects.Tipos.TipoRevisaPiezas()
                lPieza.IdForma = lTbl.Rows(i)("IdForma").ToString()
                lPieza.IdPieza = lTbl.Rows(i)("Id").ToString()
                lPieza.Largo = Math.Round(lTbl.Rows(i)("Largo"), 2)
                lPieza.Marca = lTbl.Rows(i)("Marca").ToString()

                lPieza.PathImg = "~/imagen.aspx?IdImg=" & lPieza.IdPieza
                ' "~/imgagen.aspx?id=" & tempRow.Item("imgID")

                lDatos = lTbl.Rows(i)("IdForma").ToString() & "|" & lTbl.Rows(i)("a").ToString() & "|" & lTbl.Rows(i)("b").ToString() & "|"
                lDatos = lDatos & lTbl.Rows(i)("c").ToString() & "|" & lTbl.Rows(i)("d").ToString() & "|"
                lDatos = lDatos & lTbl.Rows(i)("e").ToString() & "|" & lTbl.Rows(i)("f").ToString() & "|"
                lDatos = lDatos & lTbl.Rows(i)("g").ToString() & "|" & lTbl.Rows(i)("h").ToString() & "|"
                lDatos = lDatos & lTbl.Rows(i)("i").ToString() & "|" & lTbl.Rows(i)("j").ToString() & "|"
                lDatos = lDatos & lTbl.Rows(i)("k").ToString() & "|" & lTbl.Rows(i)("l").ToString() & "|"
                lDatos = lDatos & lTbl.Rows(i)("m").ToString() & "|" & lTbl.Rows(i)("n").ToString() & "|"
                lPieza.PathImgNew = "~/ObtenerImagen.aspx?D=" & lDatos & "&C=1"
                lPiezas.Add(lPieza)
            Next
        Catch ex As Exception
            Dim lErrror As String = "ClsDatos.Revisa_Imagenes. " & ex.Message.ToString
            RegistraError(lErrror)
        End Try
        Return lPiezas
    End Function

    Public Function EjecutaDML(ByVal iSql As String) As String
        '        Dim lCnnStr As String = lCnnStr
        Dim iCnn As New SqlConnection(ObtenerCnn.ToString)
        Dim iCmd As New SqlCommand(iSql, iCnn), lRes As String = ""
        Dim lResultado As Integer = 0
        Try
            If (iCnn.State <> ConnectionState.Open) Then
                iCnn.Open()
                lResultado = iCmd.ExecuteNonQuery()
                lRes = lResultado.ToString()
            End If
        Catch ex As Exception
            lRes = iSql.Replace("'", "''") & " - " & vbCrLf & ex.Message.ToString
            RegistraError(lRes)
        Finally
            If (iCnn.State <> ConnectionState.Closed) Then
                iCnn.Close()
            End If
        End Try
        Return lRes
    End Function

    Public Sub RegistraError(ByVal iError As String)
        Dim lResultado As String = ""
        Dim iCnn As New SqlConnection(ObtenerCnn)
        Dim lSql As String = "INSERT INTO Error_Log ([Fecha],[Modulo],[Error],[CodError]) "
        lSql = String.Concat(lSql, " VALUES  ( getdate(),'WEB','", iError.Replace("'", "''"), "','0')")
        Dim iCmd As New SqlCommand(lSql, iCnn)
        Try
            If (iCnn.State <> ConnectionState.Open) Then
                iCnn.Open()
                lResultado = iCmd.ExecuteNonQuery()
            End If
        Catch ex As Exception
            'Throw ex
        Finally
            If (iCnn.State <> ConnectionState.Closed) Then
                iCnn.Close()
            End If

        End Try

    End Sub

    Public Function EliminarUsuario(ByVal iIdUSer As String) As String
        Dim iCnn As New SqlConnection(ObtenerCnn)
        Dim iCmd As New SqlCommand("Delete from to_usuarios where Id=" + iIdUSer, iCnn), lRes As String = ""
        Dim lResultado As Integer = 0
        Try
            If (iCnn.State <> ConnectionState.Open) Then
                iCnn.Open()
                lResultado = iCmd.ExecuteNonQuery()
                lRes = lResultado.ToString()
            End If
        Catch ex As Exception
            lRes = ex.Message.ToString
        Finally
            If (iCnn.State <> ConnectionState.Closed) Then
                iCnn.Close()
            End If
        End Try
        Return lRes
    End Function

    Public Function ObtenerPiezaOC() As List(Of BussinesObjects.Tipos.TipoPiezaOC)
        'de momento solo es la opcion insertar.
        Dim lTipoSQl As New BussinesObjects.Clases.Cls_Sql, i As Integer = 0
        Dim lSql As String = lTipoSQl.SqlObtenerPiezasInsertadasOC()
        Dim lTbl As New DataTable, lPieza As BussinesObjects.Tipos.TipoPiezaOC = Nothing
        Dim lPiezas As New List(Of BussinesObjects.Tipos.TipoPiezaOC)
        lTbl = CargaTabla(lSql)
        'llenamos una lista de piezas
        For i = 0 To lTbl.Rows.Count - 1
            lPieza = New BussinesObjects.Tipos.TipoPiezaOC()
            lPieza.Cantidad = lTbl.Rows(i)("Cantidad").ToString()
            'lPieza.Correlativo = lTbl.Rows(i)("Correlativo").ToString()
            'lPieza.DetallePieza = lTbl.Rows(i)("IdDetalleForma").ToString()
            lPieza.Diametro = lTbl.Rows(i)("Diametro").ToString()
            lPieza.Estado = lTbl.Rows(i)("Estado").ToString()
            'lPieza.EsVariable = lTbl.lTblDatos.Rows[i]["EsVariable"].ToString();
            ' lPieza.FechaCreacion = lTbl.Rows(i)("Fecha").ToString().Substring(0, 10)
            lPieza.IdForma = lTbl.Rows(i)("IdFigura").ToString()
            'lPieza.IdImagen = lTbl.Rows(i)("IdImagen").ToString()
            lPieza.IdPieza = lTbl.Rows(i)("Id").ToString()
            lPieza.Largo = lTbl.Rows(i)("Largo").ToString()
            ' lPieza.Marca = lTbl.Rows(i)("Marca").ToString()
            'lPieza.Pieza = lTbl.Rows(i)("Pieza").ToString()
            lPieza.TotalKilos = lTbl.Rows(i)("peso").ToString()
            lPieza.IdObra = lTbl.Rows(i)("IdObra").ToString()
            lPiezas.Add(lPieza)
        Next
        Return lPiezas
    End Function

    Public Function GrabaPiezaOC(ByVal iPiezaOC As BussinesObjects.Tipos.TipoPiezaOC) As BussinesObjects.Tipos.TipoPiezaOC
        'de momento solo es la opcion insertar.
        Dim lRes As String = ""
        Dim lTipoSQl As New BussinesObjects.Clases.Cls_Sql
        Dim lSql As String = lTipoSQl.SqlInsertaPiezaOC(iPiezaOC)
        Dim lDal As New BussinesObjects.Clases.Cls_Datos
        lRes = EjecutaDML(lSql)
        iPiezaOC.IdPieza = lDal.ObtenerUltimoId("PiezasOC")
        Return iPiezaOC
    End Function

#Region "Marca Piezas Como Impresas"
    Public Function MarcaPiezasComoImpresas(ByVal iIds As String, ByVal IdViaje As String, ByVal iUserMod As Integer) As String
        Dim lRes As String = "", lsql As String = "", i As Integer = 0, lTmp As String = ""
        Dim lPartes() As String = Nothing, lIdIt As String = "", lPartes2() As String = Nothing
        lPartes = IdViaje.Split("-")
        If lPartes.Length > 0 Then
            lPartes2 = lPartes(1).Split("/")
            If lPartes2.Length > 0 Then
                lIdIt = lPartes2(0)
                'las piezas las marcamos con estado 50 IMPRESA EN PL
                lsql = "Update Piezas set Estado='50',FechaMod=getdate(), UserMod=" & iUserMod & " from viaje where Piezas.estado<>'00' and Piezas.Id in (" & iIds & ") "
                lsql = lsql & " And viaje.Codigo='" & IdViaje & "'  and Piezas.idViaje=viaje.Id "
                lRes = EjecutaDML(lsql)
                If IsNumeric(lRes) Then
                    ' Cambiamos el estado del viaje 
                    lsql = "Update Viaje set Estado='IVI' , FechaMod=getdate(), UserCrea=" & iUserMod & " where viaje.Codigo='" & IdViaje & "'"
                    lRes = EjecutaDML(lsql)
                    If IsNumeric(lRes) Then
                        '----------------         
                        Dim lDAl2 As New ClsB_O
                        Dim lNroAprbadas As String = lDAl2.ObtenerPiezasPorIdVaje_y_Estado(lIdIt, "I")
                        Dim lNroTotales As String = lDAl2.ObtenerPiezasPorIdVaje_y_Estado(lIdIt, "T")
                        If Val(lNroAprbadas) = Val(lNroTotales) Then
                            'Debemos cambiar el estado a Estado="A"
                            lsql = " Update It set estado ='IVI',FechaMod=getdate(), UserMod=" & iUserMod & "  from Viaje where Viaje.IdIt=It.Id and Viaje.codigo='" & IdViaje & "'"
                            lRes = New ClsDatos().EjecutaDML(lsql)
                        Else
                            'de momento no hacemos nada
                        End If
                        '-------------------            
                        ' lRes = EjecutaDML(lsql)
                    End If
                End If
            End If
        End If

        ' Y la It en estado I
        Return lRes
    End Function

#End Region
#Region "Marca Piezas Como Impresas"
    Public Function MarcaPiezasComoLaminasImpresas(ByVal IdViaje As String, ByVal lIdEtiqueta As Integer, ByVal UsuarioImprime As String) As String
        Dim lRes As String = "", lsql As String = "", i As Integer = 0, lTmp As String = ""
        Dim lPartes() As String = Nothing, lIdIt As String = "", lPartes2() As String = Nothing
        Dim lDal As New ClsDatos
        ''**************************
        Dim lCnnStr As String = lDal.ObtenerCnn(), Cmd As SqlCommand = Nothing

        Using Con As New SqlConnection(lCnnStr)
            ' // Abrimos la conexión
            If Con.State <> Data.ConnectionState.Open Then Con.Open()
            Dim tran As SqlTransaction = Con.BeginTransaction
            Try
                'Insertamos en el log de etiquetas Impresas ------------------------------
                lsql = String.Concat("Insert into EtiquetasImpresas (UserImprime,IdDetallePaquetePieza ) Values ('")
                lsql = String.Concat(lsql, UsuarioImprime, "',", lIdEtiqueta, ")")
                Cmd = New SqlCommand(lsql, Con)
                Cmd.Transaction = tran
                Cmd.ExecuteNonQuery()

                'Cambiamos el estado del viaje     -----------------------------------
                lsql = String.Concat("update viaje set Estado='IET' where codigo='", IdViaje, "' and estado not in ('IET')")
                Cmd = New SqlCommand(lsql, Con)
                Cmd.Transaction = tran
                Cmd.ExecuteNonQuery()

                'Cambiamos el estado de la IT     -----------------------------------
                lsql = String.Concat("update it  set Estado='IET' from viaje v ")
                lsql = String.Concat(lsql, " where it.id=v.IdIt and  v.codigo='", IdViaje, "' ")
                Cmd = New SqlCommand(lsql, Con)
                Cmd.Transaction = tran
                Cmd.ExecuteNonQuery()

                lsql = "Update Piezas set Estado='51' from DetallePaquetesPieza d where  d.id=" & lIdEtiqueta
                lsql = lsql & " and Piezas.estado<>'00' and piezas.id=d.IdPieza  "
                Cmd = New SqlCommand(lsql, Con)
                Cmd.Transaction = tran
                Cmd.ExecuteNonQuery()

                tran.Commit()
                lRes = "OK"
            Catch ex As Exception
                tran.Rollback()
                lRes = ex.Message.ToString()
            Finally
                If Con.State <> Data.ConnectionState.Closed Then Con.Close()
            End Try

        End Using


        Return lRes
    End Function

#End Region


    Public Function ObtenerKgsViajes(ByVal iViajes As String) As String
        Dim lRes As DataTable, lsql As String = " ", lDal As New ClsDatos, lPartes() As String = Nothing
        Dim lLista As New ArrayList, i As Integer = 0, TotallKgs As Integer = 0, lGuias As String = ""
        'Dim lCodigos As String = ""
        'En INET se concatenan los viajes y el separdor puede ser , o ;

        lPartes = iViajes.Split(",")
        If lPartes.Length = 1 Then
            lPartes = iViajes.Split(";")
            If lPartes.Length = 1 Then
                'Hay solo un viaje 
                lLista.Add(lPartes(0))
            Else
                For i = 0 To lPartes.Length - 1
                    lLista.Add(lPartes(i))
                Next
            End If
        Else
            For i = 0 To lPartes.Length - 1
                lLista.Add(lPartes(i))
            Next
        End If

        TotallKgs = 0
        For i = 0 To lLista.Count - 1
            lsql = "Select p.IdViaje ,  SUM (d.kgspaquete) kilosViaje"
            lsql = String.Concat(lsql, " from Piezas p , DetallePaquetesPieza d , viaje v  where   p.Id =d.IdPieza   ")
            lsql = String.Concat(lsql, " and p.estado<>'00' and v.estado<>'00' and d.idviaje=v.id and codigo='", lLista(i).ToString.Trim, "'  group by p.idviaje, d.IdViaje  ")
            lRes = CargaTabla(lsql)
            If lRes.Rows.Count > 0 Then
                TotallKgs = TotallKgs + Val(lRes.Rows(0)("KilosViaje").ToString)
                'lGuias = String.Concat (lGuias , "-" lRes.Rows(i)("KilosViaje").ToString)
            End If
        Next

        Return TotallKgs

    End Function


    Public Function PiezaConFactorDeCorrecion(iIdPiezaTipob As String, iIdPieza As String) As Boolean
        Dim lRes As Boolean = False
        Dim lTbl As New DataTable, lsql As String = " ", lDal As New ClsDatos

        If Val(iIdPiezaTipob) > 0 Then
            lsql = String.Concat("  SP_Consultas_WS  160,'PTB','", iIdPiezaTipob, "','','','','',''")
        Else
            lsql = String.Concat("  SP_Consultas_WS  160,'P','", iIdPieza, "','','','','',''")
        End If
        lTbl = CargaTabla(lsql)
        If lTbl.Rows.Count > 0 Then
            If (lTbl.Rows(0)("FC").ToString.ToUpper.Equals("S")) Then
                lRes = True
            End If
        End If

        Return lRes
    End Function

#Region "Metodos Privados"

    Private Function ObtenerIT(ByVal iIdIt As String) As BussinesObjects.Tipos.Tipo_IT
        Dim lListaPiezas As New List(Of BussinesObjects.Tipos.Tipo_Pieza)
        Dim lIT As New BussinesObjects.Tipos.Tipo_IT
        Dim lTbl As New DataTable
        Dim lSql As String = " Select *, isnull(sumakilos,'S') SumarKilos from It where Id=" & iIdIt

        lTbl = CargaTabla(lSql)
        If lTbl.Rows.Count > 0 Then
            lIT.CodigoIT = lTbl.Rows(0)("COdigoIt").ToString 'lTbl.Rows(0)("COdigoIt").ToString
            lIT.NroIt = lTbl.Rows(0)("NroIt").ToString
            lIT.EntregadoA = lTbl.Rows(0)("EntragadoA").ToString
            lIT.EntregadoPor = lTbl.Rows(0)("EntregadoPor").ToString
            lIT.Id = lTbl.Rows(0)("id").ToString
            lIT.FechaEntrega = lTbl.Rows(0)("FechaEntrega").ToString
            lIT.FechaDespacho = lTbl.Rows(0)("FechaDespacho").ToString
            lIT.IdObra = lTbl.Rows(0)("IdObra").ToString
            lIT.FechaCrea = lTbl.Rows(0)("FechaCreacion").ToString
            lIT.TipoIT = lTbl.Rows(0)("TipoIt").ToString
            lIT.Estado = lTbl.Rows(0)("Estado").ToString
            lIT.IdSucursal = lTbl.Rows(0)("IdSucursal").ToString
            lIT.SumaKilos = lTbl.Rows(0)("SumarKilos").ToString
            lIT.EsFacturable = lTbl.Rows(0)("TipoGUIA_INET").ToString
            lIT.IdMotivoReposicion = lTbl.Rows(0)("idMotivoRep").ToString


            lSql = "select count(1),round(sum(totalKgs),0) from piezas where Estado<>'00' and Id_It = " & iIdIt
            lTbl = CargaTabla(lSql)
            If lTbl.Rows.Count > 0 Then
                lIT.NroPiezas = lTbl.Rows(0)(0).ToString
                lIT.TotalKgs = lTbl.Rows(0)(1).ToString
            End If



        End If
        Return lIT
    End Function

    Private Function ObtenerITPorCodViaje(ByVal iCodViaje As String) As BussinesObjects.Tipos.Tipo_IT
        Dim lListaPiezas As New List(Of BussinesObjects.Tipos.Tipo_Pieza)
        Dim lIT As New BussinesObjects.Tipos.Tipo_IT
        Dim lTbl As New DataTable, lIdViaje As String = ""
        Dim lSql As String = " Select Viaje.Id IdViaje , * from It , Viaje where Viaje.codigo='" & iCodViaje & "' and It.Id=IdIt"

        lTbl = CargaTabla(lSql)
        If lTbl.Rows.Count > 0 Then
            lIdViaje = lTbl.Rows(0)("IdViaje").ToString
            lIT.CodigoIT = lTbl.Rows(0)("COdigoIt").ToString
            lIT.EntregadoA = lTbl.Rows(0)("EntragadoA").ToString
            lIT.EntregadoPor = lTbl.Rows(0)("EntregadoPor").ToString
            lIT.Id = lTbl.Rows(0)("id").ToString
            lIT.FechaEntrega = lTbl.Rows(0)("FechaEntrega").ToString
            lIT.FechaDespacho = lTbl.Rows(0)("FechaDespacho").ToString
            lIT.IdObra = lTbl.Rows(0)("IdObra").ToString
            lIT.FechaCrea = lTbl.Rows(0)("FechaCreacion").ToString
            lIT.TipoIT = lTbl.Rows(0)("TipoIt").ToString
            lSql = "select count(1),round(sum(totalKgs),0) from piezas where Estado<>'00' and  IdViaje = " & lIdViaje
            lTbl = CargaTabla(lSql)
            If lTbl.Rows.Count > 0 Then
                lIT.NroPiezas = lTbl.Rows(0)(0).ToString
                lIT.TotalKgs = lTbl.Rows(0)(1).ToString
            End If
        End If
        Return lIT
    End Function

    Private Function CreaMensaje(ByVal iIt As BussinesObjects.Tipos.Tipo_IT, ByVal iOrigen As String) As BussinesObjects.Tipos.Tipo_Msg
        Dim lMsg As New BussinesObjects.Tipos.Tipo_Msg
        Dim lDests As New List(Of BussinesObjects.Tipos.TipoDestinatarioMsg)
        Dim lDest As BussinesObjects.Tipos.TipoDestinatarioMsg = Nothing
        Dim lNomObra As String = "", lNroPiezas As String = "", lSql As String = ""
        Dim lTabla As New DataTable, i As Integer = 0

        'Obtenemos los datos de la Obra
        lSql = " select obra,count(1) NroPiezas from piezas P, HojaDespiece Hd"
        lSql = lSql & " where p.Estado<>'00' and  p.Id_hd = hd.id And idObra =" & iIt.IdObra & " group by obra"
        lTabla = CargaTabla(lSql)
        If Not lTabla Is Nothing And lTabla.Rows.Count > 0 Then
            lNomObra = lTabla.Rows(0)("Obra").ToString
            lNroPiezas = lTabla.Rows(0)(1).ToString
            lMsg.Detalle = String.Concat(" Se ha Creado una nueva I.T (", iIt.Id, ")  con fecha: ", iIt.FechaCrea)
            lMsg.Detalle = String.Concat(lMsg.Detalle, vbCrLf, " Para la obra: ", lNomObra, " Con ", lNroPiezas, " piezas")
            lMsg.IdObra = iIt.IdObra
            lMsg.Origen = iOrigen
            'Obtenemos los datos de los destinatrios 
            lSql = " select Id from to_usuarios"
            lSql = lSql & " where Vigente='S' and RecibeMsg='S' "
            lTabla = CargaTabla(lSql)
            For i = 0 To lTabla.Rows.Count - 1
                lDest = New BussinesObjects.Tipos.TipoDestinatarioMsg
                lDest.IdUserDestino = lTabla.Rows(i)(0).ToString
                lDest.Leido = "N"
                lDest.Vigente = "S"
                lDests.Add(lDest)
            Next
            lMsg.ListaDest = lDests
        End If
        Return lMsg
    End Function

    Public Function GrabaMensaje(ByVal iMsg As BussinesObjects.Tipos.Tipo_Msg) As BussinesObjects.Tipos.Tipo_Msg
        Dim lTipoSQl As New BussinesObjects.Clases.Cls_Sql
        Dim lSql As String = lTipoSQl.SqlInsertaMSG(iMsg)
        Dim lDal As New BussinesObjects.Clases.Cls_Datos
        Dim lRes As String = "", i As Integer = 0, lEstado As Boolean = False

        lRes = EjecutaDML(lSql)
        Try
            If Val(lRes) > 0 Then
                iMsg.Id = lDal.ObtenerUltimoId("Mensajes")
                For i = 0 To iMsg.ListaDest.Count - 1
                    iMsg.ListaDest(i).IdMsg = iMsg.Id
                    lSql = lTipoSQl.SqlInsertaDestMSG(iMsg.ListaDest(i))
                    lRes = EjecutaDML(lSql)
                    If Val(lRes) > 0 Then
                        lEstado = True
                    Else
                        lEstado = False
                    End If
                Next
            End If
        Catch ex As Exception
            iMsg.Error = ex.Message.ToString
        End Try
        Return iMsg
    End Function

    Public Function DevolucionCompletoDeCamion(ByVal iCodigoViaje As String) As String
        Dim lRes As String = ""
        Try





        Catch ex As Exception
            lRes = ex.Message
        End Try


        Return lRes

    End Function

#End Region






End Class

