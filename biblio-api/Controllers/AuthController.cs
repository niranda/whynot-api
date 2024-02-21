using Biblio.UtilityServices.Models.Auth;
using Biblio.UtilityServices.Services.Auth;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace NomadChat.WebAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        // POST: Auth/Login
        public async Task<IActionResult> Login(AuthModel authModel)
        {
            var result = await _authService.Login(authModel);
            if (result.IsSuccess)
                HttpContext.Response.Cookies.Append("Token", result.Token, new CookieOptions() { SameSite = SameSiteMode.None, Secure = true });

            return Ok(result.ErrorMessage);
        }

        [Authorize]
        [HttpPost("Logout")]
        // POST: Auth/Logout
        public IActionResult Logout()
        {
            HttpContext.Response.Cookies.Delete("Token");

            return Ok(true);
        }
    }
}
