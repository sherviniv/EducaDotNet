using Educa.Application.Common.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Educa.WebUI.Middlewares
{
    public class AutoLoggerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public AutoLoggerMiddleware(
            RequestDelegate next,
            ILoggerFactory loggerFactory)
        {
            _next = next;
            _logger = loggerFactory.CreateLogger<AutoLoggerMiddleware>();
        }

        public async Task Invoke(HttpContext context, ICurrentUserService currentUserService)
        {
            try
            {
                await _next(context);
            }
            finally
            {
                _logger.LogInformation(
                    "User {user} Requested {method} {url} => {statusCode}",
                    currentUserService.UserId ?? "anonymous",
                    context.Request?.Method,
                    context.Request?.Path.Value,
                    context.Response?.StatusCode);
            }
        }
    }

    public static class AutoLoggerMiddlewareExtensions
    {
        //in order to log userid add it after app.addAuth
        public static IApplicationBuilder UseAutoLoggerMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AutoLoggerMiddleware>();
        }
    }
}
