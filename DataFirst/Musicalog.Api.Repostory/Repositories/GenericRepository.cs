using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Musicalog.Api.EFCore.Interfaces;
using Musicalog.Domain.Models;

namespace Musicalog.Api.EFCore.Repositories
{
   
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected MusicCatalogContext _context { get; set; }
        public GenericRepository(MusicCatalogContext context)
        {
            this._context = context;
        }
        public IQueryable<T> FindAll()
        {
            return this._context.Set<T>();
        }
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this._context.Set<T>()
                .Where(expression);
        }
        public void Create(T entity)
        {
            this._context.Set<T>().Add(entity);
        }
        public void Update(T entity)
        {
            this._context.Set<T>().Update(entity);
            //_context.Entry(entity).CurrentValues.SetValues(entity);

        }
        public void Delete(T entity)
        {
            this._context.Set<T>().Remove(entity);
        }
        public async Task SaveAsync()
        {
            await this._context.SaveChangesAsync();
        }

    }
}
