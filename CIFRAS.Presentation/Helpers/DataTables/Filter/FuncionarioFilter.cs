using CIFRAS.Application.Interfaces;
using CIFRAS.Application.ViewModel;
using CIFRAS.Presentation.Helpers.DataTables.Data;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CIFRAS.Presentation.Helpers.DataTables.Filter
{
    public class FuncionarioFilter
    {
        private readonly IFuncionarioAppService _funcionarioApp;

        public FuncionarioFilter(IFuncionarioAppService funcionarioApp)
        {
            _funcionarioApp = funcionarioApp;
        }

        public Expression<Func<FuncionarioVm, bool>> ToExpression(string searchParameter)
        {
            Expression<Func<FuncionarioVm, bool>> expression = x => (x.Nome.Contains(searchParameter)) && x.Ativo;
            return expression;
        }

        private ICollection<FuncionarioVm> Filter(int start, int length, string search, int sortColumn, string orderDir)
        {
            var orderBy = string.Empty;
            switch (sortColumn)
            {
                case 0:
                    orderBy = $"Nome {orderBy}";
                    break;
                case 1:
                    orderBy = $"Cpf {orderBy}";
                    break;
                case 2:
                    orderBy = $"Cargo {orderBy}";
                    break;
                default:
                    orderBy = $"FuncionarioId {orderBy}";
                    break;
            }
            return _funcionarioApp.ObterTodosPaginado(ToExpression(search), start, length, orderBy) ?? new List<FuncionarioVm>();
        }

        public FuncionarioData ProcessFilter(int draw, int start, int length, string searchValue, string orderColumn, string orderDir)
        {
            int count = _funcionarioApp.ContarRegistros();

            if (length == -1)
                length = count;

            FuncionarioData dataTable = new FuncionarioData
            {
                draw = draw,
                recordsTotal = count,
                data = Filter(start, length, searchValue, int.Parse(orderColumn), orderDir),
                recordsFiltered = _funcionarioApp.ContarRegistrosPorExpressao(ToExpression(searchValue))
            };

            return dataTable;
        }
    }
}