using Microsoft.EntityFrameworkCore;
using PictureSharing.Repositories;

namespace PictureSharing.Extations;

public static class ConfigureExtensions
{
    public static void ConfigureDbContexts(this IServiceCollection serviceCollection, ConfigurationManager configurationManager)
    {
        serviceCollection.AddDbContext<DataContext>(optionsBuilder =>
        {
            optionsBuilder
                .UseNpgsql(configurationManager.GetConnectionString("DefaultConnectionString"));
        });
    }

    public static void ConfigureRepositories(this IServiceCollection serviceCollection)
    {
    }
}