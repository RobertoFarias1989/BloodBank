using BloodBank.Core.Entities;
using BloodBank.Infrastructure.EmailExtensions;
using BloodBank.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace BloodBank.Infrastructure.HostedService;

public class BloodStockHostedService : BackgroundService
{
    private readonly ILogger<BloodStockHostedService> _logger;
    private readonly IServiceProvider _serviceProvider;
    private readonly IEmail _email;
    private readonly IHostApplicationLifetime _applicationLifetime;

    public BloodStockHostedService(ILogger<BloodStockHostedService> logger, IEmail email, IHostApplicationLifetime applicationLifetime, IServiceProvider serviceProvider)
    {
        _logger = logger;    
        _email = email;
        _applicationLifetime = applicationLifetime;
        _serviceProvider = serviceProvider;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
      
            _logger.LogInformation("BloodStockHostedService running at: {time}", DateTimeOffset.Now);

            using(var scope = _serviceProvider.CreateAsyncScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<BloodBankDbContext>();

                var bs = await dbContext
               .BloodStocks
               .AsNoTracking()
               .GroupBy(x => new { x.BloodType, x.RHFactor })
               .Select(xl => new
               {
                   xl.Key.BloodType,
                   xl.Key.RHFactor,
                   A = xl.Sum(ml => ml.QuantityML)
               }).Where(xl => xl.A < 420).ToListAsync();


                foreach (var blood in bs)
                {
                    _email.SendEmail("INFORMEUMEMAILVALIDOAQUI248@gmail.com"
                        , "Warning: BloodStockLevel is very low."
                        , $"The amount of {blood.BloodType} {blood.RHFactor} is under {420}");

                }

            await Task.Delay(1000, stoppingToken);
        }
    }
}
