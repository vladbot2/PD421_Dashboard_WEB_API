using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PD421_Dashboard_WEB_API.DAL.Entitites;
using PD421_Dashboard_WEB_API.DAL.Repositories.Genre;

namespace PD421_Dashboard_WEB_API.Controllers
{
    public class UpdateGenreRequest
    {
        public required string Id { get; set; }
        public required string Name { get; set; }
    }

    [ApiController]
    [Route("api/genre")]
    public class GenreController : ControllerBase
    {
        private readonly IGenreRepository _genreRepository;

        public GenreController(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] string name)
        {
            var entity = new GenreEntity
            {
                Name = name,
                NormalizedName = name.ToUpper()
            };
            await _genreRepository.CreateAsync(entity);
            return Ok("Жанр успішно додано");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateGenreRequest request)
        {
            var entity = await _genreRepository.GetByIdAsync(request.Id);

            if(entity == null)
            {
                return NotFound($"Жанр '{request.Name}' не знайдено");
            }

            entity.Name = request.Name;
            entity.NormalizedName = request.Name.ToUpper();
            await _genreRepository.UpdateAsync(entity);

            return Ok("Жанр успішно змінено");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(string? id)
        {
            if(string.IsNullOrEmpty(id))
            {
                return NotFound("Не вдалося знайти жанр");
            }

            var entity = await _genreRepository.GetByIdAsync(id);

            if(entity == null)
            {
                return BadRequest($"Не вдалося знайти жанр з id '{id}'");
            }

            await _genreRepository.DeleteAsync(entity);

            return Ok($"Жанр {entity.Name} успішно видалено");
        }

        [HttpGet]
        public async Task<IActionResult> GetById(string? id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound("Не вдалося знайти жанр");
            }

            var entity = await _genreRepository.GetByIdAsync(id);

            if (entity == null)
            {
                return BadRequest($"Не вдалося знайти жанр з id '{id}'");
            }

            return Ok(entity);
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetAllAsync()
        {
            var entities = await _genreRepository.GetAll().ToListAsync();
            return Ok(entities);
        }
    }
}
