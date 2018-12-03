using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;

namespace WebApiSample.Api._21
{
    public static class RequestLogExtensions
    {
        /// <summary>
        /// To write the headers to the app's response
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static IApplicationBuilder WriteLogIntoResponse(this IApplicationBuilder app)
        {
            app.Run(async (context) =>
            {
                context.Response.ContentType = "text/plain";

                // Request method, scheme, and path
                await context.Response.WriteAsync(
                    $"Request Method: {context.Request.Method}{Environment.NewLine}");
                await context.Response.WriteAsync(
                    $"Request Scheme: {context.Request.Scheme}{Environment.NewLine}");
                await context.Response.WriteAsync(
                    $"Request Path: {context.Request.Path}{Environment.NewLine}");

                // Headers
                await context.Response.WriteAsync($"Request Headers:{Environment.NewLine}");

                foreach (var header in context.Request.Headers)
                {
                    await context.Response.WriteAsync($"{header.Key}: " +
                        $"{header.Value}{Environment.NewLine}");
                }

                await context.Response.WriteAsync(Environment.NewLine);

                // Connection: RemoteIp
                await context.Response.WriteAsync(
                    $"Request RemoteIp: {context.Connection.RemoteIpAddress}");
            });
            return app;
        }

        /// <summary>
        /// To write the headers to the app's response
        /// </summary>
        /// <param name="app"></param>
        /// <returns></returns>
        public static IApplicationBuilder WriteLogIntoFile(this IApplicationBuilder app)
        {
            //var logger = _loggerFactory.CreateLogger<Startup>();
            //app.Use(async (context, next) =>
            //{
            //    // Request method, scheme, and path
            //    logger.LogDebug("Request Method: {METHOD}", context.Request.Method);
            //    logger.LogDebug("Request Scheme: {SCHEME}", context.Request.Scheme);
            //    logger.LogDebug("Request Path: {PATH}", context.Request.Path);

            //    // Headers
            //    foreach (var header in context.Request.Headers)
            //    {
            //        logger.LogDebug("Header: {KEY}: {VALUE}", header.Key, header.Value);
            //    }

            //    // Connection: RemoteIp
            //    logger.LogDebug("Request RemoteIp: {REMOTE_IP_ADDRESS}",
            //        context.Connection.RemoteIpAddress);

            //    await next();
            //});
            return app;
        }
    }
}
