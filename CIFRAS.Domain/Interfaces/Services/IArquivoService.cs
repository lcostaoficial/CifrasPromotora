using CIFRAS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web;

namespace CIFRAS.Domain.Interfaces.Services
{
    public interface IArquivoService : IDisposable
    {
        void UploadArquivo(Arquivo model, HttpPostedFileBase arquivo);
        void Adicionar(Arquivo model);
        void Atualizar(Arquivo model);
        void Remover(Arquivo model);
        int ContarRegistros();
        int ContarRegistrosPorExpressao(Expression<Func<Arquivo, bool>> expression);
        Arquivo BuscarPorId(int id);
        ICollection<Arquivo> BuscarPorExpressao(Expression<Func<Arquivo, bool>> expression);
        ICollection<Arquivo> ObterTodosPaginado(Expression<Func<Arquivo, bool>> expression, int start, int take, string orderBy);
        ICollection<Arquivo> BuscarTodos();
    }
}