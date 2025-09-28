using Microsoft.AspNetCore.Mvc;
using PD421_Dashboard_WEB_API.DTOs;
using PD421_Dashboard_WEB_API.Services;

namespace PD421_Dashboard_WEB_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GameController : ControllerBase
    {
        private readonly GameService _service;

        public GameController(GameService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateGameDto dto)
        {
            var res = await _service.Create(dto);
            if (!res.Success) return BadRequest(res.Message);
            return Ok(res.Data);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateGameDto dto)
        {
            var res = await _service.Update(dto);
            if (!res.Success) return NotFound(res.Message);
            return Ok(res.Data);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var res = await _service.Delete(id);
            if (!res.Success) return NotFound(res.Message);
            return Ok(res.Data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var res = await _service.GetById(id);
            if (!res.Success) return NotFound(res.Message);
            return Ok(res.Data);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var res = await _service.GetAll();
            return Ok(res.Data);
        }

        [HttpGet("genre/{genre}")]
        public async Task<IActionResult> GetByGenre(string genre)
        {
            var res = await _service.GetByGenre(genre);
            return Ok(res.Data);
        }
    }
}
