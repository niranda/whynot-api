using Biblio.Infrastructure.Business.Services.Token;
using Biblio.Infrastrusture.Data.Entities;
using Biblio.Infrastrusture.Data.Stores;
using Biblio.UtilityServices.Common.Enums;
using Biblio.UtilityServices.Models.Auth;
using Biblio.UtilityServices.Services.Encryption;
using Biblio.UtilityServices.Settings;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace Biblio.Infrastructure.Business.Services.Auth
{
    public class AuthInfrastructureService : IAuthInfrastructureService
    {
        private readonly ITokenService _tokenService;
        private readonly IUserRepository _userRepository;
        private readonly EncryptionSettings _settings;
        private readonly ILogger _logger;

        public AuthInfrastructureService(
            ITokenService tokenService,
            IUserRepository userRepository,
            EncryptionSettings encryptionSettings,
            ILoggerFactory loggerFactory)
        {
            _tokenService = tokenService;
            _userRepository = userRepository;
            _settings = encryptionSettings;
            _logger = loggerFactory.CreateLogger<AuthInfrastructureService>();
        }

        public async Task<AuthResultModel> Login(AuthModel authModel)
        {
            var user = await _userRepository.FindByUsername(authModel.Name);

            if (user == null || !CheckPassword(user, authModel.Password))
            {
                _logger.LogInformation($"Unsuccessful login attempt with email {authModel.Name}");
                return UnsuccessfulLogin(ErrorCode.InvalidLogin);
            }

            _logger.LogInformation($"User {authModel.Name} successfully logged in");
            return new AuthResultModel
            {
                IsSuccess = true,
                Token = _tokenService.GenerateJWT(user)
            };
        }

        private bool CheckPassword(User user, string password)
        {
            return EncryptionService.Decrypt(user.PasswordHash, _settings.Key) == password;
        }

        private static AuthResultModel UnsuccessfulLogin(ErrorCode errorCode)
        {
            return new AuthResultModel { IsSuccess = false, ErrorMessage = errorCode };
        }
    }
}
