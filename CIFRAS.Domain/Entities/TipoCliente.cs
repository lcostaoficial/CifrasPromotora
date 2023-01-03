using System.Collections.Generic;

namespace CIFRAS.Domain.Entities
{
    public class TipoCliente
    {
        public int TipoClienteId { get; set; }
        public string Descricao { get; set; }
        public bool Ativo { get; set; } = true;

        public ICollection<Cliente> ListaCliente { get; set; }
        public ICollection<ReciboEmprestimo> ListaReciboEmprestimo { get; set; }

        public void Excluir()
        {
            Ativo = false;
        }
    }
}