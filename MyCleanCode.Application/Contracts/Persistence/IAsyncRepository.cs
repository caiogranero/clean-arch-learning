using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyCleanCode.Application.Contracts.Persistence
{
    public interface IAsyncRepository<T> where T : class
    {
        // TODO: Exists(int id)
        Task<T> GetByIdAsync(int id);
        // TODO: Change to IQueryable instead of IReadOnlyList
        Task<IReadOnlyList<T>> ListAllAsync();
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
    }
}