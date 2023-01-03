$(document).ready(function () {

    var tableUrl = $("#datatable").data("table");
    var translatorUrl = $("#datatable").data("translator");

    var buttonDetail = function (id) {
        var detailUrl = $("#datatable").data("detail");
        return '<a class="btn btn-success" title="Detalhar" href="' + detailUrl + '/' + id + '" data-togle="tooltip"> <i class="fa fa-eye" aria-hidden="true"> </i> </a>';
    }

    var buttonFile = function (id) {
        var fileUrl = $("#datatable").data("file");
        return '<a class="btn btn-primary" title="Arquivos" href="' + fileUrl + '/' + id + '" data-togle="tooltip"> <i class="fa fa-paperclip" aria-hidden="true"> </i> </a>';
    }

    var buttonEdit = function (id) {
        var editUrl = $("#datatable").data("edit");
        return '<a class="btn btn-info" title="Editar" href="' + editUrl + '/' + id + '" data-togle="tooltip"> <i class="fa fa-pencil-square-o" aria-hidden="true"> </i> </a>';
    }

    var buttonRemove = function (id) {
        var removeUrl = $("#datatable").data("remove");
        return '<a href="#" onclick="confirmarExclusao(event, this);" class="btn btn-danger" title="Excluir" data-remove="' + removeUrl + '/' + id + '" data-togle="tooltip"> <i class="fa fa-trash" aria-hidden="true"> </i> </a>';
    }

    var buttons = function (id) {
        return '<div class="text-center text-nowrap">' + buttonDetail(id) + ' ' + buttonFile(id) + ' ' + buttonEdit(id) + ' ' + buttonRemove(id) + ' ' + '</div>';
    }

    var carregarTabela = function (tipoClienteId = "", cidade = "") {
        $('#datatable').dataTable({
            "language": {
                "url": translatorUrl
            },
            "processing": true,
            "serverSide": true,
            "info": true,
            "stateSave": true,
            "lengthMenu": [[10, 20, 50, -1], [10, 20, 50, "All"]],
            "ajax": {
                "url": tableUrl + '?TipoClienteId=' + tipoClienteId + '&Cidade=' + cidade,
                "type": "GET"
            },
            "columns": [
                { "data": "Nome", "orderable": true, "width": "41%" },
                { "data": "Cpf", "orderable": true, "width": "14%" },              
                { "data": "TipoClienteView", "orderable": true, "width": "14%" },
                { "data": "MargemDisponivelView", "orderable": true, "width": "14%" },
                { "data": "DataVisualizacaoFormatada", "orderable": true, "width": "12%" },
                {
                    mRender: function (data, type, row) {
                        return buttons(row.ClienteId);
                    },
                    "orderable": false, "width": "5%"
                }
            ],
            "order": [[0, "asc"]],
            "destroy": true
        });
    }

    $(document).ready(function () {
        carregarTabela();
        $("#btnFiltrarCliente").click(function () {
            var tipoClienteId = $("#TipoClienteId").val();
            var cidade = $("#Cidade").val();
            $('#modalFiltrarCliente').modal('toggle');
            carregarTabela(tipoClienteId, cidade);
        });
    });

});