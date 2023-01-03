/* Importação da fonte do recibo */
pdfMake.fonts = {
    Verdana: {
        normal: 'Verdana.ttf',
        bold: 'Verdana Bold.ttf',
        italics: 'Verdana Italic.ttf',
        bolditalics: 'Verdana Bold Italic.ttf'
    }
}

var Download = function (e, mode) {

    /* Obtém o endereço onde será consultado os dados */
    var downloadUrl = $(e).data('url');

    /* Consulta o modelo a partir do endereço obtido */
    $.getJSON(downloadUrl, function (model) {

        /* Array do conteúdo da tabela */
        var rows = [];

        if (model.ListaReciboEmprestimo.length > 0)
        {
            /* Cabeçalho da tabela */
            rows.push(
                [
                    { text: 'Nome do Cliente', style: 'tableHeader' },
                    { text: 'Banco', style: 'tableHeader' },
                    { text: 'Convênio', style: 'tableHeader' },
                    { text: 'Valor Solicitado', style: 'tableHeader' },
                    { text: 'Valor Liberado', style: 'tableHeader' },
                    { text: '%', style: 'tableHeader' }
                ]
            );
            /* Carregamento do conteúdo da tabela */
            $.each(model.ListaReciboEmprestimo, function (i, item) {
                rows.push(
                    [
                        { text: item.NomeCliente.toUpperCase(), style: 'tableColor' },
                        { text: item.BancoView.toUpperCase(), style: 'tableColor' },
                        { text: item.TipoClienteView.toUpperCase() + ' ' + item.EspecificacaoEmprestimoFormatado.toUpperCase() + ' ' + item.QtdeParcelas + 'X', style: 'tableColor' },
                        { text: item.ValorSolicitado.toFixed(2), style: 'tableColor' },
                        { text: item.ValorLiberado.toFixed(2), style: 'tableColor' },
                        { text: item.PercentualComissao.toFixed(2), style: 'tableColor' }
                    ]
                )
            });
        }
        else {
            swal('Falha', 'Este recibo não possui uma lista de empréstimos!', 'error');
        }

        var dd = {
            content: [
                {
                    alignment: 'left',
                    image: 'logo.png',
                    width: 150
                },
                {
                    text: '\n\n',
                },
                {
                    text: 'RECIBO DE COMISSAO AUTONOMA: ' + model.Corretor.NomeAbreviado.toUpperCase() + '\n',
                    style: 'header',
                },
                {
                    text: 'Data: ' + model.DataEmissaoFormatada + '\n',
                    fontSize: 10,
                    alignment: 'right',
                    margin: [0, 0, 0, 10],
                },
                {
                    text: [
                        { text: 'Eu, ', style: 'standardColor' },
                        { text: model.Corretor.Nome.toUpperCase() + ' ', bold: true, style: 'standardColor' },
                        { text: 'portador do CPF nº ', style: 'standardColor' },
                        { text: model.Corretor.Cpf.replace(/[^0-9]/g, '') + ', ', bold: true, style: 'standardColor' },
                        { text: 'recebi de ', style: 'standardColor' },
                        { text: model.NomeFantasiaConcedente.toUpperCase() + ' ' + model.TelefoneConcedente + ', ', bold: true, style: 'standardColor' },
                        { text: 'a importância de R$ ' + model.TotalLiquido.toFixed(2) + ' (' + model.TotalLiquidoExtenso + ') ', style: 'standardColor' },
                        { text: 'referente ao pagamento de comissão autonoma, com o detalhamento abaixo.\n\n', style: 'standardColor' }
                    ]
                },
                {
                    text: [
                        { text: 'Declaro se de minha responsabilidade toda(o) e qualquer recolhimento de Imposto(s) (Federeais, Estaduais e/ou Municipais) ', style: 'standardColor' },
                        { text: 'que se fizer(em) necessário(s), isentando assim a ', style: 'standardColor' },
                        { text: model.NomeFantasiaConcedente.toUpperCase() + ' ' + model.TelefoneConcedente + ' ', bold: true, style: 'standardColor' },
                        { text: 'de fazê-lo. ', style: 'standardColor' },
                        { text: 'Sendo o que se expôs, assino e alego a veracidade do contrato de trabalho autônomo conforme a Lei 9.608/98, ', style: 'standardColor' },
                        { text: 'afirmando assim não possuir nenhum vinculo empregatício.\n\n', style: 'standardColor' }
                    ]
                },
                {
                    text: [
                        { text: 'DADOS DO CORRETOR\n', bold: true, style: 'standardColor' },
                        { text: 'NOME: ', bold: true, style: 'standardColor' },
                        { text: model.Corretor.Nome.toUpperCase() + '\n', style: 'standardColor' },
                        { text: 'BANCO: ', bold: true, style: 'standardColor' },
                        { text: model.BancoCorretor + '  ', style: 'standardColor' },
                        { text: 'AGÊNCIA: ', bold: true, style: 'standardColor' },
                        { text: model.Corretor.NumeroAgencia + '  ', style: 'standardColor' },
                        { text: 'CONTA: ', bold: true, style: 'standardColor' },
                        { text: model.Corretor.NumeroConta + '  ', style: 'standardColor' },
                        { text: 'TIPO: ', bold: true, style: 'standardColor' },
                        { text: model.TipoContaDestinoFormatada.toUpperCase() + '\n\n', style: 'standardColor' }
                    ]
                },
                {
                    table: {
                        widths: ['28%', '20%', '15%', '15%', '15%', '7%'],
                        body: rows
                    },
                    layout: {
                        hLineWidth: function (i, node) {
                            return (i === 0 || i === node.table.body.length) ? 1 : 1;
                        },
                        vLineWidth: function (i, node) {
                            return (i === 0 || i === node.table.widths.length) ? 1 : 1;
                        },
                        hLineColor: function (i, node) {
                            return (i === 0 || i === node.table.body.length) ? '#BD4E19' : '#BD4E19';
                        },
                        vLineColor: function (i, node) {
                            return (i === 0 || i === node.table.widths.length) ? '#BD4E19' : '#BD4E19';
                        }
                    }
                },
                {
                    alignment: 'justify',
                    columns: [
                        {
                            alignment: 'left',                           
                            text: [
                                { text: '\n\n\n_____________________________________________\n ' + model.Corretor.Nome.toUpperCase() + '\n ' + model.Corretor.Cpf.replace(/[^0-9]/g, ''), alignment: 'center', style: 'standardColor' },
                            ] 
                        },
                        {
                            alignment: 'right',                           
                            text: [
                                { text: '\n Total de Valor Liberados: ', bold: true, style: 'secundaryColor' },
                                { text: 'R$ \n ' + model.TotalLiberado.toFixed(2) + ' \n\n', fontSize: 10, alignment: 'right', bold: true, style: 'standardColor' },
                                { text: 'Valor da Comissão: ', bold: true, style: 'secundaryColor' },
                                { text: 'R$ \n ' + model.TotalComissao.toFixed(2) + ' \n\n', fontSize: 10, alignment: 'right', bold: true, style: 'standardColor' },
                                { text: 'Custo de TED: ', bold: true, style: 'secundaryColor' },
                                { text: 'R$ \n -' + model.CustoTed.toFixed(2) + ' \n\n', fontSize: 10, alignment: 'right', bold: true, color: 'red' },
                                { text: 'Outros Descontos: ', bold: true, style: 'secundaryColor' },
                                { text: 'R$ \n -' + model.OutrosDescontos.toFixed(2) + ' \n\n', fontSize: 10, alignment: 'right', bold: true, color: 'red' },
                                { text: 'Valor a Receber: ', bold: true, style: 'secundaryColor' },
                                { text: 'R$ \n ' + model.TotalLiquido.toFixed(2) + ' \n\n', fontSize: 10, alignment: 'right', bold: true, style: 'standardColor' },
                            ]
                        }
                    ]
                },
                {
                    text: [
                        { text: '\nObservações: \n\n', bold: true, style: 'standardColor' },
                        { text: model.Observacoes, style: 'standardColor' }
                    ]
                }
            ],
            styles: {
                header: {
                    fontSize: 10,
                    bold: true,
                    margin: [0, 0, 0, 10],
                    alignment: 'center',
                    color: '#416488'
                },
                tableHeader: {
                    bold: true,
                    color: '#BD4E19',
                    alignment: 'left'
                },
                tableColor: {
                    color: '#BD4E19'
                },
                standardColor: {
                    color: '#416488'
                },
                secundaryColor: {
                    color: '#BD4E19'
                }
            },
            defaultStyle: {
                alignment: 'justify',
                fontSize: 8.5,
                font: 'Verdana'
            }
        }

        /* Visualizar */
        if (mode == 1) {
            pdfMake.createPdf(dd).open();
        }

        /* Imprimir */
        if (mode == 2)
        {
            pdfMake.createPdf(dd).print();
        }

        /* Download */
        if (mode == 3) {
            pdfMake.createPdf(dd).download('recibo.pdf');
        }   
        
    });
}