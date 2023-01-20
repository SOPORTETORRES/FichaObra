
function logininvalido() {
    Swal.fire({
        icon: 'error',
        title: 'Oops...',
        text: 'Usuario o contrasena no validos',
        showConfirmButton: false,
        timer: 1500
    })
}

function registrook() {
    Swal.fire(
        'Listo...',
        'la solicitud se ha registrado correctamente',
        'success',
        window.location.href = "index.aspx"
    )
}


function registrofalse() {
    Swal.fire({
        icon: 'error',
        title: 'Oops...',
        text: 'No se ha podido ingresar la solicitud',
        showConfirmButton: false,
        timer: 1500
    })
}

function tipoCotizacion() {
    const dpTipoCotizacion = document.getElementById('dpTipoCotizacion');
    Swal.fire({
        icon: 'error',
        title: 'Oops...',
        text: 'Campo Tipo Cotizacion no se ha seleccionado',
        showConfirmButton: false,
        timer: 1500,
        focus: dpTipoCotizacion.focus()
    })
}

function region() {
    const cbRegiones = document.getElementById('cbRegiones');
    Swal.fire({
        icon: 'error',
        title: 'Oops...',
        text: 'Campo Region no se ha seleccionado',
        showConfirmButton: false,
        timer: 1500,
        focus: cbRegiones.focus()
    })
}

function tipoObra() {
    const cbTipoObra = document.getElementById('cbTipoObra');
    Swal.fire({
        icon: 'error',
        title: 'Oops...',
        text: 'Campo Tipo Obra no se ha seleccionado',
        showConfirmButton: false,
        timer: 1500,
        focus: cbTipoObra.focus()
    })
}

function calidadAcero() {
    const checkCalidad = document.getElementById('checkCalidad');
    Swal.fire({
        icon: 'error',
        title: 'Oops...',
        text: 'Campo Calidad Acero no se ha seleccionado',
        showConfirmButton: false,
        timer: 1500,
        focus: checkCalidad.focus()
    })
}

function fabricacion() {
    Swal.fire({
        icon: 'error',
        title: 'Oops...',
        text: 'Campo Lugar Fabricacion no se ha seleccionado',
        showConfirmButton: false,
        timer: 1500
    })
}

function reajuste() {
    const cbTipoAjuste = document.getElementById('cbTipoAjuste');
    Swal.fire({
        icon: 'error',
        title: 'Oops...',
        text: 'Campo Tipo Reajuste no se ha seleccionado',
        showConfirmButton: false,
        timer: 1500,
        focus: cbTipoAjuste.focus()
    })
}

function vigenciaAlambre() {
    const cbVigenciaAlambre = document.getElementById('cbVigenciaAlambre');
    Swal.fire({
        icon: 'error',
        title: 'Oops...',
        text: 'Campo Vigencia Alambre no se ha seleccionado',
        showConfirmButton: false,
        timer: 1500,
        focus: cbVigenciaAlambre.focus()
    })
}

function vigenciaFlete() {
    const cbVigenciaTransporte = document.getElementById('cbVigenciaTransporte');
    Swal.fire({
        icon: 'error',
        title: 'Oops...',
        text: 'Campo Vigencia Flete no se ha seleccionado',
        showConfirmButton: false,
        timer: 1500,
        focus: cbVigenciaTransporte.focus()
    })
}

function fechaObra() {
    const txtFechaObra = document.getElementById('txtFechaObra');
    Swal.fire({
        icon: 'error',
        title: 'Oops...',
        text: 'Debe seleccionar fecha de la obra',
        showConfirmButton: false,
        timer: 1500,
        focus: txtFechaObra.focus()
    })
}

function FechaVigencia() {
    const txtFechaVigencia = document.getElementById('txtFechaVigencia');
    Swal.fire({
        icon: 'error',
        title: 'Oops...',
        text: 'Debe seleccionar fecha de vigencia',
        showConfirmButton: false,
        timer: 1500,
        focus: txtFechaVigencia.focus()
    })
}

