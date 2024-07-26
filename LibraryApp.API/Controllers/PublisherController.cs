using LibraryApp.API.Context;
using LibraryApp.API.DTO.PublisherDTO;
using LibraryApp.API.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        private readonly LibraryContext context;

        public PublisherController(LibraryContext context) 
        {
            this.context = context;
        }

        [HttpPost]
        public IActionResult Post([FromBody] AddPublisherDTO publisher)
        {
            var response = context.Publishers.Add(publisher.ToPublisher());
            context.SaveChanges();

            return Ok(PublisherInfoDTO.FromPublisher(response.Entity));
        }

        [HttpPut]
        public IActionResult Put(EditPublisherDTO publisherDTO)
        {
            int id = publisherDTO.Id;
            string pname = publisherDTO.PublisherName;

            var publisher = context.Publishers.FirstOrDefault(x => x.Id == id);
            if (publisher is null) { return NotFound(); }
            publisher.PublisherName = pname;

            context.SaveChanges();
            return Ok(PublisherInfoDTO.FromPublisher(publisher));
        }

        [HttpGet]
        public IActionResult Get(int id)
        {
            var publisher = context.Publishers.FirstOrDefault(x => x.Id == id && !x.isDeleted);
            if (publisher == null) return NotFound();

            return Ok(PublisherInfoDTO.FromPublisher(publisher));
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var publisher = context.Publishers.FirstOrDefault(x => x.Id == id);
            if (publisher == null) return NotFound();
            publisher.isDeleted = true;

            context.SaveChanges();

            return NoContent();
        }

        [HttpGet]
        [Route("list")]
        public IActionResult GetAll()
        {
            var publisher = context.Publishers.Where(x => !x.isDeleted).ToList();
            if (publisher == null) return NotFound();

            List<PublisherInfoDTO> listDTO = new List<PublisherInfoDTO>();

            publisher.ForEach(x => listDTO.Add(PublisherInfoDTO.FromPublisher(x)));

            return Ok(listDTO);
        }
    }
}
