using Microsoft.EntityFrameworkCore;
using WEBAPI_order_ticket.Models;

namespace WEBAPI_order_ticket.Repositories.RoomRepository
{
    public class RoomRepository : IRoomRepository
    {
        private OrderTicketContext _context;

        public RoomRepository(OrderTicketContext dbContext)
        {
            _context = dbContext;
        }
        public async Task<Room> AddAsync(Room entity)
        {
            try
            {
                _context.Rooms.Add(entity);
                await _context.SaveChangesAsync().ConfigureAwait(false);
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while adding room {entity.RoomId}.", ex);
            }
        }

        public Task DeleteAsync(string key)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Room>> GetAllAsync()
        {
            try
            {
                return await _context.Rooms.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while getting all rooms.", ex);
            }
        }

        public async Task<IEnumerable<Room>> GetAllByIdCinema(string idCinema)
        {
            try
            {
                var roomByIdCinemas = await _context.Rooms.Where(x => x.IdCinema == idCinema).ToListAsync();
                return roomByIdCinemas;
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while find room with id cinemas {idCinema}.", ex);
            }
        }

        public async Task<Room?> GetByIdAsync(string key)
        {
            try
            {
                return await _context.Rooms.FirstAsync(u => u.RoomId == key);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while getting room with id {key}.", ex);
            }
        }

        public async Task UpdateAsync(Room entity, string key)
        {
            try
            {
                var userUpdate =
                    await _context.Rooms.AsNoTracking().FirstOrDefaultAsync(x => x.RoomId == entity.RoomId);
                if (userUpdate == null)
                {
                    throw new ArgumentException($"User with id {entity.RoomId} does not exist");
                }
                _context.Rooms.Update(entity);
                await _context.SaveChangesAsync().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while updating room with id {entity.RoomId}.", ex);
            }
        }
    }
}
