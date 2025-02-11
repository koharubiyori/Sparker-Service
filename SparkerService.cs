using Serilog;
using Serilog.Sinks.SystemConsole.Themes;
using Sparker_Service.LocalServices;
using Sparker_Service.Utils;

namespace Sparker_Service
{
  public class SparkerService : BackgroundService
  {
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
      var localServer = new LocalServer(NetworkUtils.GetAvailablePort(Constants.DefaultServerPort));
      await localServer.Run(stoppingToken);
    }
  }
}