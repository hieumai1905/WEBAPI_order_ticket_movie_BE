using Microsoft.EntityFrameworkCore;
using WEBAPI_order_ticket.Models;

namespace WEBAPI_order_ticket.Repositories.MovieRepository;

public class MovieRepository : IMovieRepository
{
    private readonly OrderTicketContext _context;

    public MovieRepository(OrderTicketContext dbContext)
    {
        _context = dbContext;
    }

    public async Task<IEnumerable<Movie>> GetAllAsync()
    {
        try
        {
            return await _context.Movies.ToListAsync();
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while getting all movies.", ex);
        }
    }

    public async Task<Movie?> GetByIdAsync(string key)
    {
        try
        {
            return await _context.Movies.FirstAsync(u => u.MovieId == key);
        }
        catch (Exception ex)
        {
            throw new Exception($"An error occurred while getting movie with id {key}.", ex);
        }
    }

    public async Task<Movie> AddAsync(Movie entity)
    {
        try
        {
            _context.Movies.Add(entity);
            await _context.SaveChangesAsync().ConfigureAwait(false);
            return entity;
        }
        catch (Exception ex)
        {
            throw new Exception($"An error occurred while adding movie {entity.MovieId}.", ex);
        }
    }

    public async Task UpdateAsync(Movie entity, string key)
    {
        try
        {
            var movieUpdate =
                await _context.Movies.AsNoTracking().FirstOrDefaultAsync(x => x.MovieId == entity.MovieId);
            if (movieUpdate == null)
            {
                throw new ArgumentException($"Movie with id {entity.MovieId} does not exist");
            }

            _context.Movies.Update(entity);
            await _context.SaveChangesAsync().ConfigureAwait(false);
        }
        catch (Exception ex)
        {
            throw new Exception($"An error occurred while updating movie with id {entity.MovieId}.", ex);
        }
    }

    public async Task DeleteAsync(string key)
    {
        try
        {
            var movieCurrent = await _context.Movies.FindAsync(key);
            if (movieCurrent == null)
            {
                throw new ArgumentException($"Movie with id {key} does not exist");
            }

            _context.Movies.Remove(movieCurrent);
            await _context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new Exception($"An error occurred while deleting movie with id {key}.", ex);
        }
    }

    public async Task<IEnumerable<Movie>> GetMovieByNameAsync(string name)
    {
        try
        {
            var movies = _context.Movies.Where(x => x.Title.Contains(name)).ToList();
            return movies;
        }
        catch (Exception ex)
        {
            throw new Exception($"An error occurred while getting movie with name {name}.", ex);
        }
    }

    public async Task<IEnumerable<Movie>> GetMovieByGenreAsync(int genreId)
    {
        try
        {
            var movies = _context.Movies.Where(x => x.GenreId == genreId).ToList();
            return movies;
        }
        catch (Exception ex)
        {
            throw new Exception($"An error occurred while getting movie with genre id {genreId}.", ex);
        }
    }

    public async Task<IEnumerable<Movie>> GetMovieNowShow()
    {
        try
        {
            var movies = await _context.Movies.Where(u => u.ReleasedDate <= DateTime.Now).ToListAsync();
            return movies;
        }
        catch (Exception ex)
        {
            throw new Exception($"An error occurred while getting movie now show.", ex);
        }
    }

    public async Task<IEnumerable<Movie>> GetMovieCommingShow()
    {
        try
        {
            var movies = await _context.Movies.Where(u => u.ReleasedDate > DateTime.Now).ToListAsync();
            return movies;
        }
        catch (Exception ex)
        {
            throw new Exception($"An error occurred while getting movie comming show.", ex);
        }
    }
}