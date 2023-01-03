using System.ComponentModel.DataAnnotations;
using System.Web;

namespace CIFRAS.Application.ViewModel
{
    public class ImportacaoVm
    {
        #region Não mapeados
        [Required(ErrorMessage = "Campo obrigatório")]
        public HttpPostedFileBase Arquivo { get; set; }

        public string LogPath { get; set; }

        [Display(Name = "Destino da Importação")]
        [Required(ErrorMessage = "Campo obrigatório")]
        public int TipoClienteId { get; set; }
        #endregion
    }
}