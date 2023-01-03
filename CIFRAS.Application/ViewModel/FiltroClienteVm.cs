using System.ComponentModel.DataAnnotations;

namespace CIFRAS.Application.ViewModel
{
    public class FiltroClienteVm
    {
        [Display(Name = "Tipo de Cliente")]
        public int? TipoClienteId { get; set; }

        public string Cidade { get; set; }
    }
}