using App.Domain.Models.Kernels;
using FluentValidation.Results;

namespace App.Domain.Interfaces.Kernels
{
    public interface IExceptionNotificationKernel
    {
        public bool HasNotifications { get; }
        public IReadOnlyCollection<Notification> Notifications { get; }

        public void AddNotification(Notification notification);
        public void AddNotifications(IEnumerable<Notification> notifications);
        public void AddNotifications(ValidationResult validationResult);
        public void ThrowException();
    }
}
