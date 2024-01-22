using BudgetApp.BLL;
using Microsoft.AspNetCore.Mvc;
using System.Transactions;

namespace BudgetApp.Controllers
{
    public class TransactionController : Controller
    {
        private readonly IRepository<Transaction> _repository;

        public TransactionController(IRepository<Transaction> repository)
        {
            _repository = repository;
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
