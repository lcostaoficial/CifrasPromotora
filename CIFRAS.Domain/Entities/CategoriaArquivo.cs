using System.Collections.Generic;

namespace CIFRAS.Domain.Entities
{
    public class CategoriaArquivo
    {
        public int CategoriaArquivoId { get; set; }
        public string Descricao { get; set; }
        public bool Ativo { get; set; } = true;

        public ICollection<Arquivo> ListaArquivo { get; set; }

        public void Excluir()
        {
            Ativo = false;
        }
    }
}