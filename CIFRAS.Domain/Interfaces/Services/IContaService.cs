using CIFRAS.Domain.Entities;
using System;
using System.Collections.Generic;

namespace CIFRAS.Domain.Interfaces.Services
{
    public interface IContaService : IDisposable
    {
        void Adicionar(Conta model);
        void Atualizar(Conta model);
        void Remover(Conta model);
        Conta BuscarPorId(int id);
        ICollection<Conta> BuscarTodos();
        bool VerificarExistenciaConta(int clienteId, string numeroAgencia, string numeroConta);
    }
}