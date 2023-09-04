using API.Interfaces.Services;
using App.Domain.Interfaces.Kernels;
using AutoMapper;

namespace API.Services
{
    public class ServiceWrapper : IServiceWrapper
    {
        private readonly IServiceProvider _serviceProvider;

        public ServiceWrapper(IServiceProvider serviceProvider) =>
            _serviceProvider = serviceProvider;

        public IExceptionNotificationKernel ExceptionNotification => GetService<IExceptionNotificationKernel>();

        public IMapper Mapper => GetService<IMapper>();

        private TService GetService<TService>() => _serviceProvider.GetService<TService>();
    }
}
