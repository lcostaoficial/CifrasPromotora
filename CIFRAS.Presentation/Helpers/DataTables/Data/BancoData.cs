using CIFRAS.Application.ViewModel;
using System.Collections.Generic;

namespace CIFRAS.Presentation.Helpers.DataTables.Data
{
    public class BancoData
    {
        public int draw { get; set; }
        public int recordsTotal { get; set; }
        public int recordsFiltered { get; set; }
        public ICollection<BancoVm> data { get; set; }
    }
}