using Microsoft.EntityFrameworkCore;
using AutumnStore.Data.Model;

namespace AutumnStore.Data.Repository
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Category> Category { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<User> User { get; set; }

    }
}
