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
    request.get("/Category/CategoriesList", function (result) {
        var html = '';
        $.each(result, function (key, item) {
            html += '<tr>';
            html += '<td>' + item.Id_Category + '</td>';
            html += '<td>' + item.Name + '</td>';
            html += '<td>' + item.Description + '</td>';
            html += '<td>' + (item.Status ? 'Activo' : 'Inactivo') + '</td>';
            html += '<td>' + item.Author + '</td>';
            html += '<td>' + item.Date_Creation + '</td>';
            html += '<td>' + item.Date_Update + '</td>';
            html += '<td><a href="#" class="btn btn-outline-primary" onclick="return getbyID(' + item.Id_Category + ')">Actualizar</a>' +
                '  <a href="#" class="btn btn-outline-danger" onclick="Delele(' + item.Id_Category + ')">Eliminar</a></td>';
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
    var categoryObj = {
        Name: $('#Name').val(),
        Description: $('#Description').val(),
        Stock: $('#Stock').val(),
        Status: $('#Status').val()
    };

    request.post("/Category/CategoriesAdd", categoryObj, function (result) {
        $("#myModal .close").click();
        loadData();
        clear();
    });
}

function getbyID(Id) {
    request.get("/Category/CategoriesgetbyID/" + Id, function (result) {
        $('#Id_Category').val(result.Id_Category);
        $('#Name').val(result.Name);
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
    var categoryObj = {
        Id_Category: $('#Id_Category').val(),
        Name: $('#Name').val(),
        Description: $('#Description').val(),
        Stock: $('#Stock').val(),
        Status: $('#Status').val()
    };
    request.post("/Category/CategoriesUpdate", categoryObj, function (result) {
        loadData();
        clear();
        $("#myModal .close").click();
        $('#Id_Category').val("");
        $('#Name').val("");
        $('#Description').val("");
        $('#Stock').val("");
        $('#Status').val("");
    });
}

function Delele(Id) {
    var ans = confirm("Seguro que desea eliminar esta categoria?");
    if (ans) {
        request.post("/Category/CategoriesDelete/" + Id, null, function (result) {
            loadData();
        });
    }
}

function clear() {

    $('#Id_Category').val("");
    $('#Name').val("");
    $('#Description').val("");
    $('#Status').val("");

    $('#btnUpdate').hide();
    $('#btnAdd').show();
}

function validate() {

    var validation = $("#form").validate({
        rules: {
            name: 'required',
            description: 'required',
            status: 'required',
        },
        messages: {
            name: 'Este campo es requerido',
            description: 'Este campo es requerido',
            status: 'Este campo es requerido',
        },
    });

    if (validation.form()) {
        return true;
    }

    return false;
}