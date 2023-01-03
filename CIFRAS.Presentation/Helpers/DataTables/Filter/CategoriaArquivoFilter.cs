using CIFRAS.Application.Interfaces;
using CIFRAS.Application.ViewModel;
using CIFRAS.Presentation.Helpers.DataTables.Data;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CIFRAS.Presentation.Helpers.DataTables.Filter
{
    public class CategoriaArquivoFilter
    {
        private readonly ICategoriaArquivoAppService _categoriaArquivoApp;

        public CategoriaArquivoFilter(ICategoriaArquivoAppService categoriaArquivoApp)
        {
            _categoriaArquivoApp = categoriaArquivoApp;
        }

        public Expression<Func<CategoriaArquivoVm, bool>> ToExpression(string searchParameter)
        {
            Expression<Func<CategoriaArquivoVm, bool>> expression = x => (x.Descricao.Contains(searchParameter)) && x.Ativo;
            return expression;
        }

        private ICollection<CategoriaArquivoVm> Filter(int start, int length, string search, int sortColumn, string orderDir)
        {
            var orderBy = string.Empty;
            switch (sortColumn)
            {
                case 0:
                    orderBy = $"Descricao {orderDir}";
                    break;
                default:
                    orderBy = $"CategoriaArquivoId {orderDir}";
                    break;
            }
            return _categoriaArquivoApp.ObterTodosPaginado(ToExpression(search), start, length, orderBy) ?? new List<CategoriaArquivoVm>();
        }

        public CategoriaArquivoData ProcessFilter(int draw, int start, int length, string searchValue, string orderColumn, string orderDir)
        {
            int count = _categoriaArquivoApp.ContarRegistros();

            if (length == -1)
                length = count;

            CategoriaArquivoData dataTable = new CategoriaArquivoData
            {
                draw = draw,
                recordsTotal = count,
                data = Filter(start, length, searchValue, int.Parse(orderColumn), orderDir),
                recordsFiltered = _categoriaArquivoApp.ContarRegistrosPorExpressao(ToExpression(searchValue))
            };

            return dataTable;
        }
    }
}