namespace CIFRAS.Domain.Entities
{
    public class Arquivo
    {
        public int ArquivoId { get; set; }
        public string Descricao { get; set; }
        public string Caminho { get; set; }

        public int CategoriaArquivoId { get; set; }
        public CategoriaArquivo CategoriaArquivo { get; set; }

        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
    }
}