using System.Collections.Generic;
using CIFRAS.Application.Interfaces;
using CIFRAS.Application.ViewModel;
using CIFRAS.Domain.Interfaces.Services;
using CIFRAS.Application.Mapper;
using CIFRAS.Domain.Entities;
using System;

namespace CIFRAS.Application.AppServices
{
    public class ReciboEmprestimoAppService : IReciboEmprestimoAppService
    {
        private readonly IReciboEmprestimoService _reciboEmprestimoService;

        public ReciboEmprestimoAppService(IReciboEmprestimoService reciboEmprestimoService)
        {
            _reciboEmprestimoService = reciboEmprestimoService;
        }

        public void Adicionar(ReciboEmprestimoVm model)
        {
            _reciboEmprestimoService.Adicionar(MapperConfig.Mapper.Map<ReciboEmprestimo>(model));
        }

        public void Atualizar(ReciboEmprestimoVm model)
        {
            _reciboEmprestimoService.Atualizar(MapperConfig.Mapper.Map<ReciboEmprestimo>(model));
        }

        public void Remover(ReciboEmprestimoVm model)
        {
            _reciboEmprestimoService.Remover(MapperConfig.Mapper.Map<ReciboEmprestimo>(model));
        }

        public ReciboEmprestimoVm BuscarPorId(int id)
        {
            return MapperConfig.Mapper.Map<ReciboEmprestimoVm>(_reciboEmprestimoService.BuscarPorId(id));
        }

        public ICollection<ReciboEmprestimoVm> BuscarTodos()
        {
            return MapperConfig.Mapper.Map<ICollection<ReciboEmprestimoVm>>(_reciboEmprestimoService.BuscarTodos());
        }

        public void Dispose()
        {
            _reciboEmprestimoService.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}