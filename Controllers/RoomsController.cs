using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WEBAPI_order_ticket.Models;
using WEBAPI_order_ticket.Repositories.RoomRepository;

namespace WEBAPI_order_ticket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private IRoomRepository _roomRepository;

        public RoomsController(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        [HttpGet()]
        public async Task<ActionResult<IEnumerable<Room>>> GetAllRoom()
        {
            try
            {
                var rooms = await _roomRepository.GetAllAsync();
                return Ok(rooms);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Room>> GetRoomById([FromRoute] string id)
        {
            try
            {
                var room = await _roomRepository.GetByIdAsync(id);
                return Ok(room);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost()]
        public async Task<ActionResult<Room>> CreateRoom(Room room)
        {
            try
            {
                room.RoomId = Guid.NewGuid().ToString();
                var newRoom = await _roomRepository.AddAsync(room);
                return CreatedAtAction(nameof(GetRoomById), new { id = newRoom.RoomId }, newRoom);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("cinemas/{idCinema}")]
        public async Task<ActionResult<Room>> GetRoomByIdCinema([FromRoute] string idCinema)
        {
            try
            {
                var rooms = await _roomRepository.GetAllByIdCinema(idCinema);
                return Ok(rooms);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpPut]
        public async Task<IActionResult> UpdateRoom(Room room, string id)
        {
            if (room.RoomId != id)
            {
                return BadRequest();
            }
            try
            {
                await _roomRepository.UpdateAsync(room, id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
