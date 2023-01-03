using CIFRAS.Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CIFRAS.Application.Interfaces
{
    public interface ICategoriaArquivoAppService : IDisposable
    {
        void Adicionar(CategoriaArquivoVm model);
        void Atualizar(CategoriaArquivoVm model);
        void Remover(CategoriaArquivoVm model);
        int ContarRegistros();
        int ContarRegistrosPorExpressao(Expression<Func<CategoriaArquivoVm, bool>> expression);
        CategoriaArquivoVm BuscarPorId(int id);
        ICollection<CategoriaArquivoVm> BuscarPorExpressao(Expression<Func<CategoriaArquivoVm, bool>> expression);
        ICollection<CategoriaArquivoVm> ObterTodosPaginado(Expression<Func<CategoriaArquivoVm, bool>> expression, int start, int take, string orderBy);
        ICollection<CategoriaArquivoVm> BuscarTodos();
    }
}