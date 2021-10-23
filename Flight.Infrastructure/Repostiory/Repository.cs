using Flight.Entities.Interfaces;
using Flight.Infrastructre.Data;

using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Flight.Infrastructre.Repostiory
{
    public class Repository<T> : IRepository<T> where T : class
    {
        readonly DbSet<T> entity;
        public FlightDbContext _context { get; }
        public Repository(FlightDbContext context)
        {
            _context = context;
            entity = context.Set<T>();
        }
        public async Task<bool> Create(T t)
        {
            if (t != null)
            {
                await entity.AddAsync(t);
                return true;
            }
            return false;
        }

        public async Task<bool> Delete(int id)
        {
            var entityToDelete = await entity.FindAsync(id);
            if (entityToDelete != null)
            {
                entity.Remove(entityToDelete);
                return true;
            }
            return false;
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            return entity.Where(expression);
        }

        public IQueryable<T> GetAll()
        {
            return entity.AsNoTracking();
        }

        public async Task<T> GetById(int id)
        {
            return await entity.FindAsync(id);
        }

        public Task Update(T t)
        {
            entity.Attach(t);
            return Task.Run(() =>
            _context.Entry(t).State = EntityState.Modified
            );
        }
    }
}
