using Microsoft.EntityFrameworkCore;

namespace BoynerCase.Models
{
    public class CaseDbContext : DbContext
    {
        public CaseDbContext(DbContextOptions<CaseDbContext> opt) : base(opt) { }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; } 
    }
}
