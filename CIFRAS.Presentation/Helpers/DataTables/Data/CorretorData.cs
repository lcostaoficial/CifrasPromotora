﻿using CIFRAS.Application.ViewModel;
using System.Collections.Generic;

namespace CIFRAS.Presentation.Helpers.DataTables.Data
{
    public class CorretorData
    {
        public int draw { get; set; }
        public int recordsTotal { get; set; }
        public int recordsFiltered { get; set; }
        public ICollection<CorretorVm> data { get; set; }
    }
}