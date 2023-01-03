using CIFRAS.Application.Interfaces;
using CIFRAS.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using CIFRAS.Application.ViewModel;
using System.Linq.Expressions;
using CIFRAS.Application.Mapper;
using CIFRAS.Domain.Entities;

namespace CIFRAS.Application.AppServices
{
    public class FuncionarioAppService : IFuncionarioAppService 
    {
        private readonly IFuncionarioService _funcionarioService;

        public FuncionarioAppService(IFuncionarioService funcionarioService)
        {
            _funcionarioService = funcionarioService;
        }

        public void Adicionar(FuncionarioVm model)
        {
            _funcionarioService.Adicionar(MapperConfig.Mapper.Map<Funcionario>(model));
        }

        public void Atualizar(FuncionarioVm model)
        {
            _funcionarioService.Atualizar(MapperConfig.Mapper.Map<Funcionario>(model));
        }

        public void Remover(FuncionarioVm model)
        {
            _funcionarioService.Remover(MapperConfig.Mapper.Map<Funcionario>(model));
        }

        public int ContarRegistros()
        {
            return _funcionarioService.ContarRegistros();
        }

        public int ContarRegistrosPorExpressao(Expression<Func<FuncionarioVm, bool>> expression)
        {
            return _funcionarioService.ContarRegistrosPorExpressao(MapperConfig.Mapper.Map<Expression<Func<Funcionario, bool>>>(expression));
        }

        public bool ValidarLogin(string login, string senha)
        {
            return _funcionarioService.ValidarLogin(login, senha);
        }

        public FuncionarioVm UsuarioLogado()
        {
            return MapperConfig.Mapper.Map<FuncionarioVm>(_funcionarioService.UsuarioLogado());
        }

        public void DesconectarUsuario()
        {
            _funcionarioService.DesconectarUsuario();
        }

        public FuncionarioVm BuscarPorId(int id)
        {
            return MapperConfig.Mapper.Map<FuncionarioVm>(_funcionarioService.BuscarPorId(id));
        }

        public ICollection<FuncionarioVm> BuscarPorExpressao(Expression<Func<FuncionarioVm, bool>> expression)
        {
            return MapperConfig.Mapper.Map<ICollection<FuncionarioVm>>(_funcionarioService.BuscarPorExpressao(MapperConfig.Mapper.Map<Expression<Func<Funcionario, bool>>>(expression)));
        }

        public ICollection<FuncionarioVm> ObterTodosPaginado(Expression<Func<FuncionarioVm, bool>> expression, int start, int take, string orderBy)
        {
            return MapperConfig.Mapper.Map<ICollection<FuncionarioVm>>(_funcionarioService.ObterTodosPaginado(MapperConfig.Mapper.Map<Expression<Func<Funcionario, bool>>>(expression), start, take, orderBy));
        }

        public ICollection<FuncionarioVm> BuscarTodos()
        {
            return MapperConfig.Mapper.Map<ICollection<FuncionarioVm>>(_funcionarioService.BuscarTodos());
        }

        public void Dispose()
        {
            _funcionarioService.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}