Public Class InfAumentoOC
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            CargaDesplegable()
            CargaDatos()

        End If
    End Sub

    Private Sub CargaDesplegable()
        Dim lTbl As New DataTable, lFecha As Date = Now.Date, i As Integer = 0
        Dim lPeriodo As String = "", lfila As DataRow
        lTbl.Columns.Add("Periodo", Type.GetType("System.String"))
        For i = 1 To 6
            lfila = lTbl.NewRow
            lfila("Periodo") = String.Concat(lFecha.Month, "-", lFecha.Year)
            lTbl.Rows.Add(lfila)
            lFecha = DateAdd(DateInterval.Month, -1, lFecha)
        Next
        Cmb_Mes.DataSource = lTbl
        Cmb_Mes.DataTextField = "Periodo"
        Cmb_Mes.DataValueField = "Periodo"
        Cmb_Mes.DataBind()
    End Sub

    Private Sub CargaDatos()
        Dim lSql As String = "", lTbl As New DataTable, lDal As New Datos
        Dim i As Integer = 0, lTotalKgs As Integer = 0, lFila As DataRow = Nothing


        lSql = " SP_Consultas_WS 165,'','','','','','','' "
        lTbl = lDal.CargaTabla(lSql, "L")

        For i = 0 To lTbl.Rows.Count - 1
            lTotalKgs = lTotalKgs + Val(lTbl.Rows(i)("KgsAgregados").ToString)
            lTbl.Rows(i)("KgsAgregados") = Format(Val(lTbl.Rows(i)("KgsAgregados").ToString), "#,##0")
        Next

        lFila = lTbl.NewRow
        lFila("Cliente") = "Total"
        lFila("KgsAgregados") = Format(Val(lTotalKgs), "#,##0")
        lTbl.Rows.Add(lFila)

        Gr_AumentosOC.DataSource = lTbl
        Gr_AumentosOC.DataBind()

    End Sub

    Private Sub CargaDatos(iMes As String, iYear As String)
        Dim lSql As String = "", lTbl As New DataTable, lDal As New Datos
        Dim i As Integer = 0, lTotalKgs As Integer = 0, lFila As DataRow = Nothing


        lSql = String.Concat(" SP_Consultas_WS 167,'", iMes, "','", iYear, "','','','','','' ")
        lTbl = lDal.CargaTabla(lSql, "L")

        For i = 0 To lTbl.Rows.Count - 1
            lTotalKgs = lTotalKgs + Val(lTbl.Rows(i)("KgsAgregados").ToString)
            lTbl.Rows(i)("KgsAgregados") = Format(Val(lTbl.Rows(i)("KgsAgregados").ToString), "#,##0")
        Next

        lFila = lTbl.NewRow
        lFila("Cliente") = "Total"
        lFila("KgsAgregados") = Format(Val(lTotalKgs), "#,##0")
        lTbl.Rows.Add(lFila)

        Gr_AumentosOC.DataSource = lTbl
        Gr_AumentosOC.DataBind()

    End Sub

    Protected Sub Btn_Buscar_Click(sender As Object, e As EventArgs) Handles Btn_Buscar.Click
        Dim lPer As String = Cmb_Mes.SelectedValue
        Dim lPartes() As String = lPer.Split("-")
        CargaDatos(lPartes(0), lPartes(1))
    End Sub
End Class