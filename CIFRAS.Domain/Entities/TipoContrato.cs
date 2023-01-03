using System.Collections.Generic;

namespace CIFRAS.Domain.Entities
{
    public class TipoContrato
    {
        public int TipoContratoId { get; set; }
        public string Descricao { get; set; }
        public bool Ativo { get; set; } = true;

        public ICollection<Contrato> ListaContrato { get; set; }

        public void Excluir()
        {
            Ativo = false;
        }
    }
}