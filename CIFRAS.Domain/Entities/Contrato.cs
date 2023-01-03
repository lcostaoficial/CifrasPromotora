using System;

namespace CIFRAS.Domain.Entities
{
    public class Contrato
    {
        public int ContratoId { get; set; }
        public string NumeroContrato { get; set; }
        public DateTime? DataInicio { get; set; }        
        public decimal ValorFinanciado { get; set; }       
        public decimal ValorParcela { get; set; }
        public int TotalParcelas { get; set; }        

        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        
        public int? BancoId { get; set; }
        public Banco Banco { get; set; }

        public int TipoContratoId { get; set; }
        public TipoContrato TipoContrato { get; set; }
    }
}