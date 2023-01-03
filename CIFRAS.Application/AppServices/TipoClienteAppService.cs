using CIFRAS.Application.Interfaces;
using CIFRAS.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using CIFRAS.Application.ViewModel;
using CIFRAS.Application.Mapper;
using CIFRAS.Domain.Entities;
using System.Linq.Expressions;

namespace CIFRAS.Application.AppServices
{
    public class TipoClienteAppService : ITipoClienteAppService
    {
        private readonly ITipoClienteService _tipoClienteService;

        public TipoClienteAppService(ITipoClienteService tipoClienteService)
        {
            _tipoClienteService = tipoClienteService;
        }

        public void Adicionar(TipoClienteVm model)
        {
            _tipoClienteService.Adicionar(MapperConfig.Mapper.Map<TipoCliente>(model));
        }

        public void Atualizar(TipoClienteVm model)
        {
            _tipoClienteService.Atualizar(MapperConfig.Mapper.Map<TipoCliente>(model));
        }

        public void Remover(TipoClienteVm model)
        {
            _tipoClienteService.Remover(MapperConfig.Mapper.Map<TipoCliente>(model));
        }

        public int ContarRegistros()
        {
            return _tipoClienteService.ContarRegistros();
        }

        public int ContarRegistrosPorExpressao(Expression<Func<TipoClienteVm, bool>> expression)
        {
            return _tipoClienteService.ContarRegistrosPorExpressao(MapperConfig.Mapper.Map<Expression<Func<TipoCliente, bool>>>(expression));
        }

        public TipoClienteVm BuscarPorId(int id)
        {
            return MapperConfig.Mapper.Map<TipoClienteVm>(_tipoClienteService.BuscarPorId(id));
        }

        public ICollection<TipoClienteVm> BuscarPorExpressao(Expression<Func<TipoClienteVm, bool>> expression)
        {
            return MapperConfig.Mapper.Map<ICollection<TipoClienteVm>>(_tipoClienteService.BuscarPorExpressao(MapperConfig.Mapper.Map<Expression<Func<TipoCliente, bool>>>(expression)));
        }       

        public ICollection<TipoClienteVm> ObterTodosPaginado(Expression<Func<TipoClienteVm, bool>> expression, int start, int take, string orderBy)
        {
            return MapperConfig.Mapper.Map<ICollection<TipoClienteVm>>(_tipoClienteService.ObterTodosPaginado(MapperConfig.Mapper.Map<Expression<Func<TipoCliente, bool>>>(expression), start, take, orderBy));
        }

        public ICollection<TipoClienteVm> BuscarTodos()
        {
            return MapperConfig.Mapper.Map<ICollection<TipoClienteVm>>(_tipoClienteService.BuscarTodos());
        }

        public void Dispose()
        {
            _tipoClienteService.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}