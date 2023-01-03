using System.ComponentModel.DataAnnotations;
using System.Web.Script.Serialization;

namespace CIFRAS.Application.ViewModel
{
    public class ContatoVm
    {
        #region Atributos
        public int ContatoId { get; set; }

        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "Campo obrigatório")]
        [MinLength(2, ErrorMessage = "Mínimo 2 caracteres")]
        [MaxLength(255, ErrorMessage = "Máximo 255 caracteres")]
        public string Descricao { get; set; }

        [Display(Name = "Tipo de Contato")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        [EnumDataType(typeof(TipoContato), ErrorMessage = "Campo obrigatório!")]
        public TipoContato TipoContato { get; set; }
        #endregion

        #region Relacionamentos
        public int ClienteId { get; set; }

        [ScriptIgnore]
        public ClienteVm Cliente { get; set; }
        #endregion

        #region Não mapeados
        public string TipoContatoView => TipoContato.ToString();
        #endregion
    }
}