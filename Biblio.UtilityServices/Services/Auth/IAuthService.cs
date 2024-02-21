using Biblio.UtilityServices.Models.Auth;

namespace Biblio.UtilityServices.Services.Auth
{
    public interface IAuthService
    {
        Task<AuthResultModel> Login(AuthModel authModel);
    }
}
