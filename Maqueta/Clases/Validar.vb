Public Class Validar
    Public lnotificacion As Integer
    Public fabricacion As String, suministro As String, diametro As String, sucursal As String, calidadsum As String, preciosuministro As String
    Public obra As String, cantenf As String, txt3_1 As String, txt3_3 As String, txt3_4 As String, txt3_44 As String, txt3_6 As String
    Public txt3_12 As String, txt4_1 As String, txt4_2 As String, txt4_3 As String, txt4_4 As String, txt5_1 As String, dp6_1 As String
    Public dp7_1 As String, direccion As String, calidad As String, dp7_3 As String
    Public txtcomodin As String, preciocomodin As String, cbTransporte As String, txtCantidadKgs As String, txtPrecioTransporte As String
    Public NombreCliente As String, Prefijo As String, Telefono As String, Email As String, Empresa As String, Rut As String


    Public Function Suministros() As Boolean
        Dim lresultado As Boolean
        If suministro = "Seleccione:" Then
            lnotificacion = 11
            lresultado = False
        Else
            If diametro = "Seleccione:" Then
                lnotificacion = 12
                lresultado = False
            Else
                If sucursal = "Seleccione:" Then
                    lnotificacion = 13
                    lresultado = False
                Else
                    If preciosuministro = "" Then
                        lnotificacion = 14
                        lresultado = False
                    Else
                        If calidadsum = "Seleccione:" Then
                            lnotificacion = 37
                            lresultado = False
                        Else
                            If fabricacion = "Seleccione:" Then
                                lnotificacion = 38
                                lresultado = False
                            Else
                                If calidad = "Seleccione:" Then
                                    lnotificacion = 40
                                    lresultado = False
                                Else
                                    lresultado = True
                                End If
                            End If
                        End If
                    End If
                End If
            End If
        End If
        Return lresultado
    End Function

    Public Function comodin() As Boolean
        Dim lresultado As Boolean
        If txtcomodin = "" Then
            lnotificacion = 31
            lresultado = False
        Else
            If preciocomodin = "" Then
                lnotificacion = 32
                lresultado = False
            Else
                lresultado = True
            End If
        End If
        Return lresultado
    End Function

    Public Function flete() As Boolean
        Dim lresultado As Boolean
        If cbTransporte = "Cliente retira" Then
            lresultado = True
        Else
            If cbTransporte = "Seleccione:" Then
                lnotificacion = 33
                lresultado = False
            Else
                If txtPrecioTransporte = "" Then
                    lnotificacion = 35
                    lresultado = False
                Else
                    lresultado = True
                End If
            End If
        End If
        Return lresultado
    End Function

    Public Function formatPeso(valor As String) As String
        Dim newvalor As String
        If valor.IndexOf(",") > -1 Then
            newvalor = FormatNumber(valor.Replace(".", ","), 1, , , TriState.True)
            Return newvalor
        Else
            'Format(CDbl(valor.ToString), "#,##0")
            newvalor = Format(CDbl(valor), "#,##0")
            Return newvalor
        End If
    End Function

    Public Function ValidaLogistica(codigo As String, TiempoDesplazamiento As String)
        Dim lres As String = "OK"
        If codigo = "" Then
            lres = "CodigoEr"
        Else
            If TiempoDesplazamiento = "Seleccione:" Then
                lres = "TiempoDespEr"
            End If
        End If
        Return lres
    End Function

    Public Function ValidaCostoDespacho(neto As String, sobreestadia As String, FleteFalso As String, N_factura As String)
        Dim lres As String = "OK"
        If neto = "" Then
            lres = "neto()"
        Else
            If sobreestadia = "" Then
                lres = "sobreestadia()"
            Else
                If FleteFalso = "" Then
                    lres = "FleteFalso()"
                Else
                    If N_factura = "" Then
                        lres = "N_factura()"
                    End If
                End If
            End If
        End If
        Return lres
    End Function

End Class
