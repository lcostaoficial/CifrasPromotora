using CIFRAS.Application.Interfaces;
using CIFRAS.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using CIFRAS.Application.ViewModel;
using CIFRAS.Application.Mapper;
using CIFRAS.Domain.Entities;

namespace CIFRAS.Application.AppServices
{
    public class ContaAppService : IContaAppService
    {
        private readonly IContaService _contaService;

        public ContaAppService(IContaService contaService)
        {
            _contaService = contaService;
        }

        public void Adicionar(ContaVm model)
        {
            _contaService.Adicionar(MapperConfig.Mapper.Map<Conta>(model));
        }

        public void Atualizar(ContaVm model)
        {
            _contaService.Atualizar(MapperConfig.Mapper.Map<Conta>(model));
        }

        public void Remover(ContaVm model)
        {
            _contaService.Remover(MapperConfig.Mapper.Map<Conta>(model));
        }

        public ContaVm BuscarPorId(int id)
        {
            return MapperConfig.Mapper.Map<ContaVm>(_contaService.BuscarPorId(id));
        }

        public ICollection<ContaVm> BuscarTodos()
        {
            return MapperConfig.Mapper.Map<ICollection<ContaVm>>(_contaService.BuscarTodos());
        }

        public void Dispose()
        {
            _contaService.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}