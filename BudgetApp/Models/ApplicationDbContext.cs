using Microsoft.EntityFrameworkCore;

namespace BudgetApp.Models
{
    public class ApplicationDbContext : DbContext
    {
        public virtual DbSet<Transaction> Transactions { get; set; }
        public virtual DbSet<Category> Categories { get; set; }

        //private readonly string _connectionString;

        //public ApplicationDbContext(string connectionString)
        //{
        //    _connectionString = connectionString;
        //}

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(_connectionString);
        //    base.OnConfiguring(optionsBuilder);
        //}
    }
}
