using CIFRAS.Application.Interfaces;
using System;
using System.Collections.Generic;
using CIFRAS.Application.ViewModel;
using System.Linq.Expressions;
using CIFRAS.Domain.Interfaces.Services;
using CIFRAS.Domain.Entities;
using CIFRAS.Application.Mapper;

namespace CIFRAS.Application.AppServices
{
    public class CorretorAppService : ICorretorAppService
    {
        private readonly ICorretorService _corretorService;

        public CorretorAppService(ICorretorService corretorService)
        {
            _corretorService = corretorService;
        }

        public void Adicionar(CorretorVm model)
        {
            _corretorService.Adicionar(MapperConfig.Mapper.Map<Corretor>(model));
        }

        public void Atualizar(CorretorVm model)
        {
            _corretorService.Atualizar(MapperConfig.Mapper.Map<Corretor>(model));
        }

        public void Remover(CorretorVm model)
        {
            _corretorService.Remover(MapperConfig.Mapper.Map<Corretor>(model));
        }

        public int ContarRegistros()
        {
            return _corretorService.ContarRegistros();
        }

        public int ContarRegistrosPorExpressao(Expression<Func<CorretorVm, bool>> expression)
        {
            return _corretorService.ContarRegistrosPorExpressao(MapperConfig.Mapper.Map<Expression<Func<Corretor, bool>>>(expression));
        }

        public CorretorVm BuscarPorId(int id)
        {
            return MapperConfig.Mapper.Map<CorretorVm>(_corretorService.BuscarPorId(id));
        }

        public ICollection<CorretorVm> BuscarPorExpressao(Expression<Func<CorretorVm, bool>> expression)
        {
            return MapperConfig.Mapper.Map<ICollection<CorretorVm>>(_corretorService.BuscarPorExpressao(MapperConfig.Mapper.Map<Expression<Func<Corretor, bool>>>(expression)));
        }

        public ICollection<CorretorVm> ObterTodosPaginado(Expression<Func<CorretorVm, bool>> expression, int start, int take, string orderBy)
        {
            return MapperConfig.Mapper.Map<ICollection<CorretorVm>>(_corretorService.ObterTodosPaginado(MapperConfig.Mapper.Map<Expression<Func<Corretor, bool>>>(expression), start, take, orderBy));
        }

        public ICollection<CorretorVm> BuscarTodos()
        {
            return MapperConfig.Mapper.Map<ICollection<CorretorVm>>(_corretorService.BuscarTodos());
        }        

        public void Dispose()
        {
            _corretorService.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}