$(document).ready(function () {
    var backUrl = $("#backUrl").val();
    $("#title").attr("href", backUrl);
});

$(document).ready(function () {
    var clienteId = $("#clienteId").val();
    var buscarClienteUrl = $("#buscarClienteUrl").val();
    $.ajax({
        dataType: "json",
        type: "GET",
        url: buscarClienteUrl + "/" + clienteId,
        success: function (dados) {
            $(dados).each(function (i) {
                $("#txtNomeCliente").append(dados.Nome);
            });
        }
    })
});