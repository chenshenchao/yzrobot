using Microsoft.Extensions.Hosting;

namespace YzRobot.Server.Services;

public class UdpServices : BackgroundService
{
    public UdpServices()
    {
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while(!stoppingToken.IsCancellationRequested)
        {
            await Task.Yield();
        }
    }
}
