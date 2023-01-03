using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CIFRAS.Application.ViewModel
{
    public class BancoVm
    {
        #region Atributos
        public int BancoId { get; set; }

        [Display(Name = "Descrição")]
        [MinLength(1, ErrorMessage = "Mínimo 1 caractere")]
        [MaxLength(255, ErrorMessage = "Máximo 255 caracteres")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Descricao { get; set; }

        [MaxLength(10, ErrorMessage = "Máximo 10 caracteres")]
        public string Sigla { get; set; }

        [Display(Name = "Código")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public int? CodigoBanco { get; set; }

        public bool Ativo { get; set; } = true;
        #endregion

        #region Listas
        public ICollection<ContaVm> ListaConta { get; set; }
        public ICollection<ContratoVm> ListaContrato { get; set; }
        #endregion
    }
}