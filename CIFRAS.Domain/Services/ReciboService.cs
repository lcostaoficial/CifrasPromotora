using CIFRAS.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using CIFRAS.Domain.Entities;
using System.Linq.Expressions;
using CIFRAS.Domain.Interfaces.Repositories;

namespace CIFRAS.Domain.Services
{
    public class ReciboService : IReciboService
    {
        private readonly IReciboRepository _reciboRepository;

        public ReciboService(IReciboRepository reciboRepository)
        {
            _reciboRepository = reciboRepository;
        }

        public void Adicionar(Recibo model)
        {
            _reciboRepository.Adicionar(model);
        }

        public void Atualizar(Recibo model)
        {
            _reciboRepository.Atualizar(model);
        }

        public void Remover(Recibo model)
        {
            model = BuscarPorId(model.ReciboId);
            model.Excluir();
            _reciboRepository.Atualizar(model);
        }

        public int ContarRegistros(bool ativo = true)
        {
            return _reciboRepository.ContarRegistros(ativo);
        }

        public int ContarRegistrosPorExpressao(Expression<Func<Recibo, bool>> expression)
        {
            return _reciboRepository.ContarRegistrosPorExpressao(expression);
        }

        public Recibo BuscarPorId(int id, bool ativo = true)
        {
            return _reciboRepository.BuscarPorId(id, ativo);
        }

        public Recibo BuscarPorIdCustomizado(int id, bool ativo = true)
        {
            return _reciboRepository.BuscarPorIdCustomizado(id, ativo);
        }

        public ICollection<Recibo> ObterTodosPaginado(Expression<Func<Recibo, bool>> expression, int start, int take, string orderBy)
        {
            return _reciboRepository.ObterTodosPaginado(expression, start, take, orderBy);
        }

        public ICollection<Recibo> BuscarPorExpressao(Expression<Func<Recibo, bool>> expression)
        {
            return _reciboRepository.BuscarPorExpressao(expression);
        }

        public ICollection<Recibo> BuscarTodos(bool ativo = true)
        {
            return _reciboRepository.BuscarTodos(ativo);
        }

        public void Dispose()
        {
            _reciboRepository.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}