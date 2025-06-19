using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SchoolWith.Core.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T>Add(T entity);
        Task<IEnumerable<T>> GetAll();
        Task<T> Find(Expression<Func<T, bool>> criteria);
        Task<T> Update(T entity);
        Task<T> Delete(T entity);
        Task<T> FindById(int id);

        Task<int> CommitChanges();


    }
}
