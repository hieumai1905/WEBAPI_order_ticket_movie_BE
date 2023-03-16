using WEBAPI_order_ticket.Models;

namespace WEBAPI_order_ticket.Repositories.GenreRepository;

public interface IGenreRepository: IGeneralRepository<Genre, int>
{
    Task<int> GetMaxGenreId();
}