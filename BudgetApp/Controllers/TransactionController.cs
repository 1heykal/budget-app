using BudgetApp.BLL;
using BudgetApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace BudgetApp.Controllers
{
    public class TransactionController : Controller
    {
        private readonly IRepository<Transaction, Guid> _repository;

        public TransactionController(IRepository<Transaction, Guid> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var transactions = _repository.GetAll();
            return View(transactions);
        }

        [HttpGet("/id")]
        public IActionResult GetById(Guid id)
        {
            var transaction = _repository.GetById(id);
            return View(transaction);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                _repository.Add(transaction);
            }

            return View();
        }

        [HttpGet]
        public IActionResult Delete(Guid id)
        {
            var transaction = _repository.GetById(id);
            return View(transaction);
        }

        [HttpPost]
        public IActionResult Delete(Transaction transaction)
        {
            if (ModelState.IsValid)
            {
                _repository.Delete(transaction.Id);
            }
            return View();
        }


    }
}
