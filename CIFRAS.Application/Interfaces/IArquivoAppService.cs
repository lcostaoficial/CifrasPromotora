using CIFRAS.Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CIFRAS.Application.Interfaces
{
    public interface IArquivoAppService : IDisposable
    {
        void UploadArquivo(ArquivoVm model);
        void Adicionar(ArquivoVm model);
        void Atualizar(ArquivoVm model);
        void Remover(ArquivoVm model);
        int ContarRegistros();
        int ContarRegistrosPorExpressao(Expression<Func<ArquivoVm, bool>> expression);
        ArquivoVm BuscarPorId(int id);
        ICollection<ArquivoVm> BuscarPorExpressao(Expression<Func<ArquivoVm, bool>> expression);
        ICollection<ArquivoVm> ObterTodosPaginado(Expression<Func<ArquivoVm, bool>> expression, int start, int take, string orderBy);
        ICollection<ArquivoVm> BuscarTodos();
    }
}