using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace StoreApp.Models
{
    public class RepositoryContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

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
                new Product() { Id = 5, ProductName = "Deck", Price = 1_500 }
                );

            modelBuilder.Entity<Category>().HasData(
                new Category() { Id=1 , CategoryName="Book"},
                new Category() { Id=2,CategoryName="Electronic"}
                );
        }


    }
}
