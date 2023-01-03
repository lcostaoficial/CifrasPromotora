using System.Collections.Generic;
using CIFRAS.Application.Interfaces;
using CIFRAS.Application.ViewModel;
using System;
using System.Linq.Expressions;
using CIFRAS.Domain.Interfaces.Services;
using CIFRAS.Application.Mapper;
using CIFRAS.Domain.Entities;
using CIFRAS.Application.Helpers.General;

namespace CIFRAS.Application.AppServices
{
    public class ReciboAppService : IReciboAppService
    {
        private readonly IReciboService _reciboService;

        public ReciboAppService(IReciboService reciboService)
        {
            _reciboService = reciboService;
        }

        public void Adicionar(ReciboVm model)
        {
            _reciboService.Adicionar(MapperConfig.Mapper.Map<Recibo>(model));
        }

        public void Atualizar(ReciboVm model)
        {
            _reciboService.Atualizar(MapperConfig.Mapper.Map<Recibo>(model));
        }

        public void Remover(ReciboVm model)
        {
            _reciboService.Remover(MapperConfig.Mapper.Map<Recibo>(model));
        }

        public int ContarRegistros()
        {
            return _reciboService.ContarRegistros();
        }

        public int ContarRegistrosPorExpressao(Expression<Func<ReciboVm, bool>> expression)
        {
            return _reciboService.ContarRegistrosPorExpressao(MapperConfig.Mapper.Map<Expression<Func<Recibo, bool>>>(expression));
        }

        public ReciboVm BuscarPorId(int id)
        {
            return MapperConfig.Mapper.Map<ReciboVm>(_reciboService.BuscarPorId(id));
        }

        public ReciboVm BuscarPorIdCustomizado(int id)
        {
            var modelVm = MapperConfig.Mapper.Map<ReciboVm>(_reciboService.BuscarPorIdCustomizado(id));
            modelVm.ListaReciboEmprestimo.ForEach(x => x.SetView(x.Banco.Descricao, x.TipoCliente.Descricao));
            return modelVm;
        }

        public ICollection<ReciboVm> BuscarPorExpressao(Expression<Func<ReciboVm, bool>> expression)
        {
            return MapperConfig.Mapper.Map<ICollection<ReciboVm>>(_reciboService.BuscarPorExpressao(MapperConfig.Mapper.Map<Expression<Func<Recibo, bool>>>(expression)));
        }

        public ICollection<ReciboVm> ObterTodosPaginado(Expression<Func<ReciboVm, bool>> expression, int start, int take, string orderBy)
        {
            return MapperConfig.Mapper.Map<ICollection<ReciboVm>>(_reciboService.ObterTodosPaginado(MapperConfig.Mapper.Map<Expression<Func<Recibo, bool>>>(expression), start, take, orderBy));
        }

        public ICollection<ReciboVm> BuscarTodos()
        {
            return MapperConfig.Mapper.Map<ICollection<ReciboVm>>(_reciboService.BuscarTodos());
        }        

        public void Dispose()
        {
            _reciboService.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}