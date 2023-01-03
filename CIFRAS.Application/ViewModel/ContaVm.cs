using System.ComponentModel.DataAnnotations;
using System.Web.Script.Serialization;

namespace CIFRAS.Application.ViewModel
{
    public class ContaVm
    {
        #region Atributos
        public int ContaId { get; set; }

        [Display(Name = "Agência")]
        [MinLength(2, ErrorMessage = "Mínimo 2 caracteres")]
        [MaxLength(10, ErrorMessage = "Máximo 10 caracteres")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string NumeroAgencia { get; set; }

        [Display(Name = "Conta")]
        [MinLength(2, ErrorMessage = "Mínimo 2 caracteres")]
        [MaxLength(10, ErrorMessage = "Máximo 10 caracteres")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string NumeroConta { get; set; }
        #endregion

        #region Relacionamentos
        [Display(Name = "Banco")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public int? BancoId { get; set; }
        public BancoVm Banco { get; set; }

        public int ClienteId { get; set; }

        [ScriptIgnore]
        public ClienteVm Cliente { get; set; }
        #endregion

        #region Comportamento
        public void SetView(string bancoDescricao)
        {            
            this.BancoView = bancoDescricao;
            this.Banco = null;
        }
        #endregion

        #region Não mapeados
        public string BancoView { get; set; }
        #endregion
    }
}