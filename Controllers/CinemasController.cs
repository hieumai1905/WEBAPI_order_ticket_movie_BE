using Microsoft.AspNetCore.Mvc;
using WEBAPI_order_ticket.Models;
using WEBAPI_order_ticket.Repositories.CinemaRepository;

namespace WEBAPI_order_ticket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CinemasController : ControllerBase
    {
        private readonly ICinemaRepository _cinemaRepository;

        public CinemasController(ICinemaRepository cinemaRepository)
        {
            _cinemaRepository = cinemaRepository;
        }

        [HttpGet()]
        public async Task<ActionResult<IEnumerable<Cast>>> GetAllCinema()
        {
            try
            {
                var cinemass = await _cinemaRepository.GetAllAsync();
                return Ok(cinemass);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Cinema>> GetCinemaById([FromRoute] string id)
        {
            try
            {
                var cinemas = await _cinemaRepository.GetByIdAsync(id);
                return Ok(cinemas);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("search/name")]
        public async Task<ActionResult<Cinema>> GetCinemaContainName([FromQuery] string q)
        {
            try
            {
                var cinemas = await _cinemaRepository.GetAllAsync();
                return Ok(cinemas);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("search/cities")]
        public async Task<ActionResult<Cinema>> GetCinemaInCity([FromQuery] string city)
        {
            try
            {
                var cinemas = await _cinemaRepository.GetCinemaByCity(city);
                return Ok(cinemas);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet("movies")]
        public async Task<ActionResult<Cinema>> GetCinemaShowMovie([FromQuery] string id)
        {
            try
            {
                var cinemas = await _cinemaRepository.GetCinemaShowMovie(id);
                return Ok(cinemas);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost()]
        public async Task<ActionResult<Cinema>> CreateCinema(Cinema cinemas)
        {
            try
            {
                cinemas.IdCinema = Guid.NewGuid().ToString();
                var newCinema = await _cinemaRepository.AddAsync(cinemas);
                return CreatedAtAction(nameof(GetCinemaById), new { id = newCinema.IdCinema }, newCinema);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
