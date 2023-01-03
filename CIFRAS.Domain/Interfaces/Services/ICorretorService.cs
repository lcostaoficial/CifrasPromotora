using CIFRAS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CIFRAS.Domain.Interfaces.Services
{
    public interface ICorretorService : IDisposable
    {
        void Adicionar(Corretor model);
        void Atualizar(Corretor model);
        void Remover(Corretor model);
        int ContarRegistros(bool ativo = true);
        int ContarRegistrosPorExpressao(Expression<Func<Corretor, bool>> expression);
        Corretor BuscarPorId(int id, bool ativo = true);
        ICollection<Corretor> BuscarPorExpressao(Expression<Func<Corretor, bool>> expression);
        ICollection<Corretor> ObterTodosPaginado(Expression<Func<Corretor, bool>> expression, int start, int take, string orderBy);
        ICollection<Corretor> BuscarTodos(bool ativo = true);
    }
}