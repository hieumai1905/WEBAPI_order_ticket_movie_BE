using Microsoft.EntityFrameworkCore;
using WEBAPI_order_ticket.Models;

namespace WEBAPI_order_ticket.Repositories.CastRepository
{
    public class CastRepository : ICastRepository
    {
        private OrderTicketContext _context;

        public CastRepository(OrderTicketContext dbContext)
        {
            _context = dbContext;
        }
        public async Task<Cast> AddAsync(Cast entity)
        {
            try
            {
                _context.Casts.Add(entity);
                await _context.SaveChangesAsync().ConfigureAwait(false);
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while adding genre {entity.CastId}.", ex);
            }
        }

        public Task DeleteAsync(string key)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Cast>> GetAllAsync()
        {
            try
            {
                return await _context.Casts.Include(x=>x.Movies).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while getting all movies.", ex);
            }
        }

        public async Task<Cast?> GetByIdAsync(string key)
        {
            try
            {
                return await _context.Casts.Include(x => x.Movies).FirstAsync(u => u.CastId == key);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while getting genre with id {key}.", ex);
            }
        }

        public Task UpdateAsync(Cast entity, string key)
        {
            throw new NotImplementedException();
        }
    }
}
