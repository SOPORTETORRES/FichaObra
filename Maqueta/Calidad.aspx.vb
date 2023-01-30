Imports System.Drawing

Public Class Calidad
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim obra As Integer = Session("obra")
        ResumenCertificacion()
        CargaDatosObra(obra)
        CargaTablaLotesPerdidos()
        CargaTablaControlesObra()
        EstadoBloqueo()
    End Sub

    Private Sub CargaDatosObra(IdOBra As String)
        Dim ldal As New Datos
        Dim lSql As String = ""
        Dim lTabla As New Data.DataTable
        lTabla = ldal.CargaTabla_DatosObra(IdOBra)
        If lTabla.Rows.Count > 0 Then
            '----------------- DATOS DE SOLICITUD ------------------------------
            txtNombreObra.Text = lTabla.Rows(0)("Nombre").ToString()
            txtSigla.Text = lTabla.Rows(0)("SiglaObra").ToString()
            txtEstado.Text = lTabla.Rows(0)("EstadoAlta").ToString()
        Else
            'Validar sin informacion
        End If
    End Sub

    Private Sub ResumenCertificacion()
        Dim ldal As New Datos, lSql As String = "", obra As Integer = Session("obra"), lTabla As New Data.DataTable
        Dim data1 As Integer, data2 As Integer, data3 As Integer, totalData As Integer
        lSql = String.Concat("select  MailCalidadEnviado as Email, count(1) from it , viaje v where idobra= ", obra, " and it.id=v.idit  and nroguiaINET>0 group by MailCalidadEnviado ")
        Try
            lTabla = ldal.CargaTabla(lSql, "L")
            If lTabla.Rows.Count > 0 Then
                If lTabla.Rows(0)("Email").ToString().Equals("E") Then
                    data1 = Val(lTabla.Rows(0)("Column1").ToString())
                End If
                If lTabla.Rows(1)("Email").ToString().Equals("S") Then
                    data2 = Val(lTabla.Rows(1)("Column1").ToString())
                End If
                If lTabla.Rows(2)("Email").ToString().Equals("") Then
                    data3 = Val(lTabla.Rows(2)("Column1").ToString())
                End If
                totalData = data1 + data2 + data3
                lblDespachado.Text = totalData
                lblCertificado.Text = data2
                lblPorcentaje.Text = Math.Round((data2 / totalData) * 100, 2) & " %"
                'lcDisponible = lcAprobada - lcuso2
                '    lbl_lcDatoDisponible.Text = Format(Val(lcDisponible), "#,##0") & " UF"
                'lcporcentaje = Math.Round((lcDisponible * 100) / lcAprobada)
            End If
        Catch ex As Exception
            'error
        End Try
    End Sub

    Private Sub CargaTablaLotesPerdidos()
        Dim lDAtos As New Datos, lTblRes As New DataTable, IdObra As String = ""
        IdObra = Session("obra")
        lTblRes = lDAtos.CargaTablaLotesPerdidos(IdObra)
        gvLotesMissed.DataSource = lTblRes
        gvLotesMissed.DataBind()
    End Sub

    Private Sub CargaTablaControlesObra()
        Dim lDAtos As New Datos, lTblRes As New DataTable, IdObra As String = ""
        IdObra = Session("obra")
        lTblRes = lDAtos.CargaTablaControlesObra(IdObra)
        gvControl.DataSource = lTblRes
        gvControl.DataBind()
    End Sub

    Protected Sub gvControl_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles gvControl.RowDataBound
        If e.Row.Cells(4).Text = "Rechazado" Then
            e.Row.BackColor = Color.LightSalmon
            e.Row.ForeColor = Color.White
        ElseIf e.Row.Cells(4).Text = "Aprobado" Then
            e.Row.BackColor = Color.LightGreen
            e.Row.ForeColor = Color.White
        End If
    End Sub

    Protected Sub btnExportar_Click(sender As Object, e As EventArgs) Handles btnExportar.Click
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

    Private Sub EstadoBloqueo()
        Dim ldal As New Datos, lSql As String = "", obra As Integer = Session("obra"), lTabla As New Data.DataTable
        lSql = String.Concat("Select top 1 Par1 IdObra,  o.nombre      , PAr3 Obs from to_parametros  , Obras o  where  subTabla = 'BloqueosCalidad' and par1=o.id and o.id = ", obra, "")
        Try
            lTabla = ldal.CargaTabla(lSql, "L")
            If lTabla.Rows.Count > 0 Then
                txtBloqueo.Text = "Bloqueada"
                txtObs.Text = lTabla.Rows(0)("Obs").ToString()
            Else
                txtBloqueo.Text = "No registra bloqueo"
            End If
        Catch ex As Exception
            'error
        End Try
    End Sub

    Protected Sub BtnCuadroProg_Click(sender As Object, e As EventArgs) Handles BtnCuadroProg.Click
        Response.Write("<script>window.open('http://192.168.1.195/Infomes/CuadroProgramacionPr.aspx','_blank');</script>")
    End Sub

    Protected Sub btnPantallaCamiones_Click(sender As Object, e As EventArgs) Handles btnPantallaCamiones.Click
        Response.Write("<script>window.open('http://192.168.1.195/Infomes/ResumenDesp.aspx','_blank');</script>")
    End Sub

    Protected Sub btnListado_Click(sender As Object, e As EventArgs) Handles btnListado.Click
        Response.Redirect("LotesNoEncontrados.aspx")
    End Sub
End Class