using CIFRAS.Application.Interfaces;
using CIFRAS.Application.ViewModel;
using CIFRAS.Presentation.Helpers.DataTables.Data;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CIFRAS.Presentation.Helpers.DataTables.Filter
{
    public class BancoFilter
    {
        private readonly IBancoAppService _bancoApp;

        public BancoFilter(IBancoAppService bancoApp)
        {
            _bancoApp = bancoApp;
        }

        public Expression<Func<BancoVm, bool>> ToExpression(string searchParameter)
        {
            Expression<Func<BancoVm, bool>> expression = x => (x.Descricao.Contains(searchParameter)) && x.Ativo;
            return expression;
        }

        private ICollection<BancoVm> Filter(int start, int length, string search, int sortColumn, string orderDir)
        {
            var orderBy = string.Empty;
            switch (sortColumn)
            {
                case 0:
                    orderBy = $"Descricao {orderDir}";
                    break;
                case 1:
                    orderBy = $"Sigla {orderDir}";
                    break;
                case 2:
                    orderBy = $"CodigoBanco {orderDir}";
                    break;
                default:
                    orderBy = $"BancoId {orderDir}";
                    break;
            }
            return _bancoApp.ObterTodosPaginado(ToExpression(search), start, length, orderBy) ?? new List<BancoVm>();
        }

        public BancoData ProcessFilter(int draw, int start, int length, string searchValue, string orderColumn, string orderDir)
        {
            int count = _bancoApp.ContarRegistros();

            if (length == -1)
                length = count;

            BancoData dataTable = new BancoData
            {
                draw = draw,
                recordsTotal = count,
                data = Filter(start, length, searchValue, int.Parse(orderColumn), orderDir),
                recordsFiltered = _bancoApp.ContarRegistrosPorExpressao(ToExpression(searchValue))
            };

            return dataTable;
        }
    }
}