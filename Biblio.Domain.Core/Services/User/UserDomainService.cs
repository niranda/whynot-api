using Biblio.Infrastrusture.Data.Entities;
using Biblio.Infrastrusture.Data.Stores;
using Biblio.UtilityServices.Services.Encryption;
using Biblio.UtilityServices.Services.User;
using Biblio.UtilityServices.Settings;
using Microsoft.AspNetCore.Identity;

namespace Biblio.Domain.Core.Services.UserS
{
    public class UserDomainService : IUserBaseService<User>
    {
        private readonly EncryptionSettings _encryptionSettings;
        private readonly IUserRepository _userRepository;
        private readonly UserManager<User> _userManager;

        public UserDomainService(EncryptionSettings encryptionSettings, IUserRepository userRepository, UserManager<User> userManager)
        {
            _encryptionSettings = encryptionSettings;
            _userRepository = userRepository;
            _userManager = userManager;
        }

        public async Task<Guid> CreateUser(string role, string username, string? email)
        {
            string password = EncryptionService.RandomString(10);

            User user = new()
            {
                UserName = username,
                NormalizedUserName = username,
                Email = email,
                SecurityStamp = Guid.NewGuid().ToString(),
                PasswordHash = EncryptionService.Encrypt(password, _encryptionSettings.Key),
                RoleId = await _userRepository.GetRoleId(role)
            };

            return await _userRepository.Create(user);
        }

        public async Task<User?> GetUserByEmail(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _userRepository.GetAll();
        }

        public async Task<User> UpdateUser(User user)
        {
            await _userManager.UpdateAsync(user);

            return user;
        }

        public async Task<bool> DeleteUser(User user)
        {
            await _userManager.DeleteAsync(user);

            return true;
        }

    }
}
