using Biblio.Domain.Core.Models;
using Biblio.UtilityServices.Models.Common;
using Biblio.UtilityServices.Services.BiblioLending;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace NomadChat.WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BiblioLendingInfoController : ControllerBase
    {
        private readonly IBiblioLendingInfoService<BiblioLendingInfoDomain> _bookService;

        public BiblioLendingInfoController(IBiblioLendingInfoService<BiblioLendingInfoDomain> bookService)
        {
            _bookService = bookService;
        }

        [Authorize]
        [HttpGet]
        // GET: BookInfo
        public async Task<IActionResult> GetBookInfos()
        {
            return Ok(await _bookService.GetAllBookInfos());
        }

        [Authorize]
        [HttpGet("BookInfosByReaderId")]
        // GET: BookInfosByReaderId
        public async Task<IActionResult> GetBookInfosByReaderId(Guid id)
        {
            return Ok(await _bookService.GetAllBookInfosByReaderId(id));
        }

        [Authorize]
        [HttpGet("BookInfoByReaderIdAndBookId")]
        // GET: BookInfoByReaderIdAndBookId
        public async Task<IActionResult> GetBookInfoByReaderIdAndBookId([FromQuery] GetLendingInfoRequest request)
        {
            return Ok(await _bookService.GetBookInfoByReaderIdAndBookId(request));
        }

        [Authorize]
        [HttpGet("{id}")]
        // GET: BookInfo/{id}
        public async Task<IActionResult> GetBookInfoById(Guid id)
        {
            return Ok(await _bookService.GetBookInfoById(id));
        }

        [Authorize]
        [HttpPost]
        // POST: BookInfo
        public async Task<IActionResult> CreateBookInfo(BiblioLendingInfoDomain request)
        {
            return Ok(await _bookService.AddBookInfo(request));
        }

        [Authorize]
        [HttpPut]
        // PUT: BookInfo
        public async Task<IActionResult> UpdateBookInfo(BiblioLendingInfoDomain request)
        {
            return Ok(await _bookService.UpdateBookInfo(request));
        }

        [Authorize]
        [HttpDelete("{id}")]
        // DELETE: BookInfo/{id}
        public async Task<IActionResult> DeleteBook(Guid id)
        {
            return Ok(await _bookService.DeleteBookInfo(id));
        }
    }
}
