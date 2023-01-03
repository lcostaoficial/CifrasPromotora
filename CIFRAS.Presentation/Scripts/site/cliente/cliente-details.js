var GerarTabelaContrato = function (list) {
    if (list.length > 0) {
        return {
            table: {
                widths: ['39%', '20%', '17%', '7%', '17%'],
                body: list
            }
        }
    }
    else {
        return null;
    }
}

var GerarTabelaContato = function (list) {
    if (list.length > 0) {
        return {
            table: {
                widths: ['20%', '80%'],
                body: list
            }
        }
    }
    else {
        return null;
    }
}

var Imprimir = function (e) {

    var downloadUrl = $(e).data('url');

    $.getJSON(downloadUrl, function (model) {

        var contratos = [];
        var contatos = [];

        if (model.ListaContrato.length > 0) {
            contratos.push(
                [
                    { text: 'CONTRATOS', style: 'tableHeader', colSpan: 5, alignment: 'center' }, null, null, null, null
                ],
                [
                    { text: 'BANCO', style: 'tableHeader' },
                    { text: 'VALOR FINANCIADO', style: 'tableHeader' },
                    { text: 'VALOR PARCELA', style: 'tableHeader' },
                    { text: 'PRAZO', style: 'tableHeader' },
                    { text: 'SALDO DEVEDOR', style: 'tableHeader' }
                ],              
            );
            $.each(model.ListaContrato, function (i, item) {
                contratos.push(
                    [
                        { text: item.BancoView },
                        { text: 'R$ ' + item.ValorFinanciado.toFixed(2) },
                        { text: 'R$ ' + item.ValorParcela.toFixed(2) },
                        { text: item.ParcelaVigente + '/' + item.TotalParcelas },
                        { text: 'R$ ' + item.SaldoDevedor.toFixed(2) },
                    ]
                )
            });
        }

        if (model.ListaContato.length > 0) {
            contatos.push(
                [
                    { text: 'CONTATOS', style: 'tableHeader', colSpan: 2, alignment: 'center' }, null
                ],
                [
                    { text: 'TIPO DE CONTATO', style: 'tableHeader' },
                    { text: 'CONTATO', style: 'tableHeader' }              
                ],
            );
            $.each(model.ListaContato, function (i, item) {
                contatos.push(
                    [
                        { text: item.TipoContatoView },                       
                        { text: item.Descricao },
                    ]
                )
            });
        }

        var dd = {
            content: [
                {
                    alignment: 'left',
                    image: 'esic.png',
                    width: 150
                },
                {
                    text: '\n\n',
                },
                {
                    text: 'RELATÓRIO DE CLIENTE', style: 'header', alignment: 'center'
                },
                {
                    style: 'tableExample',
                    table: {
                        widths: ['33.33%', '33.33%', '33.33%'],
                        body: [
                            [
                                { text: 'DADOS PESSOAIS', style: 'tableHeader', colSpan: 3, alignment: 'center' }, null, null
                            ],
                            [
                                {
                                    text: [
                                        { text: 'NOME: \n', bold: true },
                                        { text: model.Nome }
                                    ]
                                },
                                {
                                    text: [
                                        { text: 'DATA DE NASCIMENTO: \n', bold: true },
                                        { text: model.DataNascimentoFormatada }
                                    ]
                                },
                                {
                                    text: [
                                        { text: 'SEXO: \n', bold: true },
                                        { text: model.SexoView }
                                    ]
                                },
                            ],
                            [
                                { text: 'DOCUMENTOS PESSOAIS', style: 'tableHeader', colSpan: 3, alignment: 'center' }, null, null
                            ],
                            [
                                {
                                    text: [
                                        { text: 'CPF: \n', bold: true },
                                        { text: model.Cpf }
                                    ]
                                },
                                {
                                    text: [
                                        { text: 'RG: \n', bold: true },
                                        { text: model.Rg }
                                    ]
                                },
                                {
                                    text: [
                                        { text: 'CNH: \n', bold: true },
                                        { text: model.Cnh }
                                    ]
                                },
                            ],
                            [
                                { text: 'DADOS DE ENDEREÇO', style: 'tableHeader', colSpan: 3, alignment: 'center' }, null, null
                            ],
                            [
                                {
                                    text: [
                                        { text: 'CEP: \n', bold: true },
                                        { text: model.Endereco.Cep }
                                    ]
                                },
                                {
                                    text: [
                                        { text: 'ENDEREÇO: \n', bold: true },
                                        { text: model.Endereco.NomeEndereco }
                                    ]
                                },
                                {
                                    text: [
                                        { text: 'BAIRRO: \n', bold: true },
                                        { text: model.Endereco.Bairro }
                                    ]
                                },
                            ],
                            [
                                {
                                    text: [
                                        { text: 'CIDADE: \n', bold: true },
                                        { text: model.Endereco.Cidade }
                                    ], colSpan: 2
                                },
                                null,
                                {
                                    text: [
                                        { text: 'UNIDADE FEDERAL: \n', bold: true },
                                        { text: model.Endereco.EstadoView }
                                    ]
                                }
                            ],                                                      
                        ],                     
                    },
                },             
                GerarTabelaContrato(contratos),
                {
                    text: '\n',
                },
                GerarTabelaContato(contatos)
            ],
            styles: {
                header: {
                    fontSize: 10,
                    bold: true
                },
                tableExample: {
                    margin: [0, 5, 0, 15]
                },
                tableHeader: {
                    bold: true,
                    fontSize: 10,
                    color: 'black'
                }
            },
            defaultStyle: {
                fontSize: 10
            }
        }

        pdfMake.createPdf(dd).print();

    });

}