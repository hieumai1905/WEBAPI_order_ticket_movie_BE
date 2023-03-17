using Microsoft.EntityFrameworkCore;
using WEBAPI_order_ticket.Models;

namespace WEBAPI_order_ticket.Repositories.SchedulesRepository
{
    public class ScheduleRepository : IScheduleRepository
    {
        private OrderTicketContext _context;

        public ScheduleRepository(OrderTicketContext dbContext)
        {
            _context = dbContext;
        }
        public async Task<Schedule> AddAsync(Schedule entity)
        {
            try
            {
                _context.Schedules.Add(entity);
                await _context.SaveChangesAsync().ConfigureAwait(false);
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while adding room {entity.ScheduleId}.", ex);
            }
        }

        public Task DeleteAsync(string key)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Schedule>> GetAllAsync()
        {
            try
            {
                return await _context.Schedules.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while getting all rooms.", ex);
            }
        }

        public async Task<IEnumerable<Schedule>> GetAllScheduleByIdMovie(string idMovie)
        {
            try
            {
                var roomByIdCinemas = await _context.Schedules.Where(x => x.MovieId == idMovie).ToListAsync();
                return roomByIdCinemas;
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while find room with id cinemas {idMovie}.", ex);
            }
        }

        public async Task<Schedule?> GetByIdAsync(string key)
        {
            try
            {
                return await _context.Schedules.FirstAsync(u => u.ScheduleId == key);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while getting room with id {key}.", ex);
            }
        }

        public async Task UpdateAsync(Schedule entity, string key)
        {
            throw new NotImplementedException();
        }
    }
}
