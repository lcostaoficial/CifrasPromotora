using System.Collections.Generic;

namespace CIFRAS.Domain.Entities
{
    public class Corretor
    {
        public int CorretorId { get; set; }
        public string Nome { get; set; }
        public string NomeAbreviado { get; set; }
        public string Cpf { get; set; }
        public string NumeroAgencia { get; set; }
        public string NumeroConta { get; set; }
        public TipoConta TipoConta { get; set; }
        public bool Ativo { get; set; } = true;

        public int BancoId { get; set; }
        public Banco Banco { get; set; }

        public ICollection<Recibo> ListaRecibo { get; set; }

        public void Excluir()
        {
            Ativo = false;
        }
    }
}