using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CIFRAS.Application.ViewModel
{
    public class TipoContratoVm
    {
        #region Atributos
        public int TipoContratoId { get; set; }

        [Display(Name = "Descrição")]
        [MinLength(2, ErrorMessage = "Mínimo 2 caracteres")]
        [MaxLength(255, ErrorMessage = "Máximo 255 caracteres")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Descricao { get; set; }

        public bool Ativo { get; set; } = true;
        #endregion

        #region Listas
        public ICollection<ContratoVm> ListaContrato { get; set; }
        #endregion
    }
}