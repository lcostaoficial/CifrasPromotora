using CIFRAS.Domain.Interfaces.Repositories;
using CIFRAS.Domain.Interfaces.Services;
using System;
using CIFRAS.Domain.Entities;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CIFRAS.Domain.Services
{
    public class BancoService : IBancoService
    {
        private readonly IBancoRepository _bancoRepository;

        public BancoService(IBancoRepository bancoRepository)           
        {
            _bancoRepository = bancoRepository;
        }

        public void Adicionar(Banco model)
        {
            _bancoRepository.Adicionar(model);
        }

        public Banco AdicionarComRetorno(Banco model)
        {
            return _bancoRepository.Adicionar(model);
        }

        public void Atualizar(Banco model)
        {
            _bancoRepository.Atualizar(model);
        }

        public void Remover(Banco model)
        {
            model = BuscarPorId(model.BancoId);
            model.Excluir();
            _bancoRepository.Atualizar(model);
        }

        public int ContarRegistros(bool ativo = true)
        {
            return _bancoRepository.ContarRegistros(ativo);
        }

        public int ContarRegistrosPorExpressao(Expression<Func<Banco, bool>> expression)
        {
            return _bancoRepository.ContarRegistrosPorExpressao(expression);
        }

        public Banco BuscarPorId(int id, bool ativo = true)
        {
            return _bancoRepository.BuscarPorId(id, ativo);
        }

        public ICollection<Banco> ObterTodosPaginado(Expression<Func<Banco, bool>> expression, int start, int take, string orderBy)
        {
            return _bancoRepository.ObterTodosPaginado(expression, start, take, orderBy);
        }

        public ICollection<Banco> BuscarPorExpressao(Expression<Func<Banco, bool>> expression)
        {
            return _bancoRepository.BuscarPorExpressao(expression);
        }

        public ICollection<Banco> BuscarTodos(bool ativo = true)
        {
            return _bancoRepository.BuscarTodos(ativo);
        }

        public Banco BuscarPorCodigo(int codigoBanco, bool ativo = true)
        {
            return _bancoRepository.BuscarPorCodigo(codigoBanco, ativo);
        }

        public Banco BuscarPorDescricao(string descricao, bool ativo = true)
        {
            return _bancoRepository.BuscarPorDescricao(descricao, ativo);
        }

        public void Dispose()
        {
            _bancoRepository.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}