var frmAdicionarEmprestimo = $("#frmAdicionarEmprestimo");
frmAdicionarEmprestimo.submit(function (e) {
    e.preventDefault();
    var action = $("#modalConfirmarEmprestimo").data("add");
    $.ajax({
        url: action,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify({
            NomeCliente: frmAdicionarEmprestimo.find('#NomeCliente').val(),
            TipoClienteId: frmAdicionarEmprestimo.find('#TipoClienteId').val(),
            EspecificacaoEmprestimo: frmAdicionarEmprestimo.find('#EspecificacaoEmprestimo').val(),
            BancoId: frmAdicionarEmprestimo.find('#BancoId').val(),
            ValorSolicitado: frmAdicionarEmprestimo.find('#ValorSolicitado').val(),
            ValorLiberado: frmAdicionarEmprestimo.find('#ValorLiberado').val(),
            QtdeParcelas: frmAdicionarEmprestimo.find('#QtdeParcelas').val(),
            PercentualComissao: frmAdicionarEmprestimo.find('#PercentualComissao').val()
        }),
        success: function (result) {
            $('#modalConfirmarEmprestimo').modal('toggle');
            LimparCamposEmprestimo();
            AtualizarEmprestimos();
        },
        error: function (result) {
            alert('error');
        }
    });
});

var RemoverEmprestimo = function (action) {
    $.ajax({
        dataType: "json",
        type: "GET",
        url: action,
        success: function (dados) {
            AtualizarEmprestimos();
        },
        error: function (xhr, ajaxOptions, thrownError) {
            swal('', 'Erro de conexão com o servidor!', 'error');
        }
    });
}

var AtualizarEmprestimos = function () {
    var action = $("#modalConfirmarEmprestimo").data("reload");
    $("#ListaReciboEmprestimo").load(action);
}

var LimparCamposEmprestimo = function (element) {
    LimparCampo($("#modalConfirmarEmprestimo").find("#NomeCliente"));
    LimparCampo($("#modalConfirmarEmprestimo").find("#ValorSolicitado"));
    LimparCampo($("#modalConfirmarEmprestimo").find("#ValorLiberado"));
    LimparCampo($("#modalConfirmarEmprestimo").find("#QtdeParcelas"));
    LimparCampo($("#modalConfirmarEmprestimo").find("#PercentualComissao"));
    $("#modalConfirmarEmprestimo").find("#TipoClienteId").val($('option:contains("Selecione...")').val());
    $("#modalConfirmarEmprestimo").find("#BancoId").val($('option:contains("Selecione...")').val());
    $("#modalConfirmarEmprestimo").find("#EspecificacaoEmprestimo").prop('selectedIndex', 0);
}

var LimparCampo = function (element) {
    $(element).val('');
}

$("#modalConfirmarEmprestimo").on('shown.bs.modal', function () {
    $('#NomeCliente').focus();
});