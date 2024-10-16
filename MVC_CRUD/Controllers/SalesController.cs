using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC_CRUD.Entities.Models;
using MVC_CRUD.Repositories.Interfaces;

namespace MVC_CRUD.Controllers
{
    public class SalesController : Controller
    {
        private IBaseRepository<Product> _productRepository;
        private IBaseRepository<Sales> _salesRepository;

        public SalesController(IBaseRepository<Sales> salesRepository, IBaseRepository<Product> productRepository)
        {
            _productRepository = productRepository;
            _salesRepository = salesRepository;
        }

        // GET: SalesController
        public async Task<ActionResult> Index(string search)
        {
            IEnumerable<Sales> sales;
            if (search != null)
            {
                ViewBag.Search = search;
                sales = await _salesRepository.GetAll(s => s.Name.Contains(search), new[] { "product" });
            }
            else
            {
                sales = await _salesRepository.GetAll(null, new[] { "product" });
            }
            return View("SalesList", sales);
        }



        // GET: SalesController/Create
        public async Task<ActionResult> Create()
        {
            ViewBag.Products = await _productRepository.GetAll();
            return View("SalesCreate");
        }

        // POST: SalesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Sales item)
        {
            try
            {
                await _salesRepository.AddItem(item);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("SalesCreate");
            }
        }

        // GET: SalesController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var product = await _productRepository.GetAll();
            var sale = await _salesRepository.GetById(id);
            if (sale == null)
            {
                return RedirectToAction(nameof(Index));
            }
            sale.ProductList = product.ToList();
            return View("SalesEdit", sale);
        }

        // POST: SalesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Sales item)
        {
            try
            {
                await _salesRepository.UpdateItem(item);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("SalesEdit");
            }
        }

        // GET: SalesController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var sale = await _salesRepository.GetById(id);
            if (sale == null)
            {
                return RedirectToAction(nameof(Index));
            }
            sale.product = await _productRepository.GetById(sale.ProductId);
            return View("SalesDelete", sale);
        }

        // POST: SalesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, Sales item)
        {
            try
            {
                await _salesRepository.DeleteItem(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("SalesDelete");
            }
        }
    }
}
