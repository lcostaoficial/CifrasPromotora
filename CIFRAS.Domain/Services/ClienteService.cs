using CIFRAS.Domain.Interfaces.Repositories;
using CIFRAS.Domain.Interfaces.Services;
using System;
using CIFRAS.Domain.Entities;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CIFRAS.Domain.Services
{
    public class ClienteService : IClienteService
    {
        private readonly IClienteRepository _clienteRepository;

        public ClienteService(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        public void Adicionar(Cliente model)
        {
            _clienteRepository.Adicionar(model);
        }

        public void Atualizar(Cliente model)
        {
            _clienteRepository.Atualizar(model);
        }

        public void Remover(Cliente model)
        {
            model = BuscarPorId(model.ClienteId);
            model.Excluir();
            _clienteRepository.Atualizar(model);
        }

        public int ContarRegistros(bool ativo = true)
        {
            return _clienteRepository.ContarRegistros(ativo);
        }

        public int ContarRegistrosPorExpressao(Expression<Func<Cliente, bool>> expression)
        {
            return _clienteRepository.ContarRegistrosPorExpressao(expression);
        }

        public Cliente BuscarPorId(int id, bool ativo = true)
        {
            return _clienteRepository.BuscarPorId(id, ativo);
        }

        public Cliente ObterPorIdBasico(int id)
        {
            return _clienteRepository.ObterPorIdBasico(id);
        }

        public Cliente BuscarPorIdCustomizado(int id, bool ativo = true)
        {
            return _clienteRepository.BuscarPorIdCustomizado(id, ativo);
        }

        public ICollection<Cliente> BuscarPorExpressao(Expression<Func<Cliente, bool>> expression)
        {
            return _clienteRepository.BuscarPorExpressao(expression);
        }

        public ICollection<Cliente> ObterTodosPaginado(Expression<Func<Cliente, bool>> expression, int start, int take)
        {
            return _clienteRepository.ObterTodosPaginado(expression, start, take);
        }

        public ICollection<Cliente> ObterTodosPaginado(Expression<Func<Cliente, bool>> expression, int start, int take, string orderBy)
        {
            return _clienteRepository.ObterTodosPaginado(expression, start, take, orderBy);
        }

        public ICollection<Cliente> BuscarTodos(bool ativo = true)
        {
            return _clienteRepository.BuscarTodos(ativo);
        }

        public Cliente BuscarPorCpf(string cpf, bool ativo = true)
        {
            return _clienteRepository.BuscarPorCpf(cpf, ativo);
        }

        public Cliente BuscarPorMatricula(string matricula, bool ativo = true)
        {
            return _clienteRepository.BuscarPorMatricula(matricula, ativo);
        }

        public Cliente BuscarPorCpfEMatricula(string cpf, string matricula, bool ativo = true)
        {
            return _clienteRepository.BuscarPorCpfEMatricula(cpf, matricula, ativo);
        }

        public bool PermitirInserir(string cpf, string matricula, bool ativo = true)
        {
            return _clienteRepository.PermitirInserir(cpf, matricula, ativo);
        }

        public void Dispose()
        {
            _clienteRepository.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}