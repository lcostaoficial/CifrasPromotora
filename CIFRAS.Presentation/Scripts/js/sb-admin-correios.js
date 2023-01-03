LimparCampos = function () {
    $(".complemento").val("");
    $(".bairro").val("");
    $(".cidade").val("");
    $(".logradouro").val("");
    $(".estado").val("0").change();
};

BuscarCep = function (element) {
    var cep = $(element).val();
    var url = "http://api.postmon.com.br/v1/cep/" + cep;
    $.getJSON(url, function (data) {
        $(".complemento").val(data.complemento);
        $(".bairro").val(data.bairro);
        $(".cidade").val(data.cidade);
        $(".logradouro").val(data.logradouro);
        $(".estado option:contains(" + data.estado + ")").attr('selected', true);
    }).fail(function () {      
        swal('Atenção', 'O CEP informado não foi localizado!', 'warning');
        LimparCampos();
    });
};