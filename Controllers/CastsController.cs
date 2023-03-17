using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WEBAPI_order_ticket.Repositories.GenreRepository;
using WEBAPI_order_ticket.Repositories.CastRepository;
using WEBAPI_order_ticket.Models;

namespace WEBAPI_order_ticket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CastsController : ControllerBase
    {
        private readonly ICastRepository _castRepository;

        public CastsController(ICastRepository castRepository)
        {
            _castRepository = castRepository;
        }

        [HttpGet()]
        public async Task<ActionResult<IEnumerable<Cast>>> GetAllCast()
        {
            try
            {
                var casts = await _castRepository.GetAllAsync();
                return Ok(casts);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Cast>> GetCastById([FromRoute] string id)
        {
            try
            {
                var cast = await _castRepository.GetByIdAsync(id);
                return Ok(cast);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost()]
        public async Task<ActionResult<Cast>> CreateCast(Cast cast)
        {
            try
            {
                cast.CastId = Guid.NewGuid().ToString();
                var newCast = await _castRepository.AddAsync(cast);
                return CreatedAtAction(nameof(GetCastById), new { id = newCast.CastId }, newCast);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
