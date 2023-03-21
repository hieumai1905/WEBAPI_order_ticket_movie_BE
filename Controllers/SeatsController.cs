using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WEBAPI_order_ticket.Models;
using WEBAPI_order_ticket.Repositories.SeatRepository;

namespace WEBAPI_order_ticket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeatsController : ControllerBase
    {
        private ISeatRepository _seatRepository;

        public SeatsController(ISeatRepository seatRepository)
        {
            _seatRepository = seatRepository;
        }

        [HttpGet()]
        public async Task<ActionResult<IEnumerable<Seat>>> GetAllSeat()
        {
            try
            {
                var seats = await _seatRepository.GetAllAsync();
                return Ok(seats);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Seat>> GetSeatById([FromRoute] int id)
        {
            try
            {
                var seat = await _seatRepository.GetByIdAsync(id);
                return Ok(seat);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("seats/{idRoom}")]
        public async Task<ActionResult<Seat>> GetSeatByIdRoom([FromRoute] string idRoom)
        {
            try
            {
                var seats = await _seatRepository.GetAllByIdRoom(idRoom);
                return Ok(seats);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPost()]
        public async Task<ActionResult<Seat>> CreateSeat(Seat seat)
        {
            try
            {
                var maxSeatId = await _seatRepository.GetMaxSeatId();
                seat.SeatId = maxSeatId + 1;
                var newSeat = await _seatRepository.AddAsync(seat);
                return CreatedAtAction(nameof(GetSeatById), new { id = newSeat.SeatId }, newSeat);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPut()]
        public async Task<IActionResult> UpdateSeat(Seat seat, int id)
        {
            if (seat.SeatId != id)
            {
                return BadRequest();
            }
            try
            {
                await _seatRepository.UpdateAsync(seat, id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
