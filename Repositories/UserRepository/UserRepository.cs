using Microsoft.EntityFrameworkCore;
using WEBAPI_order_ticket.Models;

namespace WEBAPI_order_ticket.Repositories.UserRepository
{
    public class UserRepository : IUserRepository
    {
        private readonly OrderTicketContext _context;

        public UserRepository(OrderTicketContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<User> AddAsync(User entity)
        {
            try
            {
                _context.Users.Add(entity);
                await _context.SaveChangesAsync().ConfigureAwait(false);
                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while adding user {entity.UserId}.", ex);
            }
        }

        public async Task DeleteAsync(string key)
        {
            try
            {
                var userDelete = await _context.Users.FindAsync(key);
                if (userDelete == null)
                {
                    throw new ArgumentException($"User with id {key} does not exist");
                }

                _context.Users.Remove(userDelete);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while deleting user with id {key}.", ex);
            }
        }

        public async Task<User> LoginUser(User user)
        {
            try
            {
                var userCurrent =
                    _context.Users.First(x =>
                        (x.Email == user.Email && x.Password == user.Password) ||
                        (x.Phone == user.Phone && x.Password == user.Password));
                return userCurrent;
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while finding user with Email {user.Email}.", ex);
            }
        }


        public async Task<User?> GetByIdAsync(string key)
        {
            try
            {
                return await _context.Users.FirstAsync(u => u.UserId == key);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while getting user with id {key}.", ex);
            }
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            try
            {
                return await _context.Users.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while getting all users.", ex);
            }
        }

        public async Task UpdateAsync(User entity, string key)
        {
            try
            {
                var userUpdate =
                    await _context.Users.AsNoTracking().FirstOrDefaultAsync(x => x.UserId == entity.UserId);
                if (userUpdate == null)
                {
                    throw new ArgumentException($"User with id {entity.UserId} does not exist");
                }

                _context.Users.Update(entity);
                await _context.SaveChangesAsync().ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while updating user with id {entity.UserId}.", ex);
            }
        }
    }
}