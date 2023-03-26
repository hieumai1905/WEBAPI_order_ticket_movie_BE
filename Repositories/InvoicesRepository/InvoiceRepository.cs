using Microsoft.EntityFrameworkCore;
using WEBAPI_order_ticket.Models;

namespace WEBAPI_order_ticket.Repositories.InvoicesRepository
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private OrderTicketContext _context;

        public InvoiceRepository(OrderTicketContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<Invoice> AddAsync(Invoice entity)
        {
            try
            {
                _context.Invoices.Add(entity);
                await _context.SaveChangesAsync().ConfigureAwait(false);
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while adding genre {entity.InvoiceId}.", ex);
            }
        }

        public async Task DeleteAsync(string key)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Invoice>> GetAllAsync()
        {
            try
            {
                return await _context.Invoices.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while getting all movies.", ex);
            }
        }

        public async Task<IEnumerable<Invoice>> GetAllInvoiceByIdUser(string idUser)
        {
            try
            {
                var roomByIdCinemas =
                    await _context.Invoices.Where(x => x.UserId == idUser).OrderBy(x => x.CreateAt).ToListAsync();
                return roomByIdCinemas;
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while find room with id cinemas {idUser}.", ex);
            }
        }

        public async Task<Invoice?> GetByIdAsync(string key)
        {
            try
            {
                return await _context.Invoices.FirstAsync(u => u.InvoiceId == key);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while getting genre with id {key}.", ex);
            }
        }

        public async Task UpdateAsync(Invoice entity, string key)
        {
            throw new NotImplementedException();
        }
    }
}