function suministro() {
    const cbSuministros = document.getElementById('cbSuministros');
    Swal.fire({
        icon: 'error',
        title: 'Oops...',
        text: 'Campo Suministro no se ha seleccionado',
        showConfirmButton: false,
        timer: 1500,
        focus: cbSuministros.focus()
    })
}

function diametro() {
    const dpDiametro = document.getElementById('dpDiametro');
    Swal.fire({
        icon: 'error',
        title: 'Oops...',
        text: 'Campo Diametro no se ha seleccionado',
        showConfirmButton: false,
        timer: 1500,
        focus: dpDiametro.focus()
    })
}

function sucursal() {
    const dpSucursal = document.getElementById('dpSucursal');
    Swal.fire({
        icon: 'error',
        title: 'Oops...',
        text: 'Campo Sucursal no se ha seleccionado',
        showConfirmButton: false,
        timer: 1500,
        focus: dpSucursal.focus()
    })
}

function precioSuministro() {
    const txtPrecioSuministro = document.getElementById('txtPrecioSuministro');
    Swal.fire({
        icon: 'error',
        title: 'Oops...',
        text: 'Campo precio suministro vacio',
        showConfirmButton: false,
        timer: 1500,
        focus: txtPrecioSuministro.focus()
    })
}

function obra() {
    const obra = document.getElementById('txtObra');
    Swal.fire({
        icon: 'error',
        title: 'Oops...',
        text: 'Campo obra no puede estar vacio',
        showConfirmButton: false,
        timer: 1500,
        focus: obra.focus()
    })
}

function direccion() {
    const direccion = document.getElementById('txtDireccion');
    Swal.fire({
        icon: 'error',
        title: 'Oops...',
        text: 'Campo direccion no puede estar vacio',
        showConfirmButton: false,
        timer: 1500,
        focus: direccion.focus()
    })
}

function cantenf() {
    const cantenf = document.getElementById('txtcantidadenfierradura');
    Swal.fire({
        icon: 'error',
        title: 'Oops...',
        text: 'Campo cantidad enfierradura no puede estar vacio',
        showConfirmButton: false,
        timer: 1500,
        focus: cantenf.focus()
    })
}

function txt3_1() {
    const txt3_1 = document.getElementById('txt3_1');
    Swal.fire({
        icon: 'error',
        title: 'Oops...',
        text: 'Campo texto del punto 3.1 no puede estar vacio',
        showConfirmButton: false,
        timer: 1500,
        focus: txt3_1.focus()
    })
}

function txt3_3() {
    const txt3_3 = document.getElementById('txt3_3');
    Swal.fire({
        icon: 'error',
        title: 'Oops...',
        text: 'Campo texto del punto 3.3 no puede estar vacio',
        showConfirmButton: false,
        timer: 1500,
        focus: txt3_3.focus()
    })
}

function txt3_4() {
    const txt3_4 = document.getElementById('txt3_4');
    Swal.fire({
        icon: 'error',
        title: 'Oops...',
        text: 'Campo texto del punto 3.4 no puede estar vacio',
        showConfirmButton: false,
        timer: 1500,
        focus: txt3_4.focus()
    })
}

function txt3_44() {
    const txt3_44 = document.getElementById('txt3_44');
    Swal.fire({
        icon: 'error',
        title: 'Oops...',
        text: 'Segun campo de texto del punto 3.4 no puede estar vacio',
        showConfirmButton: false,
        timer: 1500,
        focus: txt3_44.focus()
    })
}

function txt3_6() {
    const txt3_6 = document.getElementById('txt3_6');
    Swal.fire({
        icon: 'error',
        title: 'Oops...',
        text: 'Campo de texto del punto 3.6 no puede estar vacio',
        showConfirmButton: false,
        timer: 1500,
        focus: txt3_6.focus()
    })
}

function txt3_12() {
    const txt3_12 = document.getElementById('txt3_12');
    Swal.fire({
        icon: 'error',
        title: 'Oops...',
        text: 'Campo de texto del punto 3.12 no puede estar vacio',
        showConfirmButton: false,
        timer: 1500,
        focus: txt3_12.focus()
    })
}

