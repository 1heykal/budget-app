﻿using BudgetApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BudgetApp.BLL
{
    public class TransactionRepository : IRepository<Transaction, Guid>
    {
        private readonly ApplicationDbContext _context;

        public TransactionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Transaction entity)
        {
            _context.Transactions.Add(entity);
            _context.SaveChanges();
        }

        public Transaction GetById(Guid id) => _context.Transactions.Include(t => t.Category).FirstOrDefault(t => t.Id == id);

        public IEnumerable<Transaction> GetAll() => _context.Transactions.Include(t => t.Category).ToList();

        public void Update(Transaction entity)
        {
            _context.Transactions.Update(entity);
            _context.SaveChanges();

        }

        public void Delete(Guid id)
        {
            _context.Transactions.Remove(GetById(id));
            _context.SaveChanges();

        }
    }
}
