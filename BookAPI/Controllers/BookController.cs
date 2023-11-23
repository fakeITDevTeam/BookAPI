using BookAPI.Services.BookService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        //public async Task<IActionResult> GetAllBooks()
        public async Task<ActionResult<List<Book>>> GetAllBooks()
        {            
            //var result  = _bookService.GetAllBooks();
            
            //return Ok(result);

            return await _bookService.GetAllBooks();
        }

        [HttpGet("{id}")]        
        public async Task<ActionResult<Book>> GetBookById(int id)
        {
            var result = await _bookService.GetBookById(id);

            if (result == null)
                return NotFound("Book not found");

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<Book>>> AddBook(Book book)
        {
            var result = await _bookService.AddBook(book);

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Book>>> UpdateBook(int id, Book request)
        {
            var result = await _bookService.UpdateBook(id, request);

            if (result == null)
                return NotFound("Book not found");

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Book>>> DeleteBook(int id)
        {
            var result = await _bookService.DeleteBook(id);

            if (result == null)
                return NotFound("Book not found");

            return Ok(result);
        }
    }
}
