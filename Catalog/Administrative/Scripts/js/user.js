$(function () {
    $('#btnAdd').on('click', function () {
        Add();
    });
    $('#btnUpdate').on('click', function () {
        Update();
    });
    $('#btnLogIn').on('click', function () {
        Validate();
    });
    
});

function Add() {
    var res = validate();
    if (res == false) {
        return false;
    }
    var userObj = {
        Name: $('#Name').val(),
        LastName: $('#LastName').val(),
        Address: $('#Address').val(),
        Phone: $('#Phone').val(),
        Email: $('#Email').val(),
        Password: $('#Password').val()
    };
    request.post("/User/UsersAdd", userObj, function (result) {
        alert("Se ha registrado exitosamente");
    });
}

function Validate() {
    var res = validateLogin();
    if (res == false) {
        return false;
    }
    var userObj = {
        Email: $('#Email').val(),
        Password: $('#Password').val()
    };
    request.post("/User/UsersValidate", userObj, function (result) {
        if (result.Id_User != 0)
            window.location.href = "https://localhost:44333/User/Index";
        else
            alert("Credenciales incorrectas");
    });
}

function Update() {
    var res = validate();
    if (res == false) {
        return false;
    }
    var userObj = {
        Id_User: $('#Id_User').val(),
        Name: $('#Name').val(),
        LastName: $('#LastName').val(),
        Address: $('#Address').val(),
        Phone: $('#Phone').val(),
        Email: $('#Email').val(),
        Password: $('#Password').val()
    };
    request.post("/User/UsersUpdate", userObj, function (result) {
        $("#myModal .close").click();
    });
}

function validate() {
    var validation = $("#form").validate({
        rules: {
            name: 'required',
            lastname: 'required',
            address: 'required',
            phone: { required: true, digits: true },
            email: { required : true, email: true},
            password: 'required',
        },
        messages: {
            name: 'Este campo es requerido',
            lastname: 'Este campo es requerido',
            address: 'Este campo es requerido',
            phone: { required: 'Este campo es requerido', digits: 'Solo se aceptan numeros'},
            email: { required: 'Este campo es requerido', email: 'Email no valido'},
            password: 'Este campo es requerido',
        },
    });

    if (validation.form()) {
        return true;
    }

    return false;
}

function validateLogin() {
    var validation = $("#form").validate({
        rules: {
            email: 'required',
            password: 'required',
        },
        messages: {
            email: 'Este campo es requerido',
            password: 'Este campo es requerido',
        },
    });

    if (validation.form()) {
        return true;
    }

    return false;
}