using CIFRAS.Domain.Entities;
using System;
using System.Collections.Generic;

namespace CIFRAS.Domain.Interfaces.Services
{
    public interface IContratoService : IDisposable
    {
        void Adicionar(Contrato model);
        void Atualizar(Contrato model);
        void Remover(Contrato model);
        Contrato BuscarPorId(int id);
        Contrato BuscarPorNumero(string numeroContrato);
        ICollection<Contrato> BuscarTodos();
        bool VerificarExistenciaContrato(string numeroContrato);
    }
}