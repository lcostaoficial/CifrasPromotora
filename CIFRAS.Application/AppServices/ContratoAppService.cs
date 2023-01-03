using CIFRAS.Application.Interfaces;
using CIFRAS.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using CIFRAS.Application.ViewModel;
using CIFRAS.Application.Mapper;
using CIFRAS.Domain.Entities;

namespace CIFRAS.Application.AppServices
{
    public class ContratoAppService : IContratoAppService
    {
        private readonly IContratoService _contratoService;

        public ContratoAppService(IContratoService contratoService)
        {
            _contratoService = contratoService;
        }

        public void Adicionar(ContratoVm model)
        {
            _contratoService.Adicionar(MapperConfig.Mapper.Map<Contrato>(model));
        }

        public void Atualizar(ContratoVm model)
        {
            _contratoService.Atualizar(MapperConfig.Mapper.Map<Contrato>(model));
        }

        public void Remover(ContratoVm model)
        {
            _contratoService.Remover(MapperConfig.Mapper.Map<Contrato>(model));
        }

        public ContratoVm BuscarPorId(int id)
        {
            return MapperConfig.Mapper.Map<ContratoVm>(_contratoService.BuscarPorId(id));
        }

        public ICollection<ContratoVm> BuscarTodos()
        {
            return MapperConfig.Mapper.Map<ICollection<ContratoVm>>(_contratoService.BuscarTodos());
        }

        public void Dispose()
        {
            _contratoService.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}