$(document).ready(function () {

    var tableUrl = $("#datatable").data("table");
    var translatorUrl = $("#datatable").data("translator");

    var buttonEdit = function (id) {
        var editUrl = $("#datatable").data("edit");
        return '<a class="btn btn-info" title="Editar" href="' + editUrl + '/' + id + '" data-togle="tooltip"> <i class="fa fa-pencil-square-o" aria-hidden="true"> </i> </a>';
    }

    var buttonRemove = function (id) {
        var removeUrl = $("#datatable").data("remove");
        return '<a href="#" onclick="confirmarExclusao(event, this);" class="btn btn-danger" title="Excluir" data-remove="' + removeUrl + '/' + id + '" data-togle="tooltip"> <i class="fa fa-trash" aria-hidden="true"> </i> </a>';
    }

    var buttonDownload = function (id) {
        var downloadUrl = $("#datatable").data("download");
        return '<a class="btn btn-primary" onclick="Download(this, 3)" title="Download" href="#" data-url="' + downloadUrl + '/' + id + '" data-togle="tooltip"> <i class="fa fa-download" aria-hidden="true"> </i> </a>';
    }

    var buttonPrint = function (id) {
        var downloadUrl = $("#datatable").data("download");
        return '<a class="btn btn-warning" onclick="Download(this, 2)" title="Imprimir" href="#" data-url="' + downloadUrl + '/' + id + '" data-togle="tooltip"> <i class="fa fa-print" aria-hidden="true"> </i> </a>';
    }

    var buttonView = function (id) {
        var downloadUrl = $("#datatable").data("download");
        return '<a class="btn btn-success" onclick="Download(this, 1)" title="Visualizar" href="#" data-url="' + downloadUrl + '/' + id + '" data-togle="tooltip"> <i class="fa fa-eye" aria-hidden="true"> </i> </a>';
    }

    var buttons = function (id) {
        return '<div class="text-center text-nowrap">' + buttonView(id) + ' ' + buttonPrint(id) + ' ' + buttonDownload(id) + ' ' + buttonEdit(id) + ' ' + buttonRemove(id) + ' ' + '</div>';
    }    

    $("#datatable").dataTable({
        "language": {
            "url": translatorUrl
        },
        "processing": true,
        "serverSide": true,
        "info": true,
        "stateSave": false,
        "lengthMenu": [[10, 20, 50, -1], [10, 20, 50, "All"]],
        "ajax": {
            "url": tableUrl,
            "type": "GET"
        },
        "columns": [
            { "data": "Corretor.Nome", "orderable": true, "width": "75%" },
            { "data": "DataEmissaoFormatada", "orderable": true, "width": "20%" },
            {
                mRender: function (data, type, row) {
                    return buttons(row.ReciboId);
                },
                "orderable": false, "width": "5%"
            }
        ],
        "order": [[0, "asc"]]
    });

});