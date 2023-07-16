$(function () {
    loadData();

    $("#Name").on("keyup", function (event) {
        $.ajax({
            url: "/Home/SearchProductList/" + event.target.value,
            typr: "GET",
            contentType: "application/json;charset=UTF-8",
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
                    html += '<td><a href="#" class="btn btn-outline-primary" onclick="return getbyID(' + item.Id_Product + ')">Actualizar</a>';
                    html += '</tr>';
                });
                $('.tbody').html(html);
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    });

    $("#Id_Category").on("change", function () {
        $.ajax({
            url: "/Home/ListByCategory/" + $(this).find('option:selected').text(),
            typr: "GET",
            contentType: "application/json;charset=UTF-8",
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
                    html += '<td><a href="#" class="btn btn-outline-primary" onclick="return getbyID(' + item.Id_Product + ')">Actualizar</a>';
                    html += '</tr>';
                });
                $('.tbody').html(html);
            },
            error: function (errormessage) {
                alert(errormessage.responseText);
            }
        });
    });
});


function loadData() {
    $.ajax({
        url: "/Home/List",
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
                html += '<td><a href="#" class="btn btn-outline-primary" onclick="return getbyID(' + item.Id_Product + ')">Actualizar</a>';
                html += '</tr>';
            });
            $('.tbody').html(html);
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
}

function getbyID(Id) {
    $.ajax({
        url: "/Home/GetById/" + Id,
        typr: "GET",
        contentType: "application/json;charset=UTF-8",
        dataType: "json",
        success: function (result) {
            $('#Id_Product').val(result.Id_Product);
            $('#Detail').val(result.Detail);

            $('#myModal').modal('show');
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
    return false;
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
    $.ajax({
        url: "/Home/UpdateDetail",
        data: JSON.stringify(productObj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            loadData();
            $('#myModal').modal('hide');
            $('#Id_Product').val("");
            $('#Detail').val("");
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
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