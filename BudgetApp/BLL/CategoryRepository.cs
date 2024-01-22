using BudgetApp.Models;

namespace BudgetApp.BLL
{
    public class CategoryRepository : IRepository<Category, int>
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Create(Category entity)
        {
            _context.Categories.Add(entity);
        }

        public Category GetById(int id) => _context.Categories.FirstOrDefault(c => c.Id == id);
        public IEnumerable<Category> GetAll() => _context.Categories.ToList();

        public void Update(Category entity)
        {
            _context.Categories.Update(entity);
        }

        public void Delete(int id)
        {
            _context.Categories.Remove(GetById(id));
        }
    }
}
