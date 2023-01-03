using System.Collections.Generic;
using CIFRAS.Application.Helpers.General;
using System;
using System.ComponentModel.DataAnnotations;

namespace CIFRAS.Application.ViewModel
{
    public class ReciboVm
    {
        #region Atributos
        public int ReciboId { get; set; }

        [Display(Name = "Nome Fantasia")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string NomeFantasiaConcedente { get; set; }

        [Display(Name = "Telefone")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string TelefoneConcedente { get; set; }

        [Display(Name = "Custo de TED")]
        public decimal? CustoTed { get; set; }

        [Display(Name = "Outros Descontos")]
        public decimal? OutrosDescontos { get; set; } = 0;

        [Display(Name = "Observações")]
        public string Observacoes { get; set; }

        [Display(Name = "Data de Emissão")]
        public DateTime DataEmissao { get; set; } = DateTime.Now;

        public bool Ativo { get; set; } = true;
        #endregion

        #region Relacionamentos  
        [Display(Name = "Corretor")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public int CorretorId { get; set; }
        public CorretorVm Corretor { get; set; }
        #endregion       

        #region Comportamentos
        public decimal CalcularTotalLiberado()
        {
            decimal totalLiberados = 0;
            if (ListaReciboEmprestimo != null)
            {
                foreach (var item in ListaReciboEmprestimo)
                {
                    totalLiberados += item.ValorLiberado;
                }
            }           
            return totalLiberados;
        }

        public decimal CalcularTotalComissao()
        {
            decimal totalValores = 0;
            if (ListaReciboEmprestimo != null)
            {
                foreach (var item in ListaReciboEmprestimo)
                {
                    decimal totalIndividual = (item.ValorLiberado * item.PercentualComissao) / 100;
                    totalValores += totalIndividual;
                }
            }
            return Math.Round(totalValores, 2);
        }

        public decimal CalcularValorLiquido()
        {
            return CalcularTotalComissao() - ((this.CustoTed ?? 0) + (this.OutrosDescontos ?? 0));
        }
        #endregion

        #region Listas
        public ICollection<ReciboEmprestimoVm> ListaReciboEmprestimo { get; set; }
        #endregion

        #region Não mapeados
        public string DataEmissaoFormatada => $"{DataEmissao.ToShortDateString()} {this.DataEmissao.ToShortTimeString()}";
        public string TipoContaDestinoFormatada => Corretor.TipoConta.ToString();
        public decimal TotalLiberado => CalcularTotalLiberado();
        public decimal TotalComissao => CalcularTotalComissao();
        public string TotalLiquidoExtenso => CalcularValorLiquido().ParaExtenso();
        public decimal TotalLiquido => CalcularValorLiquido();

        public string BancoCorretor
        {
            get
            {
                if (this.Corretor.Banco == null)
                {
                    return "";
                }
                else if (this.Corretor.Banco.CodigoBanco == null || this.Corretor.Banco.CodigoBanco?.ToString() == "")
                {
                    return this.Corretor.Banco.Descricao;
                }
                else
                {
                    return this.Corretor.Banco.CodigoBanco.ToString();
                }
            }
        }
        #endregion
    }
}