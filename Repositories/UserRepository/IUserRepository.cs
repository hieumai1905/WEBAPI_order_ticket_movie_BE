using WEBAPI_order_ticket.Models;

namespace WEBAPI_order_ticket.Repositories.UserRepository
{
    public interface IUserRepository : IGeneralRepository<User, string>
    {
        Task<User?> LoginUser(User user);
        bool CheckExitsEmailAsync(string email);
    }
}