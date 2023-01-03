using CIFRAS.Application.Interfaces;
using CIFRAS.Application.ViewModel;
using CIFRAS.Infra.CrossCutting.Helpers;
using CIFRAS.Presentation.Helpers.DataTables.Filter;
using System;
using System.Web.Mvc;

namespace CIFRAS.Presentation.Controllers
{
    public class CorretorController : Controller
    {
        private readonly ICorretorAppService _corretorApp;
        private readonly IBancoAppService _bancoApp;

        public CorretorController(ICorretorAppService corretorApp, IBancoAppService bancoApp)
        {
            _corretorApp = corretorApp;
            _bancoApp = bancoApp;
        }

        public ActionResult ObterTabela(int draw, int start, int length)
        {
            string searchValue = Request.QueryString["search[value]"];
            string orderColumn = Request.QueryString["order[0][column]"];
            string orderDir = Request.QueryString["order[0][dir]"];
            var dataTable = new CorretorFilter(_corretorApp).ProcessFilter(draw, start, length, searchValue, orderColumn, orderDir);
            return Json(dataTable, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Adicionar()
        {
            SetViewBag();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Adicionar(CorretorVm model)
        {
            try
            {
                if (!ModelState.IsValid) throw new Exception();
                _corretorApp.Adicionar(model);
                return RedirectToAction("Index").Success();
            }
            catch (Exception e)
            {
                SetViewBag();
                return View(model).Error(e.Message);
            }
        }

        public ActionResult Editar(int id)
        {
            SetViewBag();
            var model = _corretorApp.BuscarPorId(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(CorretorVm model)
        {
            try
            {
                if (!ModelState.IsValid) throw new Exception();
                _corretorApp.Atualizar(model);
                return RedirectToAction("Index").Success();
            }
            catch (Exception e)
            {
                SetViewBag();
                return View(model).Error(e.Message);
            }
        }

        public ActionResult Remover(int id)
        {
            try
            {
                _corretorApp.Remover(new CorretorVm { CorretorId = id });
                return RedirectToAction("Index").Success();
            }
            catch (Exception e)
            {
                return RedirectToAction("Index").Error(e.Message);
            }
        }

        public void SetViewBag()
        {
            ViewBag.Bancos = _bancoApp.BuscarTodos();
        }
    }
}