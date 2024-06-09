using BloodBank.Core.Repositories;
using BloodBank.Infrastructure.EmailExtensions;
using BloodBank.Infrastructure.HostedService;
using BloodBank.Infrastructure.Persistence;
using BloodBank.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BloodBank.Infrastructure;

public static class InfrastructureModule
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddRepositories()
            .AddDbContexts(configuration)
            .AddUnitOfWork()
            .AddHostedService<BloodStockHostedService>()
            .AddSingleton<IEmail,Email>();

        return services;
    }

    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IBloodStockRepository, BloodStockRepository>();
        services.AddScoped<IDonationRepository, DonationRepository>();
        services.AddScoped<IDonorRepository, DonorRepository>();

        return services;
    }

    private static IServiceCollection AddDbContexts(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("BloodBank");

        services.AddDbContext<BloodBankDbContext>(options => options.UseSqlServer(connectionString));

        return services;
    }

    private static IServiceCollection AddUnitOfWork(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}
