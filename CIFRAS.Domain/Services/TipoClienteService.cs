using System.Collections.Generic;
using CIFRAS.Domain.Entities;
using CIFRAS.Domain.Interfaces.Repositories;
using CIFRAS.Domain.Interfaces.Services;
using System;
using System.Linq.Expressions;

namespace CIFRAS.Domain.Services
{
    public class TipoClienteService : ITipoClienteService
    {
        private readonly ITipoClienteRepository _tipoClienteRepository;

        public TipoClienteService(ITipoClienteRepository tipoClienteRepository)
        { 
            _tipoClienteRepository = tipoClienteRepository;
        }

        public void Adicionar(TipoCliente model)
        {
            _tipoClienteRepository.Adicionar(model);
        }

        public void Atualizar(TipoCliente model)
        {
            _tipoClienteRepository.Atualizar(model);
        }

        public void Remover(TipoCliente model)
        {
            model = _tipoClienteRepository.BuscarPorId(model.TipoClienteId);
            model.Excluir();
            _tipoClienteRepository.Atualizar(model);
        }

        public int ContarRegistros(bool ativo = true)
        {
            return _tipoClienteRepository.ContarRegistros(ativo);
        }

        public int ContarRegistrosPorExpressao(Expression<Func<TipoCliente, bool>> expression)
        {
            return _tipoClienteRepository.ContarRegistrosPorExpressao(expression);
        }

        public TipoCliente BuscarPorId(int id, bool ativo = true)
        {
            return _tipoClienteRepository.BuscarPorId(id, ativo);
        }  

        public ICollection<TipoCliente> ObterTodosPaginado(Expression<Func<TipoCliente, bool>> expression, int start, int take, string orderBy)
        {
            return _tipoClienteRepository.ObterTodosPaginado(expression, start, take, orderBy);
        }

        public ICollection<TipoCliente> BuscarPorExpressao(Expression<Func<TipoCliente, bool>> expression)
        {
            return _tipoClienteRepository.BuscarPorExpressao(expression);
        }

        public ICollection<TipoCliente> BuscarTodos(bool ativo = true)
        {
            return _tipoClienteRepository.BuscarTodos(ativo);
        }

        public TipoCliente BuscarPorDescricao(string descricao, bool ativo = true)
        {
            return _tipoClienteRepository.BuscarPorDescricao(descricao, ativo);
        }

        public void Dispose()
        {
            _tipoClienteRepository.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}