using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WEBAPI_order_ticket.Models;
using WEBAPI_order_ticket.Repositories.SchedulesRepository;

namespace WEBAPI_order_ticket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchedulesController : ControllerBase
    {

        private IScheduleRepository _scheduleRepository;

        public SchedulesController(IScheduleRepository scheduleRepository)
        {
            _scheduleRepository = scheduleRepository;
        }

        [HttpGet()]
        public async Task<ActionResult<IEnumerable<Schedule>>> GetAllSchedule()
        {
            try
            {
                var schedules = await _scheduleRepository.GetAllAsync();
                return Ok(schedules);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Schedule>> GetScheduleById([FromRoute] string id)
        {
            try
            {
                var schedule = await _scheduleRepository.GetByIdAsync(id);
                return Ok(schedule);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("movies/{idMovie}")]
        public async Task<ActionResult<Schedule>> GetScheduleByIdCinema([FromRoute] string idMovie)
        {
            try
            {
                var schedules = await _scheduleRepository.GetAllScheduleByIdMovie(idMovie);
                return Ok(schedules);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost()]
        public async Task<ActionResult<Schedule>> CreateSchedule(Schedule schedule)
        {
            try
            {
                schedule.ScheduleId = Guid.NewGuid().ToString();
                var newSchedule = await _scheduleRepository.AddAsync(schedule);
                return CreatedAtAction(nameof(GetScheduleById), new { id = newSchedule.ScheduleId }, newSchedule);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
