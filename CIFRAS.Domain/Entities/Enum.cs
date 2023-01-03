namespace CIFRAS.Domain.Entities
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
        Telefone,
        Celular,
        Email
    }

    public enum Estado
    {
        AC,
        AL,
        AP,
        AM,
        BA,
        CE,
        DF,
        ES,
        GO,
        MA,
        MT,
        MS,
        MG,
        PA,
        PB,
        PR,
        PE,
        PI,
        RR,
        RO,
        RJ,
        RN,
        RS,
        SC,
        SP,
        SE,
        TO
    }

    public enum SituacaoCliente
    {
        AtivoPermanente = 1,
        Aposentado = 2,
        Cedido = 3,
        Redistribuido = 4,
        AtivoPermanenteLei887894 = 5,
        ReformaCbmPm = 6,
        ReservaCbmPm = 7,
        AtivoDecJudic = 8,
        AposentadoDecJudic = 9,
        CedidoSusLei8270 = 10,
        PensaoVitalicia = 11,
        PensaoTemporaria = 12,
        BeneficiarioPensao = 13,
        PensaoGraciosaVitalicia = 14
    }

    public enum Cargo
    {
        Administrador = 1,
        Assistente = 2
    }

    public enum TipoConta
    { 
        Corrente = 1,
        Poupança = 2,
        Salário = 3
    }

    public enum EspecificacaoEmprestimo
    {      
        Novo = 1,
        Refin = 2,
        RefinMargem = 3,
        Portabilidade = 4,
        RefinDaPortabilidade = 5,
        NovoEspecial = 6,
        RefinEspercial = 7,
        CartãoComSaque = 8,
        Cartão = 9,
        SaqueComplementar = 10
    }
}