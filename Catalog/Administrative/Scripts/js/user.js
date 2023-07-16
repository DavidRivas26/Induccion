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
    $.ajax({
        url: "/User/UsersAdd",
        data: JSON.stringify(userObj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            alert("Se ha registrado exitosamente");
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

function showModal() {
    $('#myModal').modal('show');
}

function hideModal() {
    $('#myModal').modal('hide');
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
    $.ajax({
        url: "/User/UsersValidate",
        data: JSON.stringify(userObj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            if (result.Id_User != 0)
                window.location.href = "https://localhost:44333/User/Index";
            else
                alert("Credenciales incorrectas");
        },
        error: function (errormessage) {
            alert(errormessage.responseText);        
        }
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
    $.ajax({
        url: "/User/UsersUpdate",
        data: JSON.stringify(userObj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            hideModal();
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
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