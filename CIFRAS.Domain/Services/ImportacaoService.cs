using System.Web;
using CIFRAS.Domain.Interfaces.Services;
using System.IO;
using CIFRAS.Infra.CrossCutting.Helpers;
using CIFRAS.Domain.Entities;
using System.Collections.Generic;
using System;
using CIFRAS.Domain.Helpers;

namespace CIFRAS.Domain.Services
{
    public class ImportacaoService : IImportacaoService
    {
        private readonly IClienteService _clienteService;
        private readonly IContratoService _contratoService;
        private readonly IContatoService _contatoService;
        private readonly IBancoService _bancoService;
        private readonly IContaService _contaService;
        private readonly ITipoContratoService _tipoContratoService;
        private readonly ITipoClienteService _tipoClienteService;

        public ImportacaoService(IClienteService clienteService, IContratoService contratoService, IContatoService contatoService, IBancoService bancoService, IContaService contaService, ITipoContratoService tipoContratoService, ITipoClienteService tipoClienteService)
        {
            _clienteService = clienteService;
            _contratoService = contratoService;
            _contatoService = contatoService;
            _bancoService = bancoService;
            _contaService = contaService;
            _tipoContratoService = tipoContratoService;
            _tipoClienteService = tipoClienteService;
        }

        public string ImportarArquivo(HttpPostedFileBase arquivo, int tipoClienteId)
        {
            //Contador de de erros
            int erros = 0;

            //Define o caminho virtual
            var virtualPatch = $"~/Logs/{LogImportacao.Filename}";

            //Define o caminho físico do arquivo de log
            var physicalPath = HttpContext.Current.Server.MapPath(virtualPatch);

            //Avisa a classe de log que o processo de importação será iniciado
            LogImportacao.Save(physicalPath, LogImportacao.Msg("Iniciado o processo de importação..."));

            //Importar o arquivo para a memória
            StreamReader streamReader = arquivo.ToStreamReader();

            //Busca o tipo de cliente que foi solicitado a inserção
            var tipoCliente = _tipoClienteService.BuscarPorId(tipoClienteId);
            
            //Verifica se existe o tipo de cliente INSS
            if (tipoCliente == null)
            {
                LogImportacao.Save(physicalPath, LogImportacao.Msg("Falha ao tentar encontrar o tipo de cliente selecionado"));
                LogImportacao.Save(physicalPath, LogImportacao.Msg("Operação concluída sem sucesso"));
                throw new Exception("Falha ao tentar encontrar o tipo de cliente selecionado!");
            }

            //Declaração do contador responsável pela contagem das linhas
            int count = 0;

            //Declaração da variável que vai receber a quebra de cada linha do CSV
            string line = string.Empty;

            //Percorre todas as linhas da tabela
            while ((line = streamReader.ReadLine()) != null)
            {
                //Evita que o topo identificador seja lido
                if (count < 1)
                {
                    count++;
                    continue;
                }

                //Cria a o array de índices
                var item = line.Split(';');

                //Executa a varredura ignorando erros e adicionando no Log
                try
                {
                    //Verifica se o cliente já existe
                    var cliente = _clienteService.BuscarPorCpfEMatricula(item.ToText(MapeamentoImportacao.Cpf).RuleCpf(), item.ToText(MapeamentoImportacao.Matricula));

                    //Verifica se matrícula é nula
                    if (string.IsNullOrEmpty(item.ToText(MapeamentoImportacao.Matricula)))
                    {
                        throw new Exception("Cliente sem matrícula");
                    }

                    //Busca o banco do contrato pelo código
                    var bancoContrato = _bancoService.BuscarPorCodigo(item.ToInt(MapeamentoImportacao.CodigoBanco));

                    //Busca o banco do contrato pela descrição mais próxima
                    bancoContrato = bancoContrato ?? _bancoService.BuscarPorDescricao(item.ToText(MapeamentoImportacao.NomeBanco));

                    //Caso não haja banco existente é criada uma nova instância
                    bancoContrato = bancoContrato ?? new Banco()
                    {
                        Descricao = item.ToText(MapeamentoImportacao.NomeBanco),
                        Sigla = string.Empty,
                        CodigoBanco = item.ToInt(MapeamentoImportacao.CodigoBanco)
                    };

                    //Se o nome do banco não for repassado na planilha o contrato não terá banco
                    if (item.ToText(MapeamentoImportacao.NomeBanco) == "")
                    {
                        bancoContrato = null;
                    }

                    //Verifica se é necessário inserir o banco na base dados
                    else if (bancoContrato.BancoId == 0)
                    {
                        bancoContrato = _bancoService.AdicionarComRetorno(bancoContrato);
                    }

                    //Busca o banco do cliente pela descrição mais próxima
                    var bancoCliente = _bancoService.BuscarPorDescricao(item.ToText(MapeamentoImportacao.Banco));

                    //Caso não haja banco existente é criada uma nova instância
                    bancoCliente = bancoCliente ?? new Banco
                    {
                        Descricao = item.ToText(MapeamentoImportacao.Banco),
                        Sigla = string.Empty,
                        CodigoBanco = null
                    };

                    //Se a descrição do banco estiver vazia o banco será nulo
                    if (item.ToText(MapeamentoImportacao.Banco) == "")
                    {
                        bancoCliente = null;
                    }

                    //Busca o tipo de contrato pela descrição mais próxima
                    var tipoContrato = _tipoContratoService.BuscarPorDescricao(item.ToText(MapeamentoImportacao.Tipo));

                    //Instancia um novo tipo de contrato caso não exista a descrição
                    tipoContrato = tipoContrato ?? new TipoContrato()
                    {
                        Descricao = item.ToText(MapeamentoImportacao.Tipo)
                    };

                    //Caso exista o cliente atual
                    if (cliente != null)
                    {
                        //Atualiza endereço
                        cliente.Endereco.Cep = item.ToText(MapeamentoImportacao.Cep);
                        cliente.Endereco.NomeEndereco = item.ToText(MapeamentoImportacao.Endereco);
                        cliente.Endereco.Bairro = item.ToText(MapeamentoImportacao.Bairro);
                        cliente.Endereco.Cidade = item.ToText(MapeamentoImportacao.Cidade);
                        cliente.Endereco.Estado = item.ToText(MapeamentoImportacao.Uf).RuleEstado<Estado>();

                        //Atualiza fonte de contrato
                        cliente.RendaBruta = item.ToDecimal(MapeamentoImportacao.ValorBeneficio);
                        cliente.DescontoRenda = item.ToDecimal(MapeamentoImportacao.Desconto);                       
                        cliente.Rmc = item.ToText(MapeamentoImportacao.Rmc) == "SIM" ? true : false;
                        cliente.UsoRmc = item.ToDecimal(MapeamentoImportacao.UsoRmc);
                        cliente.CodigoBancoRmc = item.ToInt(MapeamentoImportacao.BancoRmc);

                        //Verifica quais contas não existem para adicionar
                        if (!_contaService.VerificarExistenciaConta(cliente.ClienteId, item.ToText(MapeamentoImportacao.Agencia), item.ToText(MapeamentoImportacao.ContaCorrente)))
                        {
                            //Insere uma nova conta para o cliente
                            cliente.ListaConta.Add(new Conta
                            {
                                BancoId = bancoCliente?.BancoId,
                                Banco = bancoCliente,
                                NumeroAgencia = item.ToText(MapeamentoImportacao.Agencia),
                                NumeroConta = item.ToText(MapeamentoImportacao.ContaCorrente),
                            });
                        }

                        if (item.ToText(MapeamentoImportacao.NumeroContrato) != "")
                        {
                            //Verifica se o número do contrato atual não existe
                            if (_contratoService.VerificarExistenciaContrato(item.ToText(MapeamentoImportacao.NumeroContrato)) == false)
                            {
                                //Insere novo contrato
                                cliente.ListaContrato.Add(new Contrato()
                                {
                                    NumeroContrato = item.ToText(MapeamentoImportacao.NumeroContrato),
                                    DataInicio = item.ToDate(MapeamentoImportacao.DataInicio),                                    
                                    ValorFinanciado = item.ToDecimal(MapeamentoImportacao.ValorEmprestimo),                                   
                                    ValorParcela = item.ToDecimal(MapeamentoImportacao.ValorParcela),
                                    TotalParcelas = item.ToInt(MapeamentoImportacao.Prazo),                                   
                                    ClienteId = cliente.ClienteId,
                                    BancoId = bancoContrato?.BancoId,
                                    Banco = bancoContrato,
                                    TipoContratoId = tipoContrato.TipoContratoId,
                                    TipoContrato = tipoContrato
                                });
                            }                          
                        }

                        //Insere contatos
                        foreach (var contato in item.ToText(MapeamentoImportacao.Telefone).Split(','))
                        {
                            //Verifica quais contatos não existem para adicionar
                            if (!_contatoService.VerificarExistenciaContato(contato))
                            {
                                if (contato != "")
                                    cliente.ListaContato.Add(new Contato() { Descricao = contato, TipoContato = TipoContato.Telefone });
                            }
                        }

                        //Atualiza cliente no banco de dados
                        _clienteService.Atualizar(cliente);
                    }
                    //Caso não exista o cliente atual
                    else
                    {
                        //Instância para novo cliente
                        cliente = new Cliente
                        {
                            ListaConta = new List<Conta>(),
                            ListaContrato = new List<Contrato>(),
                            Nome = item.ToText(MapeamentoImportacao.Nome),
                            Cpf = item.ToText(MapeamentoImportacao.Cpf).RuleCpf(),
                            NumeroMatricula = item.ToText(MapeamentoImportacao.Matricula),
                            NumeroEspecie = item.ToInt(MapeamentoImportacao.Especie),
                            TipoClienteId = tipoCliente.TipoClienteId,
                            ListaContato = new List<Contato>(),
                            RendaBruta = item.ToDecimal(MapeamentoImportacao.ValorBeneficio),
                            DescontoRenda = item.ToDecimal(MapeamentoImportacao.Desconto),                           
                            Rmc = item.ToText(MapeamentoImportacao.Rmc) == "SIM" ? true : false,
                            UsoRmc = item.ToDecimal(MapeamentoImportacao.UsoRmc),
                            CodigoBancoRmc = item.ToInt(MapeamentoImportacao.BancoRmc),
                            Endereco = new Endereco
                            {
                                Cep = item.ToText(MapeamentoImportacao.Cep),
                                NomeEndereco = item.ToText(MapeamentoImportacao.Endereco),
                                Bairro = item.ToText(MapeamentoImportacao.Bairro),
                                Cidade = item.ToText(MapeamentoImportacao.Cidade),
                                Estado = item.ToText(MapeamentoImportacao.Uf).RuleEstado<Estado>()
                            }
                        };

                        //Insere uma nova conta para o cliente
                        cliente.ListaConta.Add(new Conta
                        {
                            BancoId = bancoCliente?.BancoId,
                            Banco = bancoCliente,
                            NumeroAgencia = item.ToText(MapeamentoImportacao.Agencia),
                            NumeroConta = item.ToText(MapeamentoImportacao.ContaCorrente),
                        });

                        //Insere novo contrato
                        if (item.ToText(MapeamentoImportacao.NumeroContrato) != "")
                        {
                            cliente.ListaContrato.Add(new Contrato()
                            {
                                NumeroContrato = item.ToText(MapeamentoImportacao.NumeroContrato),
                                DataInicio = item.ToDate(MapeamentoImportacao.DataInicio),                               
                                ValorFinanciado = item.ToDecimal(MapeamentoImportacao.ValorEmprestimo),                              
                                ValorParcela = item.ToDecimal(MapeamentoImportacao.ValorParcela),
                                TotalParcelas = item.ToInt(MapeamentoImportacao.Prazo),                                
                                ClienteId = cliente.ClienteId,
                                BancoId = bancoContrato?.BancoId,
                                Banco = bancoContrato,
                                TipoContratoId = tipoContrato.TipoContratoId,
                                TipoContrato = tipoContrato
                            });
                        }

                        //Insere novos contatos
                        foreach (var contato in item.ToText(MapeamentoImportacao.Telefone).Split(','))
                        {
                            if (contato != "")
                                cliente.ListaContato.Add(new Contato() { Descricao = contato, TipoContato = TipoContato.Telefone });
                        }

                        //Adiciona cliente no banco de dados
                        _clienteService.Adicionar(cliente);
                    }
                }
                catch (Exception e)
                {
                    //Se for localizada falha na linha atual o Log será gravado
                    LogImportacao.Save(physicalPath, LogImportacao.Msg($"Linha: {count + 1} - Falha encontrada na planilha. Motivo: {e.Message} "));
                    erros++;
                }

                //Incrementa contador
                count++;
            }

            //Conclui a operação no Log
            LogImportacao.Save(physicalPath,
                erros == 0
                    ? LogImportacao.Msg("Operação concluída sem erros")
                    : LogImportacao.Msg($"Operação concluída mas contém {erros} erro(s)"));

            //Fecha o arquivo e encerra a leitura
            streamReader.Close();
            //Retorna arquivo de Log
            return virtualPatch;
        }
    }
}