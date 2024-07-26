using LibraryApp.API.Entities;

namespace LibraryApp.API.DTO.AuthorsDTO
{
    public class AuthorInfoDTO : BaseAuthorDTO
    {
        public int Id { get; set; }

        public static AuthorInfoDTO FromAuthor(Author author)
        {
            return new AuthorInfoDTO
            {
                Id = author.Id,
                FirstName = author.FirstName,
                LastName = author.LastName,
            };
            
        }
    }
}
