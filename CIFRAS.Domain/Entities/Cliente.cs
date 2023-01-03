using System;
using System.Collections.Generic;

namespace CIFRAS.Domain.Entities
{
    public class Cliente
    {
        public int ClienteId { get; set; }   
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }     
        public DateTime? DataExpedicaoRg { get; set; }
        public string OrgaoRg { get; set; }
        public string Cnh { get; set; }
        public DateTime? DataNascimento { get; set; }
        public string NumeroMatricula { get; set; }      
        public string OrgaoFuncional { get; set; }
        public int? NumeroEspecie { get; set; }
        public Sexo Sexo { get; set; }
        public SituacaoCliente? SituacaoCliente { get; set; }
        public string Anotacoes { get; set; }
        public decimal? RendaBruta { get; set; }
        public decimal? DescontoRenda { get; set; }       
        public bool? Rmc { get; set; }
        public decimal? UsoRmc { get; set; }
        public int? CodigoBancoRmc { get; set; }
        public bool Ativo { get; set; } = true;
        public DateTime? DataVisualizacao { get; set; }

        public int EnderecoId { get;set ;}
        public Endereco Endereco { get; set; }

        public int TipoClienteId { get; set; }
        public TipoCliente TipoCliente { get; set; }

        public ICollection<Conta> ListaConta { get; set; }
        public ICollection<Contrato> ListaContrato { get; set; }
        public ICollection<Contato> ListaContato { get; set; }
        public ICollection<Arquivo> ListaArquivo { get; set; }

        public void Excluir()
        {
            Ativo = false;
        }
    }
}