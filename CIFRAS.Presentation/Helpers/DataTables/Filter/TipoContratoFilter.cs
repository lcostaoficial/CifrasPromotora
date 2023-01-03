using CIFRAS.Application.Interfaces;
using CIFRAS.Application.ViewModel;
using CIFRAS.Presentation.Helpers.DataTables.Data;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CIFRAS.Presentation.Helpers.DataTables.Filter
{
    public class TipoContratoFilter
    {
        private readonly ITipoContratoAppService _tipoContratoApp;

        public TipoContratoFilter(ITipoContratoAppService tipoContratoApp)
        {
            _tipoContratoApp = tipoContratoApp;
        }

        public Expression<Func<TipoContratoVm, bool>> ToExpression(string searchParameter)
        {
            Expression<Func<TipoContratoVm, bool>> expression = x => (x.Descricao.Contains(searchParameter)) && x.Ativo;
            return expression;
        }

        private ICollection<TipoContratoVm> Filter(int start, int length, string search, int sortColumn, string orderDir)
        {
            var orderBy = string.Empty;
            switch (sortColumn)
            {
                case 0:
                    orderBy = $"Descricao {orderDir}";
                    break;
                default:
                    orderBy = $"TipoContratoId {orderDir}";
                    break;
            }
            return _tipoContratoApp.ObterTodosPaginado(ToExpression(search), start, length, orderBy) ?? new List<TipoContratoVm>();
        }

        public TipoContratoData ProcessFilter(int draw, int start, int length, string searchValue, string orderColumn, string orderDir)
        {
            int count = _tipoContratoApp.ContarRegistros();

            if (length == -1)
                length = count;

            TipoContratoData dataTable = new TipoContratoData
            {
                draw = draw,
                recordsTotal = count,
                data = Filter(start, length, searchValue, int.Parse(orderColumn), orderDir),
                recordsFiltered = _tipoContratoApp.ContarRegistrosPorExpressao(ToExpression(searchValue))
            };

            return dataTable;
        }
    }
}