using Biblio.Infrastrusture.Data.Context;
using Biblio.Infrastrusture.Data.Entities;
using Biblio.UtilityServices.Services.Encryption;
using Biblio.UtilityServices.Settings;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace NomadChat.WebAPI.Helpers.Database
{
    public class DbInitializer
    {
        private static ApplicationContext _context;
        private static EncryptionSettings _settings;
        private static RoleManager<Role> _roleManager;
        private static UserManager<User> _userManager;

        static DbInitializer()
        {
        }

        public static async Task Initialize(IServiceProvider services)
        {
            _context = services.GetRequiredService<ApplicationContext>();
            _settings = services.GetRequiredService<EncryptionSettings>();
            _roleManager = services.GetRequiredService<RoleManager<Role>>();
            _userManager = services.GetRequiredService<UserManager<User>>();

            var dbCreator = _context.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;

            if (!dbCreator.Exists())
            {
                dbCreator.Create();
                _context.Database.Migrate();
                await AddInitialData();
                _context.SaveChanges();
            }
        }

        private static async Task AddInitialData()
        {
            await AddTestUsers();
        }

        private static async Task AddTestUsers()
        {
            var testUsername = "biblio";
            var testRole = "User";
            var testPassword = EncryptionService.Encrypt("123456", _settings.Key);

            var isUserRole = await _roleManager.FindByNameAsync(testRole);
            if (isUserRole == null)
            {
                await _roleManager.CreateAsync(new Role(testRole));
            }

            var isUser = await _userManager.FindByNameAsync(testUsername);
            if (isUser == null)
            {
                var userRole = await _context.Roles.FirstOrDefaultAsync(role => role.Name == testRole);

                var user = new User(testUsername, userRole!);

                await _userManager.CreateAsync(user);

                user.PasswordHash = testPassword;

                await _userManager.AddToRoleAsync(user, testRole);
            }
        }
    }
}
