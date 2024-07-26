using LibraryApp.API.Entities;

namespace LibraryApp.API.DTO.AuthorsDTO
{
    public class AddAuthorsDTO : BaseAuthorDTO
    {
        public Author ToAuthor()
        {
            return new Author()
            {
                FirstName = this.FirstName,
                LastName = this.LastName,
            };
        }
    }
}
