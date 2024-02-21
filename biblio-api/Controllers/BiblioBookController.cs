using Biblio.Domain.Core.Models;
using Biblio.UtilityServices.Services.BiblioBook;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace NomadChat.WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BiblioBookController : ControllerBase
    {
        private readonly IBiblioBookService<BiblioBookDomain> _bookService;

        public BiblioBookController(IBiblioBookService<BiblioBookDomain> bookService)
        {
            _bookService = bookService;
        }

        [Authorize]
        [HttpGet]
        // GET: Book
        public async Task<IActionResult> GetBooks()
        {
            return Ok(await _bookService.GetAllBooks());
        }

        [Authorize]
        [HttpGet("TopBooksByYear")]
        // GET: TopBooksByYear
        public async Task<IActionResult> GetTopBooksByYear()
        {
            return Ok(await _bookService.GetTopPopularBooksByYear());
        }

        [Authorize]
        [HttpGet("TopBooksByMonth")]
        // GET: TopBooksByMonth
        public async Task<IActionResult> GetTopBooksByMonth()
        {
            return Ok(await _bookService.GetTopPopularBooksByMonth());
        }

        [Authorize]
        [HttpGet("{id}")]
        // GET: Book/{id}
        public async Task<IActionResult> GetBookById(Guid id)
        {
            return Ok(await _bookService.GetBookById(id));
        }

        [Authorize]
        [HttpPost]
        // POST: Book
        public async Task<IActionResult> CreateBook(BiblioBookDomain request)
        {
            return Ok(await _bookService.AddBook(request));
        }

        [Authorize]
        [HttpPut]
        // PUT: Book
        public async Task<IActionResult> UpdateBook(BiblioBookDomain request)
        {
            return Ok(await _bookService.UpdateBook(request));
        }

        [Authorize]
        [HttpDelete("{id}")]
        // DELETE: Book/{id}
        public async Task<IActionResult> DeleteBook(Guid id)
        {
            return Ok(await _bookService.DeleteBook(id));
        }
    }
}
