using Serilog;
using Serilog.Sinks.SystemConsole.Themes;
using Sparker_Service;
using Sparker_Service.Preferences;

InitializeLogger();
Preference.InitializeAllPreferences();

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddWindowsService(options =>
{
  options.ServiceName = "Sparker-Service";
});
builder.Services.AddHostedService<SparkerService>();

var host = builder.Build();
host.Run();

void InitializeLogger()
{
  var loggerConfiguration = new LoggerConfiguration()
    .WriteTo.File(Path.Combine(Constants.LogDirPath, ".log"), rollingInterval: RollingInterval.Day);

  #if DEBUG
    loggerConfiguration
      .MinimumLevel.Debug()
      .WriteTo.Console(theme: AnsiConsoleTheme.Code, applyThemeToRedirectedOutput: true);
  #else
    loggerConfiguration
      .MinimumLevel.Error();
  #endif
  
  Log.Logger = loggerConfiguration.CreateLogger();
  
  AppDomain.CurrentDomain.UnhandledException += (object sender, UnhandledExceptionEventArgs e) =>
  {
    if (e.ExceptionObject is Exception exception)
    {
      Log.Error(exception, "Unhandled exception");
    }
  };
}