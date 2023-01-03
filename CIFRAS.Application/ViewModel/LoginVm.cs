using System.ComponentModel.DataAnnotations;

namespace CIFRAS.Application.ViewModel
{
    public class LoginVm
    {
        #region Atributos
        [Required(ErrorMessage = "Campo obrigatório.")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        public string Senha { get; set; }
        #endregion
    }
}
