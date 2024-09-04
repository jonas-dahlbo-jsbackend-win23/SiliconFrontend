using Microsoft.AspNetCore.Antiforgery;

namespace SiliconFrontend.Middleware
{
    public class AntiforgeryMiddleware
    {
        private readonly RequestDelegate _next;

        public AntiforgeryMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, IAntiforgery antiforgery)
        {
            if (context.Request.Path == "/account/logout")
            {
                // Skip anti-forgery validation for this endpoint
                await _next(context);
            }
            else
            {
                // Perform anti-forgery validation for other requests
                await antiforgery.ValidateRequestAsync(context);
                await _next(context);
            }
        }
    }
}
