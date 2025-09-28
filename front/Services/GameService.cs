using PD421_Dashboard_WEB_API.DAL.Entities;
using PD421_Dashboard_WEB_API.DAL.Repositories;
using PD421_Dashboard_WEB_API.DTOs;
using PD421_Dashboard_WEB_API.Models;

namespace PD421_Dashboard_WEB_API.Services
{
    public class GameService
    {
        private readonly GameRepository _repo;

        public GameService(GameRepository repo)
        {
            _repo = repo;
        }

        public async Task<ServiceResponse<GameDto>> Create(CreateGameDto dto)
        {
            var game = new Game { Title = dto.Title, Genre = dto.Genre, Price = dto.Price };
            var created = await _repo.Create(game);
            return new ServiceResponse<GameDto> { Data = Map(created) };
        }

        public async Task<ServiceResponse<GameDto>> Update(UpdateGameDto dto)
        {
            var game = await _repo.GetById(dto.Id);
            if (game == null)
                return new ServiceResponse<GameDto> { Success = false, Message = "Not found" };

            game.Title = dto.Title;
            game.Genre = dto.Genre;
            game.Price = dto.Price;

            var updated = await _repo.Update(game);
            return new ServiceResponse<GameDto> { Data = Map(updated) };
        }

        public async Task<ServiceResponse<bool>> Delete(int id)
        {
            var game = await _repo.GetById(id);
            if (game == null)
                return new ServiceResponse<bool> { Success = false, Message = "Not found" };

            await _repo.Delete(game);
            return new ServiceResponse<bool> { Data = true };
        }

        public async Task<ServiceResponse<GameDto>> GetById(int id)
        {
            var game = await _repo.GetById(id);
            if (game == null)
                return new ServiceResponse<GameDto> { Success = false, Message = "Not found" };

            return new ServiceResponse<GameDto> { Data = Map(game) };
        }

        public async Task<ServiceResponse<List<GameDto>>> GetAll()
        {
            var games = await _repo.GetAll();
            return new ServiceResponse<List<GameDto>> { Data = games.Select(Map).ToList() };
        }

        public async Task<ServiceResponse<List<GameDto>>> GetByGenre(string genre)
        {
            var games = await _repo.GetByGenre(genre);
            return new ServiceResponse<List<GameDto>> { Data = games.Select(Map).ToList() };
        }

        private GameDto Map(Game g)
        {
            return new GameDto { Id = g.Id, Title = g.Title, Genre = g.Genre, Price = g.Price };
        }
    }
}
