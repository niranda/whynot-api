using Biblio.Infrastrusture.Data.Context;
using Biblio.Infrastrusture.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace NomadChat.WebAPI.Configs
{
    public static class IdentityExtensions
    {
        public static void SetupIdentity(this IServiceCollection serviceCollection, bool enableDefaultTokenProviders = true)
        {
            serviceCollection.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            serviceCollection.TryAddScoped<UserManager<User>>();
            serviceCollection.TryAddScoped<RoleManager<Role>>();

            var identityBuilder = serviceCollection.AddIdentityCore<User>(opt =>
            {
                opt.Password.RequireDigit = false;
                opt.Password.RequiredLength = 6;
            });

            identityBuilder = new IdentityBuilder(identityBuilder.UserType, typeof(Role), identityBuilder.Services);
            identityBuilder.AddEntityFrameworkStores<ApplicationContext>();

            if (enableDefaultTokenProviders)
            {
                identityBuilder.AddDefaultTokenProviders();
            }
        }
    }
}
