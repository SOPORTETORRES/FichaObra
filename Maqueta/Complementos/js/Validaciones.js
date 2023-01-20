const form = document.getElementById('form');
const inputs = document.querySelectorAll('#form input');
const obra = document.getElementById('txtObra');
const txt3_1 = document.getElementById('txt3_1');

const expresiones = {
    usuario: /^[a-zA-Z0-9\_\-]{4,16}$/, // Letras, numeros, guion y guion_bajo
    nombre: /^[a-zA-ZÀ-ÿ\s]{1,40}$/, // Letras y espacios, pueden llevar acentos.
    password: /^.{4,12}$/, // 4 a 12 digitos.
    correo: /^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$/,
    telefono: /^\d{7,14}$/ // 7 a 14 numeros.
}

window.addEventListener('load', () => {
    const form = document.querySelector('#form')
    const obra = document.getElementById('txtObra')
    const txt3_1 = document.getElementById('txt3_1')

})

const validarForm = (e) => {
    const valorObra = obra.value.trim()
    const valor3_1 = txt3_1.value.trim()
    switch (e.target.name) {
        case "txtObra":
            if (!valorObra) {
                console.log('campo vacio')
                validaFalla(obra, 'Campo vacio')
            } else {
                console.log('campo ook')
                validaOK(obra)
            }
            break;
        case "txt3_1":
            if (!valor3_1) {
                console.log('campo vacio')
                validaFalla(txt3_1, 'Campo vacio')
            } else {
                console.log('campo ook')
                validaOK(txt3_1)
            }
            break;


    }
}

const validaFalla = (input, msje) => {
    const formControl = input.parentElement
    const aviso = formControl.querySelector('p')
    aviso.innerText = msje
    formControl.className = 'Falla'
}

const validaOK = (input, msje) => {
    const formControl = input.parentElement
    //formControl.className = 'ok '
}






inputs.forEach((input) => {
    input.addEventListener('keyup', validarForm);
    input.addEventListener('blur', validarForm);
});

form.addEventListener('submit', (e) => {
    e.preventDefault();
});

function ClickModal() {
    var button = document.getElementById("btnOrdenCompra");
    button.click()
}