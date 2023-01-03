using CIFRAS.Application.ViewModel;
using System;
using System.Collections.Generic;

namespace CIFRAS.Application.Interfaces
{
    public interface IContaAppService : IDisposable
    {
        void Adicionar(ContaVm model);
        void Atualizar(ContaVm model);
        void Remover(ContaVm model);
        ContaVm BuscarPorId(int id);
        ICollection<ContaVm> BuscarTodos();
    }
}