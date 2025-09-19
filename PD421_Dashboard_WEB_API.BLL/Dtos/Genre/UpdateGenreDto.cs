using System.ComponentModel.DataAnnotations;

namespace PD421_Dashboard_WEB_API.BLL.Dtos.Genre
{
    public class UpdateGenreDto // PUT
    {
        [Required]
        public required string Id { get; set; }
        [Required]
        public required string Name { get; set; }
    }
}
