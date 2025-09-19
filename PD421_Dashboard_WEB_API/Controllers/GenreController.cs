using Microsoft.AspNetCore.Mvc;
using PD421_Dashboard_WEB_API.BLL.Dtos.Genre;
using PD421_Dashboard_WEB_API.BLL.Services.Genre;

namespace PD421_Dashboard_WEB_API.Controllers
{
    [ApiController]
    [Route("api/genre")]
    public class GenreController : ControllerBase
    {
        private readonly IGenreService _genreService;

        public GenreController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] CreateGenreDto dto)
        {
            var response = await _genreService.CreateAsync(dto);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateGenreDto dto)
        {
            var response = await _genreService.UpdateAsync(dto);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(string? id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest("Id не вказано");
            }

            var response = await _genreService.DeleteAsync(id);
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetById(string? id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return BadRequest("Id не вказано");
            }

            var response = await _genreService.GetByIdAsync(id);
            return Ok(response);
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetAllAsync()
        {
            var response = await _genreService.GetAllAsync();
            return Ok(response);
        }
    }
}
