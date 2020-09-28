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
        public DbSet<OrderProduct> OrderProduct { get; set; }
        public DbSet<Order> Order { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderProduct>()
                .HasKey(e => new { e.OrderId, e.ProductId });
            //.HasMany(e => e.ProductId);

            //modelBuilder.Entity<Order>()
            //    .HasMany(e => e.OrderProduct);
        }

        //builder.HasOne(e => e.Orderobj).WithMany(e => e.OrderItems).HasForeignKey(e => e.OrderId);

    }
}
