using Application.Common.Interfaces;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace Infrastructure;
public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services,IConfiguration configuration)
    {
        services.AddDbContext<IApplicationDbContext, ApplicationDbContext>(option =>
        {
            option.UseNpgsql(configuration.GetConnectionString("DbConnect"));
        });

        return services;
    }
}
