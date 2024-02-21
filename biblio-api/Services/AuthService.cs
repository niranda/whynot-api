using Biblio.Infrastructure.Business.Services.Auth;
using Biblio.UtilityServices.Models.Auth;
using Biblio.UtilityServices.Services.Auth;

namespace NomadChat.WebAPI.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAuthInfrastructureService _authService;
        private readonly ILogger _logger;
        public AuthService(IAuthInfrastructureService authService, ILoggerFactory loggerFactory)
        {
            _authService = authService;
            _logger = loggerFactory.CreateLogger<AuthService>();
        }

        public Task<AuthResultModel> Login(AuthModel authModel)
        {
            if (authModel == null)
            {
                throw new ArgumentNullException(nameof(authModel));
            }

            _logger.LogInformation($"Request to log in a user {authModel.Name}");
            return _authService.Login(authModel);
        }
    }
}
