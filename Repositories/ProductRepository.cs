using Entities.Models;
using Entities.RequestParameters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Repositories.Contracts;
using Repositories.Extensions;
using StoreApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public sealed class  ProductRepository : RepositoryBase<Product>, IProductRepository //sealed class birdaha kalıtım alınamaz
    {
        public ProductRepository(RepositoryContext context) : base(context)
        {

        }

        public void CreateOneProduct(Product product) => Create(product);




        public void DeleteOneProduct(Product product) => Remove(product);

       

        public IQueryable<Product> GetAllProducts(bool trackChanges) => FindAll(trackChanges);

        public IQueryable<Product> GetAllProductsWithDetails(ProductRequestParameters p)
        {
            return _context.Products.FilteredByCategoryId(p.CategoryId)
                 .FilterBySearchTerm(p.SearchTerm).FilteredByPrice(p.MinPrice,p.MaxPrice,p.IsValidPrice);
        }

        public Product? GetOneProduct(int id, bool trackChanges)
        {
            return FindByCondition(p => p.Id == id, trackChanges);
        }

        public IQueryable<Product> GetShowcaseProducts(bool trackChanges)
        {
            return FindAll(trackChanges)
                .Where(p => p.ShowCase == true);
        }

        public void UpdateOneProduct(Product entity) => Update(entity);

       
    }
}
