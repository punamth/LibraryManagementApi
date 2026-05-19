using LibraryManagementApi.Models;
using LibraryManagementApi.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_bookService.GetAllBooks());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var book = _bookService.GetBookById(id);
            if (book == null) return NotFound();
            return Ok(book);
        }

        [HttpPost]
        public IActionResult Add(Book book)
        {
            _bookService.AddBook(book);
            return Ok("Book added successfully.");
        }

        [HttpPut]
        public IActionResult Update(Book book)
        {
            _bookService.UpdateBook(book);
            return Ok("Book updated successfully.");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _bookService.DeleteBook(id);
            return Ok("Book deleted successfully.");
        }
    }
}