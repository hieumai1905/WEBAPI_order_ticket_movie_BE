using WEBAPI_order_ticket.Models;

namespace WEBAPI_order_ticket.Repositories.MovieRepository;

public interface IMovieRepository : IGeneralRepository<Movie, string>
{
    Task<IEnumerable<Movie>> GetMovieByNameAsync(string title);
    Task<IEnumerable<Movie>> GetMovieByGenreAsync(int genreId);
    Task<IEnumerable<Movie>> GetMovieNowShow();
    Task<IEnumerable<Movie>> GetMovieCommingShow();

    Task<IEnumerable<Movie>> GetMovieByCinema(string cinemaId);
}