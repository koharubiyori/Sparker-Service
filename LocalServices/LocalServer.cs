using Microsoft.AspNetCore.Builder;
using Serilog;
using Sparker_Service.LocalServices.Routes.Info;
using Sparker_Service.LocalServices.Routes.Power;
using Sparker_Service.LocalServices.Routes.Settings;
using Sparker.LocalServices.Middlewares;

namespace Sparker_Service.LocalServices
{
  public class LocalServer
  {
    private readonly WebApplication _app;

    public LocalServer(int port)
    {
      var builder = WebApplication.CreateSlimBuilder();
      builder.Services
        .AddSerilog()
        .ConfigureHttpJsonOptions(static options =>
          options.SerializerOptions.TypeInfoResolverChain.Insert(0, Sparker_Service.LocalServices.LocalServicesJsonGenContext.Default)
        );
      _app = builder.Build();
      _app.Urls.Add($"http://0.0.0.0:{port}");
      BindRoutes();
      UseMiddlewares();
    }

    private void UseMiddlewares()
    {
      _app.Use(new OnlyLanBuilder().Build());
    }
    
    private void BindRoutes()
    {
      _app.MapGet("/", () => "Hello World!");
      _app.MapPost("/info/approach", (InfoRoute.ApproachArguments args) => InfoRoute.Approach(args));
      _app.MapPost("/info/getBasicInfo", InfoRoute.GetBasicInfo);
      
      _app.MapPost("/power/shutdown", (PowerRoute.ShutdownArguments args) => PowerRoute.Shutdown(args));
      _app.MapPost("/power/sleep", (PowerRoute.SleepArguments args) => PowerRoute.Sleep(args));
      
      _app.MapPost("/settings/setLanOnly", (SettingsRoute.SettingValue<bool?> args) => SettingsRoute.SetLanOnly(args));
    }

    public Task Run(CancellationToken stoppingToken)
    {
      return _app.RunAsync(stoppingToken);
    }
  }
}
