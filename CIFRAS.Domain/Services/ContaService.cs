using CIFRAS.Domain.Interfaces.Repositories;
using CIFRAS.Domain.Interfaces.Services;
using System;
using CIFRAS.Domain.Entities;
using System.Collections.Generic;

namespace CIFRAS.Domain.Services
{
    public class ContaService : IContaService
    {
        private readonly IContaRepository _contaRepository;

        public ContaService(IContaRepository bancoClienteRepository)           
        {
            _contaRepository = bancoClienteRepository;
        }

        public void Adicionar(Conta model)
        {
            _contaRepository.Adicionar(model);
        }

        public void Atualizar(Conta model)
        {
            _contaRepository.Atualizar(model);
        }

        public void Remover(Conta model)
        {
            model = BuscarPorId(model.ContaId);
            _contaRepository.Remover(model);
        }

        public Conta BuscarPorId(int id)
        {
            return _contaRepository.BuscarPorId(id);
        }

        public ICollection<Conta> BuscarTodos()
        {
            return _contaRepository.BuscarTodos();
        }

        public bool VerificarExistenciaConta(int clienteId, string numeroAgencia, string numeroConta)
        {
            return _contaRepository.VerificarExistenciaConta(clienteId, numeroAgencia, numeroConta);
        }

        public void Dispose()
        {
            _contaRepository.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}