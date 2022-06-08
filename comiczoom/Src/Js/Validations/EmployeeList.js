function validaForm(f) {
    // Inicializacion
    let ok = true;
    let msg = "ERROR\n";
    // ------------------------------------------

    // Valida rut
    let valRut = ValRut.validaRut(f.inpRut.value);
    if (!valRut) {
        msg += "- Formato inválido de RUT\n";
        ok = false;
    }

    // Validar celular
    if (!/^\+\d{9,23}$/.test(f.inpCelular.value)) {
        msg += "- Formato inválido de Celular\n";
        ok = false;
    }

    // Validar campos de contraseña
    if (validaCargo() == 1) {
        if (f.fPass.value != "" && f.sPass.value != "") {
            if (f.fPass.value != f.sPass.value) {
                ok = false;
                msg += "- Las contraseñas deben ser iguales";
            } 
        } else {
            ok = false;
            msg += "- Debe llenar ambos campos de contraseña";
        }
    }

    // Mostrar alerta con errores
    if (ok == false) {
        alert(msg);
    }

    return ok;
}

function validaCargo() {
    // Inicializacion
    let inpCargo = document.getElementById("inpCargo").value; // Select de cargos
    let conPass = document.getElementById("con-pass"); // Container/Seccion de contraseñas

    // Mostrar o no el Container/Seccion de contraseñas
    if (inpCargo == "1" || inpCargo == "2") {
        conPass.classList.remove("d-none");
        return 1;
    } else {
        conPass.classList.add("d-none");
        return 0;
    }
}