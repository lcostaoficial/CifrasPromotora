using CIFRAS.Application.Interfaces;
using CIFRAS.Application.ViewModel;
using CIFRAS.Infra.CrossCutting.Helpers;
using CIFRAS.Presentation.Helpers.DataTables.Filter;
using System;
using System.Web.Mvc;

namespace CIFRAS.Presentation.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class CategoriaArquivoController : Controller
    {
        private readonly ICategoriaArquivoAppService _categoriaArquivoApp;

        public CategoriaArquivoController(ICategoriaArquivoAppService categoriaArquivoApp)
        {
            _categoriaArquivoApp = categoriaArquivoApp;
        }

        public ActionResult ObterTabela(int draw, int start, int length)
        {
            string searchValue = Request.QueryString["search[value]"];
            string orderColumn = Request.QueryString["order[0][column]"];
            string orderDir = Request.QueryString["order[0][dir]"];
            var dataTable = new CategoriaArquivoFilter(_categoriaArquivoApp).ProcessFilter(draw, start, length, searchValue, orderColumn, orderDir);
            return Json(dataTable, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Adicionar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Adicionar(CategoriaArquivoVm model)
        {
            try
            {
                if (!ModelState.IsValid) throw new Exception();
                _categoriaArquivoApp.Adicionar(model);
                return RedirectToAction("Index").Success();
            }
            catch (Exception e)
            {
                return View(model).Error(e.Message);
            }
        }

        public ActionResult Editar(int id)
        {
            var model = _categoriaArquivoApp.BuscarPorId(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(CategoriaArquivoVm model)
        {
            try
            {
                if (!ModelState.IsValid) throw new Exception();
                _categoriaArquivoApp.Atualizar(model);
                return RedirectToAction("Index").Success();
            }
            catch (Exception e)
            {
                return View(model).Error(e.Message);
            }
        }

        public ActionResult Remover(int id)
        {
            try
            {
                _categoriaArquivoApp.Remover(new CategoriaArquivoVm { CategoriaArquivoId = id });
                return RedirectToAction("Index").Success();
            }
            catch (Exception e)
            {
                return RedirectToAction("Index").Error(e.Message);
            }
        }
    }
}