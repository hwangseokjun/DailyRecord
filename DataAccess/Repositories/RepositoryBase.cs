using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected readonly DbContext Context;
        protected readonly DbSet<T> DbSet;

        public RepositoryBase(DbContext context)
        {
            Context = context;
            DbSet = context.Set<T>();
        }

        public async Task<bool> DeleteAsync(T entity)
        {
            DbSet.Remove(entity);
            int count = await Context.SaveChangesAsync();

            return count > 0;
        }

        public async Task<bool> DeleteByIdAsync(int id)
        {
            T entity = await DbSet.FindAsync(id);

            return await DeleteAsync(entity);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await DbSet.FindAsync(id);
        }

        public IQueryable<T> GetQueryable()
        {
            return DbSet.AsQueryable();
        }

        public async Task<bool> InsertAsync(T entity)
        {
            DbSet.Add(entity);
            int count = await Context.SaveChangesAsync();

            return count > 0;
        }

        public async Task<bool> UpdateAsync(T entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            int count = await Context.SaveChangesAsync();

            return count > 0;
        }
    }
}
