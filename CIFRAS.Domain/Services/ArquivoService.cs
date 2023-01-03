using CIFRAS.Domain.Interfaces.Repositories;
using CIFRAS.Domain.Interfaces.Services;
using System;
using CIFRAS.Domain.Entities;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Web;
using CIFRAS.Domain.Helpers;

namespace CIFRAS.Domain.Services
{
    public class ArquivoService : IArquivoService
    {
        private readonly IArquivoRepository _arquivoRepository;
        private readonly IClienteService _clienteService;

        public ArquivoService(IArquivoRepository arquivoRepository, IClienteService clienteService)
        {
            _arquivoRepository = arquivoRepository;
            _clienteService = clienteService;
        }

        public void UploadArquivo(Arquivo model, HttpPostedFileBase arquivo)
        {
            var cliente = _clienteService.BuscarPorId(model.ClienteId);
            var path = HttpContext.Current.Server.MapPath($"~/Uploads/{cliente.Cpf.Replace(".", "").Replace("-", "")}");
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);
            var extension = Path.GetExtension(arquivo.FileName);
            var fileName = $"{arquivo.FileName.CalculateMD5Hash()}{extension}";
            arquivo.SaveAs($"{path}/{fileName}");
            model.Caminho = $"~/Uploads/{cliente.Cpf.Replace(".", "").Replace("-", "")}/{fileName}";
            Adicionar(model);
        }

        public void Adicionar(Arquivo model)
        {
            _arquivoRepository.Adicionar(model);
        }

        public void Atualizar(Arquivo model)
        {
            _arquivoRepository.Atualizar(model);
        }

        public void Remover(Arquivo model)
        {
            model = BuscarPorId(model.ArquivoId);
            _arquivoRepository.Remover(model);
            File.Delete(HttpContext.Current.Server.MapPath(model.Caminho));
        }

        public int ContarRegistros()
        {
            return _arquivoRepository.ContarRegistros();
        }

        public int ContarRegistrosPorExpressao(Expression<Func<Arquivo, bool>> expression)
        {
            return _arquivoRepository.ContarRegistrosPorExpressao(expression);
        }

        public Arquivo BuscarPorId(int id)
        {
            return _arquivoRepository.BuscarPorId(id);
        }

        public ICollection<Arquivo> ObterTodosPaginado(Expression<Func<Arquivo, bool>> expression, int start, int take, string orderBy)
        {
            return _arquivoRepository.ObterTodosPaginado(expression, start, take, orderBy);
        }

        public ICollection<Arquivo> BuscarPorExpressao(Expression<Func<Arquivo, bool>> expression)
        {
            return _arquivoRepository.BuscarPorExpressao(expression);
        }

        public ICollection<Arquivo> BuscarTodos()
        {
            return _arquivoRepository.BuscarTodos();
        }

        public void Dispose()
        {
            _arquivoRepository.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}