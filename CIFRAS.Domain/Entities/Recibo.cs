using System;
using System.Collections.Generic;

namespace CIFRAS.Domain.Entities
{
    public class Recibo
    {
        public int ReciboId { get; set; }
        public string NomeFantasiaConcedente { get; set; }
        public string TelefoneConcedente { get; set; }
        public decimal? CustoTed { get; set; }
        public decimal? OutrosDescontos { get; set; }
        public string Observacoes { get; set; }        
        public DateTime DataEmissao { get; set; } = DateTime.Now;
        public bool Ativo { get; set; } = true;

        public int CorretorId { get; set; }
        public Corretor Corretor { get; set; }

        public ICollection<ReciboEmprestimo> ListaReciboEmprestimo { get; set; }

        public void Excluir()
        {
            Ativo = false;
        }
    }
}