using CIFRAS.Application.Interfaces;
using CIFRAS.Application.ViewModel;
using CIFRAS.Presentation.Helpers.DataTables.Data;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using Microsoft.Ajax.Utilities;
using System.Linq;

namespace CIFRAS.Presentation.Helpers.DataTables.Filter
{
    public class ClienteFilter
    {
        private readonly IClienteAppService _clienteApp;

        public ClienteFilter(IClienteAppService clienteApp)
        {
            _clienteApp = clienteApp;
        }

        public Expression<Func<ClienteVm, bool>> ToExpression(string searchParameter, FiltroClienteVm model)
        {
            if (model.TipoClienteId != 0 && model.TipoClienteId != null && !model.Cidade.IsNullOrWhiteSpace())
            {
                return x => (x.Nome.Contains(searchParameter) || x.Cpf.Contains(searchParameter) || x.Rg.Contains(searchParameter)) && x.Endereco.Cidade.Contains(model.Cidade) && x.TipoClienteId == model.TipoClienteId && x.Ativo;
            }
            else if (model.TipoClienteId != 0 && model.TipoClienteId != null)
            {
                return x => (x.Nome.Contains(searchParameter) || x.Cpf.Contains(searchParameter) || x.Rg.Contains(searchParameter)) && x.TipoClienteId == model.TipoClienteId && x.Ativo;
            }
            else if (!model.Cidade.IsNullOrWhiteSpace())
            {
                return x => (x.Nome.Contains(searchParameter) || x.Cpf.Contains(searchParameter) || x.Rg.Contains(searchParameter)) && x.Endereco.Cidade.Contains(model.Cidade) && x.Ativo;
            }
            else
            {
                return x => (x.Nome.Contains(searchParameter) || x.Cpf.Contains(searchParameter) || x.Rg.Contains(searchParameter)) && x.Ativo;
            }
        }

        private ICollection<ClienteVm> Filter(int start, int length, string search, int sortColumn, string orderDir, FiltroClienteVm model)
        {
            var orderBy = string.Empty;
            switch (sortColumn)
            {
                case 0:
                    orderBy = $"Nome {orderDir}";
                    break;
                case 1:
                    orderBy = $"Cpf {orderDir}";
                    break;
                case 2:                   
                    orderBy = $"TipoClienteId {orderDir}";
                    break;
                case 3:
                    if (orderDir.ToLower() == "ASC")
                    {
                        return _clienteApp.ObterTodosPaginado(ToExpression(search, model), start, length).OrderBy(x => x.MargemDisponivel).ToList() ?? new List<ClienteVm>();
                    }
                    else
                    {
                        return _clienteApp.ObterTodosPaginado(ToExpression(search, model), start, length).OrderByDescending(x => x.MargemDisponivel).ToList() ?? new List<ClienteVm>();
                    }
                case 4:
                    orderBy = $"DataVisualizacao {orderDir}";
                    break;
                default:
                    orderBy = $"ClienteId {orderDir}";
                    break;
            }
            return _clienteApp.ObterTodosPaginado(ToExpression(search, model), start, length, orderBy) ?? new List<ClienteVm>();
        }

        public ClienteData ProcessFilter(int draw, int start, int length, string searchValue, string orderColumn, string orderDir, FiltroClienteVm model)
        {
            int count = 0;

            if (model.TipoClienteId == 0)
            {
                _clienteApp.ContarRegistros();
            }
            else
            {
                _clienteApp.ContarRegistrosPorExpressao(x => x.TipoClienteId == model.TipoClienteId && x.Ativo);
            }

            if (length == -1)
                length = count;

            ClienteData dataTable = new ClienteData
            {
                draw = draw,
                recordsTotal = count,
                data = Filter(start, length, searchValue, int.Parse(orderColumn), orderDir, model),
                recordsFiltered = _clienteApp.ContarRegistrosPorExpressao(ToExpression(searchValue, model))
            };

            return dataTable;
        }
    }
}