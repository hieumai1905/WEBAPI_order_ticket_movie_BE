using WEBAPI_order_ticket.Models;

namespace WEBAPI_order_ticket.Repositories.InvoicesRepository
{
    public interface IInvoiceRepository : IGeneralRepository<Invoice, string>
    {
        Task<IEnumerable<Invoice>> GetAllInvoiceByIdUser(String idUser);
    }
}
