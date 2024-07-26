using LibraryApp.API.Context;
using LibraryApp.API.DTO.AuthorsDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly LibraryContext context;


        public AuthorController(LibraryContext context)
        {
            this.context = context;
        }
        [HttpPost]
        public IActionResult Post([FromBody] AddAuthorsDTO author) 
        {
            var response = context.Authors.Add(author.ToAuthor());
            context.SaveChanges();

            return Ok(AuthorInfoDTO.FromAuthor(response.Entity));
        }

        [HttpPut]
        public IActionResult Put(EditAuthorDTO authorDTO)
        {
            int id = authorDTO.Id;
            string name = authorDTO.FirstName;
            string lname = authorDTO.LastName;

            var author = context.Authors.FirstOrDefault(x => x.Id == id);
            if (author is null) { return NotFound(); }
            author.FirstName = name;
            author.LastName = lname;

            context.SaveChanges();
            return Ok(AuthorInfoDTO.FromAuthor(author));
        }

        [HttpGet]
        public IActionResult Get(int id)
        {
            var author = context.Authors.FirstOrDefault(x => x.Id == id && !x.isDeleted);
            if (author == null) return NotFound();

            return Ok(AuthorInfoDTO.FromAuthor(author));
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var author = context.Authors.FirstOrDefault(x => x.Id == id);
            if (author == null) return NotFound();
            author.isDeleted = true;

            context.SaveChanges();

            return NoContent();
        }

        [HttpGet]
        [Route("list")]
        public IActionResult GetAll()
        {

            var author = context.Authors.Where(x => !x.isDeleted).ToList();
            if (author == null) return NotFound();

            List<AuthorInfoDTO> listDTO = new List<AuthorInfoDTO>();

            author.ForEach(x => listDTO.Add(AuthorInfoDTO.FromAuthor(x)));

            return Ok(listDTO);

        }

    }
}
