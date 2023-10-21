using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace MyEMShop.EndPoint.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class CSPMiddleware
    {
        private readonly RequestDelegate _next;

        public CSPMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
            httpContext.Response.Headers.Add("Content-Security-Policy", "script-src 'self'");
            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class CSPMiddlewareExtensions
    {
        public static IApplicationBuilder UseCSPMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CSPMiddleware>();
        }
    }
}
