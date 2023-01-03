using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Script.Serialization;

namespace CIFRAS.Application.ViewModel
{
    public class TipoClienteVm
    {
        #region Atributos
        [Key]
        public int TipoClienteId { get; set; }

        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "Campo obrigatório")]
        [MinLength(2, ErrorMessage = "O tamanho mínimo são 2 caracteres")]
        [StringLength(255, ErrorMessage = "O tamanho máximo são 255 caracteres")]
        public string Descricao { get; set; }

        public bool Ativo { get; set; } = true;
        #endregion

        #region Listas
        [ScriptIgnore]
        public ICollection<ClienteVm> ListaCliente { get; set; }
        #endregion
    }
}