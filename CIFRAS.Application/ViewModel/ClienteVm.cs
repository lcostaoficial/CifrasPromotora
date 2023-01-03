using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CIFRAS.Application.ViewModel
{
    public class ClienteVm
    {
        #region Atributos
        [Key]
        public int ClienteId { get; set; }
       
        [Required(ErrorMessage = "Campo obrigatório")]      
        [MaxLength(150, ErrorMessage = "Máximo 150 caracteres")]
        public string Nome { get; set; }

        [Display(Name = "CPF")]
        [Required(ErrorMessage = "Campo obrigatório")]
        [MaxLength(14, ErrorMessage = "Máximo 14 caracteres")]
        public string Cpf { get; set; }

        [Display(Name = "RG")]       
        [MaxLength(12, ErrorMessage = "Máximo 12 caracteres")]
        public string Rg { get; set; }

        [Display(Name = "Data de Expedição RG")]
        public DateTime? DataExpedicaoRg { get; set; }

        [Display(Name = "Orgão Expedidor RG")]
        [MaxLength(100, ErrorMessage = "Máximo 100 caracteres")]
        public string OrgaoRg { get; set; }

        [Display(Name = "CNH")]
        [MaxLength(11, ErrorMessage = "Máximo 11 caracteres")]
        public string Cnh { get; set; }

        [Display(Name = "Data de Nascimento")]       
        public DateTime? DataNascimento { get; set; }

        [Display(Name = "Matrícula")]
        [Required(ErrorMessage = "Campo obrigatório")]
        [MaxLength(20, ErrorMessage = "Máximo 20 caracteres")]
        public string NumeroMatricula { get; set; }

        [Display(Name = "Orgão Ocupante")]
        [MaxLength(100, ErrorMessage = "Máximo 100 caracteres")]
        public string OrgaoFuncional { get; set; }

        [Display(Name = "Situação")]
        public SituacaoCliente? SituacaoCliente { get; set; }

        [Display(Name = "Número Espécie")]        
        public int? NumeroEspecie { get; set; }
       
        public Sexo Sexo { get; set; }

        [Display(Name = "Anotações")]
        [MaxLength(255, ErrorMessage = "Máximo 255 caracteres")]
        public string Anotacoes { get; set; }

        [Display(Name = "Salário/Benefício")]
        public decimal? RendaBruta { get; set; }

        [Display(Name = "Descontos INSS/IR")]
        public decimal? DescontoRenda { get; set; }

        [Display(Name = "RMC")]
        public bool? Rmc { get; set; }

        [Display(Name = "RMC Utilizada")]
        public decimal? UsoRmc { get; set; }

        [Display(Name = "Cód. do Banco da RMC ")]
        public int? CodigoBancoRmc { get; set; }

        public bool Ativo { get; set; } = true;

        public DateTime? DataVisualizacao { get; set; }
        #endregion

        #region Relacionamentos      
        [Display(Name = "Tipo de Cliente")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public int TipoClienteId { get; set; }
        public TipoClienteVm TipoCliente { get; set; }

        public int EnderecoId { get; set; }
        public EnderecoVm Endereco { get; set; }
        #endregion

        #region Não mapeados
        public string TipoClienteView => TipoCliente?.Descricao;
        public string SexoView => Sexo == 0 ? "" : Sexo.ToString();
        public string DataNascimentoFormatada {
            get
            {
                if (DataNascimento != null)
                {
                    return DataNascimento?.ToShortDateString();
                }
                else
                {
                    return string.Empty;
                }
            }
        }
        public string DataVisualizacaoFormatada
        {
            get
            {
                if (DataVisualizacao != null)
                {
                    return DataVisualizacao?.ToShortDateString();
                }
                else
                {
                    return "Pendente";
                }
            }
        }
        public decimal MargemTotal => Math.Round(RendaBruta * (decimal)0.30 ?? 0, 2);        
        public decimal MargemUtilizada
        {
            get
            {
                if (ListaContrato != null && ListaContrato.Any())
                {
                    decimal totalContratos = 0;
                    foreach (var item in ListaContrato)
                    {
                        if (item.DataInicio != null && item.Quitado == false)
                            totalContratos += item.ValorParcela;
                    }
                    return totalContratos;
                }
                else
                {
                    return 0;
                }
            }
        }
        public decimal MargemDisponivel => Math.Round(MargemTotal - MargemUtilizada, 2);
        public string MargemDisponivelView => $"R$ {MargemDisponivel.ToString("N2")}";
        #endregion

        #region Listas
        public ICollection<ContaVm> ListaConta { get; set; }
        public ICollection<ContratoVm> ListaContrato { get; set; }
        public ICollection<ContatoVm> ListaContato { get; set; }
        public ICollection<ArquivoVm> ListaArquivo { get; set; }
        #endregion

        #region Comportamentos
        public void ValidarRmc()
        {
            if (Rmc == null)
            {
                UsoRmc = null;
                CodigoBancoRmc = null;
            }
            else
            {
                if (Rmc == true)
                {
                    if (UsoRmc == null || CodigoBancoRmc == null)
                    {
                        throw new Exception("A RMC foi habilitada para este(a) cliente, então a sua utilização e banco devem serem informados!");
                    }
                }
                else
                {
                    UsoRmc = null;
                    CodigoBancoRmc = null;
                }
            }
        }

        public void SetarDataVisualizacao()
        {
            DataVisualizacao = DateTime.Now;
        }
        #endregion
    }
}