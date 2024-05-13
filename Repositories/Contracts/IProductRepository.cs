﻿using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IProductRepository : IRepositoryBase<Product>
    {
        IQueryable<Product> GetAllProducts(bool trackChanges); //Repositorybaseden gelen ifadeyi farklı kullandık.
        Product? GetOneProduct(int id,bool trackChanges);
    }
}