function txt4_1() {
    const txt4_1 = document.getElementById('txt4_1');
    Swal.fire({
        icon: 'error',
        title: 'Oops...',
        text: 'Campo de texto del punto 4.1 no puede estar vacio',
        showConfirmButton: false,
        timer: 1500,
        focus: txt4_1.focus()
    })
}

function txt4_2() {
    const txt4_2 = document.getElementById('txt4_2');
    Swal.fire({
        icon: 'error',
        title: 'Oops...',
        text: 'Campo de texto del punto 4.2 no puede estar vacio',
        showConfirmButton: false,
        timer: 1500,
        focus: txt4_2.focus()
    })
}

function txt4_3() {
    const txt4_3 = document.getElementById('txt4_3');
    Swal.fire({
        icon: 'error',
        title: 'Oops...',
        text: 'Campo de texto del punto 4.3 no puede estar vacio',
        showConfirmButton: false,
        timer: 1500,
        focus: txt4_3.focus()
    })
}

function txt4_4() {
    const txt4_4 = document.getElementById('txt4_4');
    Swal.fire({
        icon: 'error',
        title: 'Oops...',
        text: 'Campo de texto del punto 4.4 no puede estar vacio',
        showConfirmButton: false,
        timer: 1500,
        focus: txt4_4.focus()
    })
}

function txt5_1() {
    const txt5_1 = document.getElementById('txt5_1');
    Swal.fire({
        icon: 'error',
        title: 'Oops...',
        text: 'Campo de texto del punto 5.1 no puede estar vacio',
        showConfirmButton: false,
        timer: 1500,
        focus: txt5_1.focus()
    })
}

function dp6_1() {
    const dp6_1 = document.getElementById('dp6_1');
    Swal.fire({
        icon: 'error',
        title: 'Oops...',
        text: 'Campo de texto del punto 6.1 no puede estar vacio',
        showConfirmButton: false,
        timer: 1500,
        focus: dp6_1.focus()
    })
}

function dp7_1() {
    const dp7_1 = document.getElementById('dp7_1');
    Swal.fire({
        icon: 'error',
        title: 'Oops...',
        text: 'Campo de texto del punto 7.1 no puede estar vacio',
        showConfirmButton: false,
        timer: 1500,
        focus: dp7_1.focus()
    })
}

function dp7_3() {
    const dp7_3 = document.getElementById('dp7_3');
    Swal.fire({
        icon: 'error',
        title: 'Oops...',
        text: 'Campo de texto del punto 7.3 no puede estar vacio',
        showConfirmButton: false,
        timer: 1500,
        focus: dp7_3.focus()
    })
}


function txtcomodin() {
    const txtcomodin = document.getElementById('txtComodin');
    Swal.fire({
        icon: 'error',
        title: 'Oops...',
        text: 'Campo texto no puede estar vacio',
        showConfirmButton: false,
        timer: 1500,
        focus: txtcomodin.focus()
    })
}

function txtPrecioComodin() {
    const txtPrecioComodin = document.getElementById('txtPrecioComodin');
    Swal.fire({
        icon: 'error',
        title: 'Oops...',
        text: 'Campo precio no puede estar vacio',
        showConfirmButton: false,
        timer: 1500,
        focus: txtPrecioComodin.focus()
    })
}

function cbTransporte() {
    const cbTransporte = document.getElementById('cbTransporte');
    Swal.fire({
        icon: 'error',
        title: 'Oops...',
        text: 'Campo tipo transporte sin seleccion',
        showConfirmButton: false,
        timer: 1500,
        focus: cbTransporte.focus()
    })
}

function txtCantidadKgs() {
    const txtCantidadKgs = document.getElementById('txtCantidadKgs');
    Swal.fire({
        icon: 'error',
        title: 'Oops...',
        text: 'Campo cantidad kgs no puede estar vacio',
        showConfirmButton: false,
        timer: 1500,
        focus: txtCantidadKgs.focus()
    })
}

function txtPrecioTransporte() {
    const txtPrecioTransporte = document.getElementById('txtPrecioTransporte');
    Swal.fire({
        icon: 'error',
        title: 'Oops...',
        text: 'Campo precio transporte no puede estar vacio',
        showConfirmButton: false,
        timer: 1500,
        focus: txtPrecioTransporte.focus()
    })
}

