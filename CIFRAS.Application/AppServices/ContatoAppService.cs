using CIFRAS.Application.Interfaces;
using CIFRAS.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using CIFRAS.Application.ViewModel;
using CIFRAS.Application.Mapper;
using CIFRAS.Domain.Entities;

namespace CIFRAS.Application.AppServices
{
    public class ContatoAppService : IContatoAppService
    {
        private readonly IContatoService _contatoService;

        public ContatoAppService(IContatoService contatoService)
        {
            _contatoService = contatoService;
        }

        public void Adicionar(ContatoVm model)
        {
            _contatoService.Adicionar(MapperConfig.Mapper.Map<Contato>(model));
        }

        public void Atualizar(ContatoVm model)
        {
            _contatoService.Atualizar(MapperConfig.Mapper.Map<Contato>(model));
        }

        public void Remover(ContatoVm model)
        {
            _contatoService.Remover(MapperConfig.Mapper.Map<Contato>(model));
        }

        public ContatoVm BuscarPorId(int id)
        {
            return MapperConfig.Mapper.Map<ContatoVm>(_contatoService.BuscarPorId(id));
        }

        public ICollection<ContatoVm> BuscarTodos()
        {
            return MapperConfig.Mapper.Map<ICollection<ContatoVm>>(_contatoService.BuscarTodos());
        }

        public void Dispose()
        {
            _contatoService.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}