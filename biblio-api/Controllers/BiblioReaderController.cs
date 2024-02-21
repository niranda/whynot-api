using Biblio.Domain.Core.Models;
using Biblio.UtilityServices.Services.BiblioDiscount;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace NomadChat.WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BiblioReaderController : ControllerBase
    {
        private readonly IBiblioReaderService<BiblioReaderDomain> _bookService;

        public BiblioReaderController(IBiblioReaderService<BiblioReaderDomain> bookService)
        {
            _bookService = bookService;
        }

        [Authorize]
        [HttpGet]
        // GET: Readers
        public async Task<IActionResult> GetReaders()
        {
            return Ok(await _bookService.GetAllReaders());
        }

        [Authorize]
        [HttpGet("TopReadersByYear")]
        // GET: TopReadersByYear
        public async Task<IActionResult> GetTopReadersByYear()
        {
            return Ok(await _bookService.GetTopPopularReadersByYear());
        }

        [Authorize]
        [HttpGet("TopReadersByMonth")]
        // GET: TopReadersByMonth
        public async Task<IActionResult> GetReadersByMonth()
        {
            return Ok(await _bookService.GetTopPopularReadersByMonth());
        }

        [Authorize]
        [HttpGet("{id}")]
        // GET: Reader/{id}
        public async Task<IActionResult> GetReaderById(Guid id)
        {
            return Ok(await _bookService.GetReaderById(id));
        }

        [Authorize]
        [HttpPost]
        // POST: Reader
        public async Task<IActionResult> CreateReader(BiblioReaderDomain request)
        {
            return Ok(await _bookService.AddReader(request));
        }

        [Authorize]
        [HttpPut]
        // PUT: Reader
        public async Task<IActionResult> UpdateReader(BiblioReaderDomain request)
        {
            return Ok(await _bookService.UpdateReader(request));
        }

        [Authorize]
        [HttpDelete("{id}")]
        // DELETE: Reader/{id}
        public async Task<IActionResult> DeleteReader(Guid id)
        {
            return Ok(await _bookService.DeleteReader(id));
        }
    }
}