function fechamenoractual() {
    const txtFechaVigencia = document.getElementById('txtFechaVigencia');
    Swal.fire({
        icon: 'error',
        title: 'Oops...',
        text: 'La fecha seleccionada es inferior a la fecha actual',
        showConfirmButton: false,
        timer: 1500,
        focus: txtFechaVigencia.focus()
    })
}


function seleccioninvalida() {
    Swal.fire({
        icon: 'error',
        title: 'Oops...',
        text: 'La sucursal no coincide con la seleccion',
        showConfirmButton: false,
        timer: 1500
    })
}

function calidadinvalida() {
    Swal.fire({
        icon: 'error',
        title: 'Oops...',
        text: 'La calidad no coincide con la seleccion',
        showConfirmButton: false,
        timer: 2500
    })
}

function pdferror() {
    Swal.fire({
        icon: 'error',
        title: 'Oops...',
        text: 'Hubo un error al generar el archivo pdf',
        showConfirmButton: false,
        timer: 2500
    })
}

function pdfok() {
    Swal.fire(
        'Listo...',
        'El archivo pdf se ha generado correctamente',
        'success'
    )
}

function cotizacionOK() {
    Swal.fire(
        'Listo...',
        'La cotizacion se ha creado correctamente',
        'success'
    )
}

function cotizacionError() {
    Swal.fire({
        icon: 'error',
        title: 'Oops...',
        text: 'Hubo un error crear la cotizacion',
        showConfirmButton: false,
        timer: 2500
    })
}

function updateerror() {
    Swal.fire({
        icon: 'error',
        title: 'Oops...',
        text: 'Hubo un error al guardar la cotizacion',
        showConfirmButton: false,
        timer: 2500
    })
}

function updateOK() {
    Swal.fire(
        'Listo...',
        'La cotizacion se ha guardado correctamente',
        'success',
        window.location.href = "ListadoCotizaciones.aspx"
    )
}

function crearcliente() {
    Swal.fire({
        title: 'Cliente no registrado',
        text: "puede registrarlo o reintantar el rut",
        icon: 'info',
        confirmButtonText: 'OK'
    })
}

function modificaciontrue() {
    Swal.fire({
        icon: 'success',
        title: 'Exitoso',
        text: 'El registro se ha modificado correctamente',
        showConfirmButton: false,
        timer: 1500
    })
}

function modificacionfalse() {
    Swal.fire({
        icon: 'error',
        title: 'Oops...',
        text: 'No se ha podido modificar el registro',
        showConfirmButton: false,
        timer: 1500
    })
}

function estadotrue() {
    Swal.fire({
        icon: 'success',
        title: 'Exitoso',
        text: 'Cambio de estado registrado',
        showConfirmButton: false,
        timer: 10000
    })
    window.location.href = "ListadoCotizaciones.aspx"
}

function estadofalse() {
    Swal.fire({
        icon: 'error',
        title: 'Oops...',
        text: 'Ha ocurrido un error imprevisto.',
        showConfirmButton: false,
        timer: 3500
    })
}

function servicioextraTrue() {
    Swal.fire({
        icon: 'success',
        title: 'Exitoso',
        text: 'Los servicios extra se han agregado correctamente',
        showConfirmButton: false
    })
}

function NombreObra() {
    Swal.fire({
        icon: 'error',
        title: 'Oops...',
        text: 'Debe Indicar El Nombre de la Obra',
        showConfirmButton: false,
        timer: 3500
    })
}

function CondicionPago() {
    Swal.fire({
        icon: 'error',
        title: 'Oops...',
        text: 'Debe Indicar la condición de Pago',
        showConfirmButton: false,
        timer: 3500
    })
}

function TipoFacturacion() {
    Swal.fire({
        icon: 'error',
        title: 'Oops...',
        text: 'Debe Indicar el tipo de facturacion',
        showConfirmButton: false,
        timer: 3500
    })
}

function EstadoObra() {
    Swal.fire({
        icon: 'error',
        title: 'Oops...',
        text: 'El estado ingresado no es válido',
        showConfirmButton: false,
        timer: 3500
    })
}

