using Microsoft.AspNetCore.Http;
using Sparker_Service.Utils;

namespace Sparker_Service.LocalServices.Routes.Power;

public static class PowerRoute
{
  public record ShutdownArguments(bool Force = false, int Timeout = 0, bool Reboot = false, bool Hybrid = false);
  public record SleepArguments(bool Hibernate = false);

  public static async Task<IResult> Shutdown(ShutdownArguments args)
  {
    PowerManager.Shutdown(args.Force, args.Reboot, args.Hybrid);
    if (args.Force || args.Timeout == 0) return Results.Ok();
    await Task.Delay(args.Timeout);
    PowerManager.Shutdown(true, args.Force, args.Hybrid);
    return Results.Ok();
  }

  public static IResult Sleep(SleepArguments args)
  {
    PowerManager.Sleep(args.Hibernate);
    return Results.Ok();
  }
}

