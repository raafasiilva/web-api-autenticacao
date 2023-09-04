using App.Domain.Interfaces.Kernels;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Net;
using System.Text.Json;

namespace API.Middlewares
{
    public class GlobalExceptionHandlerMiddleware : IMiddleware
    {
        private const string DEFAULT_MESSAGE = "Não foi possível realizar esta ação. Por favor, tente novamente mais tarde.";

        private readonly ILogger _logger;
        private readonly IExceptionNotificationKernel _exceptionNotificationKernel;

        public GlobalExceptionHandlerMiddleware(ILogger<GlobalExceptionHandlerMiddleware> logger, IExceptionNotificationKernel exceptionNotificationKernel) 
        {
            _logger = logger;
            _exceptionNotificationKernel = exceptionNotificationKernel;
        }
            

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception exception)
            {
                await AddExceptionMessageInContextResponseAsync(context, exception);
            }
        }

        private Task AddExceptionMessageInContextResponseAsync(HttpContext context, Exception exception)
        {
            string notificationMessage = DEFAULT_MESSAGE;

            if (_exceptionNotificationKernel.HasNotifications)
                notificationMessage = string.Join("; ", _exceptionNotificationKernel.Notifications.Select(x => x.Message));

            context.Response.ContentType = "application/json; charset=utf-8";
            context.Response.StatusCode = (int)HttpStatusCode.BadRequest;

            _logger.LogError(exception, notificationMessage);

            return context.Response.WriteAsync(JsonSerializer.Serialize(new
            {
                message = notificationMessage
            }));
        }
    }
}