function ShowPassword(pCheckPass, pNumInput) {
    let checkPass = document.getElementById(pCheckPass);

    if (pNumInput == 1) {
        let fPass = document.getElementById("fPass");

        if (checkPass.checked == true) {
            fPass.type = "text";
        } else {
            fPass.type = "password";
        }

    } else if (pNumInput == 2) {
        let fPass = document.getElementById("fPass");
        let sPass = document.getElementById("sPass");

        if (checkPass.checked == true) {
            fPass.type = "text";
            sPass.type = "text";
        } else {
            fPass.type = "password";
            sPass.type = "password";
        }
    }
}