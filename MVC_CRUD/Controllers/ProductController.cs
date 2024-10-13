using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC_CRUD.Entities.Models;
using MVC_CRUD.Repositories.Implementation;
using MVC_CRUD.Repositories.Interfaces;
namespace MVC_CRUD.Controllers
{
    public class ProductController : Controller
    {
        private IBaseRepository<Product> _productRepository;
        private IBaseRepository<Category> _categoryRepository;
        private IBaseRepository<Supplier> _supplierRepository;
        private IWebHostEnvironment _environment;
        private IUploadFile _uploadFile;


        public ProductController(IBaseRepository<Product> productRepository, IBaseRepository<Category> categoryRepository, IBaseRepository<Supplier> supplierRepository, IWebHostEnvironment environment, IUploadFile uploadFile)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
            _supplierRepository = supplierRepository;
            _environment = environment;
            _uploadFile = uploadFile;
        }

        // GET: ProductController
        public async Task<ActionResult> Index(string search)
        {
            IEnumerable<Product> products;
            if (search != null)
            {
                ViewBag.Search = search;
                products = await _productRepository.GetAll(p => p.ProductName.Contains(search), new[] { "category", "supplier" });
            }
            else
            {
                products = await _productRepository.GetAll(null, new[] { "category", "supplier" });
            }

            return View("ProductList", products);
        }

        // GET: ProductController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var product = await _productRepository.GetById(id);
            product.supplier = await _supplierRepository.GetById(product.SupplierId);
            product.category = await _categoryRepository.GetById(product.CategoryId);
            return View("ProductDetails", product);
        }

        // GET: ProductController/Create
        public async Task<ActionResult> Create()
        {
            ViewBag.Suppliers = await _supplierRepository.GetAll();
            ViewBag.Categories = await _categoryRepository.GetAll();

            return View("ProductCreate");
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Product item)
        {
            try
            {
                if (item.ImageFile != null)
                {
                    string FileName = await _uploadFile.UploadFileAsync("\\Images\\ProductsImages\\", item.ImageFile);
                    item.Picture = FileName;
                }

                await _productRepository.AddItem(item);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("ProductCreate");
            }
        }

        // GET: ProductController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var supplier = await _supplierRepository.GetAll();
            var category = await _categoryRepository.GetAll();
            var product = await _productRepository.GetById(id);
            if (product == null)
            {
                return RedirectToAction(nameof(Index));
            }
            product.CategoryList = category.ToList();
            product.SupplierList = supplier.ToList();
            return View("ProductEdit", product);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Product item)
        {
            try
            {
                if (item.ImageFile != null)
                {
                    string FileName = await _uploadFile.UploadFileAsync("\\Images\\ProductsImages\\", item.ImageFile);
                    item.Picture = FileName;
                }

                await _productRepository.UpdateItem(item);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("ProductEdit");
            }
        }

        // GET: ProductController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var product = await _productRepository.GetById(id);
            if (product == null)
            {
                return RedirectToAction(nameof(Index));
            }
            product.supplier = await _supplierRepository.GetById(product.SupplierId);
            product.category = await _categoryRepository.GetById(product.CategoryId);

            return View("ProductDelete", product);
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, Product item)
        {
            try
            {
                await _productRepository.DeleteItem(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("ProductDelete");
            }
        }
    }
}
