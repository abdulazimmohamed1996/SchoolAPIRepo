using Microsoft.EntityFrameworkCore;
using SchoolWith.Core.Interfaces;
using SchoolWith.EF.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SchoolWith.EF.Services
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly SchoolDbContext _context;
        public BaseRepository(SchoolDbContext context)
        {
            _context = context;
        }
        public async Task<T> Add(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            return entity;
        }

        public async Task<int> CommitChanges()
        {
           return await _context.SaveChangesAsync();
        }

        public async Task<T> Delete(T entity)
        {
             _context.Set<T>().Remove(entity);
            return entity;
        }

        public async Task<T> Find(Expression<Func<T, bool>> criteria)
        {
            var result = await _context.Set<T>().AsNoTracking().AsQueryable().AsNoTracking().FirstOrDefaultAsync(criteria);
            if (result == null) return null;
            _context.Entry(result).State = EntityState.Detached;
            return result;
        }

        public async Task<T> FindById(int id)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            if (entity == null) return null;
            _context.Entry(entity).State = EntityState.Detached;
            return entity;
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> Update(T entity)
        {
            var x =  _context.Entry(entity).State;
             _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync(); 

            return entity;
        }
    }
}