function EmpresanoValida() {
    Swal.fire({
        icon: 'error',
        title: 'Oops...',
        text: 'La Empresa no es válida',
        showConfirmButton: false,
        timer: 3500
    })
}

function NombreCliente() {
    Swal.fire({
        icon: 'error',
        title: 'Oops...',
        text: 'Debe Indicar El Nombre del Cliente',
        showConfirmButton: false,
        timer: 3500
    })
}

function RutCliente() {
    Swal.fire({
        icon: 'error',
        title: 'Oops...',
        text: 'Debe Indicar El RUT del Cliente',
        showConfirmButton: false,
        timer: 3500
    })
}

function CentroCosto() {
    Swal.fire({
        icon: 'error',
        title: 'Oops...',
        text: 'Debe Indicar el Centro de Costo',
        showConfirmButton: false,
        timer: 3500
    })
}

function TipoGuiaDespacho() {
    Swal.fire({
        icon: 'error',
        title: 'Oops...',
        text: 'Debe Indicar el   Tipo de Guia de despacho',
        showConfirmButton: false,
        timer: 3500
    })
}

function CodigoFacturar() {
    Swal.fire({
        icon: 'error',
        title: 'Oops...',
        text: 'Debe Indicar el Código para facturar',
        showConfirmButton: false,
        timer: 3500
    })
}

function idObra() {
    Swal.fire({
        icon: 'error',
        title: 'Oops...',
        text: 'Debe seleccionar una obra previamente',
        showConfirmButton: false,
        timer: 3500
    })
}

function SiglaObra() {
    Swal.fire({
        icon: 'error',
        title: 'Oops...',
        text: 'Falta sigla de obra o esta ya existe',
        showConfirmButton: false,
        timer: 3500
    })
}

function TipoFacturacion() {
    Swal.fire({
        icon: 'error',
        title: 'Oops...',
        text: 'Tipo facturacion se debe seleccionar una opcion valida',
        showConfirmButton: false,
        timer: 3500
    })
}

function updateER() {
    Swal.fire({
        icon: 'error',
        title: 'Oops...',
        text: 'Ocurrio un error al intentar actualizar los datos',
        showConfirmButton: false,
        timer: 3500
    })
}

function updateOKs() {
    Swal.fire({
        icon: 'success',
        title: 'Exitoso',
        text: 'Los datos de han actualizado correctamente',
        showConfirmButton: false,
        timer: 3500
    })
}

function GeneralOK() {
    Swal.fire({
        icon: 'success',
        title: 'Exitoso',
        text: 'Los datos se han actualizado correctamente',
        showConfirmButton: false
    })
}

function GeneralER() {
    Swal.fire({
        icon: 'error',
        title: 'Oops...',
        text: 'Ha ocurrido un imprevisto al actualizar los datos',
        showConfirmButton: false,
        timer: 3500
    })
}

function pesoOC() {
    Swal.fire({
        icon: 'error',
        title: 'Oops...',
        text: 'Se encontro un campo de peso OC con un caracter no permitido',
        showConfirmButton: false,
        timer: 3500
    })
}

function FechaOC() {
    Swal.fire({
        icon: 'error',
        title: 'Oops...',
        text: 'Debe seleccionar la fecha de la OC',
        showConfirmButton: false,
        timer: 3500
    })
}

function NumeroOC() {
    Swal.fire({
        icon: 'error',
        title: 'Oops...',
        text: 'Campo numero OC esta vacio',
        showConfirmButton: false,
        timer: 3500
    })
}
function FileOC() {
    Swal.fire({
        icon: 'error',
        title: 'Oops...',
        text: 'Debe agregar un archivo de orden de compra',
        showConfirmButton: false,
        timer: 3500
    })
}

function ArchivoExiste() {
    Swal.fire({
        icon: 'error',
        title: 'Oops...',
        text: 'El archivo de la orden de compra ya ha sido agregado previamente',
        showConfirmButton: false,
        timer: 3500
    })
}

function IngresoOCER() {
    Swal.fire({
        icon: 'error',
        title: 'Oops...',
        text: 'Ha ocurrido un imprevisto al intentar agregar la orden de compra',
        showConfirmButton: false,
        timer: 3500
    })
}

