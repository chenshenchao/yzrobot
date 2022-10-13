using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace YzRobot.Server.Services;

public class TcpServices : BackgroundService
{
    private ILogger<TcpServices> logger;

    public TcpServices(IConfiguration configuration, ILogger<TcpServices> logger)
    {

        this.logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        logger.LogInformation("tcp service start.");
        while (!stoppingToken.IsCancellationRequested)
        {
            await Task.Yield();
        }
        logger.LogInformation("tcp service end.");
    }
}
