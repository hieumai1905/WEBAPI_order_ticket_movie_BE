using WEBAPI_order_ticket.Models;
namespace WEBAPI_order_ticket.Repositories.CastRepository
{
    public interface ICastRepository : IGeneralRepository<Cast, string>
    {
        Task<IEnumerable<Cast>> getCastsInMovie(String movieId);
    }
}
