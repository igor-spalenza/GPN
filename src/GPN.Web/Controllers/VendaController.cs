using GPN.Application.DTOs;
using GPN.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GPN.Web.Controllers
{
    public class VendaController : Controller
    {
        private readonly IPedidoService _pedidoService;
        private readonly IClienteService _clienteService;

        public VendaController(IPedidoService pedidoService, IClienteService clienteService)
        {
            _clienteService = clienteService;
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
            return PartialView("_PedidoCriacao");
        }

        /*public async Task<IActionResult> AnotarPedido(int idCliente)
        {
            var cliente = await _clienteService.GetByIdAsync(1);
            var pedido = new PedidoCreateDto
            {
                ClienteId = cliente.ClienteId
            };
            return PartialView("_PedidoCriacao", pedido);
        }
        */

        // GET: VendaController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var pedido = await _pedidoService.GetByIdAsync(id);
            return View("_Details", pedido);
        }

        // GET: VendaController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VendaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PedidoCreateDto pedidoCreateDto)
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
        public async Task<ActionResult> Edit(int id)
        {
            var pedido = await _pedidoService.GetByIdAsync(id);
            return View("_Edit", pedido);
        }

        // GET: VendaController/Edit/5
        public async Task<ActionResult> EditPartial(int id)
        {
            var pedido = await _pedidoService.GetByIdAsync(id);
            return PartialView("_Edit", pedido);
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
