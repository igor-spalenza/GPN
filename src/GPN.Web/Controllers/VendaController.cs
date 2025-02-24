using GPN.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GPN.Web.Controllers
{
    public class VendaController : Controller
    {
        private readonly IPedidoService _pedidoService;

        public VendaController(IPedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }
        // GET: VendaController
        public async Task<ActionResult> Index()
        {
            var pedidos = await _pedidoService.GetAllAsync();
            return View("Index", pedidos);
        }

        // Action para a Etapa 1 de criação do Pedido
        public IActionResult NovoPedido()
        {
            return PartialView("_ClienteIdentificacao");
        }

        // Action para carregar um Pedido existente
        public IActionResult CarregarPedido(int id)
        {
            return PartialView("_PedidoDetalhes", id);
        }

        // GET: VendaController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: VendaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VendaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: VendaController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: VendaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: VendaController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: VendaController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
