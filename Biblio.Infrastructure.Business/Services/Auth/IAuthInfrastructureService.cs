using Biblio.UtilityServices.Models.Auth;

namespace Biblio.Infrastructure.Business.Services.Auth
{
    public interface IAuthInfrastructureService
    {
        Task<AuthResultModel> Login(AuthModel authModel);
    }
}
