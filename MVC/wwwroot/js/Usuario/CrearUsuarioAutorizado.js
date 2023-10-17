document.querySelector("#formCreateAutorizado").addEventListener("submit", validarDatos);
document.querySelector("#ConfirmacionContrasenia").addEventListener("input", validarPassTiempoReal);

function validarDatos(evt) {
    evt.preventDefault();
    let alias = document.querySelector("#alias").value;
    let password = document.querySelector("#password").value;
    let passwordconfirmation = document.querySelector("#ConfirmacionContrasenia").value;

    if (alias == "" || password == "" || passwordconfirmation == "") {
        document.querySelector("#pCrearUsu").value = "Verifique los datos";
    } else {
        if (compararPassword(password, passwordconfirmation) == true) {
            this.submit();
        } else {
            document.querySelector("#pCrearUsu").value = "Las contraseñas no coinciden";
        }
    }
}

function validarPassTiempoReal() {
    let password = document.querySelector("#password").value;
    let passwordconfirmation = document.querySelector("#ConfirmacionContrasenia").value;

    if (compararPassword(password, passwordconfirmation) == true) {
        document.querySelector("#pConfirmacionTiempoReal").textContent = "Las contraseñas coinciden";
    } else {
        document.querySelector("#pConfirmacionTiempoReal").textContent = "Las contraseñas no coinciden";
    }
}

function compararPassword(password, passwordconfirmation) {
    if (password == passwordconfirmation) {
        return true;
    } else {
        return false;
    }
}