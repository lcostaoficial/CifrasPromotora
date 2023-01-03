using CIFRAS.Application.ViewModel;
using System;
using System.Collections.Generic;

namespace CIFRAS.Application.Interfaces
{
    public interface  IEnderecoAppService : IDisposable
    {
        void Adicionar(EnderecoVm model);
        void Atualizar(EnderecoVm model);
        void Remover(EnderecoVm model);
        EnderecoVm BuscarPorId(int id);
        ICollection<EnderecoVm> BuscarTodos();
    }
}