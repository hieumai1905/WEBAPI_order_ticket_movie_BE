using WEBAPI_order_ticket.Models;

namespace WEBAPI_order_ticket.Repositories.CinemaRepository
{
    public interface ICinemaRepository : IGeneralRepository<Cinema, string>
    {
        Task<IEnumerable<Cinema>> GetCinemaContainName(string name);
    }
}
