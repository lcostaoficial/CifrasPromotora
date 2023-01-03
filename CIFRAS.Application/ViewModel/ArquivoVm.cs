using System.ComponentModel.DataAnnotations;
using System.Web;
using System.Web.Script.Serialization;

namespace CIFRAS.Application.ViewModel
{
    public class ArquivoVm
    {
        #region Atributos
        public int ArquivoId { get; set; }

        [Display(Name = "Descrição")]
        [MinLength(2, ErrorMessage = "Mínimo 2 caracteres")]
        [MaxLength(255, ErrorMessage = "Máximo 255")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public string Descricao { get; set; }

        [MinLength(2, ErrorMessage = "Mínimo 2 caracteres")]
        [MaxLength(255, ErrorMessage = "Máximo 255")]
        public string Caminho { get; set; }
        #endregion

        #region Relacionamentos
        [Display(Name = "Categoria de Arquivo")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public int CategoriaArquivoId { get; set; }

        public CategoriaArquivoVm CategoriaArquivo { get; set; }

        [Display(Name = "Cliente")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public int ClienteId { get; set; }

        [ScriptIgnore]
        public ClienteVm Cliente { get; set; }
        #endregion

        #region Não mapeados
        public byte[] ArquivoRetorno { get; set; }
        public HttpPostedFileBase ArquivoEnvio { get; set; }
        #endregion
    }
}