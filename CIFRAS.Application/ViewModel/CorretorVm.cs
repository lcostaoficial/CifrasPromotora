using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Script.Serialization;

namespace CIFRAS.Application.ViewModel
{
    public class CorretorVm
    {
        #region Atributos
        [Key]
        public int CorretorId { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [MaxLength(150, ErrorMessage = "Máximo 150 caracteres")]
        public string Nome { get; set; }

        [Display(Name = "Nome Abreviado")]
        [MaxLength(20, ErrorMessage = "Máximo 20 caracteres")]
        public string NomeAbreviado { get; set; }

        [Display(Name = "CPF")]
        [MaxLength(14, ErrorMessage = "Máximo 14 caracteres")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Cpf { get; set; }

        [Display(Name = "Número Agência")]
        [MaxLength(10, ErrorMessage = "Máximo 10 caracteres")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string NumeroAgencia { get; set; }

        [Display(Name = "Número da Conta")]
        [Required(ErrorMessage = "Campo obrigatório")]
        [MaxLength(10, ErrorMessage = "Máximo 10 caracteres")]
        public string NumeroConta { get; set; }

        [Display(Name = "Tipo da Conta")]  
        [Required(ErrorMessage = "Campo obrigatório")]
        [EnumDataType(typeof(TipoConta), ErrorMessage = "Campo obrigatório")]
        public TipoConta TipoConta { get; set; }

        public bool Ativo { get; set; } = true;
        #endregion

        #region Relacionamentos
        [Display(Name = "Banco")]
        public int BancoId { get; set; }
        public BancoVm Banco { get; set; }
        #endregion

        #region Listas
        [ScriptIgnore]
        public ICollection<ReciboVm> ListaRecibo { get; set; }
        #endregion
    }
}