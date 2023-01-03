using CIFRAS.Application.Interfaces;
using CIFRAS.Application.ViewModel;
using CIFRAS.Infra.CrossCutting.Helpers;
using CIFRAS.Presentation.Helpers.DataTables.Filter;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace CIFRAS.Presentation.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class ReciboController : Controller
    {
        private readonly IBancoAppService _bancoApp;
        private readonly ITipoClienteAppService _tipoClienteApp;
        private readonly ICorretorAppService _corretorApp;
        private readonly IReciboAppService _reciboApp;

        public ReciboController(IBancoAppService bancoApp, ITipoClienteAppService tipoClienteApp, ICorretorAppService corretorApp, IReciboAppService reciboApp)
        {
            _bancoApp = bancoApp;
            _tipoClienteApp = tipoClienteApp;
            _corretorApp = corretorApp;
            _reciboApp = reciboApp;
        }

        public ActionResult ObterTabela(int draw, int start, int length)
        {
            var searchValue = Request.QueryString["search[value]"];
            var orderColumn = Request.QueryString["order[0][column]"];
            var orderDir = Request.QueryString["order[0][dir]"];
            var dataTable = new ReciboFilter(_reciboApp).ProcessFilter(draw, start, length, searchValue, orderColumn, orderDir);
            return Json(dataTable, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Adicionar()
        {
            TempData["ReciboEmprestimo"] = null;
            SetViewBag();
            return View();
        }

        [HttpPost]
        public ActionResult Adicionar(ReciboVm model)
        {
            try
            {
                if (!ModelState.IsValid) throw new Exception();
                model.ListaReciboEmprestimo = TempData["ReciboEmprestimo"] as ICollection<ReciboEmprestimoVm> ?? new List<ReciboEmprestimoVm>();
                _reciboApp.Adicionar(model);
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
            var model = _reciboApp.BuscarPorIdCustomizado(id);
            TempData["ReciboEmprestimo"] = model.ListaReciboEmprestimo;
            SetViewBag();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(ReciboVm model)
        {
            try
            {
                if (!ModelState.IsValid) throw new Exception();
                model.ListaReciboEmprestimo = TempData["ReciboEmprestimo"] as ICollection<ReciboEmprestimoVm> ?? new List<ReciboEmprestimoVm>();
                _reciboApp.Atualizar(model);
                return RedirectToAction("Index").Success();
            }
            catch (Exception e)
            {
                SetViewBag();
                return View(model).Error(e.Message);
            }
        }

        public ActionResult Download(int id)
        {
            var model = _reciboApp.BuscarPorIdCustomizado(id);
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult AdicionarEmprestimo(ReciboEmprestimoVm model)
        {
            var list = TempData["ReciboEmprestimo"] as IList<ReciboEmprestimoVm> ?? new List<ReciboEmprestimoVm>();
            model.BancoView = _bancoApp.BuscarPorId(model.BancoId).Descricao;
            model.TipoClienteView = _tipoClienteApp.BuscarPorId(model.TipoClienteId).Descricao;
            list.Add(model);
            TempData["ReciboEmprestimo"] = list;
            TempData.Keep("ReciboEmprestimo");
            SetViewBag();
            return View("Index");
        }

        public JsonResult RemoverReciboEmprestimo(int index)
        {
            try
            {
                var list = TempData["ReciboEmprestimo"] as IList<ReciboEmprestimoVm>;
                list.RemoveAt(index);
                TempData["ReciboEmprestimo"] = list;
                TempData.Keep("ReciboEmprestimo");
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(e.Message, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult AtualizarEmprestimos()
        {
            var lista = TempData["ReciboEmprestimo"] as IList<ReciboEmprestimoVm> ?? new List<ReciboEmprestimoVm>();
            TempData.Keep("ReciboEmprestimo");
            return PartialView("_ListaReciboEmprestimo", lista);
        }

        public ActionResult Remover(int id)
        {
            try
            {
                _reciboApp.Remover(new ReciboVm { ReciboId = id });
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
            ViewBag.TiposClientes = _tipoClienteApp.BuscarTodos();
            ViewBag.Corretores = _corretorApp.BuscarTodos();
        }
    }
}