using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using P06Shop.Shared;
using P06Shop.Shared.Services.FilmService;
using P06Shop.Shared.Shop;

namespace P05Shop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmController : Controller
    {
        private readonly IFilmService _filmService;
        private readonly ILogger<FilmController> _logger;
        public FilmController(IFilmService filmService, ILogger<FilmController> logger)
        {
            _filmService = filmService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<Film>>>> GetFilms()
        {
            _logger.Log(LogLevel.Information, "Invoked GetFilms Method in controller");

            var result = await _filmService.GetFilmsAsync();

            if (result.Success)
                return Ok(result);
            else
                return  StatusCode(500, $"Internal server error {result.Message}");
        }

        [HttpGet("search/{text}/{page}/{pageSize}")]
        [HttpGet("search/{page}/{pageSize}")]
        public async Task<ActionResult<ServiceResponse<List<Film>>>> SearchFilms(string? text=null, int page=1, int pageSize=10)
        {
            _logger.Log(LogLevel.Information, "Invoked GetFilms Method in controller");

            var result = await _filmService.SearchFilmsAsync(text,page,pageSize);

            if (result.Success)
                return Ok(result);
            else
                return StatusCode(500, $"Internal server error {result.Message}");
        }


        // http:localhost/api/film/4 dla api REST
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<Film>>> GetFilm(int id)
        {
          
            var result = await _filmService.GetFilmByIdAsync(id);

            if (result.Success)
                return Ok(result);
            else
                return StatusCode(500, $"Internal server error {result.Message}");
        }


        [HttpPut]
        public async Task<ActionResult<ServiceResponse<Film>>> UpdateFilm([FromBody] Film film)
        {
            
            var result = await _filmService.UpdateFilmAsync(film);

            if (result.Success)
                return Ok(result);
            else
                return StatusCode(500, $"Internal server error {result.Message}");
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<Film>>> CreateFilm([FromBody] Film film)
        {
            var result = await _filmService.CreateFilmAsync(film);

            if (result.Success)
                return Ok(result);
            else
                return StatusCode(500, $"Internal server error {result.Message}");
        }

        // http:localhost/api/film/delete?id=4
        // http:localhost/api/film/4 dla api REST
        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceResponse<bool>>> DeleteFilm([FromRoute] int id)
        {
            var result = await _filmService.DeleteFilmAsync(id);

            if (result.Success)
                return Ok(result);
            else
                return StatusCode(500, $"Internal server error {result.Message}");
        }



    }
}
