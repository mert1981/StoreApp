using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using StoreApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class, new()
    {
        protected readonly RepositoryContext _context; //devraldığımız classlarda da kullanmak için protected değişkeni ile tanımlıyoruz.
        protected RepositoryBase(RepositoryContext context)
        {
            _context = context;
        }

        public void Create(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public IQueryable<T> FindAll(bool trackChanges)
        {
            return trackChanges ? _context.Set<T>() :
                _context.Set<T>().AsNoTracking();
        }

        public T? FindByCondition(Expression<Func<T, bool>> expression, bool trackChanges)
        {
            return trackChanges ? _context?.Set<T>().Where(expression).SingleOrDefault()
                : _context?.Set<T>().Where(expression).AsNoTracking().SingleOrDefault();


        }
    }

}
