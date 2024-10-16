using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC_CRUD.Entities.Models;
using MVC_CRUD.Repositories.Interfaces;

namespace MVC_CRUD.Controllers
{
    public class InventoryController : Controller
    {
        private IBaseRepository<Inventory> _inventoryRepository;
        private IBaseRepository<Product> _productRepository;
        public InventoryController(IBaseRepository<Inventory> inventoryRepository, IBaseRepository<Product> productRepository)
        {
            _inventoryRepository = inventoryRepository;
            _productRepository = productRepository;
        }

        // GET: InventoryController
        public async Task<ActionResult> Index(string search)
        {
            IEnumerable<Inventory> inventories;
            if (search != null)
            {
                ViewBag.Search = search;
                inventories = await _inventoryRepository.GetAll(i => i.InventoryName.Contains(search), new[] { "product" });
            }
            else
            {
                inventories = await _inventoryRepository.GetAll(null, new[] { "product" });
            }
            return View("InventoryList", inventories);
        }

        // GET: InventoryController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var inventory = await _inventoryRepository.GetById(id);
            inventory.product = await _productRepository.GetById(id);
            return View("InventoryDetails", inventory);
        }

        // GET: InventoryController/Create
        public async Task<ActionResult> Create()
        {
            ViewBag.Products = await _productRepository.GetAll();
            return View("InventoryCreate");
        }

        // POST: InventoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Inventory item)
        {
            try
            {
                await _inventoryRepository.AddItem(item);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("InventoryCreate");
            }
        }

        // GET: InventoryController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var inventory = await _inventoryRepository.GetById(id);
            if (inventory == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View("InventoryEdit", inventory);
        }

        // POST: InventoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Inventory item)
        {
            try
            {
                await _inventoryRepository.UpdateItem(item);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("InventoryEdit");
            }
        }

        // GET: InventoryController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var inventory = await _inventoryRepository.GetById(id);
            if (inventory == null)
            {
                return RedirectToAction(nameof(Index));
            }
            inventory.product = await _productRepository.GetById(inventory.ProductId);
            return View("InventoryDelete", inventory);
        }

        // POST: InventoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, Inventory item)
        {
            try
            {
                await _inventoryRepository.DeleteItem(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("InventoryDelete");
            }
        }
    }
}
