using CIFRAS.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using CIFRAS.Domain.Entities;
using CIFRAS.Domain.Interfaces.Repositories;

namespace CIFRAS.Domain.Services
{
    public class ReciboEmprestimoService : IReciboEmprestimoService
    {
        private readonly IReciboEmprestimoRepository _reciboEmprestimoRepository;

        public ReciboEmprestimoService(IReciboEmprestimoRepository reciboEmprestimoRepository)
        {
            _reciboEmprestimoRepository = reciboEmprestimoRepository;
        }

        public void Adicionar(ReciboEmprestimo model)
        {
            _reciboEmprestimoRepository.Adicionar(model);
        }

        public void Atualizar(ReciboEmprestimo model)
        {
            _reciboEmprestimoRepository.Atualizar(model);
        }

        public void Remover(ReciboEmprestimo model)
        {
            model = BuscarPorId(model.ReciboEmprestimoId);
            _reciboEmprestimoRepository.Remover(model);
        }

        public ReciboEmprestimo BuscarPorId(int id)
        {
            return _reciboEmprestimoRepository.BuscarPorId(id);
        }

        public ICollection<ReciboEmprestimo> BuscarTodos()
        {
            return _reciboEmprestimoRepository.BuscarTodos();
        }

        public void Dispose()
        {
            _reciboEmprestimoRepository.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}