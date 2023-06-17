using System.Text.Json;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Kma.Economy.Data;

public class DesignTimeApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        var config = GetConfiguration();
        
        var connectionString = config.GetConnectionString("DefaultConnection") ??
                               throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

        var version = ServerVersion.AutoDetect(connectionString);

        optionsBuilder.UseMySql(connectionString, version);

        return new ApplicationDbContext(optionsBuilder.Options);
    }

    private static IConfiguration GetConfiguration()
    {
        ConfigurationBuilder builder = new();
        var currentDirectory = Directory.GetCurrentDirectory();
        var appSettingsPath = Path.Combine(currentDirectory, "appsettings.json");
        builder.AddJsonFile(appSettingsPath);
        var config = builder.Build();
        return config;
    }
}