using CIFRAS.Domain.Entities;
using System;
using System.Collections.Generic;

namespace CIFRAS.Domain.Interfaces.Services
{
    public interface IEnderecoService : IDisposable
    {
        void Adicionar(Endereco model);
        void Atualizar(Endereco model);
        void Remover(Endereco model);
        Endereco BuscarPorId(int id);
        ICollection<Endereco> BuscarTodos();
    }
}