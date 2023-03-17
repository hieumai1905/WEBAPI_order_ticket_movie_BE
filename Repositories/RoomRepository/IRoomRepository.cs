using WEBAPI_order_ticket.Models;
namespace WEBAPI_order_ticket.Repositories.RoomRepository
{
    public interface IRoomRepository : IGeneralRepository<Room, string>
    {
        Task<IEnumerable<Room>> GetAllByIdCinema(string idCinema);
    }
}
