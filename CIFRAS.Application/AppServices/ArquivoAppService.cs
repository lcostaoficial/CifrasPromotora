using System.Collections.Generic;
using CIFRAS.Application.Interfaces;
using CIFRAS.Application.ViewModel;
using CIFRAS.Domain.Interfaces.Services;
using CIFRAS.Application.Mapper;
using CIFRAS.Domain.Entities;
using System;
using System.Linq.Expressions;

namespace CIFRAS.Application.AppServices
{
    public class ArquivoAppService : IArquivoAppService
    {
        private readonly IArquivoService _arquivoService;

        public ArquivoAppService(IArquivoService arquivoService)
        {
            _arquivoService = arquivoService;
        }

        public void UploadArquivo(ArquivoVm model)
        {
            _arquivoService.UploadArquivo(MapperConfig.Mapper.Map<Arquivo>(model), model.ArquivoEnvio);
        }

        public void Adicionar(ArquivoVm model)
        {
            _arquivoService.Adicionar(MapperConfig.Mapper.Map<Arquivo>(model));
        }

        public void Atualizar(ArquivoVm model)
        {
            _arquivoService.Atualizar(MapperConfig.Mapper.Map<Arquivo>(model));
        }

        public void Remover(ArquivoVm model)
        {
            _arquivoService.Remover(MapperConfig.Mapper.Map<Arquivo>(model));
        }

        public int ContarRegistros()
        {
            return _arquivoService.ContarRegistros();
        }

        public int ContarRegistrosPorExpressao(Expression<Func<ArquivoVm, bool>> expression)
        {
            return _arquivoService.ContarRegistrosPorExpressao(MapperConfig.Mapper.Map<Expression<Func<Arquivo, bool>>>(expression));
        }

        public ArquivoVm BuscarPorId(int id)
        {
            return MapperConfig.Mapper.Map<ArquivoVm>(_arquivoService.BuscarPorId(id));
        }

        public ICollection<ArquivoVm> BuscarPorExpressao(Expression<Func<ArquivoVm, bool>> expression)
        {
            return MapperConfig.Mapper.Map<ICollection<ArquivoVm>>(_arquivoService.BuscarPorExpressao(MapperConfig.Mapper.Map<Expression<Func<Arquivo, bool>>>(expression)));
        }

        public ICollection<ArquivoVm> ObterTodosPaginado(Expression<Func<ArquivoVm, bool>> expression, int start, int take, string orderBy)
        {
            return MapperConfig.Mapper.Map<ICollection<ArquivoVm>>(_arquivoService.ObterTodosPaginado(MapperConfig.Mapper.Map<Expression<Func<Arquivo, bool>>>(expression), start, take, orderBy));
        }

        public ICollection<ArquivoVm> BuscarTodos()
        {
            return MapperConfig.Mapper.Map<ICollection<ArquivoVm>>(_arquivoService.BuscarTodos());
        }

        public void Dispose()
        {
            _arquivoService.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}