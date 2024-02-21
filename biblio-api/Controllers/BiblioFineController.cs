using Biblio.Domain.Core.Models;
using Biblio.UtilityServices.Services.BiblioFine;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace NomadChat.WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BiblioFineController : ControllerBase
    {
        private readonly IBiblioFineService<BiblioFineDomain> _bookService;

        public BiblioFineController(IBiblioFineService<BiblioFineDomain> bookService)
        {
            _bookService = bookService;
        }

        [Authorize]
        [HttpGet]
        // GET: Fine
        public async Task<IActionResult> GetFines()
        {
            return Ok(await _bookService.GetAllFines());
        }

        [Authorize]
        [HttpGet("{id}")]
        // GET: Fine/{id}
        public async Task<IActionResult> GetFineById(Guid id)
        {
            return Ok(await _bookService.GetFineById(id));
        }

        [Authorize]
        [HttpPost]
        // POST: Fine
        public async Task<IActionResult> CreateFine(BiblioFineDomain request)
        {
            return Ok(await _bookService.AddFine(request));
        }

        [Authorize]
        [HttpPut]
        // PUT: Fine
        public async Task<IActionResult> UpdateFine(BiblioFineDomain request)
        {
            return Ok(await _bookService.UpdateFine(request));
        }

        [Authorize]
        [HttpDelete("{id}")]
        // DELETE: Fine/{id}
        public async Task<IActionResult> DeleteFine(Guid id)
        {
            return Ok(await _bookService.DeleteFine(id));
        }
    }
}
