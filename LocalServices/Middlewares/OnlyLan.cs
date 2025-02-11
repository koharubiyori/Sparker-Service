using Microsoft.AspNetCore.Http;
using Sparker_Service.LocalServices.Middlewares;
using Sparker_Service.Preferences;
using Sparker_Service.Utils;

namespace Sparker.LocalServices.Middlewares;

public class OnlyLanBuilder : IMiddlewareBuilder
{
  public Func<HttpContext, RequestDelegate, Task<Task?>> Build()
  {
    var enabled = Preference.Settings.LanOnly;
    if (!enabled) return (context, next) => Task.FromResult(next(context));
    return async (context, next) =>
    {
      var remoteIp = context.Connection.RemoteIpAddress;
      if (remoteIp != null && NetworkUtils.IsLocalNetwork(remoteIp)) return next(context);
      
      context.Response.StatusCode = 403; // Forbidden
      await context.Response.WriteAsync("Access denied: Only local network requests are allowed.");
      return null;
    };
  }
}
