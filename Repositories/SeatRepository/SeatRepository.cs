using Microsoft.EntityFrameworkCore;
using WEBAPI_order_ticket.Models;

namespace WEBAPI_order_ticket.Repositories.SeatRepository
{
    public class SeatRepository : ISeatRepository
    {
        private OrderTicketContext _context;

        public SeatRepository(OrderTicketContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<Seat> AddAsync(Seat entity)
        {
            try
            {
                _context.Seats.Add(entity);
                await _context.SaveChangesAsync().ConfigureAwait(false);
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while adding room {entity.SeatId}.", ex);
            }
        }

        public Task DeleteAsync(int key)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Seat>> GetAllAsync()
        {
            try
            {
                return await _context.Seats.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while getting all rooms.", ex);
            }
        }

        public async Task<IEnumerable<Seat>> GetAllAvailable(string idRoom)
        {
            try
            {
                var roomByIdCinemas = await _context.Seats.Where(x => x.Status == "AVAILABLE" && x.RoomId == idRoom).ToListAsync();
                return roomByIdCinemas;
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while get seats with available.", ex);
            }
        }

        public async Task<IEnumerable<Seat>> GetAllByIdRoom(string idRoom)
        {
            try
            {
                var roomByIdCinemas = await _context.Seats.Where(x => x.RoomId == idRoom).ToListAsync();
                return roomByIdCinemas;
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while find room with id cinemas {idRoom}.", ex);
            }
        }

        public async Task<Seat?> GetByIdAsync(int key)
        {
            try
            {
                return await _context.Seats.FirstAsync(u => u.SeatId == key);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while getting room with id {key}.", ex);
            }
        }

        public async Task UpdateAsync(Seat entity, int key)
        {
            try
            {
                var userUpdate =
                    await _context.Seats.AsNoTracking().FirstOrDefaultAsync(x => x.SeatId == entity.SeatId);
                if (userUpdate == null)
                {
                    throw new ArgumentException($"User with id {entity.SeatId} does not exist");
                }
                _context.Seats.Update(entity);
                await _context.SaveChangesAsync().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while updating room with id {entity.SeatId}.", ex);
            }
        }

        public async Task<int> GetMaxSeatId()
        {
            try
            {
                var maxId = await _context.Seats.MaxAsync(x => x.SeatId);
                return maxId;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
}
