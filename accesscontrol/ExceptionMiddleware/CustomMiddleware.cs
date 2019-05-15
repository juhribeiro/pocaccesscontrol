using System.Net;
using accesscontrol.Enums;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace accesscontrol.ExceptionMiddleware
{
    public static class CustomMiddleware
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app, ILoggerFactory loggerfactory)
        {
            var logger = loggerfactory.CreateLogger("CustomMiddleware");
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";
 
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if(contextFeature != null)
                    { 
                        logger.LogError($"Something went wrong: {contextFeature.Error}");
 
                        await context.Response.WriteAsync(new MessageDetails()
                        {
                            Type = MessageType.Warning,
                            StatusCode = context.Response.StatusCode,
                            Message = "Internal Server Error."
                        }.ToString());
                    }
                });
            });
        }
    }
}