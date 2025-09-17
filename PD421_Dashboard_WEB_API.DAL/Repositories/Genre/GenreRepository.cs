using PD421_Dashboard_WEB_API.DAL.Entitites;

namespace PD421_Dashboard_WEB_API.DAL.Repositories.Genre
{
    public class GenreRepository
        : GenericRepository<GenreEntity, string>, IGenreRepository
    {
        public GenreRepository(AppDbContext context)
            : base(context) { }
    }
}
