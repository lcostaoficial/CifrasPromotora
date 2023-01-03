using System.ComponentModel.DataAnnotations;

namespace CIFRAS.Application.ViewModel
{
    public class FuncionarioVm
    {
        #region Atributos
        [Key]
        public int FuncionarioId { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        [MinLength(2, ErrorMessage = "Mínimo de 2 caracteres.")]
        [StringLength(255, ErrorMessage = "Máximo de 255 caracteres.")]
        public string Nome { get; set; }

        [Display(Name = "CPF")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        public string Cpf { get; set; }

        [Display(Name = "Cargo")]
        [Required(ErrorMessage = "Campo obrigatório.")]
        [EnumDataType(typeof(Cargo), ErrorMessage = "Campo obrigatório!")]
        public Cargo Cargo { get; set; }

        public string CargoView => Cargo.ToString();

        [Required(ErrorMessage = "Campo obrigatório.")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Campo obrigatório.")]
        public string Senha { get; set; }

        public bool Ativo { get; set; } = true;
        #endregion
    }
}