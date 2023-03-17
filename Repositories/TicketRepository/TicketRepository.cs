using Microsoft.EntityFrameworkCore;
using WEBAPI_order_ticket.Models;

namespace WEBAPI_order_ticket.Repositories.TicketRepository
{
    public class TicketRepository : ITicketRepository
    {
        private OrderTicketContext _context;

        public TicketRepository(OrderTicketContext dbContext)
        {
            _context = dbContext;
        }
        public async Task<Ticket> AddAsync(Ticket entity)
        {
            try
            {
                _context.Tickets.Add(entity);
                await _context.SaveChangesAsync().ConfigureAwait(false);
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while adding room {entity.SeatId}.", ex);
            }
        }

        public Task DeleteAsync(string key)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Ticket>> GetAllAsync()
        {
            try
            {
                return await _context.Tickets.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while getting all rooms.", ex);
            }
        }

        public async Task<IEnumerable<Ticket>> GetAllByInvoiceId(string invoiceId)
        {
            try
            {
                var tickets = await _context.Tickets.Where(u => u.InvoiceId == invoiceId).ToListAsync();
                return tickets;
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while find room with id cinemas {invoiceId}.", ex);
            }
        }

        public async Task<Ticket?> GetByIdAsync(string key)
        {
            try
            {
                return await _context.Tickets.FirstAsync(u => u.TicketId == key);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while getting room with id {key}.", ex);
            }
        }

        public Task UpdateAsync(Ticket entity, string key)
        {
            throw new NotImplementedException();
        }
    }
}
