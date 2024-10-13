using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC_CRUD.Entities.Models;
using MVC_CRUD.Repositories.Implementation;
using MVC_CRUD.Repositories.Interfaces;

namespace MVC_CRUD.Controllers
{
    public class CategoryController : Controller
    {
        private IBaseRepository<Category> _categoryRepository;

        public CategoryController(IBaseRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        // GET: CategoryController
        public async Task<ActionResult> Index(string search)
        {
            IEnumerable<Category> category;
            if (search != null)
            {
                ViewBag.Search = search;
                category = await _categoryRepository.GetAll(p => p.CategoryName.Contains(search));
            }
            else
            {
                category = await _categoryRepository.GetAll();
            }
            return View("CategoryIndex", category);
        }

        // GET: CategoryController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var category = await _categoryRepository.GetById(id);
            return View("CategoryDetails", category);
        }

        // GET: CategoryController/Create
        public async Task<ActionResult> Create()
        {
            return View("CategoryCreate");
        }

        // POST: CategoryController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Category item)
        {
            try
            {
                await _categoryRepository.AddItem(item);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("CategoryCreate");
            }
        }

        // GET: CategoryController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var category = await _categoryRepository.GetById(id);
            if (category == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View("CategoryEdit", category);
        }

        // POST: CategoryController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, Category item)
        {
            try
            {
                await _categoryRepository.UpdateItem(item);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CategoryController/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var category = await _categoryRepository.GetById(id);
            if (category == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View("CategoryDelete", category);
        }

        // POST: CategoryController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, Category item)
        {
            try
            {
                await _categoryRepository.DeleteItem(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View("CategoryDelete");
            }
        }
    }
}
