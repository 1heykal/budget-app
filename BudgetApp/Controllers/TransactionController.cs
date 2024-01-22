using Microsoft.AspNetCore.Mvc;

namespace BudgetApp.Controllers
{
    public class TransactionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
