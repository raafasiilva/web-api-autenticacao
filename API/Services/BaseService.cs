using API.Interfaces.Services;
using App.Domain.Interfaces.Repositories;
using App.Domain.Models.Kernels;
using FluentValidation.Results;

namespace API.Services
{
    public abstract class BaseService<TService> : IBaseService where TService : IBaseService
    {
        protected readonly IServiceWrapper _serviceWrapper;
        protected readonly IRepositoryWrapper _repositoryWrapper;

        protected BaseService(IServiceWrapper serviceWrapper, IRepositoryWrapper repositoryWrapper)
        {
            _serviceWrapper = serviceWrapper;
            _repositoryWrapper = repositoryWrapper;
        }


        protected virtual void ThrowException(ValidationResult validations)
        {
            _serviceWrapper.ExceptionNotification.AddNotifications(validations);
            _serviceWrapper.ExceptionNotification.ThrowException();
        }

        protected virtual void ThrowException(string message)
        {
            _serviceWrapper.ExceptionNotification.AddNotification(new Notification(message));
            _serviceWrapper.ExceptionNotification.ThrowException();
        }
    }
}
