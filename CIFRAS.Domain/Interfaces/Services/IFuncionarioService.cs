using CIFRAS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CIFRAS.Domain.Interfaces.Services
{
    public interface IFuncionarioService : IDisposable
    {
        void Adicionar(Funcionario model);
        void Atualizar(Funcionario model);
        void Remover(Funcionario model);
        int ContarRegistros(bool ativo = true);
        int ContarRegistrosPorExpressao(Expression<Func<Funcionario, bool>> expression);
        bool ValidarLogin(string login, string senha);
        Funcionario UsuarioLogado();
        void DesconectarUsuario();
        Funcionario BuscarPorId(int id, bool ativo = true);
        ICollection<Funcionario> BuscarPorExpressao(Expression<Func<Funcionario, bool>> expression);
        ICollection<Funcionario> ObterTodosPaginado(Expression<Func<Funcionario, bool>> expression, int start, int take, string orderBy);
        ICollection<Funcionario> BuscarTodos(bool ativo = true);
    }
}