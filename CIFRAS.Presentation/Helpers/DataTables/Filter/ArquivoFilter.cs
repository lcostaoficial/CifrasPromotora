using CIFRAS.Application.Interfaces;
using CIFRAS.Application.ViewModel;
using CIFRAS.Presentation.Helpers.DataTables.Data;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CIFRAS.Presentation.Helpers.DataTables.Filter
{
    public class ArquivoFilter
    {
        private readonly IArquivoAppService _arquivoApp;
        private readonly int _clienteId;

        public ArquivoFilter(IArquivoAppService arquivoApp, int clienteId)
        {
            _arquivoApp = arquivoApp;
            _clienteId = clienteId;
        }

        public Expression<Func<ArquivoVm, bool>> ToExpression(string searchParameter)
        {
            Expression<Func<ArquivoVm, bool>> expression = x => x.Descricao.Contains(searchParameter) && (x.ClienteId == _clienteId);
            return expression;
        }

        private ICollection<ArquivoVm> Filter(int start, int length, string search, int sortColumn, string orderDir)
        {
            var orderBy = string.Empty;
            switch (sortColumn)
            {
                case 0:
                    orderBy = $"Descricao {orderDir}";
                    break;
                case 1:
                    orderBy = $"CategoriaArquivo.Descricao {orderDir}";
                    break;
                default:
                    orderBy = $"ArquivoId {orderDir}";
                    break;
            }
            return _arquivoApp.ObterTodosPaginado(ToExpression(search), start, length, orderBy) ?? new List<ArquivoVm>();
        }

        public ArquivoData ProcessFilter(int draw, int start, int length, string searchValue, string orderColumn, string orderDir)
        {
            int count = _arquivoApp.ContarRegistrosPorExpressao(x => x.ClienteId == _clienteId);

            if (length == -1)
                length = count;

            ArquivoData dataTable = new ArquivoData
            {
                draw = draw,
                recordsTotal = count,
                data = Filter(start, length, searchValue, int.Parse(orderColumn), orderDir),
                recordsFiltered = _arquivoApp.ContarRegistrosPorExpressao(ToExpression(searchValue))
            };

            return dataTable;
        }
    }
}