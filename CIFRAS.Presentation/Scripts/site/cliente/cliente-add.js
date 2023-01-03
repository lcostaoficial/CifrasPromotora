$(document).ready(function () {
    LimparCamposContrato();
    VerificaSelecaoRmc($("#Rmc").val());
});

var frmAdicionarConta = $("#frmAdicionarConta");
frmAdicionarConta.submit(function (e) {
    e.preventDefault();
    var action = $("#modalConfirmarConta").data("add");
    $.ajax({
        url: action,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify({
            BancoId: frmAdicionarConta.find('#BancoId').val(),
            NumeroAgencia: frmAdicionarConta.find('#NumeroAgencia').val(),
            NumeroConta: frmAdicionarConta.find('#NumeroConta').val(),
            NomeAgencia: frmAdicionarConta.find('#NomeAgencia').val(),
            EnderecoAgencia: frmAdicionarConta.find('#EnderecoAgencia').val()
        }),
        success: function (result) {
            $('#modalConfirmarConta').modal('toggle');
            LimparCamposConta();
            AtualizarContas();
        },
        error: function (result) {
            alert('error');
        }
    });
});

var frmAdicionarContrato = $("#frmAdicionarContrato");
frmAdicionarContrato.submit(function (e) {
    e.preventDefault();
    var action = $("#modalConfirmarContrato").data("add");
    $.ajax({
        url: action,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify({
            BancoId: frmAdicionarContrato.find('#BancoId').val(),
            TipoContratoId: frmAdicionarContrato.find('#TipoContratoId').val(),
            NumeroContrato: frmAdicionarContrato.find('#NumeroContrato').val(),
            DataInicio: frmAdicionarContrato.find('#DataInicio').val(),           
            ValorFinanciado: frmAdicionarContrato.find('#ValorFinanciado').val(),          
            ValorParcela: frmAdicionarContrato.find('#ValorParcela').val(),
            TotalParcelas: frmAdicionarContrato.find('#TotalParcelas').val()           
        }),
        success: function (result) {
            $('#modalConfirmarContrato').modal('toggle');
            LimparCamposContrato();
            AtualizarContratos();
        },
        error: function (result) {
            alert('error');
        }
    });
});

var frmAdicionarContato = $("#frmAdicionarContato");
frmAdicionarContato.submit(function (e) {
    e.preventDefault();
    var action = $("#modalConfirmarContato").data("add");
    $.ajax({
        url: action,
        type: "POST",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify({
            Descricao: frmAdicionarContato.find('#Descricao').val(),
            TipoContato: frmAdicionarContato.find('#TipoContato').val()
        }),
        success: function (result) {
            $('#modalConfirmarContato').modal('toggle');
            LimparCamposContato();
            AtualizarContatos();
        },
        error: function (result) {
            alert('error');
        }
    });
});

var RemoverConta = function (action) {
    $.ajax({
        dataType: "json",
        type: "GET",
        url: action,
        success: function (dados) {
            AtualizarContas();
        },
        error: function (xhr, ajaxOptions, thrownError) {
            swal('', 'Erro de conexão com o servidor!', 'error');
        }
    });
}

var RemoverContrato = function (action) {
    $.ajax({
        dataType: "json",
        type: "GET",
        url: action,
        success: function (dados) {
            AtualizarContratos();
        },
        error: function (xhr, ajaxOptions, thrownError) {
            swal('', 'Erro de conexão com o servidor!', 'error');
        }
    });
}

var RemoverContato = function (action) {
    $.ajax({
        dataType: "json",
        type: "GET",
        url: action,
        success: function (dados) {
            AtualizarContatos();
        },
        error: function (xhr, ajaxOptions, thrownError) {
            swal('', 'Erro de conexão com o servidor!', 'error');
        }
    });
}

var AtualizarContratos = function () {
    var action = $("#modalConfirmarContrato").data("reload");
    $("#ListaContrato").load(action);
}

var AtualizarContas = function () {
    var action = $("#modalConfirmarConta").data("reload");
    $("#ListaConta").load(action);
}

var AtualizarContatos = function () {
    var action = $("#modalConfirmarContato").data("reload");
    $("#ListaContato").load(action);
}

var LimparCamposConta = function (element) {
    LimparCampo($("#modalConfirmarConta").find("#BancoId"));
    LimparCampo($("#modalConfirmarConta").find("#NumeroAgencia"));
    LimparCampo($("#modalConfirmarConta").find("#NumeroConta"));
    LimparCampo($("#modalConfirmarConta").find("#NomeAgencia"));
    LimparCampo($("#modalConfirmarConta").find("#EnderecoAgencia"));
}

var LimparCamposContrato = function (element) {
    LimparCampo($("#modalConfirmarContrato").find("#BancoId"));
    LimparCampo($("#modalConfirmarContrato").find("#TipoContratoId"));
    LimparCampo($("#modalConfirmarContrato").find("#CodigoContrato"));
    LimparCampo($("#modalConfirmarContrato").find("#NumeroContrato"));
    LimparCampo($("#modalConfirmarContrato").find("#DataInicio"));
    LimparCampo($("#modalConfirmarContrato").find("#ValorFinanciado"));
    LimparCampo($("#modalConfirmarContrato").find("#ValorQuitacao"));
    LimparCampo($("#modalConfirmarContrato").find("#ValorParcela"));
    LimparCampo($("#modalConfirmarContrato").find("#TotalParcelas"));
}

var LimparCamposContato = function (element) {
    LimparCampo($("#modalConfirmarContato").find("#Descricao"));
    $("#modalConfirmarContato").find("#TipoContato").prop('selectedIndex', 0);
}

var LimparCampo = function (element) {
    $(element).val('');
}

var BloqueiaUsoRmc = function () {
    $("#UsoRmc").val("0,00");
    $("#CodigoBancoRmc").val("");
    $("#UsoRmc").prop('disabled', true);
    $("#CodigoBancoRmc").prop('disabled', true);
}

var DesbloqueiaUsoRmc = function () {   
    $("#UsoRmc").prop('disabled', false);
    $("#CodigoBancoRmc").prop('disabled', false);
}

$("#Rmc").on('change', function () {
    VerificaSelecaoRmc(this.value);
});

var VerificaSelecaoRmc = function (e) {
    if (e == "true") {
        DesbloqueiaUsoRmc();
    }
    else if (e == "false") {
        BloqueiaUsoRmc();
    }
    else {
        BloqueiaUsoRmc();
    }
}