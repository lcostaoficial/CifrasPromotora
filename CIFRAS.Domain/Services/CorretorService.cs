using CIFRAS.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using CIFRAS.Domain.Entities;
using System.Linq.Expressions;
using CIFRAS.Domain.Interfaces.Repositories;

namespace CIFRAS.Domain.Services
{
    public class CorretorService : ICorretorService
    {
        private readonly ICorretorRepository _corretorRepository;

        public CorretorService(ICorretorRepository corretorRepository)
        {
            _corretorRepository = corretorRepository;
        }

        public void Adicionar(Corretor model)
        {
            _corretorRepository.Adicionar(model);
        }

        public void Atualizar(Corretor model)
        {
            _corretorRepository.Atualizar(model);
        }

        public void Remover(Corretor model)
        {
            model = BuscarPorId(model.CorretorId);
            model.Excluir();
            _corretorRepository.Atualizar(model);
        }

        public int ContarRegistros(bool ativo = true)
        {
            return _corretorRepository.ContarRegistros(ativo);
        }

        public int ContarRegistrosPorExpressao(Expression<Func<Corretor, bool>> expression)
        {
            return _corretorRepository.ContarRegistrosPorExpressao(expression);
        }

        public Corretor BuscarPorId(int id, bool ativo = true)
        {
            return _corretorRepository.BuscarPorId(id, ativo);
        }

        public ICollection<Corretor> ObterTodosPaginado(Expression<Func<Corretor, bool>> expression, int start, int take, string orderBy)
        {
            return _corretorRepository.ObterTodosPaginado(expression, start, take, orderBy);
        }

        public ICollection<Corretor> BuscarPorExpressao(Expression<Func<Corretor, bool>> expression)
        {
            return _corretorRepository.BuscarPorExpressao(expression);
        }      

        public ICollection<Corretor> BuscarTodos(bool ativo = true)
        {
            return _corretorRepository.BuscarTodos(ativo);
        }          

        public void Dispose()
        {
            _corretorRepository.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}