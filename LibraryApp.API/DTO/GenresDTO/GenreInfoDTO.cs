using LibraryApp.API.Entities;

namespace LibraryApp.API.DTO.GenresDTO
{
    public class GenreInfoDTO : BaseGenreDTO
    {
        public int Id { get; set; }

        public static GenreInfoDTO FromGenre(Genre genre)
        {
            return new GenreInfoDTO()
            {
                GenreName = genre.GenreName,
                Id = genre.Id,
            };
        }
    }
}