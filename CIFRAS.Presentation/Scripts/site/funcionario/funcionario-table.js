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

    var buttons = function (id) {
        return '<div class="text-center text-nowrap">' + buttonEdit(id) + ' ' + buttonRemove(id) + ' ' + '</div>';
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
                "url": tableUrl,
                "type": "GET"
            },
            "columns": [
                { "data": "Nome", "orderable": true, "width": "84%" },
                { "data": "Cpf", "orderable": true, "width": "11%" },
                { "data": "CargoView", "orderable": true },
                {
                    mRender: function (data, type, row) {
                        return buttons(row.FuncionarioId);
                    },
                    "orderable": false, "width": "5%"
                }
            ],
            "order": [[0, "asc"]]
        });
    });

});