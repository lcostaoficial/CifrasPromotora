using System.ComponentModel.DataAnnotations;

namespace CIFRAS.Application.ViewModel
{
    public enum MapeamentoImportacao
    {
        Matricula,
        Cpf,
        Nome,
        Telefone,
        Especie,
        DataNascimento,
        Uf,
        Cidade,
        Endereco,
        Bairro,
        Cep,
        Banco,
        Agencia,
        NomeAgencia,
        EnderecoAgencia,
        ContaCorrente,
        Orgao,
        OrigemMailing,
        Higienizacao,
        Fones,
        Num0,
        Num1,
        Num2,
        Num3,
        Num4,
        Num5,
        Num6,
        Num7,
        Num8,
        Num9,
        Num10,
        Num11,
        Num12,
        Num13,
        Num14,
        Num15,
        Num16,
        Num17,
        Num18,
        Num19,
        Num20,
        Num21,
        Num22,
        Num23,
        Num24,
        Num25,
        Num26,
        Num27,
        Num28,
        Num29,
        Num30,
        Num31,
        Num32,
        Num33,
        Num34,
        Num35,
        Num36,
        Num37,
        Num38,
        Num39,
        Num40,
        Num41,
        Num42,
        Num43,
        Num44,
        Num45,
        Num46,
        Num47,
        Num48,
        Num49,
        Num50,
        Num51,
        Num52,
        Num53,
        Num54,
        Num55,
        Num56,
        Num57,
        Num58,
        Num59,
        Num60,
        Num61,
        Num62,
        Num63,
        Num64,
        Num65,
        Num66,
        ValorBeneficio,
        Desconto,
        Liquido,
        MargemConsignavel,
        ValorConsignado,
        MargemDisponivel,
        Rmc,
        UsoRmc,
        BancoRmc,
        LinhaSeparadora,
        IdContrato,
        Tipo,
        CodigoBanco,
        NomeBanco,
        NumeroContrato,
        ValorParcela,
        ValorEmprestimo,
        ValorQuitacao,
        ParcelaVigente,
        Prazo,
        DataInicio,
        DataTermino
    }

    public enum Sexo
    {
        Masculino = 1,
        Feminino = 2
    }

    public enum TipoContato
    {
        Telefone = 1,
        Celular = 2,
        Email = 3
    }

    public enum Estado
    {
        AC = 1,
        AL = 2,
        AP = 3,
        AM = 4,
        BA = 5,
        CE = 6,
        DF = 7,
        ES = 8,
        GO = 9,
        MA = 10,
        MT = 11,
        MS = 12,
        MG = 13,
        PA = 14,
        PB = 15,
        PR = 16,
        PE = 17,
        PI = 18,
        RR = 19,
        RO = 20,
        RJ = 21,
        RN = 22,
        RS = 23,
        SC = 24,
        SP = 25,
        SE = 26,
        TO = 27
    }

    public enum Cargo
    {
        Administrador = 1,
        Assistente = 2
    }

    public enum SituacaoCliente
    {
        [Display(Name = "ATIVO PERMANENTE")]
        AtivoPermanente = 1,

        [Display(Name = "APOSENTADO")]
        Aposentado = 2,

        [Display(Name = "CEDIDO")]
        Cedido = 3,

        [Display(Name = "REDISTRIBUÍDO")]
        Redistribuido = 4,

        [Display(Name = "ATIVO PERM L. 8878/94")]
        AtivoPermanenteLei887894 = 5,

        [Display(Name = "REFORMA CBM/PM")]
        ReformaCbmPm = 6,

        [Display(Name = "RESERVA CBM/PM")]
        ReservaCbmPm = 7,

        [Display(Name = "ATIVO - DEC. JUDIC")]
        AtivoDecJudic = 8,

        [Display(Name = "APOSENTADO - DEC. JUDIC")]
        AposentadoDecJudic = 9,

        [Display(Name = "CEDIDO SUS/LEI 8270")]
        CedidoSusLei8270 = 10,

        [Display(Name = "PENSÃO VITALÍCIA")]
        PensaoVitalicia = 11,

        [Display(Name = "PENSÃO TEMPORÁRIA")]
        PensaoTemporaria = 12,

        [Display(Name = "BENEFICIÁRIO PENSÃO")]
        BeneficiarioPensao = 13,

        [Display(Name = "PENSÃO GRACIOSA VITALÍCIA")]
        PensaoGraciosaVitalicia = 14
    }

    public enum TipoConta
    {
        Corrente = 1,
        Poupança = 2,
        Salário = 3
    }

    public enum EspecificacaoEmprestimo
    {
        [Display(Name = "NOVO")]
        Novo = 1,

        [Display(Name = "REFIN")]
        Refin = 2,

        [Display(Name = "REFIN+MARGEM")]
        RefinMargem = 3,

        [Display(Name = "PORTAB.")]
        Portabilidade = 4,

        [Display(Name = "REFIN DA PORTAB.")]
        RefinDaPortabilidade = 5,

        [Display(Name = "NOVO ESPECIAL")]
        NovoEspecial = 6,

        [Display(Name = "REFIN ESPECIAL")]
        RefinEspercial = 7,

        [Display(Name = "CARTÃO C/ SAQUE")]
        CartãoComSaque = 8,

        [Display(Name = "CARTÃO")]
        Cartão = 9,

        [Display(Name = "SAQUE COMPLEMENTAR")]
        SaqueComplementar = 10
    }
}