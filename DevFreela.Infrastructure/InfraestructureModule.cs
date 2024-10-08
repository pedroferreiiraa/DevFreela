using DevFreela.Core.Repositories;
using DevFreela.Core.Services;
using DevFreela.Infrastructure.AuthServices;
using DevFreela.Infrastructure.Persistence;
using DevFreela.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DevFreela.Infrastructure;

public static class InfrastructureModule
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddRepositories()
            .AddData(configuration);

        return services;
    }

    private static IServiceCollection AddData(this IServiceCollection services, IConfiguration configuration)
    {
        // var connectionString = configuration.GetConnectionString("DevFreelaCs");
        //
        // services.AddDbContext<DevFreelaDbContext>(o => o.UseSqlServer(connectionString));
        services.AddDbContext<DevFreelaDbContext>(o => o.UseInMemoryDatabase("InMemoryDatabase"));

        return services;
    }
    
    
    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IProjectRepository, ProjectRepository>();
        services.AddScoped<IUserRepository, UserRepository > ();
        services.AddScoped<IAuthService, AuthService>();

        
        
        
        return services;
    }
}