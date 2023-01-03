using System.Collections.Generic;
using CIFRAS.Application.Interfaces;
using CIFRAS.Application.ViewModel;
using CIFRAS.Domain.Interfaces.Services;
using CIFRAS.Application.Mapper;
using CIFRAS.Domain.Entities;
using System;
using System.Linq.Expressions;

namespace CIFRAS.Application.AppServices
{
    public class BancoAppService : IBancoAppService
    {
        private readonly IBancoService _bancoService;

        public BancoAppService(IBancoService bancoService)
        {
            _bancoService = bancoService;
        }

        public void Adicionar(BancoVm model)
        {
            _bancoService.Adicionar(MapperConfig.Mapper.Map<Banco>(model));
        }

        public void Atualizar(BancoVm model)
        {
            _bancoService.Atualizar(MapperConfig.Mapper.Map<Banco>(model));
        }

        public void Remover(BancoVm model)
        {
            _bancoService.Remover(MapperConfig.Mapper.Map<Banco>(model));
        }

        public int ContarRegistros()
        {
            return _bancoService.ContarRegistros();
        }

        public int ContarRegistrosPorExpressao(Expression<Func<BancoVm, bool>> expression)
        {
            return _bancoService.ContarRegistrosPorExpressao(MapperConfig.Mapper.Map<Expression<Func<Banco, bool>>>(expression));
        }

        public BancoVm BuscarPorId(int id)
        {
            return MapperConfig.Mapper.Map<BancoVm>(_bancoService.BuscarPorId(id));
        }

        public ICollection<BancoVm> BuscarPorExpressao(Expression<Func<BancoVm, bool>> expression)
        {
            return MapperConfig.Mapper.Map<ICollection<BancoVm>>(_bancoService.BuscarPorExpressao(MapperConfig.Mapper.Map<Expression<Func<Banco, bool>>>(expression)));
        }

        public ICollection<BancoVm> ObterTodosPaginado(Expression<Func<BancoVm, bool>> expression, int start, int take, string orderBy)
        {
            return MapperConfig.Mapper.Map<ICollection<BancoVm>>(_bancoService.ObterTodosPaginado(MapperConfig.Mapper.Map<Expression<Func<Banco, bool>>>(expression), start, take, orderBy));
        }

        public ICollection<BancoVm> BuscarTodos()
        {
            return MapperConfig.Mapper.Map<ICollection<BancoVm>>(_bancoService.BuscarTodos());
        }

        public void Dispose()
        {
            _bancoService.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}