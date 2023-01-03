using CIFRAS.Domain.Interfaces.Repositories;
using CIFRAS.Domain.Interfaces.Services;
using System;
using CIFRAS.Domain.Entities;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CIFRAS.Domain.Services
{
    public class TipoContratoService : ITipoContratoService
    {
        private readonly ITipoContratoRepository _tipoContratoRepository;

        public TipoContratoService(ITipoContratoRepository tipoContratoRepository)
        {
            _tipoContratoRepository = tipoContratoRepository;
        }

        public void Adicionar(TipoContrato model)
        {
            _tipoContratoRepository.Adicionar(model);
        }

        public void Atualizar(TipoContrato model)
        {
            _tipoContratoRepository.Atualizar(model);
        }

        public void Remover(TipoContrato model)
        {
            model = BuscarPorId(model.TipoContratoId);
            model.Excluir();
            _tipoContratoRepository.Atualizar(model);
        }

        public int ContarRegistros(bool ativo = true)
        {
            return _tipoContratoRepository.ContarRegistros(ativo);
        }

        public int ContarRegistrosPorExpressao(Expression<Func<TipoContrato, bool>> expression)
        {
            return _tipoContratoRepository.ContarRegistrosPorExpressao(expression);
        }

        public ICollection<TipoContrato> BuscarPorExpressao(Expression<Func<TipoContrato, bool>> expression)
        {
            return _tipoContratoRepository.BuscarPorExpressao(expression);
        }

        public ICollection<TipoContrato> ObterTodosPaginado(Expression<Func<TipoContrato, bool>> expression, int start, int take, string orderBy)
        {
            return _tipoContratoRepository.ObterTodosPaginado(expression, start, take, orderBy);
        }

        public TipoContrato BuscarPorId(int id, bool ativo = true)
        {
            return _tipoContratoRepository.BuscarPorId(id, ativo);
        }

        public ICollection<TipoContrato> BuscarTodos(bool ativo = true)
        {
            return _tipoContratoRepository.BuscarTodos(ativo);
        }

        public TipoContrato BuscarPorDescricao(string descricao, bool ativo = true)
        {
            return _tipoContratoRepository.BuscarPorDescricao(descricao, ativo);
        }

        public void Dispose()
        {
            _tipoContratoRepository.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}