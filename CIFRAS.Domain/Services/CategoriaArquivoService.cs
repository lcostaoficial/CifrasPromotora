using CIFRAS.Domain.Entities;
using CIFRAS.Domain.Interfaces.Repositories;
using CIFRAS.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CIFRAS.Domain.Services
{
    public class CategoriaArquivoService : ICategoriaArquivoService
    {
        private readonly ICategoriaArquivoRepository _categoriaArquivoRepository;

        public CategoriaArquivoService(ICategoriaArquivoRepository categoriaArquivoRepository)
        {
            _categoriaArquivoRepository = categoriaArquivoRepository;
        }

        public void Adicionar(CategoriaArquivo model)
        {
            _categoriaArquivoRepository.Adicionar(model);
        }

        public void Atualizar(CategoriaArquivo model)
        {
            _categoriaArquivoRepository.Atualizar(model);
        }

        public void Remover(CategoriaArquivo model)
        {
            model = BuscarPorId(model.CategoriaArquivoId);
            model.Excluir();
            _categoriaArquivoRepository.Atualizar(model);
        }

        public int ContarRegistros(bool ativo = true)
        {
            return _categoriaArquivoRepository.ContarRegistros(ativo);
        }

        public int ContarRegistrosPorExpressao(Expression<Func<CategoriaArquivo, bool>> expression)
        {
            return _categoriaArquivoRepository.ContarRegistrosPorExpressao(expression);
        }

        public CategoriaArquivo BuscarPorId(int id, bool ativo = true)
        {
            return _categoriaArquivoRepository.BuscarPorId(id, ativo);
        }

        public ICollection<CategoriaArquivo> ObterTodosPaginado(Expression<Func<CategoriaArquivo, bool>> expression, int start, int take, string orderBy)
        {
            return _categoriaArquivoRepository.ObterTodosPaginado(expression, start, take, orderBy);
        }

        public ICollection<CategoriaArquivo> BuscarPorExpressao(Expression<Func<CategoriaArquivo, bool>> expression)
        {
            return _categoriaArquivoRepository.BuscarPorExpressao(expression);
        }

        public ICollection<CategoriaArquivo> BuscarTodos(bool ativo = true)
        {
            return _categoriaArquivoRepository.BuscarTodos(ativo);
        }

        public void Dispose()
        {
            _categoriaArquivoRepository.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}