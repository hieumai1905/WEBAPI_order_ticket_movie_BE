using Microsoft.EntityFrameworkCore;
using WEBAPI_order_ticket.Models;

namespace WEBAPI_order_ticket.Repositories.GenreRepository;

public class GenreRepository : IGenreRepository
{
    private readonly OrderTicketContext _context;

    public GenreRepository(OrderTicketContext dbContext)
    {
        _context = dbContext;
    }

    public async Task<IEnumerable<Genre>> GetAllAsync()
    {
        try
        {
            return await _context.Genres.ToListAsync();
        }
        catch (Exception ex)
        {
            throw new Exception("An error occurred while getting all movies.", ex);
        }
    }

    public async Task<Genre?> GetByIdAsync(int key)
    {
        try
        {
            return await _context.Genres.FirstAsync(u => u.GenreId == key);
        }
        catch (Exception ex)
        {
            throw new Exception($"An error occurred while getting genre with id {key}.", ex);
        }
    }

    public async Task<Genre> AddAsync(Genre entity)
    {
        try
        {
            _context.Genres.Add(entity);
            await _context.SaveChangesAsync().ConfigureAwait(false);
            return entity;
        }
        catch (Exception ex)
        {
            throw new Exception($"An error occurred while adding genre {entity.GenreId}.", ex);
        }
    }

    public Task UpdateAsync(Genre entity, int key)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int key)
    {
        throw new NotImplementedException();
    }

    public async Task<int> GetMaxGenreId()
    {
        try
        {
            var maxId = _context.Genres.Max(x => x.GenreId);
            return maxId;
        }
        catch (Exception ex)
        {
            return 0;
        }
    }
}