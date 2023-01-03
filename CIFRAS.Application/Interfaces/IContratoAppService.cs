using CIFRAS.Application.ViewModel;
using System;
using System.Collections.Generic;

namespace CIFRAS.Application.Interfaces
{
    public interface IContratoAppService : IDisposable
    {
        void Adicionar(ContratoVm model);
        void Atualizar(ContratoVm model);
        void Remover(ContratoVm model);
        ContratoVm BuscarPorId(int id);
        ICollection<ContratoVm> BuscarTodos();
    }
}