using CIFRAS.Domain.Interfaces.Repositories;
using CIFRAS.Domain.Interfaces.Services;
using System;
using CIFRAS.Domain.Entities;
using System.Collections.Generic;

namespace CIFRAS.Domain.Services
{
    public class ContratoService : IContratoService
    {
        private readonly IContratoRepository _contratoRepository;

        public ContratoService(IContratoRepository contratoRepository)
        {
            _contratoRepository = contratoRepository;
        }

        public void Adicionar(Contrato model)
        {
            _contratoRepository.Adicionar(model);
        }

        public void Atualizar(Contrato model)
        {
            _contratoRepository.Atualizar(model);
        }

        public void Remover(Contrato model)
        {
            model = BuscarPorId(model.ContratoId);
            _contratoRepository.Remover(model);
        }

        public Contrato BuscarPorId(int id)
        {
            return _contratoRepository.BuscarPorId(id);
        }

        public Contrato BuscarPorNumero(string numeroContrato)
        {
            return _contratoRepository.BuscarPorNumero(numeroContrato);
        }

        public ICollection<Contrato> BuscarTodos()
        {
            return _contratoRepository.BuscarTodos();
        }

        public bool VerificarExistenciaContrato(string numeroContrato)
        {
            return _contratoRepository.VerificarExistenciaContrato(numeroContrato);
        }

        public void Dispose()
        {
            _contratoRepository.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}