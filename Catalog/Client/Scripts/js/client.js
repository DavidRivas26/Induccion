$(function () {
    loadData();

    $("#btnUpdate").on("click", function () {
        Update();
    });

    $("#Name").on("keyup", function (event) {
        request.get("/Home/SearchProductList/" + event.target.value, function (result) {
            setTable(result);
        });
    });

    $("#Id_Category").on("change", function () { 
        request.get("/Home/ListByCategory/" + $(this).find('option:selected').text(), function (result) {
            setTable(result);

        });
    });
});


function loadData() {
    request.get("/Home/List", function (result) {
        setTable(result);
    });
}

function setTable(result) {
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
        html += '<td><a href="#" class="btn btn-outline-primary" onclick="return getbyID(' + item.Id_Product + ')">Actualizar</a>';
        html += '</tr>';
    });
    $('.tbody').html(html);
}

function getbyID(Id) {
    request.get("/Home/GetById/" + Id, function (result) {
        $('#Id_Product').val(result.Id_Product);
        $('#Detail').val(result.Detail);
        $('#myModal').modal('show');
    });
    return false;
}

function clear() {
    $('#Id_Product').val("");
    $('#Detail').val("");
}

function Update() {
    var res = validate();
    if (res == false) {
        return false;
    }
    var productObj = {
        Id_Product: $('#Id_Product').val(),
        Detail: $('#Detail').val()
    };
    request.post("/Home/UpdateDetail", productObj, function (result) {
        loadData();
        $('#myModal').modal('hide');
        $('#Id_Product').val("");
        $('#Detail').val("");
    });
}

function validate() {

    var validation = $("#form").validate({
        rules: {
            detail: 'required'
        },
        messages: {
            detail: 'Este campo es requerido'
        },
    });

    if (validation.form()) {
        return true;
    }

    return false;
}  