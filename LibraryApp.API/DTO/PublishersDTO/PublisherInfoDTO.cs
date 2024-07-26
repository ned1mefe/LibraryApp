using LibraryApp.API.Entities;

namespace LibraryApp.API.DTO.PublisherDTO
{
    public class PublisherInfoDTO : BasePublisherDTO
    {
        public int Id { get; set; }

        public static PublisherInfoDTO FromPublisher(Publisher publisher)
        {
            return new PublisherInfoDTO
            {
                Id = publisher.Id,
                PublisherName = publisher.PublisherName,
            };
        }
    }
}
