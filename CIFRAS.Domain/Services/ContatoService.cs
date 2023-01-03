using CIFRAS.Domain.Interfaces.Repositories;
using CIFRAS.Domain.Interfaces.Services;
using System;
using CIFRAS.Domain.Entities;
using System.Collections.Generic;

namespace CIFRAS.Domain.Services
{
    public class ContatoService : IContatoService
    {
        private readonly IContatoRepository _contatoRepository;

        public ContatoService(IContatoRepository contatoRepository)
        {
            _contatoRepository = contatoRepository;
        }

        public void Adicionar(Contato model)
        {
            _contatoRepository.Adicionar(model);
        }

        public void Atualizar(Contato model)
        {
            _contatoRepository.Atualizar(model);
        }

        public void Remover(Contato model)
        {
            model = BuscarPorId(model.ContatoId);
            _contatoRepository.Remover(model);
        }

        public Contato BuscarPorId(int id)
        {
            return _contatoRepository.BuscarPorId(id);
        }

        public ICollection<Contato> BuscarTodos()
        {
            return _contatoRepository.BuscarTodos();
        }

        public bool VerificarExistenciaContato(string descricao)
        {
            return _contatoRepository.VerificarExistenciaContato(descricao);
        }

        public void Dispose()
        {
            _contatoRepository.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}