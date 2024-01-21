using Microsoft.EntityFrameworkCore;

namespace BudgetApp.Models
{
    public class ApplicationDbContext : DbContext
    {



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
