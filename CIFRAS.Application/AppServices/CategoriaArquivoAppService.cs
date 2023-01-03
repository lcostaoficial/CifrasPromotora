using CIFRAS.Application.Interfaces;
using CIFRAS.Application.Mapper;
using CIFRAS.Application.ViewModel;
using CIFRAS.Domain.Entities;
using CIFRAS.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CIFRAS.Application.AppServices
{
    public class CategoriaArquivoAppService : ICategoriaArquivoAppService
    {
        private readonly ICategoriaArquivoService _categoriaArquivoService;

        public CategoriaArquivoAppService(ICategoriaArquivoService categoriaArquivoService)            
        {
            _categoriaArquivoService = categoriaArquivoService;
        }

        public void Adicionar(CategoriaArquivoVm model)
        {          
            _categoriaArquivoService.Adicionar(MapperConfig.Mapper.Map<CategoriaArquivo>(model));
        }

        public void Atualizar(CategoriaArquivoVm model)
        {
            _categoriaArquivoService.Atualizar(MapperConfig.Mapper.Map<CategoriaArquivo>(model));
        }

        public void Remover(CategoriaArquivoVm model)
        {
            _categoriaArquivoService.Remover(MapperConfig.Mapper.Map<CategoriaArquivo>(model));
        }

        public int ContarRegistros()
        {
            return _categoriaArquivoService.ContarRegistros();
        }

        public int ContarRegistrosPorExpressao(Expression<Func<CategoriaArquivoVm, bool>> expression)
        {
            return _categoriaArquivoService.ContarRegistrosPorExpressao(MapperConfig.Mapper.Map<Expression<Func<CategoriaArquivo, bool>>>(expression));
        }

        public CategoriaArquivoVm BuscarPorId(int id)
        {
            return MapperConfig.Mapper.Map<CategoriaArquivoVm>(_categoriaArquivoService.BuscarPorId(id));
        }

        public ICollection<CategoriaArquivoVm> BuscarPorExpressao(Expression<Func<CategoriaArquivoVm, bool>> expression)
        {
            return MapperConfig.Mapper.Map<ICollection<CategoriaArquivoVm>>(_categoriaArquivoService.BuscarPorExpressao(MapperConfig.Mapper.Map<Expression<Func<CategoriaArquivo, bool>>>(expression)));
        }

        public ICollection<CategoriaArquivoVm> ObterTodosPaginado(Expression<Func<CategoriaArquivoVm, bool>> expression, int start, int take, string orderBy)
        {
            return MapperConfig.Mapper.Map<ICollection<CategoriaArquivoVm>>(_categoriaArquivoService.ObterTodosPaginado(MapperConfig.Mapper.Map<Expression<Func<CategoriaArquivo, bool>>>(expression), start, take, orderBy));
        }


            public ICollection<CategoriaArquivoVm> BuscarTodos()
        {
            return MapperConfig.Mapper.Map<ICollection<CategoriaArquivoVm>>(_categoriaArquivoService.BuscarTodos());
        }

        public void Dispose()
        {
            _categoriaArquivoService.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}