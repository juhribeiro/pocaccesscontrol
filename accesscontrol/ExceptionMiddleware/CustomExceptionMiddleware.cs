using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace accesscontrol.ExceptionMiddleware
{
    public class CustomExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public CustomExceptionMiddleware(RequestDelegate next, ILoggerFactory loggerfactory)
        {
            _logger = loggerfactory.CreateLogger("CustomExceptionMiddleware");
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                _logger.LogError($" Midleware : {ex.GetType()} Exception : {ex}");
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";
            var code = HttpStatusCode.InternalServerError;
            var message = "Unexpected Error";
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            if (exception is CustomException)
            {
                var details = JsonConvert.DeserializeObject<MessageDetails>(exception.Message);
                if (details.Type == Enums.MessageType.Unauthorized)
                {
                    code = HttpStatusCode.Unauthorized;
                }
                else
                {
                    code = HttpStatusCode.BadRequest;
                }

                message = details.Message;
            }
            else if (exception is DbUpdateException && exception.InnerException != null && exception.InnerException.Message.Contains("Cannot insert duplicate key"))
            {
                code = HttpStatusCode.BadRequest;
                message = exception.InnerException.Message;
            }

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            return context.Response.WriteAsync(JsonConvert.SerializeObject(message));
        }
    }
}