using App.Domain.Interfaces.Kernels;
using App.Domain.Models.Kernels;
using FluentValidation.Results;
using System.Text.Json;

namespace App.Infraestructure.Integrations
{
    public abstract class BaseIntegration
    {
        protected readonly HttpClient _httpClient;
        protected readonly JsonSerializerOptions _jsonSerializerOptions;
        protected readonly IExceptionNotificationKernel _exceptionNotificationKernel;

        protected BaseIntegration(HttpClient httpClient, IExceptionNotificationKernel exceptionNotificationKernel)
        {
            _httpClient = httpClient;
            _jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                IgnoreReadOnlyProperties = true
            };
            _exceptionNotificationKernel = exceptionNotificationKernel;
        }

        protected virtual void ThrowException(ValidationResult validations)
        {
            _exceptionNotificationKernel.AddNotifications(validations);
            _exceptionNotificationKernel.ThrowException();
        }

        protected virtual void ThrowException(string message)
        {
            _exceptionNotificationKernel.AddNotification(new Notification(message));
            _exceptionNotificationKernel.ThrowException();
        }
    }
}
