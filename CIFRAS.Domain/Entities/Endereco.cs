using System.Collections.Generic;

namespace CIFRAS.Domain.Entities
{
    public class Endereco
    {
        public int EnderecoId { get; set; }
        public string NomeEndereco { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public Estado? Estado { get; set; }
        public string Cep { get; set; }

        public ICollection<Cliente> ListaCliente {get; set;}
    }
}