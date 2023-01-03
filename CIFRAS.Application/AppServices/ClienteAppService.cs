using CIFRAS.Application.Interfaces;
using CIFRAS.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using CIFRAS.Application.ViewModel;
using CIFRAS.Application.Mapper;
using CIFRAS.Domain.Entities;
using System.Linq.Expressions;
using CIFRAS.Application.Helpers.General;

namespace CIFRAS.Application.AppServices
{
    public class ClienteAppService : IClienteAppService
    {
        private readonly IClienteService _clienteService;

        public ClienteAppService(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        public void Adicionar(ClienteVm model)
        {
            _clienteService.Adicionar(MapperConfig.Mapper.Map<Cliente>(model));
        }

        public void Atualizar(ClienteVm model)
        {
            _clienteService.Atualizar(MapperConfig.Mapper.Map<Cliente>(model));
        }

        public void Remover(ClienteVm model)
        {
            _clienteService.Remover(MapperConfig.Mapper.Map<Cliente>(model));
        }

        public int ContarRegistros()
        {
            return _clienteService.ContarRegistros();
        }

        public int ContarRegistrosPorExpressao(Expression<Func<ClienteVm, bool>> expression)
        {
            return _clienteService.ContarRegistrosPorExpressao(MapperConfig.Mapper.Map<Expression<Func<Cliente, bool>>>(expression));
        }

        public ClienteVm BuscarPorId(int id)
        {
            return MapperConfig.Mapper.Map<ClienteVm>(_clienteService.BuscarPorId(id));
        }

        public ClienteVm BuscarPorIdBasico(int id)
        {
            return MapperConfig.Mapper.Map<ClienteVm>(_clienteService.ObterPorIdBasico(id));
        }

        public ClienteVm BuscarPorIdCustomizado(int id)
        {
            var modelVm = MapperConfig.Mapper.Map<ClienteVm>(_clienteService.BuscarPorIdCustomizado(id));
            modelVm.ListaConta.ForEach(x => x.SetView(x.Banco?.Descricao));
            modelVm.ListaContrato.ForEach(x => x.SetView(x.Banco?.Descricao, x.TipoContrato.Descricao));
            return modelVm;
        }

        public ICollection<ClienteVm> BuscarPorExpressao(Expression<Func<ClienteVm, bool>> expression)
        {
            return MapperConfig.Mapper.Map<ICollection<ClienteVm>>(_clienteService.BuscarPorExpressao(MapperConfig.Mapper.Map<Expression<Func<Cliente, bool>>>(expression)));
        }

        public ICollection<ClienteVm> ObterTodosPaginado(Expression<Func<ClienteVm, bool>> expression, int start, int take)
        {
            return MapperConfig.Mapper.Map<ICollection<ClienteVm>>(_clienteService.ObterTodosPaginado(MapperConfig.Mapper.Map<Expression<Func<Cliente, bool>>>(expression), start, take));
        }

        public ICollection<ClienteVm> ObterTodosPaginado(Expression<Func<ClienteVm, bool>> expression, int start, int take, string orderBy)
        {
            return MapperConfig.Mapper.Map<ICollection<ClienteVm>>(_clienteService.ObterTodosPaginado(MapperConfig.Mapper.Map<Expression<Func<Cliente, bool>>>(expression), start, take, orderBy));
        }

        public ICollection<ClienteVm> BuscarTodos()
        {
            return MapperConfig.Mapper.Map<ICollection<ClienteVm>>(_clienteService.BuscarTodos());
        }

        public bool PermitirInserir(string cpf, string matricula)
        {
            if (_clienteService.BuscarPorCpf(cpf) != null)
            {
                if (string.IsNullOrEmpty(matricula)) throw new Exception("O CPF informado já está cadastrado!");
                if (!_clienteService.PermitirInserir(cpf, matricula)) throw new Exception("A Matrícula informada para este CPF já está cadastrada!");
            }
            return true;
        }

        public void Dispose()
        {
            _clienteService.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}