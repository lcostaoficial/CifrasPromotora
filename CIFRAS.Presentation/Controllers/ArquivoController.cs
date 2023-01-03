using System;
using System.IO;
using System.Net.Mime;
using CIFRAS.Application.Interfaces;
using CIFRAS.Application.ViewModel;
using CIFRAS.Presentation.Helpers.DataTables.Filter;
using System.Web.Mvc;
using CIFRAS.Infra.CrossCutting.Helpers;

namespace CIFRAS.Presentation.Controllers
{
    public class ArquivoController : Controller
    {
        private readonly IArquivoAppService _arquivoApp;
        private readonly ICategoriaArquivoAppService _categoriaArquivoApp;

        public ArquivoController(IArquivoAppService arquivoApp, ICategoriaArquivoAppService categoriaArquivoApp)
        {
            _arquivoApp = arquivoApp;
            _categoriaArquivoApp = categoriaArquivoApp;
        }

        public ActionResult ObterTabela(int? clienteId, int draw, int start, int length)
        {
            string searchValue = Request.QueryString["search[value]"];
            string orderColumn = Request.QueryString["order[0][column]"];
            string orderDir = Request.QueryString["order[0][dir]"];
            var dataTable = new ArquivoFilter(_arquivoApp, clienteId ?? 0).ProcessFilter(draw, start, length, searchValue, orderColumn, orderDir);
            return Json(dataTable, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Index(int id)
        {
            return View(id);
        }

        public ActionResult Visualizar(int id)
        {
            SetViewBag();
            return View("Index", id);
        }

        public FileResult Download(int id)
        {
            var model = _arquivoApp.BuscarPorId(id);
            model.ArquivoRetorno = System.IO.File.ReadAllBytes(Server.MapPath(model.Caminho));
            var extension = Path.GetExtension(model.Caminho);
            var namefile = $"{model.Descricao}{extension}";
            return File(model.ArquivoRetorno, MediaTypeNames.Application.Octet, namefile);
        }

        [HttpPost]
        public ActionResult NovoArquivo(ArquivoVm model)
        {
            try
            {
                if (!ModelState.IsValid) throw new Exception();
                _arquivoApp.UploadArquivo(model);
                return RedirectToAction("Visualizar", new { id = model.ClienteId }).Success();
            }
            catch (Exception e)
            {
                return RedirectToAction("Visualizar", new { id = model.ClienteId }).Error(e.Message);
            }
        }

        public ActionResult Remover(int id, int clienteId)
        {
            try
            {
                _arquivoApp.Remover(new ArquivoVm() { ArquivoId = id });
                return RedirectToAction("Visualizar", new { id = clienteId }).Success();
            }
            catch (Exception e)
            {
                return RedirectToAction("Visualizar", new { id = clienteId }).Error(e.Message);
            }
        }

        public void SetViewBag()
        {
            ViewBag.CategoriasArquivos = _categoriaArquivoApp.BuscarTodos();
        }
    }
}