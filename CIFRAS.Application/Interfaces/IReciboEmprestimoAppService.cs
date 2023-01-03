using CIFRAS.Application.ViewModel;
using System;
using System.Collections.Generic;

namespace CIFRAS.Application.Interfaces
{
    public interface IReciboEmprestimoAppService : IDisposable
    {
        void Adicionar(ReciboEmprestimoVm model);
        void Atualizar(ReciboEmprestimoVm model);
        void Remover(ReciboEmprestimoVm model);
        ReciboEmprestimoVm BuscarPorId(int id);
        ICollection<ReciboEmprestimoVm> BuscarTodos();
    }
}