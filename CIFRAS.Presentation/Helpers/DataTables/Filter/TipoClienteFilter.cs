using CIFRAS.Application.Interfaces;
using CIFRAS.Application.ViewModel;
using CIFRAS.Presentation.Helpers.DataTables.Data;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CIFRAS.Presentation.Helpers.DataTables.Filter
{
    public class TipoClienteFilter
    {
        private readonly ITipoClienteAppService _tipoClienteApp;

        public TipoClienteFilter(ITipoClienteAppService tipoClienteApp)
        {
            _tipoClienteApp = tipoClienteApp;
        }

        public Expression<Func<TipoClienteVm, bool>> ToExpression(string searchParameter)
        {
            Expression<Func<TipoClienteVm, bool>> expression = x => (x.Descricao.Contains(searchParameter)) && x.Ativo;
            return expression;
        }

        private ICollection<TipoClienteVm> Filter(int start, int length, string search, int sortColumn, string orderDir)
        {
            var orderBy = string.Empty;
            switch (sortColumn)
            {
                case 0:
                    orderBy = $"Descricao {orderDir}";
                    break;           
                default:
                    orderBy = $"TipoClienteId {orderDir}";
                    break;
            }
            return _tipoClienteApp.ObterTodosPaginado(ToExpression(search), start, length, orderBy) ?? new List<TipoClienteVm>();
        }

        public TipoClienteData ProcessFilter(int draw, int start, int length, string searchValue, string orderColumn, string orderDir)
        {
            int count = _tipoClienteApp.ContarRegistros();

            if (length == -1)
                length = count;

            TipoClienteData dataTable = new TipoClienteData
            {
                draw = draw,
                recordsTotal = count,
                data = Filter(start, length, searchValue, int.Parse(orderColumn), orderDir),
                recordsFiltered = _tipoClienteApp.ContarRegistrosPorExpressao(ToExpression(searchValue))
            };

            return dataTable;
        }
    }
}