using WEBAPI_order_ticket.Models;

namespace WEBAPI_order_ticket.Repositories.TicketRepository
{
    public interface ITicketRepository : IGeneralRepository<Ticket, string>
    {
        Task<IEnumerable<Ticket>> GetAllByInvoiceId(string invoiceId);
    }
}
