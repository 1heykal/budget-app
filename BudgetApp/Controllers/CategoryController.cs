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

        public IActionResult Index()
        {
            return View();
        }
    }
}
