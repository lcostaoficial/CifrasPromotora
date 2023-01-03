namespace CIFRAS.Domain.Entities
{
    public class Conta
    {
        public int ContaId { get; set; }
        public string NumeroAgencia { get; set; }
        public string NumeroConta { get; set; }

        public int? BancoId { get; set; }
        public Banco Banco { get; set; }

        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
    }
}