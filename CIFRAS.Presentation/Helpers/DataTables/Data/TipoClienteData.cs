using CIFRAS.Application.ViewModel;
using System.Collections.Generic;

namespace CIFRAS.Presentation.Helpers.DataTables.Data
{
    public class TipoClienteData
    {
        public int draw { get; set; }
        public int recordsTotal { get; set; }
        public int recordsFiltered { get; set; }
        public ICollection<TipoClienteVm> data { get; set; }
    }
}