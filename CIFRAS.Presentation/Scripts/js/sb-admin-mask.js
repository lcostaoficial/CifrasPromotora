/* Máscara para valores monetários */
$('.money').maskMoney({
    showSymbol: false,
    decimal: ",",
    thousands: "",
    allowZero: true,
    allowNegative: true
}).maskMoney('mask', $('.money').val());

/* Máscara para data */
$(".date").mask('99/99/9999');

/* Máscara para CPF */
$(".cpf").mask('999.999.999-99');

/* Máscara para RG */
$(".rg").mask('99.999.999-9');

/* Máscara para CNPJ */
$(".cnpj").mask('99.999.999/9999-99');

/* Máscara para CEP */
$(".cep").mask('99999-999');

/* Máscara para Telefone */
$(".telefone").mask('(99) 9999-9999');

/* Máscara para Celular */
$(".celular").mask('(99) 99999-9999');

/* Máscara para valores numéricos puros */
$(".numero").keydown(function (e) {
    if ($.inArray(e.keyCode, [46, 8, 9, 27, 13, 110, 190]) !== -1 ||
        (e.keyCode === 65 && (e.ctrlKey === true || e.metaKey == true)) ||
        (e.keyCode >= 35 && e.keyCode <= 40)) {
        return;
    }
    if ((e.shiftKey || (e.keyCode < 48 || e.keyCode > 57)) && (e.keyCode < 96 || e.keyCode > 105)) {
        e.preventDefault();
    }
});