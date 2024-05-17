using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Config
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.ProductName).IsRequired();
            builder.Property(p => p.Price).IsRequired();
            builder.HasData(
                new Product() { Id = 1, CategoryId = 2,ImageUrl="/img/1.jpeg", ProductName = "Computer", Price = 17_000,ShowCase = false },
                new Product() { Id = 2, CategoryId = 2,ImageUrl="/img/2.jpeg", ProductName = "Keyboard", Price = 1_000,ShowCase = false },
                new Product() { Id = 3, CategoryId = 2,ImageUrl="/img/3.jpeg", ProductName = "Mouse", Price = 500,ShowCase = false },
                new Product() { Id = 4, CategoryId = 2,ImageUrl="/img/4.jpeg", ProductName = "Monitor", Price = 7_000,ShowCase = false },
                new Product() { Id = 5, CategoryId = 2,ImageUrl="/img/5.jpeg", ProductName = "Deck", Price = 1_500,ShowCase = false },
                new Product() { Id = 6, CategoryId = 1,ImageUrl="/img/6.jpeg", ProductName = "History", Price = 50,ShowCase = false },
                new Product() { Id = 7, CategoryId = 1,ImageUrl="/img/7.jpeg", ProductName = "Hamlet", Price = 75,ShowCase = false },
                new Product() { Id = 8, CategoryId = 2, ImageUrl = "/img/8.jpeg", ProductName = "Hp-pen", Price = 1_500,ShowCase = true },
                new Product() { Id = 9, CategoryId = 2, ImageUrl = "/img/9.jpeg", ProductName = "IPad", Price = 8000,ShowCase = true },
                new Product() { Id = 10, CategoryId = 2, ImageUrl = "/img/10.jpeg", ProductName = "Macbook Pro", Price = 70000,ShowCase = true }
                );
        }
    }
}
