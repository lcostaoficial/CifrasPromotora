using CIFRAS.Domain.Entities;
using System;
using System.Collections.Generic;

namespace CIFRAS.Domain.Interfaces.Services
{
    public interface IContatoService : IDisposable
    {
        void Adicionar(Contato model);
        void Atualizar(Contato model);
        void Remover(Contato model);
        Contato BuscarPorId(int id);
        ICollection<Contato> BuscarTodos();
        bool VerificarExistenciaContato(string descricao);
    }
}