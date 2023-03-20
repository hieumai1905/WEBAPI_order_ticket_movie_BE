using Microsoft.EntityFrameworkCore;
using WEBAPI_order_ticket.Models;

namespace WEBAPI_order_ticket.Repositories.CinemaRepository
{
    public class CinemaRepository : ICinemaRepository
    {

        private OrderTicketContext _context;

        public CinemaRepository(OrderTicketContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<Cinema> AddAsync(Cinema entity)
        {
            try
            {
                _context.Cinemas.Add(entity);
                await _context.SaveChangesAsync().ConfigureAwait(false);
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while adding genre {entity.IdCinema}.", ex);
            }
        }

        public Task DeleteAsync(string key)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Cinema>> GetAllAsync()
        {
            try
            {
                return await _context.Cinemas.Include(x => x.Movies).ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while getting all movies.", ex);
            }
        }

        public async Task<Cinema?> GetByIdAsync(string key)
        {
            try
            {
                return await _context.Cinemas.Include(x => x.Movies).FirstAsync(u => u.IdCinema == key);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while getting genre with id {key}.", ex);
            }
        }

        public async Task<IEnumerable<Cinema>> GetCinemaByCity(string cityName)
        {
            try
            {
                var cinemas = await _context.Cinemas.Include(x => x.Movies).Where(x => x.AddressCinema.Contains(cityName)).ToListAsync();
                return cinemas;
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while getting cinema at city {cityName}.", ex);
            }
        }

        public async Task<IEnumerable<Cinema>> GetCinemaContainName(string name)
        {
            try
            {
                var cinemas = await _context.Cinemas.Include(x => x.Movies).Where(x => x.NameCinema.Contains(name)).ToListAsync();
                return cinemas;
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while getting genre with id {name}.", ex);
            }
        }

        public async Task<IEnumerable<Cinema>> GetCinemaShowMovie(string idMovie)
        {
            try
            {
                var cinemas = await _context.Cinemas.Include(x => x.Movies).Where(x => x.Movies.Any(y => y.MovieId == idMovie)).ToListAsync();
                return cinemas;
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while getting cineme show movie.", ex);
            }
        }

        public Task UpdateAsync(Cinema entity, string key)
        {
            throw new NotImplementedException();
        }
    }
}
