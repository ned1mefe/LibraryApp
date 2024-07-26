using LibraryApp.API.Entities;

namespace LibraryApp.API.DTO.GenresDTO
{
    public class AddGenreDTO : BaseGenreDTO
    {
        public Genre ToGenre()
        {
            return new Genre()
            {
                GenreName = this.GenreName,
            };
        }
    }
}