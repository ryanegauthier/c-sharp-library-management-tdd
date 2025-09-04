using Microsoft.AspNetCore.Mvc;
using LMS.BusinessLogic;

namespace LMS.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly BookRepository _bookRepository;

        public BooksController(BookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        // GET: api/books
        [HttpGet]
        public ActionResult<IEnumerable<Book>> GetBooks()
        {
            var books = _bookRepository.GetAllBooks();
            return Ok(books);
        }

        // GET: api/books/{isbn}
        [HttpGet("{isbn}")]
        public ActionResult<Book> GetBook(string isbn)
        {
            var book = _bookRepository.GetBookByIsbn(isbn);
            
            if (book == null)
            {
                return NotFound($"Book with ISBN {isbn} not found.");
            }

            return Ok(book);
        }

        // POST: api/books
        [HttpPost]
        public ActionResult<Book> CreateBook([FromBody] Book book)
        {
            if (book == null)
            {
                return BadRequest("Book data is required.");
            }

            if (string.IsNullOrWhiteSpace(book.Isbn))
            {
                return BadRequest("ISBN is required.");
            }

            // Check if book already exists
            if (_bookRepository.HasBook(book.Isbn))
            {
                return Conflict($"Book with ISBN {book.Isbn} already exists.");
            }

            _bookRepository.AddBook(book);
            
            return CreatedAtAction(nameof(GetBook), new { isbn = book.Isbn }, book);
        }

        // DELETE: api/books/{isbn}
        [HttpDelete("{isbn}")]
        public ActionResult DeleteBook(string isbn)
        {
            if (!_bookRepository.HasBook(isbn))
            {
                return NotFound($"Book with ISBN {isbn} not found.");
            }

            _bookRepository.RemoveBook(isbn);
            
            return NoContent();
        }

        // GET: api/books/count
        [HttpGet("count")]
        public ActionResult<int> GetBookCount()
        {
            return Ok(_bookRepository.GetBookCount());
        }

        // GET: api/books/exists/{isbn}
        [HttpGet("exists/{isbn}")]
        public ActionResult<bool> BookExists(string isbn)
        {
            return Ok(_bookRepository.HasBook(isbn));
        }
    }
}
