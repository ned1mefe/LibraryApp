using LibraryApp.API.Entities;

namespace LibraryApp.API.DTO.PublisherDTO
{
    public class AddPublisherDTO : BasePublisherDTO
    {
        public Publisher ToPublisher()
        {
            return new Publisher()
            {
                PublisherName = this.PublisherName,
            };
        }
    }
}