function IngresoOCOK() {
    Swal.fire({
        icon: 'success',
        title: 'Exitoso',
        text: 'La orden de compra se ingreso correctamente',
        showConfirmButton: false
    })
}

function CodigosTrue() {
    Swal.fire({
        icon: 'success',
        title: 'Exitoso',
        text: 'Los codigos se han agregado correctamente',
        showConfirmButton: false
    })
}

function CodigosFalse() {
    Swal.fire({
        icon: 'error',
        title: 'Oops...',
        text: 'Ha ocurrido un imprevisto al intentar registrar los codigos de facturacion',
        showConfirmButton: false,
        timer: 3500
    })
}

function ReabrirOK() {
    Swal.fire({
        icon: 'success',
        title: 'Exitoso',
        text: 'La Obra  se ha RE ABIERTO y quedo en estado de PREALTA',
        showConfirmButton: false
    })
}

function ReabrirER() {
    Swal.fire({
        icon: 'error',
        title: 'Oops...',
        text: 'La Obra  no se podido RE ABRIR, Revisar',
        showConfirmButton: false,
        timer: 3500
    })
}

function TipoCamion() {
    Swal.fire({
        icon: 'error',
        title: 'Oops...',
        text: 'Debe seleccionar un tipo de camion',
        showConfirmButton: false,
        timer: 3500
    })
}

function ObsCamion() {
    Swal.fire({
        icon: 'error',
        title: 'Oops...',
        text: 'Campo Observacion asociada no puede estar vacio',
        showConfirmButton: false,
        timer: 3500
    })
}

function TipoRecepcion() {
    Swal.fire({
        icon: 'error',
        title: 'Oops...',
        text: 'Debe seleccionar un tipo de recepcion',
        showConfirmButton: false,
        timer: 3500
    })
}

function Hora1() {
    Swal.fire({
        icon: 'error',
        title: 'Oops...',
        text: 'Campo hora 1 no puede estar vacio',
        showConfirmButton: false,
        timer: 3500
    })
}

function Hora2() {
    Swal.fire({
        icon: 'error',
        title: 'Oops...',
        text: 'Campo hora 2 no puede estar vacio',
        showConfirmButton: false,
        timer: 3500
    })
}

function DetalleCamionOK() {
    Swal.fire({
        icon: 'success',
        title: 'Exitoso',
        text: 'La informacion del camion se guardo exitosamente',
        showConfirmButton: false
    })
}

function DetalleCamionER() {
    Swal.fire({
        icon: 'error',
        title: 'Oops...',
        text: 'Ocurrio un error imprevisto al querer guardar la informacion del camion',
        showConfirmButton: false,
        timer: 3500
    })
}

function AddAdminOK() {
    Swal.fire({
        icon: 'success',
        title: 'Exitoso',
        text: 'El administrador de obra se asigno correctamente',
        showConfirmButton: false
    })
}

function AddAdminER() {
    Swal.fire({
        icon: 'error',
        title: 'Oops...',
        text: 'Ocurrio un error imprevisto al querer asignar el administrador de obra',
        showConfirmButton: false,
        timer: 3500
    })
}

function CodigoEr() {
    Swal.fire({
        icon: 'error',
        title: 'Oops...',
        text: 'El codigo para despacho no ha sido creado previamente en INET',
        showConfirmButton: false,
        timer: 3500
    })
}

function CodigoOK() {
    Swal.fire({
        icon: 'success',
        title: 'Exitoso',
        text: 'El codigo para despacho ha sido registrado exitosamente',
        showConfirmButton: false
    })
}

function CodigoEmpty() {
    Swal.fire({
        icon: 'error',
        title: 'Oops...',
        text: 'El campo codigo para despacho no puede estar vacio',
        showConfirmButton: false,
        timer: 3500
    })
}

function TiempoDesp() {
    Swal.fire({
        icon: 'error',
        title: 'Oops...',
        text: 'El campo tiempo de desplazamiento no se ha seleccionado.',
        showConfirmButton: false,
        timer: 3500
    })
}














