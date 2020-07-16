using Microsoft.EntityFrameworkCore;
using OnlineShopping.API.Models;

namespace OnlineShopping.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options) {}

        public DbSet<Value> Values { get; set; }
        public DbSet<Category> Category {get; set;} 
        public DbSet<Products> Products {get; set;} 
        public DbSet<User> User {get; set;}  
    }
}