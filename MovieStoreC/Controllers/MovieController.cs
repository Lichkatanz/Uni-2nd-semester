using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

[ApiController]
[Route("api/movies")]
public class MovieController : ControllerBase
{
    private readonly IMovieService _movieService;

    public MovieController(IMovieService movieService)
    {
        _movieService = movieService;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetMovieAsync(int id)
    {
        var movie = await _movieService.GetMovieAsync(id);
        return Ok(movie);
    }
}
