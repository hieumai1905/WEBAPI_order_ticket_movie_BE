using WEBAPI_order_ticket.Models;
namespace WEBAPI_order_ticket.Repositories.SeatRepository
{
    public interface ISeatRepository : IGeneralRepository<Seat, int>
    {
        Task<IEnumerable<Seat>> GetAllByIdRoom(string idRoom);

        Task<IEnumerable<Seat>> GetAllAvailable(string idRoom);
        Task<int> GetMaxSeatId();
    }
}
    