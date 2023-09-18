using System.Linq.Expressions;
using BoynerCase.Models;

namespace BoynerCase.Repository
{
    public interface IRepository<T> where T : BaseEntity
    {
        IQueryable<T> GetAll();
        Task<IEnumerable<T>> GetPage(int page);
        Task<T> GetById(int id);
        Task Create(T entity);
        Task<T> Update(int id,T entity);
        Task<T> Delete(int id);
    }
}
