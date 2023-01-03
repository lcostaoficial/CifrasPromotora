var confirmarExclusao = function (event, element) {
    event.preventDefault();
    var url = $(element).data("remove");
    swal({
        title: 'Confirmar exclusão de item?',
        text: 'O item será perdido permanentemente!',
        type: 'warning',
        showCancelButton: true,
        confirmButtonText: 'Sim, tenho certeza!',
        cancelButtonText: 'Nâo, quero cancelar'
    }).then((result) => {
        if (result.value) {
            window.location.href = url;
        }
    })
}