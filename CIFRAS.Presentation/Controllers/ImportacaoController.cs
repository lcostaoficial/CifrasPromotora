using System;
using CIFRAS.Application.Interfaces;
using CIFRAS.Application.ViewModel;
using System.Web.Mvc;
using CIFRAS.Infra.CrossCutting.Helpers;

namespace CIFRAS.Presentation.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class ImportacaoController : Controller
    {
        private readonly IImportacaoAppService _importacaoApp;
        private readonly ITipoClienteAppService _tipoClienteApp;

        public ImportacaoController(IImportacaoAppService importacaoApp, ITipoClienteAppService tipoClienteApp)
        {
            _importacaoApp = importacaoApp;
            _tipoClienteApp = tipoClienteApp;
        }

        public ActionResult Index()
        {
            SetViewBag();
            return View();
        }

        [HttpPost]
        public ActionResult Index(ImportacaoVm model)
        {
            try
            {
                SetViewBag();
                if (!ModelState.IsValid) throw new Exception();
                var log = _importacaoApp.ImportarArquivo(model.Arquivo, model.TipoClienteId);
                return View(new ImportacaoVm {LogPath = log }).Success("Importação concluída com sucesso!");
            }
            catch (Exception e)
            {
                SetViewBag();
                return View().Error(e.Message);
            }
        }

        public void SetViewBag()
        {
            ViewBag.TiposClientes = _tipoClienteApp.BuscarTodos();
        }
    }
}