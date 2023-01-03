using CIFRAS.Application.Interfaces;
using CIFRAS.Application.ViewModel;
using CIFRAS.Infra.CrossCutting.Helpers;
using CIFRAS.Presentation.Helpers.DataTables.Filter;
using System;
using System.Web.Mvc;

namespace CIFRAS.Presentation.Controllers
{
    public class FuncionarioController : Controller
    {
        private readonly IFuncionarioAppService _funcionarioApp;

        public FuncionarioController(IFuncionarioAppService funcionarioApp)
        {
            _funcionarioApp = funcionarioApp;
        }

        public ActionResult Logar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Logar(LoginVm model)
        {
            try
            {
                if (!ModelState.IsValid) throw new Exception();
                bool validarUsuario = _funcionarioApp.ValidarLogin(model.Login, model.Senha);
                if (validarUsuario)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return Redirect("Logar").Error("Login ou senha inválidos!");
                }
            }
            catch (Exception e)
            {
                return Redirect("Logar").Error(e.Message);
            }
        }

        public ActionResult Sair()
        {
            try
            {
                _funcionarioApp.DesconectarUsuario();
                return Redirect("Logar").Success("Desconectado com sucesso!");
            }
            catch (Exception e)
            {
                return Redirect("Logar").Error(e.Message);
            }
        }
        
        public ActionResult ObterTabela(int draw, int start, int length)
        {
            string searchValue = Request.QueryString["search[value]"];
            string orderColumn = Request.QueryString["order[0][column]"];
            string orderDir = Request.QueryString["order[0][dir]"];
            var dataTable = new FuncionarioFilter(this._funcionarioApp).ProcessFilter(draw, start, length, searchValue, orderColumn, orderDir);
            return Json(dataTable, JsonRequestBehavior.AllowGet);
        }

        [Authorize(Roles = "Administrador")]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Administrador")]
        public ActionResult Adicionar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Adicionar(FuncionarioVm model)
        {
            try
            {
                if (!ModelState.IsValid) throw new Exception();
                _funcionarioApp.Adicionar(model);
                return RedirectToAction("Index").Success();
            }
            catch (Exception e)
            {
                return View(model).Error(e.Message);
            }
        }

        [Authorize(Roles = "Administrador")]
        public ActionResult Editar(int id)
        {
            var model = _funcionarioApp.BuscarPorId(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(FuncionarioVm model)
        {
            try
            {
                if (!ModelState.IsValid) throw new Exception();
                _funcionarioApp.Atualizar(model);
                return RedirectToAction("Index").Success();
            }
            catch (Exception e)
            {
                return View(model).Error(e.Message);
            }
        }

        [Authorize(Roles = "Administrador")]
        public ActionResult Remover(int id)
        {
            try
            {
                _funcionarioApp.Remover(new FuncionarioVm { FuncionarioId = id });
                return RedirectToAction("Index").Success();
            }
            catch (Exception e)
            {
                return RedirectToAction("Index").Error(e.Message);
            }
        }
    }
}