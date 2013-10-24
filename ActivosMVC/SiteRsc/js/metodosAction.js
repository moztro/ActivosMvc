//Ejecuta un post del formulario mapeado a la URL
//del Action en el Controller
function save(form) {
    var url = form.attr("action");
    var formData = form.serialize();

    $.ajax({
        url: url,
        type: 'POST',
        data: formData,
        success: function (data) {
            $('#msg').html(data);
        },
        error: function () {
            $('#msg').html("Error al guardar");
        }
    });
}


function search(form) {
    var url = form.attr("action");
    var formData = form.serialize();

    $.post(url, formData, function (data) {
        $('#form').val(data);
    });
}