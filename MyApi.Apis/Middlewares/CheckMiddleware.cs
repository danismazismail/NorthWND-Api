using System;

namespace MyApi.Apis.Middlewares
{
    //IOC
    //middleware class
    public class CheckMiddleware : IDisposable
    {
        private readonly RequestDelegate _next;

        public CheckMiddleware(RequestDelegate next)
        {
            _next= next;
        }

        public void Dispose()
        {
            
        }

        public async Task Invoke(HttpContext httpContext)
        {

            var hede = httpContext.Request.Headers.Keys.Contains("tc");
            if (hede)
            {
                httpContext.Response.StatusCode = 500;
                await httpContext.Response.WriteAsync("tc deüeri olmadan hiçbir methodu görüntüleyemezsin.");
            }
         


            await _next.Invoke(httpContext);
        }

    }
}
