namespace CIFRAS.Domain.Entities
{
    public class Contato
    {
        public int ContatoId { get; set; }
        public string Descricao { get; set; }
        public TipoContato TipoContato { get; set; }

        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
    }
}