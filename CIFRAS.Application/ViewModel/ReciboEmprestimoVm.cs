using CIFRAS.Application.Helpers.General;
using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Script.Serialization;

namespace CIFRAS.Application.ViewModel
{
    public class ReciboEmprestimoVm
    {
        #region Atributos
        public int ReciboEmprestimoId { get; set; }

        [Display(Name = "Nome do Cliente")]
        public string NomeCliente { get; set; }

        [Display(Name = "Especificação")]
        public EspecificacaoEmprestimo EspecificacaoEmprestimo { get; set; }

        [Display(Name = "Valor Solicitado")]
        public decimal ValorSolicitado { get; set; }

        [Display(Name = "Valor Liberado")]
        public decimal ValorLiberado { get; set; }

        [Display(Name = "Parcelas")]
        public int QtdeParcelas { get; set; }

        [Display(Name = "Comissão %")]
        public decimal PercentualComissao { get; set; }
        #endregion

        #region Relacionamentos
        [Display(Name = "Banco")]
        public int BancoId { get; set; }
        public BancoVm Banco { get; set; }

        [Display(Name = "Tipo de Cliente")]
        public int TipoClienteId { get; set; }
        public TipoClienteVm TipoCliente { get; set; }
       
        public int ReciboId { get; set; }

        [ScriptIgnore]
        public ReciboVm Recibo { get; set; }
        #endregion

        #region Não mapeados
        public string BancoView { get; set; }
        public string TipoClienteView { get; set; }
        public string EspecificacaoEmprestimoFormatado => this.EspecificacaoEmprestimo.GetEnumDisplayName();       
        #endregion

        #region Comportamentos
        public decimal CalcularComissaoIndividual()
        {
            return Math.Round((this.ValorLiberado * this.PercentualComissao) / 100, 2);
        }

        public void SetView(string bancoDescricao, string TipoClienteDescricao)
        {
            this.BancoView = bancoDescricao;
            this.Banco = null;
            this.TipoClienteView = TipoClienteDescricao;
            this.TipoCliente = null;
        }
        #endregion
    }
}