namespace CIFRAS.Domain.Entities
{
    public class ReciboEmprestimo
    {
        public int ReciboEmprestimoId { get; set; }
        public string NomeCliente { get; set; }
        public EspecificacaoEmprestimo EspecificacaoEmprestimo { get; set; }
        public decimal ValorSolicitado { get; set; }
        public decimal ValorLiberado { get; set; }
        public int QtdeParcelas { get; set; }
        public decimal PercentualComissao { get; set; }

        public int BancoId { get; set; }
        public Banco Banco { get; set; }

        public int TipoClienteId { get; set; }
        public TipoCliente TipoCliente { get; set; }

        public int ReciboId { get; set; }
        public Recibo Recibo { get; set; }
    }
}