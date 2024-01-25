using BudgetApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BudgetApp.BLL
{
    public class CategoryRepository : IRepository<Category, int>
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Category entity)
        {
            _context.Categories.Add(entity);
            _context.SaveChanges();
        }

        public Category GetById(int id) => _context.Categories.FirstOrDefault(c => c.Id == id);
        public IEnumerable<Category> GetAll() => _context.Categories.Include(c => c.Transactions).ToList();

        public void Update(Category entity)
        {
            _context.Categories.Update(entity);
            _context.SaveChanges();

        }

        public void Delete(int id)
        {

            using (var transaction = _context.Database.BeginTransaction())
            {
                try
                {
                    var category = _context.Categories.Include(c => c.Transactions).FirstOrDefault(c => c.Id == id);

                    if (category != null)
                    {
                        _context.Transactions.RemoveRange(category.Transactions);

                        _context.Categories.Remove(category);

                        _context.SaveChanges();

                        transaction.Commit();
                    }
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                }

            }



        }
    }
}
