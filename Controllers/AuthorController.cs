using LibraryManagementApi.Models;
using LibraryManagementApi.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_authorService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var author = _authorService.GetById(id);
            if (author == null) return NotFound();
            return Ok(author);
        }

        [HttpPost]
        public IActionResult Add(Author author)
        {
            _authorService.Add(author);
            return Ok("Author added successfully.");
        }

        [HttpPut]
        public IActionResult Update(Author author)
        {
            _authorService.UpdateAuthor(author);
            return Ok("Author updated successfully.");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _authorService.DeleteAuthor(id);
            return Ok("Author deleted successfully.");
        }
    }
}