using System.Collections.Generic;

namespace CIFRAS.Domain.Entities
{
    public class Banco
    {
        public int BancoId { get; set; }
        public string Descricao { get; set; }
        public string Sigla { get; set; }
        public int? CodigoBanco { get; set; }
        public bool Ativo { get; set; } = true;

        public ICollection<Recibo> ListaRecibo { get; set; }
        public ICollection<ReciboEmprestimo> ListaReciboEmprestimo { get; set; }
        public ICollection<Conta> ListaConta { get; set; }
        public ICollection<Contrato> ListaContrato { get; set; }
        public ICollection<Corretor> ListaCorretor { get; set; }

        public void Excluir()
        {
            Ativo = false;
        }
    }
}