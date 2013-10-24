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

function validaCampos() {
    formulario = "Form1";
    var valido = true;
    var frmEl = document.getElementById("Form1").elements;
    for (var i = 0; i < frmEl.length; i++) {
        var obj = frmEl[i];
            if (obj.className == "cNecesario" ) {
                if (obj.value == "" || obj.value == 0) {
                    obj.style.border = "1px dashed red";
                    valido = false;
                } else
                    obj.style.border = "1px solid #cccccc";
            }
    }

    if (valido == false) {
        alert("Los campos en rojo son obligatorios.");
    }
    return valido;
}

var pageUrl = '<%=ResolveUrl("~/MedidorAgua.aspx")%>'
function llenarColonias() {
    $("#<%=ddlColonias.ClientID%>").attr("disabled", "disabled");
    if ($('#<%=ddlMunicipio.ClientID%>').val() == "0") {
        $('#<%=ddlColonias.ClientID %>').empty().append('<option selected="selected" value="0">seleccionar Colonia</option>');
    }
    else {
        $('#<%=ddlColonias.ClientID %>').empty().append('<option selected="selected" value="0">Cargando...</option>');
        $.ajax({
            type: "POST",
            url: pageUrl + '/llenarColonias',
            data: '{idMunicipio: ' + $('#<%=ddlMunicipio.ClientID%>').val() + '}',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: OnLLenarColonias,
            failure: function (response) {
                alert(response.d);
            }
        });
    }
}

function OnLLenarColonias(response) {
    llenarControl(response.d, $("#<%=ddlColonias.ClientID %>"));
}

function llenarControl(list, control) {
    if (list.length > 0) {
        control.removeAttr("disabled");
        control.empty().append('<option selected="selected" value="0">Seleccionar Colonia</option>');
        $.each(list, function () {
            control.append($("<option></option>").val(this['Value']).html(this['Text']));
        });
    }
    else {
        control.empty().append('<option selected="selected" value="0">Sin Colonias Disponibles<option>');
    }
}