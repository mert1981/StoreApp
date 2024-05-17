using Repositories.Contracts;
using StoreApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProductRepository _productRepository;
        private readonly IOrderRepository _orderRepository;
        private readonly RepositoryContext _repositoryContext;
        
        public RepositoryManager(IProductRepository productRepository,RepositoryContext context,ICategoryRepository categoryRepository,IOrderRepository orderRepository)
        {
            _productRepository = productRepository;
            _repositoryContext = context;
            _categoryRepository = categoryRepository;
            _orderRepository = orderRepository;
        }
        public IProductRepository Product => _productRepository;

        public ICategoryRepository Category => _categoryRepository;

        public IOrderRepository Order => _orderRepository;

        public void Save()
        {
            _repositoryContext.SaveChanges();   
        }
    }
}
