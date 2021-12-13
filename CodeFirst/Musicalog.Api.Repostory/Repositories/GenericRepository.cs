using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Musicalog.Api.EFCore.Interfaces;

namespace Musicalog.Api.EFCore.Repositories
{
    //public class GenericRepository<T> : IGenericRepository<T> where T:class
    //{
    //    protected ApplicationDbContext _context;
    //    internal DbSet<T> dbSet;

    //    public GenericRepository(ApplicationDbContext context)
    //    {
    //        this._context = context;
    //        this.dbSet = context.Set<T>();
    //    }

    //    public virtual async Task<bool> Add(T entity)
    //    {
    //        await dbSet.AddAsync(entity);
    //        return true;
    //    }

    //    public Task<bool> Delete(T entity)
    //    {
    //        dbSet.Remove(entity);

    //    }

    //    public Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public Task<IEnumerable<T>> GetAll()
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public Task<T> GetById(int Id)
    //    {
    //        throw new NotImplementedException();
    //    }

    //    public Task<bool> Upsert(T entity)
    //    {
    //        throw new NotImplementedException();
    //    }
    //}
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected ApplicationDbContext _context { get; set; }
        public GenericRepository(ApplicationDbContext context)
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
