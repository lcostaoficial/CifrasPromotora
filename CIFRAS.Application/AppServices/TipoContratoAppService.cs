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
    public class TipoContratoAppService : ITipoContratoAppService
    {
        private readonly ITipoContratoService _tipoContratoService;

        public TipoContratoAppService(ITipoContratoService tipoContratoService)
        {
            _tipoContratoService = tipoContratoService;
        }

        public void Adicionar(TipoContratoVm model)
        {
            _tipoContratoService.Adicionar(MapperConfig.Mapper.Map<TipoContrato>(model));
        }

        public void Atualizar(TipoContratoVm model)
        {
            _tipoContratoService.Atualizar(MapperConfig.Mapper.Map<TipoContrato>(model));
        }

        public void Remover(TipoContratoVm model)
        {
            _tipoContratoService.Remover(MapperConfig.Mapper.Map<TipoContrato>(model));
        }

        public int ContarRegistros()
        {
            return _tipoContratoService.ContarRegistros();
        }

        public int ContarRegistrosPorExpressao(Expression<Func<TipoContratoVm, bool>> expression)
        {
            return _tipoContratoService.ContarRegistrosPorExpressao(MapperConfig.Mapper.Map<Expression<Func<TipoContrato, bool>>>(expression));
        }

        public ICollection<TipoContratoVm> BuscarPorExpressao(Expression<Func<TipoContratoVm, bool>> expression)
        {
            return MapperConfig.Mapper.Map<ICollection<TipoContratoVm>>(_tipoContratoService.BuscarPorExpressao(MapperConfig.Mapper.Map<Expression<Func<TipoContrato, bool>>>(expression)));
        }

        public ICollection<TipoContratoVm> ObterTodosPaginado(Expression<Func<TipoContratoVm, bool>> expression, int start, int take, string orderBy)
        {
            return MapperConfig.Mapper.Map<ICollection<TipoContratoVm>>(_tipoContratoService.ObterTodosPaginado(MapperConfig.Mapper.Map<Expression<Func<TipoContrato, bool>>>(expression), start, take, orderBy));
        }

        public TipoContratoVm BuscarPorId(int id)
        {
            return MapperConfig.Mapper.Map<TipoContratoVm>(_tipoContratoService.BuscarPorId(id));
        }

        public ICollection<TipoContratoVm> BuscarTodos()
        {
            return MapperConfig.Mapper.Map<ICollection<TipoContratoVm>>(_tipoContratoService.BuscarTodos());
        }

        public void Dispose()
        {
            _tipoContratoService.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}