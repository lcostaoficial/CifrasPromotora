using CIFRAS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CIFRAS.Domain.Interfaces.Services
{
    public interface IClienteService : IDisposable
    {
        void Adicionar(Cliente model);
        void Atualizar(Cliente model);
        void Remover(Cliente model);
        int ContarRegistros(bool ativo = true);
        int ContarRegistrosPorExpressao(Expression<Func<Cliente, bool>> expression);
        Cliente BuscarPorId(int id, bool ativo = true);
        Cliente ObterPorIdBasico(int id);
        Cliente BuscarPorIdCustomizado(int id, bool ativo = true);
        ICollection<Cliente> BuscarPorExpressao(Expression<Func<Cliente, bool>> expression);
        ICollection<Cliente> ObterTodosPaginado(Expression<Func<Cliente, bool>> expression, int start, int take);
        ICollection<Cliente> ObterTodosPaginado(Expression<Func<Cliente, bool>> expression, int start, int take, string orderBy);
        ICollection<Cliente> BuscarTodos(bool ativo = true);
        Cliente BuscarPorCpf(string cpf, bool ativo = true);
        Cliente BuscarPorMatricula(string matricula, bool ativo = true);
        Cliente BuscarPorCpfEMatricula(string cpf, string matricula, bool ativo = true);
        bool PermitirInserir(string cpf, string matricula, bool ativo = true);
    }
}