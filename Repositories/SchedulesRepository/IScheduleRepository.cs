using WEBAPI_order_ticket.Models;
namespace WEBAPI_order_ticket.Repositories.SchedulesRepository
{
    public interface IScheduleRepository : IGeneralRepository<Schedule, string>
    {
        Task<IEnumerable<Schedule>> GetAllScheduleByIdMovie(string idMovie);
    }
}
