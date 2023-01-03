using CIFRAS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CIFRAS.Domain.Interfaces.Services
{
    public interface IReciboService : IDisposable
    {
        void Adicionar(Recibo model);
        void Atualizar(Recibo model);
        void Remover(Recibo model);
        int ContarRegistros(bool ativo = true);
        int ContarRegistrosPorExpressao(Expression<Func<Recibo, bool>> expression);
        Recibo BuscarPorId(int id, bool ativo = true);
        Recibo BuscarPorIdCustomizado(int id, bool ativo = true);
        ICollection<Recibo> BuscarPorExpressao(Expression<Func<Recibo, bool>> expression);
        ICollection<Recibo> ObterTodosPaginado(Expression<Func<Recibo, bool>> expression, int start, int take, string orderBy);
        ICollection<Recibo> BuscarTodos(bool ativo = true);
    }
}