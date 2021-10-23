using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Flight.Entities.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<bool> Create(T t);
        Task<T> GetById(int id);
        IEnumerable<T> Find(Expression<Func<T, bool>> expression);
        IQueryable<T> GetAll();
        Task Update(T t);
        Task<bool> Delete(int id);
    }
}
