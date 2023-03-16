using WEBAPI_order_ticket.Models;

namespace WEBAPI_order_ticket.Repositories
{
    public interface IGeneralRepository<T, K>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetByIdAsync(K key);
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity, K key);
        Task DeleteAsync(K key);
    }
}
