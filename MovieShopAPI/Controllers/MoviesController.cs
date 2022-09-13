using ApplicationCore.Contracts.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MovieShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;
        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        [Route("top-grossing")]
        public async Task<IActionResult> GetTop30GrossingMovies()
        {
            var movies = await _movieService.GetTop30GrossingMovies();

            if(movies == null || !movies.Any())
            {
                return NotFound(new {errorMessage = "No Movies Found."});
            }

            return Ok(movies);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetMovie(int id)
        {
            var movie = await _movieService.GetMovieDetails(id);
            if(movie == null)
            {
                return NotFound(new {errorMessage = "No Movie found for {id}" });
            }

            return Ok(movie);
        }

        [HttpGet]
        [Route("genre/{genreId:int}")]
        public async Task<IActionResult> GetByGenre(int id)
        {
            var movie = await _movieService.GetMoviesByPagination(id);
            if (movie == null)
            {
                return NotFound(new { errorMessage = "No Movie found for {id}" });
            }

            return Ok(movie);
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllMovies()
        {
            var movie = await _movieService.GetMoviesByPagination(1);
            if (movie == null)
            {
                return NotFound(new { errorMessage = "No Movie found for {id}" });
            }

            return Ok(movie);
        }
    }

}
