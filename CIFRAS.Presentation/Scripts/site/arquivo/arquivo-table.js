$(document).ready(function () {

    var tableUrl = $("#datatable").data("table");
    var translatorUrl = $("#datatable").data("translator");
    var clienteId = $("#clienteId").val();

    var buttonDownload = function (id) {
        var downloadUrl = $("#datatable").data("download");
        return '<a class="btn btn-info" title="Baixar" href="' + downloadUrl + '/' + id + '" data-togle="tooltip"> <i class="fa fa-download" aria-hidden="true"> </i> </a>';
    }

    var buttonRemove = function (id) {
        var removeUrl = $("#datatable").data("remove");
        return '<a href="#" onclick="confirmarExclusao(event, this);" class="btn btn-danger" title="Excluir" data-remove="' + removeUrl + '/' + id + '?clienteId=' + clienteId + '" data-togle="tooltip"> <i class="fa fa-trash" aria-hidden="true"> </i> </a>';
    }   

    var buttons = function (id) {
        return '<div class="text-center text-nowrap">' + buttonDownload(id) + ' ' + buttonRemove(id) + ' ' + '</div>';
    }    

    $(document).ready(function () {       
        $('#datatable').dataTable({
            "language": {
                "url": translatorUrl
            },
            "processing": true,
            "serverSide": true,
            "info": true,
            "stateSave": false,
            "lengthMenu": [[10, 20, 50, -1], [10, 20, 50, "All"]],
            "ajax": {
                "url": tableUrl + '?clienteId=' + clienteId,
                "type": "GET"
            },
            "columns": [
                { "data": "Descricao", "orderable": true, "width": "80%" },
                { "data": "CategoriaArquivo.Descricao", "orderable": true, "width": "15%" },
                {
                    mRender: function (data, type, row) {
                        return buttons(row.ArquivoId);
                    },
                    "orderable": false, "width": "5%"
                }
            ],
            "order": [[0, "asc"]]
        });
    });

});