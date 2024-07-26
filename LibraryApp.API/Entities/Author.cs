namespace LibraryApp.API.Entities
{
    public class Author : Citizen
    {
        public ICollection<Book> Books { get; set; }
    }
}
