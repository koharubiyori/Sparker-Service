using Microsoft.AspNetCore.Http;

namespace Sparker_Service.LocalServices.Middlewares
{
  public interface IMiddlewareBuilder
  {
    Func<HttpContext, RequestDelegate, Task<Task?>> Build();
  }
}
