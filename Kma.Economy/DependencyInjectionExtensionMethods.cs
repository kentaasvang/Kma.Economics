using Kma.Economy.Data;
using Microsoft.EntityFrameworkCore;

namespace Kma.Economy;

public static class DependencyInjectionExtensionMethods
{
    public static void AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration[UserSecretConstants.DefaultConnection] ??
                               throw new InvalidOperationException(
                                   $"Connection string {nameof(UserSecretConstants.DefaultConnection)} not found.");

        var serverVersion = ServerVersion.AutoDetect(connectionString);

        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseMySql(connectionString, serverVersion));

        services.AddDatabaseDeveloperPageExceptionFilter();
    }
}