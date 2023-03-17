using Microsoft.AspNetCore.Mvc;
using WEBAPI_order_ticket.Models;
using WEBAPI_order_ticket.Repositories.GenreRepository;

namespace WEBAPI_order_ticket.Controllers;

[Route("api/")]
[ApiController]
public class GenresController : ControllerBase
{
    private readonly IGenreRepository _genreRepository;

    public GenresController(IGenreRepository genreRepository)
    {
        _genreRepository = genreRepository;
    }

    [HttpGet("genres")]
    public async Task<ActionResult<IEnumerable<Genre>>> GetAllMovie()
    {
        try
        {
            var genres = await _genreRepository.GetAllAsync();
            return Ok(genres);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpGet("genres/{id}")]
    public async Task<ActionResult<Genre>> GetMovieById([FromRoute] int id)
    {
        try
        {
            var genre = await _genreRepository.GetByIdAsync(id);
            return Ok(genre);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
    [HttpPost("genres")]
    public async Task<ActionResult<Genre>> CreateMovie(Genre genre)
    {
        try
        {
            var maxGenreId = await _genreRepository.GetMaxGenreId();
            genre.GenreId = maxGenreId + 1;
            var newGenre = await _genreRepository.AddAsync(genre);
            return CreatedAtAction(nameof(GetMovieById), new { id = newGenre.GenreId }, newGenre);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}