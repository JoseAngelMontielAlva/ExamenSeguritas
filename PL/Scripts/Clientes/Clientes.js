$(document).ready(function () { 
    GetAll();
});

function GetAll() {
    $.ajax({
        type: 'GET',
        url: 'http://localhost:1044/Clientes/Get',
        success: function (result) { 
            $('#Clientes tbody').empty();
            $.each(result.Objects, function (i, clientes) {
                var filas =
                    '<tr>'
                        + '<td class="text-center"> <button onclick="GetById(' + clientes.IdClientes + ')"><span class="glyphicon glyphicon-check" style="color:#FF7F00"></span></button></td>'
                        + "<td  id='id' class='hidden'>" + clientes.IdClientes + "</td>"
                        + "<td class='text-center'>" + clientes.Nombre + "</td>"
                        + "<td class='text-center'>" + clientes.FechaModificacion + "</ td>"
                        + '<td class="text-center"> <button onclick="Eliminar(' + clientes.IdClientes + ')"><span class="glyphicon glyphicon-trash" style="color:#E60026"></span></button></td>'
                    + "</tr>";
                $("#Clientes tbody").append(filas);
            });
        },
        error: function (result) {
            alert('Error en la consulta.' + result.responseJSON.ErrorMessage);
        }
    });
};




function GetById(IdClientes) {
    $.ajax({
        type: 'GET',
        url: 'http://localhost:1044/Clientes/GetId?IdClientes=' + IdClientes,
        success: function (result) {
            $('#txtIdClientes').val(result.Object.IdClientes);
            $('#txtNombre').val(result.Object.Nombre);
            $('#txtFechaModificacion').val(result.Object.FechaModificacion);
            $('#ModalUpdate').modal('show');
        },
        error: function (result) {
            alert('Error en la consulta.' + result.responseJSON.ErrorMessage);
        }
    });
}

function Eliminar(IdClientes) {

    if (confirm("¿Estas seguro de eliminar el cliente seleccionado?")) {
        $.ajax({
            type: 'GET',
            url: 'http://localhost:1044/Clientes/Delete?IdClientes=' + IdClientes,
            success: function (result) {
                $('#myModal').modal();
                GetAll();
            },
            error: function (result) {
                alert('Error en la consulta.' + result.responseJSON.ErrorMessage);
            }
        });
    };
};

function IniciarTextbox() {
    $('#txtIdCliente').val('');
    $('#txtNombre').val('');
    $('#txtFechaModificacion').val('');
    $('#ModalUpdate').modal('show');
}

function ShowModal() {
    $('#ModalUpdate').modal('show');
    IniciarTextbox();
}

function Guardar() {
    var clientes = {
        IdClientes: $('#txtIdClientes').val(),
        Nombre: $('#txtNombre').val(),
        FechaModificacion: $('#txtFechaModificacion').val(),
    }
    if ($('#txtIdClientes').val() == 0) {
        Add(clientes);
    }
    else {
        Update(clientes);
    }

    function Add() {
        $.ajax({
            type: 'POST',
            url: 'http://localhost:1044/Clientes/Add',
            data: JSON.stringify(clientes),
            contentType: 'application/json; charset=utf-8',
            success: function (result) {
                $('#myModal').modal();
                $('#ModalUpdate').modal('hide');
                GetAll();
                Console(respond);
            },
            error: function (result) {
                alert('Error en la consulta.' + result.responseJSON.ErrorMessage);
            }
        });
    };

    function Update() {
        $.ajax({
            type: 'POST',
            url: 'http://localhost:1044/Clientes/Update',
            data: JSON.stringify(clientes),
            contentType: 'application/json; charset=utf-8',
            success: function (result) {
                $('#myModal').modal();
                $('#ModalUpdate').modal('hide');
                GetAll();
                Console(respond);
            },
            error: function (result) {
                alert('Error en la consulta.' + result.responseJSON.ErrorMessage);
            }
        });

    };
}

function SoloLetras(e) {
    var letra = e.onkeypress.arguments[0].key;
    if (!/[^a-zA-Z]/.test(letra)) {
        $("#lblErrorNombre").hide();
        return true;
    }
    else {
        if (e.id == "txtNombre") {
            $("#lblErrorNombre").text('Solo se aceptan letras');
            $("#lblErrorNombre").show();
        }
        return false;
    }
}