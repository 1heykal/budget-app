using BudgetApp.BLL;
using BudgetApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace BudgetApp.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IRepository<Category, int> _repository;

        public CategoryController(IRepository<Category, int> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                _repository.Add(category);
            }
            return RedirectToAction("Get", category.Id);
        }

        [HttpGet]
        public IActionResult Index()
        {
            var categories = _repository.GetAll();
            return View(categories);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {

            var category = _repository.GetById(id);
            if (category is null)
            {
                return RedirectToAction("Index");
            }
            return View(category);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var category = _repository.GetById(id);
            if (category is null)
            {
                return RedirectToAction("Index");
            }
            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {

            if (ModelState.IsValid)
            {
                _repository.Update(category);
            }
            return RedirectToAction("Get", category.Id);

        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            var category = _repository.GetById(id);
            if (category is null)
            {
                return RedirectToAction("Index");
            }
            return View(category);
        }

        [HttpPost]
        public IActionResult Delete(Category category)
        {
            if (ModelState.IsValid)
            {
                _repository.Delete(category.Id);
            }
            return RedirectToAction("Index");
        }
    }
}
