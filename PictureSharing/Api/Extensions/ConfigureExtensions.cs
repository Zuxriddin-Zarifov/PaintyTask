using Microsoft.EntityFrameworkCore;
using PictureSharing.Infrastructures;
using PictureSharing.Infrastructures.Interface;
using PictureSharing.Infrastructures.Repositories;
using PictureSharing.Infrastructures.Services;
using PictureSharing.Middlewares;

namespace PictureSharing.Extations;

public static class ConfigureExtensions
{
    public static void ConfigureDbContexts(this IServiceCollection serviceCollection,
        ConfigurationManager configurationManager)
    {
        serviceCollection.AddDbContext<DataContext>(optionsBuilder =>
        {
            optionsBuilder
                .UseNpgsql(configurationManager.GetConnectionString("DefaultConnectionString"));
        });
    }

    public static void ConfigureRepositories(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddScoped<ExceptionHandlerMiddleware>();
        serviceCollection.AddScoped<IUserRepository, UserRepository>();
        serviceCollection.AddScoped<IUserService, UserService>();
        serviceCollection.AddScoped<IPhotoRepository, PhotoRepository>();
        serviceCollection.AddScoped<IPhotoService, PhotoService>();
        serviceCollection.AddScoped<ITokenService, TokenService>();
        serviceCollection.AddScoped<IAuthService, AuthService>();
        serviceCollection.AddScoped<IFriendRepository, FriendRepository>();
        serviceCollection.AddScoped<IFriendService, FriendService>();
    }
}