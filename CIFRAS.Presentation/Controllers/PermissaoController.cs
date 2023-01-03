using CIFRAS.Application.Interfaces;
using System.Web.Mvc;

namespace CIFRAS.Presentation.Controllers
{
    [Authorize]
    public class PermissaoController : Controller
    {
        private readonly IFuncionarioAppService _funcionarioApp;

        public PermissaoController(IFuncionarioAppService funcionarioApp)
        {
            _funcionarioApp = funcionarioApp;
        }

        public ActionResult LayoutMenu()
        {
            var model = _funcionarioApp.UsuarioLogado();
            if (model != null)
            {
                return PartialView("_LayoutMenu", model);
            }
            else
            {
                return RedirectToAction("Sair", "Funcionario");
            }
        }

        public ActionResult LayoutTop()
        {
            var model = _funcionarioApp.UsuarioLogado();
            if (model != null)
            {
                return PartialView("_LayoutTop", model);
            }
            else
            {
                return RedirectToAction("Sair", "Funcionario");
            }
        }

        public ActionResult ModalPerfil()
        {
            var model = _funcionarioApp.UsuarioLogado();
            if (model != null)
            {
                return PartialView("_ModalPerfil", model);
            }
            else
            {
                return RedirectToAction("Sair", "Funcionario");
            }
        }
    }
}