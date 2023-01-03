using CIFRAS.Application.Interfaces;
using CIFRAS.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using CIFRAS.Application.ViewModel;
using CIFRAS.Application.Mapper;
using CIFRAS.Domain.Entities;

namespace CIFRAS.Application.AppServices
{
    public class EnderecoAppService : IEnderecoAppService
    {
        private readonly IEnderecoService _enderecoService;

        public EnderecoAppService(IEnderecoService enderecoService)
        {
            _enderecoService = enderecoService;
        }

        public void Adicionar(EnderecoVm model)
        {
            _enderecoService.Adicionar(MapperConfig.Mapper.Map<Endereco>(model));
        }

        public void Atualizar(EnderecoVm model)
        {
            _enderecoService.Atualizar(MapperConfig.Mapper.Map<Endereco>(model));
        }

        public void Remover(EnderecoVm model)
        {
            _enderecoService.Remover(MapperConfig.Mapper.Map<Endereco>(model));
        }

        public EnderecoVm BuscarPorId(int id)
        {
            return MapperConfig.Mapper.Map<EnderecoVm>(_enderecoService.BuscarPorId(id));
        }

        public ICollection<EnderecoVm> BuscarTodos()
        {
            return MapperConfig.Mapper.Map<ICollection<EnderecoVm>>(_enderecoService.BuscarTodos());
        }

        public void Dispose()
        {
            _enderecoService.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}