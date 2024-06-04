using learn_admin_backend.Exestions;
using System.Globalization;

namespace learn_admin_backend.Exestions
{
    public class ErrorMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var exceptionHandlerPathFeature = context.Features.Get<>()
            await _next(context);
        }

    }
}


public static class ErrorMiddlewareExtensions
{
    public static IApplicationBuilder UseErrorMiddleware(
        this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ErrorMiddleware>();
    }
}