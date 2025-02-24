using GPN.Application.DTOs;
using GPN.Application.Interfaces;
using GPN.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GPN.Web.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

        // GET: ClienteController
        public async Task<ActionResult> Index()
        {
            var clientes = await _clienteService.GetAllAsync();
            return View("Index", clientes);
        }

        // GET: ClienteController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var cliente = await _clienteService.GetByIdAsync(id);
            return View(cliente);
        }

        // GET: ClienteController/Create
        public ActionResult Create()
        {
            return View("Cadastro");
        }

        // POST: ClienteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Cliente cliente)
        {
            ModelState.Remove("ClienteId");
            ModelState.Remove("Cpf");
            if (ModelState.IsValid)
            {
                if (cliente.ClienteId == 0)
                {
                    try
                    {
                        var clienteDto = new ClienteCreateDto(cliente);
                        await _clienteService.AddAsync(clienteDto);
                        return RedirectToAction(nameof(Index));
                    }
                    catch
                    {
                        return View();
                    }
                }
            }

            return View(cliente);
        }

        // GET: ClienteController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var cliente = await _clienteService.GetByIdAsync(id);
            return View(cliente);
        }

        // POST: ClienteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(ClienteDto cliente)
        {
            ModelState.Remove("ClienteId");
            ModelState.Remove("Cpf");
            if (ModelState.IsValid)
            {
                try
                {
                    await _clienteService.UpdateAsync(cliente);
                    return RedirectToAction("Details", new { id = cliente.ClienteId });
                }
                catch
                {
                    return View(cliente);
                }
            }

            return View(cliente.ClienteId);
        }

        // GET: ClienteController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ClienteController/Delete/5
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
