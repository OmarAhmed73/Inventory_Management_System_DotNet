using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC_CRUD.Entities.Models;
using MVC_CRUD.Repositories.Implementation;
using MVC_CRUD.Repositories.Interfaces;

namespace MVC_CRUD.Controllers
{

    public class SupplierController : Controller
    {
        private IBaseRepository<Supplier> _supplierRepository;
        private IBaseRepository<Product> _productRepository;
        public SupplierController(IBaseRepository<Supplier> supplierRepository, IBaseRepository<Product> productRepository)
        {
            _supplierRepository = supplierRepository;
            _productRepository = productRepository;
        }

        // GET: SupplierController
        public async Task<ActionResult> Index(string search)
        {
            IEnumerable<Supplier> suppliers;
            if (search != null)
            {
                ViewBag.Search = search;
                suppliers = await _supplierRepository.GetAll(p => p.SupplierName.Contains(search));
                foreach (var supplier in suppliers)
                {
                    supplier.Products = await _productRepository.GetAll(p => p.SupplierId == supplier.SupplierID);
                }
            }
            else
            {
                suppliers = await _supplierRepository.GetAll();
                foreach (var supplier in suppliers)
                {
                    supplier.Products = await _productRepository.GetAll(p => p.SupplierId == supplier.SupplierID);
                }
            }
            return View("SupplierIndex", suppliers);
        }

        // GET: SupplierController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var supplier = await _supplierRepository.GetById(id);
            return View("SupplierDetails", supplier);
        }

        // GET: SupplierController/Create
        public async Task<ActionResult> Create()
        {
            return View("SupplierCreate");
        }

        // POST: SupplierController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Supplier item)
        {
            try
            {
                await _supplierRepository.AddItem(item);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("SupplierCreate");
            }
        }

        // GET: SupplierController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var supplier = await _supplierRepository.GetById(id);
            if (supplier == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View("SupplierEdit", supplier);
        }

        // POST: SupplierController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Supplier item)
        {
            try
            {
                await _supplierRepository.UpdateItem(item);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SupplierController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var supplier = await _supplierRepository.GetById(id);
            if (supplier == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View("SupplierDelete", supplier);
        }

        // POST: SupplierController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, Supplier item)
        {
            try
            {
                await _supplierRepository.DeleteItem(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("SupplierDelete");
            }
        }
    }
}
