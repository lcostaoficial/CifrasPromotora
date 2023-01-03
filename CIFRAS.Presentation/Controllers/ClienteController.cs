using CIFRAS.Application.Interfaces;
using CIFRAS.Application.ViewModel;
using CIFRAS.Infra.CrossCutting.Helpers;
using CIFRAS.Presentation.Helpers.DataTables.Filter;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace CIFRAS.Presentation.Controllers
{
    [Authorize]
    public class ClienteController : Controller
    {
        private readonly IClienteAppService _clienteApp;
        private readonly IBancoAppService _bancoApp;
        private readonly ITipoClienteAppService _tipoClienteApp;
        private readonly ITipoContratoAppService _tipoContratoApp;

        public ClienteController(IClienteAppService clienteApp, IBancoAppService bancoApp, ITipoClienteAppService tipoClienteApp, ITipoContratoAppService tipoContratoApp)
        {
            _clienteApp = clienteApp;
            _bancoApp = bancoApp;
            _tipoClienteApp = tipoClienteApp;
            _tipoContratoApp = tipoContratoApp;
        }

        public ActionResult ObterTabela(int draw, int start, int length, FiltroClienteVm model)
        {
            string searchValue = Request.QueryString["search[value]"];
            string orderColumn = Request.QueryString["order[0][column]"];
            string orderDir = Request.QueryString["order[0][dir]"];
            var dataTable = new ClienteFilter(_clienteApp).ProcessFilter(draw, start, length, searchValue, orderColumn, orderDir, model);
            return Json(dataTable, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Index()
        {
            SetViewBagTipoCliente();
            return View();
        }

        public ActionResult Adicionar()
        {
            TempData["Contas"] = null;
            TempData["Contratos"] = null;
            TempData["Contatos"] = null;
            SetViewBag();
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Adicionar(ClienteVm model)
        {
            try
            {
                if (!ModelState.IsValid) throw new Exception();
                model.ValidarRmc();
                model.ListaConta = TempData["Contas"] as ICollection<ContaVm> ?? new List<ContaVm>();
                model.ListaContrato = TempData["Contratos"] as ICollection<ContratoVm> ?? new List<ContratoVm>();
                model.ListaContato = TempData["Contatos"] as ICollection<ContatoVm> ?? new List<ContatoVm>();
                if (_clienteApp.PermitirInserir(model.Cpf, model.NumeroMatricula)) _clienteApp.Adicionar(model);
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
            var model = _clienteApp.BuscarPorIdCustomizado(id);
            TempData["Contas"] = model.ListaConta;
            TempData["Contratos"] = model.ListaContrato;
            TempData["Contatos"] = model.ListaContato;
            SetViewBag();
            return View(model);
        }

        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(ClienteVm model)
        {
            try
            {
                if (!ModelState.IsValid) throw new Exception();
                model.ListaConta = TempData["Contas"] as ICollection<ContaVm> ?? new List<ContaVm>();
                model.ListaContrato = TempData["Contratos"] as ICollection<ContratoVm> ?? new List<ContratoVm>();
                model.ListaContato = TempData["Contatos"] as ICollection<ContatoVm> ?? new List<ContatoVm>();
                _clienteApp.Atualizar(model);
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
                _clienteApp.Remover(new ClienteVm { ClienteId = id });
                return RedirectToAction("Index").Success();
            }
            catch (Exception e)
            {
                return RedirectToAction("Index").Error(e.Message);
            }
        }

        public ActionResult Detalhes(int id)
        {
            var cliente = _clienteApp.BuscarPorIdBasico(id);
            cliente.SetarDataVisualizacao();
            _clienteApp.Atualizar(cliente);
            SetViewBagTipoCliente();
            var model = _clienteApp.BuscarPorIdCustomizado(id);           
            return View(model);
        }

        [HttpPost]
        public ActionResult AdicionarConta(ContaVm model)
        {
            var list = TempData["Contas"] as IList<ContaVm> ?? new List<ContaVm>();
            model.BancoView = _bancoApp.BuscarPorId(model.BancoId ?? 0).Descricao;
            list.Add(model);
            TempData["Contas"] = list;
            TempData.Keep("Contas");
            SetViewBagTipoCliente();
            return View("Index");
        }

        public JsonResult RemoverConta(int index)
        {
            try
            {
                var list = TempData["Contas"] as IList<ContaVm>;
                list.RemoveAt(index);
                TempData["Contas"] = list;
                TempData.Keep("Contas");
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(e.Message, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult AtualizarContas()
        {
            var lista = TempData["Contas"] as IList<ContaVm> ?? new List<ContaVm>();
            TempData.Keep("Contas");
            return PartialView("_ListaConta", lista);
        }

        [HttpPost]
        public ActionResult AdicionarContrato(ContratoVm model)
        {
            var list = TempData["Contratos"] as IList<ContratoVm> ?? new List<ContratoVm>();
            model.BancoView = _bancoApp.BuscarPorId(model.BancoId ?? 0).Descricao;
            model.TipoContratoView = _tipoContratoApp.BuscarPorId(model.TipoContratoId).Descricao;
            list.Add(model);
            TempData["Contratos"] = list;
            TempData.Keep("Contratos");
            SetViewBagTipoCliente();
            return View("Index");
        }

        public JsonResult RemoverContrato(int index)
        {
            try
            {
                var list = TempData["Contratos"] as IList<ContratoVm>;
                list.RemoveAt(index);
                TempData["Contratos"] = list;
                TempData.Keep("Contratos");
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(e.Message, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult AtualizarContratos()
        {
            var lista = TempData["Contratos"] as IList<ContratoVm> ?? new List<ContratoVm>();
            TempData.Keep("Contratos");
            return PartialView("_ListaContrato", lista);
        }

        [HttpPost]
        public ActionResult AdicionarContato(ContatoVm model)
        {
            var list = TempData["Contatos"] as IList<ContatoVm> ?? new List<ContatoVm>();
            list.Add(model);
            TempData["Contatos"] = list;
            TempData.Keep("Contatos");
            SetViewBagTipoCliente();
            return View("Index");
        }

        public JsonResult RemoverContato(int index)
        {
            try
            {
                var list = TempData["Contatos"] as IList<ContatoVm>;
                list.RemoveAt(index);
                TempData["Contatos"] = list;
                TempData.Keep("Contatos");
                return Json(true, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(e.Message, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult AtualizarContatos()
        {
            var lista = TempData["Contatos"] as IList<ContatoVm> ?? new List<ContatoVm>();
            TempData.Keep("Contatos");
            return PartialView("_ListaContato", lista);
        }

        public JsonResult BuscarCliente(int id)
        {
            var model = _clienteApp.BuscarPorId(id);
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Imprimir(int id)
        {
            var model = _clienteApp.BuscarPorIdCustomizado(id);
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        public void SetViewBag()
        {
            ViewBag.Bancos = _bancoApp.BuscarTodos();
            ViewBag.TiposClientes = _tipoClienteApp.BuscarTodos();
            ViewBag.TiposContratos = _tipoContratoApp.BuscarTodos();
        }

        public void SetViewBagTipoCliente()
        {
            ViewBag.TiposClientes = _tipoClienteApp.BuscarTodos();
        }
    }
}