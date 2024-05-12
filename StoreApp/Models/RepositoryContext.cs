using Microsoft.EntityFrameworkCore;

namespace StoreApp.Models
{
    public class RepositoryContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options)
        {
            
        }

        //Çekirdek Datalar oluşturuyoruz.
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Product>().HasData(
                new Product() { Id= 1, ProductName="Computer", Price=17_000},
                new Product() { Id = 2, ProductName = "Keyboard", Price = 1_000 },
                new Product() { Id = 3, ProductName = "Mouse", Price = 500 },
                new Product() { Id = 4, ProductName = "Monitor", Price = 7_000 },
                new Product() { Id = 5, ProductName = "DEck", Price = 1_500 }
                );
        }


    }
}
