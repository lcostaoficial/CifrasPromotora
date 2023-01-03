using CIFRAS.Domain.Interfaces.Repositories;
using CIFRAS.Domain.Interfaces.Services;
using System;
using CIFRAS.Domain.Entities;
using System.Collections.Generic;

namespace CIFRAS.Domain.Services
{
    public class EnderecoService : IEnderecoService
    {
        private readonly IEnderecoRepository _enderecoRepository;

        public EnderecoService(IEnderecoRepository enderecoRepository)
        {
            _enderecoRepository = enderecoRepository;
        }

        public void Adicionar(Endereco model)
        {
            _enderecoRepository.Adicionar(model);
        }

        public void Atualizar(Endereco model)
        {
            _enderecoRepository.Atualizar(model);
        }

        public void Remover(Endereco model)
        {
            model = BuscarPorId(model.EnderecoId);
            _enderecoRepository.Remover(model);
        }

        public Endereco BuscarPorId(int id)
        {
            return _enderecoRepository.BuscarPorId(id);
        }

        public ICollection<Endereco> BuscarTodos()
        {
            return _enderecoRepository.BuscarTodos();
        }

        public void Dispose()
        {
            _enderecoRepository.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}