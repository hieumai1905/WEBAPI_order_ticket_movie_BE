using Microsoft.AspNetCore.Mvc;
using WEBAPI_order_ticket.Models;
using WEBAPI_order_ticket.Repositories.MovieRepository;

namespace WEBAPI_order_ticket.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MoviesController : ControllerBase
{
    private readonly IMovieRepository _movieRepository;

    public MoviesController(IMovieRepository movieRepository)
    {
        _movieRepository = movieRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Movie>>> GetAllMovie()
    {
        try
        {
            var movies = await _movieRepository.GetAllAsync();
            return Ok(movies);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Movie>> GetMovieById([FromRoute] string id)
    {
        try
        {
            var movie = await _movieRepository.GetByIdAsync(id);
            return Ok(movie);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPost]
    public async Task<ActionResult<Movie>> CreateMovie(Movie movie)
    {
        try
        {
            movie.MovieId = Guid.NewGuid().ToString();
            var newMovie = await _movieRepository.AddAsync(movie);
            return CreatedAtAction(nameof(GetMovieById), new { id = newMovie.MovieId }, newMovie);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpGet]
    [Route("search/name")]
    public async Task<ActionResult<IEnumerable<Movie>>> GetMovieByName([FromQuery] string title)
    {
        try
        {
            var movies = await _movieRepository.GetMovieByNameAsync(title);
            return Ok(movies);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpGet]
    [Route("search/genres")]
    public async Task<ActionResult<IEnumerable<Movie>>> GetMovieByGenre([FromQuery] int genreId)
    {
        try
        {
            var movies = await _movieRepository.GetMovieByGenreAsync(genreId);
            return Ok(movies);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}