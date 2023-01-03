using System.ComponentModel.DataAnnotations;

namespace CIFRAS.Application.ViewModel
{
    public class CategoriaArquivoVm
    {
        #region Atributos
        [Key]
        public int CategoriaArquivoId { get; set; }

        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "Campo obrigatório")]
        [MinLength(2, ErrorMessage = "Mínimo 2 caracteres")]
        [StringLength(255, ErrorMessage = "Máximo 255 caracteres")]
        public string Descricao { get; set; }

        public bool Ativo { get; set; } = true;
        #endregion
    }
}