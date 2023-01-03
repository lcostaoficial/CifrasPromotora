using CIFRAS.Application.Interfaces;
using CIFRAS.Application.ViewModel;
using CIFRAS.Presentation.Helpers.DataTables.Data;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CIFRAS.Presentation.Helpers.DataTables.Filter
{
    public class ReciboFilter
    {
        private readonly IReciboAppService _reciboApp;

        public ReciboFilter(IReciboAppService reciboApp)
        {
            _reciboApp = reciboApp;
        }

        public Expression<Func<ReciboVm, bool>> ToExpression(string searchParameter)
        {
            Expression<Func<ReciboVm, bool>> expression = x => (x.Corretor.Nome.Contains(searchParameter)) && x.Ativo;
            return expression;
        }

        private ICollection<ReciboVm> Filter(int start, int length, string search, int sortColumn, string orderDir)
        {           
            switch (sortColumn)
            {
                case 0:
                    orderDir = $"Corretor.Nome {orderDir}";
                    break;
                case 1:
                    orderDir = $"DataEmissao {orderDir}";
                    break;               
                default:
                    orderDir = $"DataEmissao ORDER BY DESC";
                    break;
            }
            return _reciboApp.ObterTodosPaginado(ToExpression(search), start, length, orderDir) ?? new List<ReciboVm>();
        }

        public ReciboData ProcessFilter(int draw, int start, int length, string searchValue, string orderColumn, string orderDir)
        {
            int count = _reciboApp.ContarRegistros();

            if (length == -1)
                length = count;

            ReciboData dataTable = new ReciboData
            {
                draw = draw,
                recordsTotal = count,
                data = Filter(start, length, searchValue, int.Parse(orderColumn), orderDir),
                recordsFiltered = _reciboApp.ContarRegistrosPorExpressao(ToExpression(searchValue))
            };

            return dataTable;
        }
    }
}