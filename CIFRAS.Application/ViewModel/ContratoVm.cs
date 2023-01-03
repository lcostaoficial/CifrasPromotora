using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Script.Serialization;
using CIFRAS.Application.Helpers.General;

namespace CIFRAS.Application.ViewModel
{
    public class ContratoVm
    {
        #region Atributos
        public int ContratoId { get; set; }

        [Display(Name = "Número do Contrato")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string NumeroContrato { get; set; }

        [Display(Name = "Data Inicial")]
        public DateTime? DataInicio { get; set; }

        [Display(Name = "Valor Financiado")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public decimal ValorFinanciado { get; set; }      

        [Display(Name = "Valor da Parcela")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public decimal ValorParcela { get; set; }

        [Display(Name = "Total de Parcelas")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public int TotalParcelas { get; set; }
        #endregion

        #region Relacionamentos
        public int ClienteId { get; set; }

        [ScriptIgnore]
        public ClienteVm Cliente { get; set; }

        [Display(Name = "Banco")]
        public int? BancoId { get; set; }
        public BancoVm Banco { get; set; }

        [Display(Name = "Tipo Contrato")]
        public int TipoContratoId { get; set; }
        public TipoContratoVm TipoContrato { get; set; }
        #endregion

        #region Comportamento
        public void SetView(string bancoDescricao, string tipoContratoDescricao)
        {
            this.BancoView = bancoDescricao;
            this.TipoContratoView = tipoContratoDescricao;
            this.Banco = null;
            this.TipoContrato = null;
        }
        #endregion

        #region Não mapeados     
        public string BancoView { get; set; }
        public string TipoContratoView { get; set; }
        public DateTime? DataFinal => DataInicio?.AddMonths(TotalParcelas - 1);
        public string DataInicioView => (DataInicio != null) ? DataInicio.Value.ToShortDateString() : string.Empty;
        public string DataFimView => (DataFinal != null) ? DataFinal.Value.ToShortDateString() : string.Empty;
        public decimal SaldoDevedor => (ValorParcela * TotalParcelas) - (ParcelaVigente * ValorParcela);
        public int ParcelaVigente
        {
            get
            {
                var parcelaVigente = DateExtension.GetMonthsBetween(DateTime.Now, DataInicio ?? DateTime.Now);
                if (parcelaVigente > TotalParcelas)
                {
                    parcelaVigente = TotalParcelas;
                }
                if (parcelaVigente < 0)
                {
                    parcelaVigente = 0;
                }
                return parcelaVigente;
            }
        }
        public bool Quitado => ParcelaVigente == TotalParcelas;
        #endregion
    }
}