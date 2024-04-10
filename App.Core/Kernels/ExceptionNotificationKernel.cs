using App.Domain.Interfaces.Kernels;
using App.Domain.Models.Kernels;
using FluentValidation.Results;

namespace App.Domain.Kernels
{
    public class ExceptionNotificationKernel : IExceptionNotificationKernel
    {
        private readonly List<Notification> _notifications;

        public ExceptionNotificationKernel() =>
            _notifications = [];


        public bool HasNotifications => _notifications.Any();

        public IReadOnlyCollection<Notification> Notifications => _notifications;


        public void AddNotification(Notification notification) =>
            _notifications.Add(notification);

        public void AddNotifications(IEnumerable<Notification> notifications) =>
            _notifications.AddRange(notifications);

        public void AddNotifications(ValidationResult validationResult) =>
            validationResult.Errors.ForEach(x => _notifications.Add(new Notification(x.ErrorMessage)));

        public void ThrowException() =>
            throw new Exception();
    }
}
