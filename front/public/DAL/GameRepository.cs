using Microsoft.EntityFrameworkCore;

namespace PD421_Dashboard_WEB_API.DAL
{
    public class GameRepository
    {
        private readonly AppDbContext _context;

        public GameRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Game> Create(Game game)
        {
            _context.Games.Add(game);
            await _context.SaveChangesAsync();
            return game;
        }

        public async Task<Game> Update(Game game)
        {
            _context.Games.Update(game);
            await _context.SaveChangesAsync();
            return game;
        }

        public async Task Delete(Game game)
        {
            _context.Games.Remove(game);
            await _context.SaveChangesAsync();
        }

        public async Task<Game> GetById(int id)
        {
            return await _context.Games.FindAsync(id);
        }

        public async Task<List<Game>> GetAll()
        {
            return await _context.Games.ToListAsync();
        }

        public async Task<List<Game>> GetByGenre(string genre)
        {
            return await _context.Games.Where(x => x.Genre == genre).ToListAsync();
        }
    }
}
