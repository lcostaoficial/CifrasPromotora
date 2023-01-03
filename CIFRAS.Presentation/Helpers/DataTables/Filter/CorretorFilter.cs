using CIFRAS.Application.Interfaces;
using CIFRAS.Application.ViewModel;
using CIFRAS.Presentation.Helpers.DataTables.Data;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CIFRAS.Presentation.Helpers.DataTables.Filter
{
    public class CorretorFilter
    {
        private readonly ICorretorAppService _corretorApp;

        public CorretorFilter(ICorretorAppService corretorApp)
        {
            _corretorApp = corretorApp;
        }

        public Expression<Func<CorretorVm, bool>> ToExpression(string searchParameter)
        {
            Expression<Func<CorretorVm, bool>> expression = x => (x.Nome.Contains(searchParameter) || x.Cpf.Contains(searchParameter)) && x.Ativo;
            return expression;
        }

        private ICollection<CorretorVm> Filter(int start, int length, string search, int sortColumn, string orderDir)
        {
            var orderBy = string.Empty;
            switch (sortColumn)
            {
                case 0:
                    orderBy = $"Nome {orderDir}";
                    break;
                case 2:
                    orderBy = $"Cpf {orderDir}";
                    break;
                default:
                    orderBy = $"CorretorId {orderDir}";
                    break;
            }
            return _corretorApp.ObterTodosPaginado(ToExpression(search), start, length, orderBy) ?? new List<CorretorVm>();
        }

        public CorretorData ProcessFilter(int draw, int start, int length, string searchValue, string orderColumn, string orderDir)
        {
            int count = _corretorApp.ContarRegistros();

            if (length == -1)
                length = count;

            CorretorData dataTable = new CorretorData
            {
                draw = draw,
                recordsTotal = count,
                data = Filter(start, length, searchValue, int.Parse(orderColumn), orderDir),
                recordsFiltered = _corretorApp.ContarRegistrosPorExpressao(ToExpression(searchValue))
            };

            return dataTable;
        }
    }
}