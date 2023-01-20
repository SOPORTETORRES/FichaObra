Public Class CambioPrecioMasivo
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If IsPostBack = False Then
            CargaDatos()
        End If
    End Sub

    Private Sub CargaDatos()
        Dim lSql As String = "", lTblRes As New DataTable, i As Integer = 0, lDal As New Datos
        Dim lTblServicios As New DataTable(), lFila As DataRow, lTotalPr As Double = 0

        '**********Servicios
        lTblServicios.Columns.Add("Servicio", Type.GetType("System.String"))
        lTblServicios.Columns.Add("Codigo", Type.GetType("System.String"))

        lFila = lTblServicios.NewRow() : lFila("Servicio") = "Suministro" : lFila("Codigo") = "S" : lTblServicios.Rows.Add(lFila)
        'lFila = lTblServicios.NewRow() : lFila("Servicio") = "Preparación" : lFila("Codigo") = "P" : lTblServicios.Rows.Add(lFila)
        'lFila = lTblServicios.NewRow() : lFila("Servicio") = "Pre Armado" : lFila("Codigo") = "PA" : lTblServicios.Rows.Add(lFila)
        'lFila = lTblServicios.NewRow() : lFila("Servicio") = "Instalación" : lFila("Codigo") = "I" : lTblServicios.Rows.Add(lFila)
        lFila = lTblServicios.NewRow() : lFila("Servicio") = "Seleccionar" : lFila("Codigo") = "0" : lTblServicios.Rows.Add(lFila)

        Cmb_Servicios.DataSource = lTblServicios
        Cmb_Servicios.DataTextField = "Servicio"
        Cmb_Servicios.DataValueField = "Codigo"
        Cmb_Servicios.SelectedIndex = lTblServicios.Rows.Count - 1
        Cmb_Servicios.DataBind()

        '***************Cargamos las Obras
        lSql = String.Concat("Exec [SP_Consultas_WS] 228,'','','','','','',''")
        lTblRes = lDal.CargaTabla(lSql, "L")
        For i = 0 To lTblRes.Rows.Count - 1
            lTotalPr = Val(lTblRes.Rows(i)("KgsOc").ToString) * Val(lTblRes.Rows(i)("PrecioActual").ToString)
            lTblRes.Rows(i)("KgsOc") = Format(Val(lTblRes.Rows(i)("KgsOc").ToString), "#,##0")
            lTblRes.Rows(i)("PrecioActual") = Format(Val(lTblRes.Rows(i)("PrecioActual").ToString.Replace(".", "")), "#,##0")
            lTblRes.Rows(i)("TotalProyecto") = Format(Val(lTotalPr.ToString), "#,##0")
        Next


        Gr_Datos.DataSource = lTblRes
        Gr_Datos.DataBind()

        Dim lTbl As New DataTable
        lSql = "exec SP_Consultas_WS 34,'','','','','','',''"

        lTbl = lDal.CargaTabla(lSql, "L")
        lFila = lTbl.NewRow
        lFila("Suc") = "Seleccione Sucursal"
        lFila("Sucursal") = "Seleccione Sucursal"
        lTbl.Rows.Add(lFila)

        Cmb_sucursal.DataSource = lTbl
        Cmb_sucursal.DataTextField = "Suc"
        Cmb_sucursal.DataValueField = "Sucursal"
        Cmb_sucursal.SelectedIndex = lTbl.Rows.Count - 1
        Cmb_sucursal.DataBind()
    End Sub

End Class