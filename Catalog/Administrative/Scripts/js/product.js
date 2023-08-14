$(function () {
    loadData();
    $('#btnAdd').on('click', function () {
        Add();
    });
    $('#btnUpdate').on('click', function () {
        Update();
    });
});

function loadData() {
    request.get("/Product/ProductsList", function (result) {
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

    request.post("/Product/ProductsAdd", productObj, function (result) {
        $("#myModal .close").click();
        loadData();
        clear();
    });
}

function getbyID(Id) {
    request.get("/Product/ProductsgetbyID/" + Id, function (result) {
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

    request.post("/Product/ProductsUpdate", productObj, function (result) {
        loadData();
        clear();
        $("#myModal .close").click();
        $('#Id_Product').val("");
        $('#Id_Category').val("");
        $('#Name').val("");
        $('#Description').val("");
        $('#Detail').val("");
        $('#Stock').val("");
        $('#Status').val("");
    });
}

function Delele(Id) {
    var ans = confirm("Seguro que desea eliminar este producto?");
    if (ans) {
        request.post("/Product/ProductsDelete/" + Id, null, function (result) {
            loadData();
        });
    }
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