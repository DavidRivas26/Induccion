$(function () {
    loadData();
});

function loadData() {
    $.ajax({
        url: "/Product/ProductsList",
        type: "GET",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            var html = '';
            $.each(result, function (key, item) {
                html += '<tr>';
                html += '<td>' + item.Id_Product + '</td>';
                html += '<td>' + item.Id_Category + '</td>';
                html += '<td>' + item.Name + '</td>';
                html += '<td>' + item.Description + '</td>';
                html += '<td>' + item.Stock + '</td>';
                html += '<td>' + item.Detail + '</td>';
                html += '<td>' + (item.Status ? 'Activo' : 'Inactivo') + '</td>';
                html += '<td>' + item.Author + '</td>';
                html += '<td>' + item.Date_Creation + '</td>';
                html += '<td>' + item.Date_Update + '</td>';
                html += '<td><a href="#" class="btn btn-outline-primary" onclick="return getbyID(' + item.Id_Product + ')">Actualizar</a>' +
                    '  <a href="#" class="btn btn-outline-danger" onclick="Delele(' + item.Id_Product + ')">Eliminar</a></td>';
                html += '</tr>';
            });
            $('.tbody').html(html);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

function Add() {
    var res = validate();
    if (res == false) {
        return false;
    }
    var productObj = {
        Id_Category: $('#Id_Category').val(),
        Name: $('#Name').val(),
        Detail: $('#Detail').val(),
        Description: $('#Description').val(),
        Stock: $('#Stock').val(),
        Status: $('#Status').val()
    };
    $.ajax({
        url: "/Product/ProductsAdd",
        data: JSON.stringify(productObj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            loadData();
            $('#myModal').modal('hide');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

function getbyID(Id) {
    $.ajax({
        url: "/Product/ProductsgetbyID/" + Id,
        typr: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            $('#Id_Product').val(result.Id_Product);
            $('#Id_Category option:contains("' + result.Id_Category + '")').prop('selected', true);
            $('#Name').val(result.Name);
            $('#Detail').val(result.Detail);
            $('#Description').val(result.Description);
            $('#Stock').val(result.Stock);
            $(`#Status option[value='${result.Status}']`).prop('selected', true);
                   
            $('#myModal').modal('show');
            $('#btnUpdate').show();
            $('#btnAdd').hide();
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    return false;
}

function Update() {
    var res = validate();
    if (res == false) {
        return false;
    }
    var productObj = {
        Id_Product: $('#Id_Product').val(),
        Id_Category: $('#Id_Category').val(),
        Name: $('#Name').val(),
        Description: $('#Description').val(),
        Stock: $('#Stock').val(),
        Detail: $('#Detail').val(),
        Status: $('#Status').val()
    };
    $.ajax({
        url: "/Product/ProductsUpdate",
        data: JSON.stringify(productObj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            loadData();
            $('#myModal').modal('hide');
            $('#Id_Product').val("");
            $('#Id_Category').val("");
            $('#Name').val("");
            $('#Description').val("");
            $('#Detail').val("");
            $('#Stock').val("");
            $('#Status').val("");
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

function Delele(Id) {
    var ans = confirm("Seguro que desea eliminar este producto?");
    if (ans) {
        $.ajax({
            url: "/Product/ProductsDelete/" + Id,
            type: "POST",
            contentType: "application/json;charset=UTF-8",
            dataType: "json",
            success: function (result) {
                loadData();
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    }
}

function showModal() {
    clear();
    $('#myModal').modal('show');
}

function hideModal() {
    clear();
    $('#myModal').modal('hide');
}

function clear() {
    $('#Id_Product').val("");
    $('#Id_Category').val("");
    $('#Name').val("");
    $('#Detail').val("");
    $('#Description').val("");
    $('#Stock').val("");
    $('#Status').val("");

    $('#btnUpdate').hide();
    $('#btnAdd').show();
}

function validate() {

    var validation = $("#form").validate({
        rules: {
            id_category: 'required',
            name: 'required',
            description: 'required',
            detail: 'required',
            stock: { required: true, digits: true },
            status: 'required',
        },
        messages: {
            id_category: 'Este campo es requerido',
            name: 'Este campo es requerido',
            description: 'Este campo es requerido',
            detail: 'Este campo es requerido',
            stock: { required: 'Este campo es requerido', digits: 'Solo se aceptan numeros' },
            status: 'Este campo es requerido',
        },
    });

    if (validation.form()) {
        return true;
    }

    return false;
}  