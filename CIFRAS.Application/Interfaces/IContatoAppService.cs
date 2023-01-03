using CIFRAS.Application.ViewModel;
using System;
using System.Collections.Generic;

namespace CIFRAS.Application.Interfaces
{
    public interface IContatoAppService : IDisposable
    {
        void Adicionar(ContatoVm model);
        void Atualizar(ContatoVm model);
        void Remover(ContatoVm model);
        ContatoVm BuscarPorId(int id);
        ICollection<ContatoVm> BuscarTodos();
    }
}