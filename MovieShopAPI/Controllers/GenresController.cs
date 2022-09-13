using ApplicationCore.Contracts.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MovieShopAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly IGenreService _genreService;
        public GenresController(IGenreService genreService)
        {
            _genreService = genreService;
        }
        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetGenres()
        {
            var genre = await _genreService.GetAllGenres();
            if (genre == null)
            {
                return NotFound(new { errorMessage = "No Genres found.}" });
            }

            return Ok(genre);
        }
    }
}
