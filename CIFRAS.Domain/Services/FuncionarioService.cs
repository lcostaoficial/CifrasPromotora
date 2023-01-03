using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using CIFRAS.Domain.Entities;
using CIFRAS.Domain.Interfaces.Repositories;
using CIFRAS.Domain.Interfaces.Services;
using CIFRAS.Domain.Interfaces.Security;

namespace CIFRAS.Domain.Services
{
    public class FuncionarioService : IFuncionarioService
    {
        private readonly IFuncionarioRepository _funcionarioRepository;
        private readonly ISecurity _security;

        public FuncionarioService(IFuncionarioRepository funcionarioRepository, ISecurity security)
        {
            _funcionarioRepository = funcionarioRepository;
            _security = security;
        }

        public void Adicionar(Funcionario model)
        {
            _funcionarioRepository.Adicionar(model);
        }

        public void Atualizar(Funcionario model)
        {
            _funcionarioRepository.Atualizar(model);
        }

        public void Remover(Funcionario model)
        {
            model = BuscarPorId(model.FuncionarioId);
            model.Excluir();
            _funcionarioRepository.Atualizar(model);
        }

        public int ContarRegistros(bool ativo = true)
        {
            return _funcionarioRepository.ContarRegistros(ativo);
        }

        public int ContarRegistrosPorExpressao(Expression<Func<Funcionario, bool>> expression)
        {
            return _funcionarioRepository.ContarRegistrosPorExpressao(expression);
        }

        public bool ValidarLogin(string login, string senha)
        {
            var model = _funcionarioRepository.ValidarLogin(login, senha);
            if (model != null)
                _security.LogIn(model.FuncionarioId, true);
            return (model != null) ? true : false;
        }

        public Funcionario UsuarioLogado()
        {
            return _funcionarioRepository.BuscarPorId(_security.UserId());
        }

        public void DesconectarUsuario()
        {
            _security.Logout();
        }

        public Funcionario BuscarPorId(int id, bool ativo = true)
        {
            return _funcionarioRepository.BuscarPorId(id, ativo);
        }

        public ICollection<Funcionario> ObterTodosPaginado(Expression<Func<Funcionario, bool>> expression, int start, int take, string orderBy)
        {
            return _funcionarioRepository.ObterTodosPaginado(expression, start, take, orderBy);
        }

        public ICollection<Funcionario> BuscarPorExpressao(Expression<Func<Funcionario, bool>> expression)
        {
            return _funcionarioRepository.BuscarPorExpressao(expression);
        }

        public ICollection<Funcionario> BuscarTodos(bool ativo = true)
        {
            return _funcionarioRepository.BuscarTodos(ativo);
        }

        public void Dispose()
        {
            _funcionarioRepository.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}